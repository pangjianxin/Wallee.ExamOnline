import {
  User,
  UserManager,
  UserManagerSettings,
  UserProfile,
  WebStorageStateStore,
} from "oidc-client-ts";
import { defineStore } from "pinia";

export type MaybeNull<T> = T | null;

export interface OidcState {
  oidcSettings: UserManagerSettings;
  user: MaybeNull<User>;
  userManager: MaybeNull<UserManager>;
  token: MaybeNull<string>;
  hasExpiresAt: boolean;
  redirect_uri: MaybeNull<string>;
}

export const useOidcStore = defineStore({
  id: "oidc",
  state: (): OidcState => {
    return {
      oidcSettings: {
        authority: "http://localhost:5007",
        scope: "openid profile ExamOnline",
        client_id: "ExamOnline_Vue_App",
        client_secret: undefined,
        redirect_uri: origin + "/signin-callback",
        response_type: "code",
        loadUserInfo: true,
        userStore: new WebStorageStateStore({
          prefix: "vue3-oidc",
          store: window.localStorage,
        }),
      },
      user: null,
      userManager: null,
      token: null,
      hasExpiresAt: false,
      redirect_uri: import.meta.env["VITE_OIDC_REDIRECT_URI"],
    };
  },
  getters: {
    getToken(): string | null {
      return this.token || null;
    },
    tokenExpired(): boolean {
      console.log(this.user);
      return true;
    },
    getUserManager(): UserManager {
      if (!this.userManager) {
        this.userManager = new UserManager(
          this.oidcSettings as UserManagerSettings
        );
        this.userManager.events.addUserLoaded((user: User) => {
          console.log("add Uer Loaded", user);
          localStorage.setItem("xxxooxx", user.access_token);
        });
        this.userManager.events.removeUserLoaded((user: User) => {
          console.log("remove usere loaded", user);
        });
        this.userManager.events.addUserSignedIn(() => {
          console.log("user signed in ");
        });
      }
      return this.userManager as UserManager;
    },
  },
  actions: {
    async storeUser(user: User) {
      this.user = user;
      await this.getUserManager?.storeUser(user);
    },
    async removeUser() {
      this.user = null;
      await this.getUserManager?.removeUser();
    },
    storeToken(token: string) {
      this.token = token;
    },
  },
  persist: {
    storage: localStorage,
    //paths: ["user"],
    key: "oidc-",
  },
});
