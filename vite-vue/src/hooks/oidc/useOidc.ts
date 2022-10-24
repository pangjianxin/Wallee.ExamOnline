import { SigninRedirectArgs, SignoutRedirectArgs } from "oidc-client-ts";

import useOidcStore from "/@/store/modules/useOidcStore";
import { isPathOfCallback } from "/@/utils/oidc";

function signinRedirect(arg?: SigninRedirectArgs) {
  const oidcStore = useOidcStore();
  if (oidcStore.isTokenInValid) {
    oidcStore.getUserManager?.signinRedirect(arg);
  }
}

async function signoutRedirect(arg?: SignoutRedirectArgs) {
  const oidcStore = useOidcStore();
  await oidcStore.getUserManager?.signoutRedirect(arg);
}

/**
 * @fn autoAuthenticate - will try to authenticate the user silently
 */
async function autoAuthenticate(uri: string = "") {
  const oidcStore = useOidcStore();
  const user = await oidcStore.getUserManager?.getUser();
  //if the user and pathCallback is not, then we can authenticate
  if (!user && !isPathOfCallback()) {
    localStorage.setItem(
      "OIDC_REDIRECT_URI",
      uri || location.pathname + location.search || "/"
    );
    await oidcStore.getUserManager?.removeUser();
    await oidcStore.getUserManager?.signinRedirect();
    return;
  }
  //if the user is not and pathCallback is, then we can set the user
  if (!user && isPathOfCallback()) {
    const user = await oidcStore.getUserManager?.signinRedirectCallback();

    await oidcStore.storeUserProfile(user.profile);
    return;
  }
  //if the user and pathCallback of true, then we can set the user
  if (user && !isPathOfCallback()) {
    await oidcStore.storeUserProfile(user.profile);
    //if the user has expired, then we can remove the user
    if (oidcStore.isTokenInValid) {
      await signoutRedirect();
      return;
    }
    return;
  }
}

export function useOidc() {
  return {
    autoAuthenticate,
    signinRedirect,
    signoutRedirect,
  };
}
