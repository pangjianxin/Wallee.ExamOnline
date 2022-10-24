import {
  User,
  UserManager,
  UserManagerSettings,
  UserProfile,
  WebStorageStateStore,
} from "oidc-client-ts";
import { defineStore } from "pinia";
import useApplicationConfigStore from "./useApplicationConfigStore";

export type MaybeNull<T> = T | null;

export interface OidcState {
  oidcSettings: UserManagerSettings;
  userProfile: MaybeNull<UserProfile>;
  userManager: MaybeNull<UserManager>;
  access_token: MaybeNull<string>;
  refresh_token: MaybeNull<string>;
  id_token: MaybeNull<string>;
  expires_at: MaybeNull<number> | undefined;
}

export default defineStore("oidc", {
  state: (): OidcState => {
    return {
      oidcSettings: {
        authority: import.meta.env["VITE_OIDC_AUTHORITY"],
        scope: import.meta.env["VITE_OIDC_SCOPE"],
        client_id: import.meta.env["VITE_OIDC_CLIENT_ID"],
        client_secret: undefined,
        redirect_uri: origin + import.meta.env["VITE_OIDC_REDIRECT_URI"],
        response_type: "code",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({
          prefix: "oidc-",
          store: window.sessionStorage,
        }),
      },
      userProfile: null,
      userManager: null,
      access_token: null,
      expires_at: null,
      refresh_token: null,
      id_token: null,
    };
  },

  getters: {
    getToken(): string | null {
      return this.access_token || null;
    },
    getUserProfile(): MaybeNull<UserProfile> {
      return this.userProfile;
    },
    //check token expiration. return true if it expired
    isTokenInValid(): boolean {
      const expiredTimeStamp = this.expires_at;
      if (expiredTimeStamp) {
        const currentTimeStamp = Math.round(Number(new Date()) / 1000);
        return currentTimeStamp > expiredTimeStamp;
      } else {
        return true;
      }
    },
    getUserManager(): UserManager {
      if (!this.userManager) {
        this.userManager = new UserManager(
          this.oidcSettings as UserManagerSettings
        );
        this.userManager.events.addUserLoaded((user: User) => {});
        this.userManager.events.removeUserLoaded((user: User) => {
          console.log("remove usere loaded", user);
        });
        this.userManager.events.addUserSignedIn(() => {
          console.log("user signed in ");
        });
        this.userManager.events.addAccessTokenExpired(() => {
          console.log("token expired");
        });
      }
      return this.userManager as UserManager;
    },
  },
  actions: {
    async store(user: User) {
      await this.getUserManager?.storeUser(user);
      this.storeAccessToken(user.access_token);
      this.storeIdToken(user.id_token || null);
      this.storeRefreshToken(user.refresh_token || null);
      this.storeExpredAt(user.expires_at);
      this.storeUserProfile(user.profile);

      const appConfigStore = useApplicationConfigStore();
      await appConfigStore.initConfig();
    },
    async oidcLogout() {
      await this.getUserManager?.removeUser();
      const appConfigStore = useApplicationConfigStore();
      appConfigStore.$reset();
      this.$reset();
    },
    storeUserProfile(userProfile: UserProfile) {
      this.userProfile = userProfile;
    },
    storeIdToken(idToken: MaybeNull<string>) {
      this.id_token = idToken;
    },
    storeAccessToken(accessToken: MaybeNull<string>) {
      this.access_token = accessToken;
    },
    storeExpredAt(expiresAt: MaybeNull<number> | undefined) {
      this.expires_at = expiresAt;
    },
    storeRefreshToken(refreshToken: MaybeNull<string>) {
      this.refresh_token = refreshToken;
    },
  },
  persist: {
    storage: localStorage,
    paths: [
      "access_token",
      "userProfile",
      "expires_at",
      "refresh_token",
      "id_token",
    ],
    key: "oidc-store"
  },
});
