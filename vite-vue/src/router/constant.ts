import { RouteRecordRaw } from "vue-router";

const loginRoute: RouteRecordRaw = {
  path: "/login",
  component: () => import("/@/views/sys/login/Login.vue"),
};

const oidcLoginCallback: RouteRecordRaw = {
  path: "/signin-callback",
  component: () => import("/@/views/sys/login/OidcLoginCallback.vue"),
};

const oidcLogoutCallback: RouteRecordRaw = {
  path: "/oidc-logout",
  component: () => import("/@/views/sys/login/OIdcLogoutCallback.vue"),
};

export default [loginRoute, oidcLoginCallback, oidcLogoutCallback];
