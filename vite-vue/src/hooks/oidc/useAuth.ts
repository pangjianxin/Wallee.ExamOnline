import { SigninRedirectArgs, SignoutRedirectArgs } from "oidc-client-ts";

import { useOidcStore } from "/@/store/modules/useOidcStore";
import { isPathOfCallback } from "/@/utils/oidc";

const oidcStore = useOidcStore();

function signinRedirect(arg?: SigninRedirectArgs) {
  if (!oidcStore.user) {
    oidcStore.getUserManager?.signinRedirect(arg);
  }
}

async function signoutRedirect(arg?: SignoutRedirectArgs) {
  await oidcStore.getUserManager?.signoutRedirect(arg);
}

/**
 * @fn autoAuthenticate - will try to authenticate the user silently
 */
async function autoAuthenticate(uri: string = "") {
  const user = (await oidcStore.getUserManager?.getUser()) || oidcStore.user;
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

    await oidcStore.storeUser(user!);
    return;
  }
  //if the user and pathCallback of true, then we can set the user
  if (user && !isPathOfCallback()) {
    await oidcStore.storeUser(user);
    //if the user has expired, then we can remove the user
    if (oidcStore.hasExpiresAt) {
      await signoutRedirect();
      return;
    }
    return;
  }
}

export function useAuth() {
  return {
    autoAuthenticate,
    signinRedirect,
    signoutRedirect,
  };
}
