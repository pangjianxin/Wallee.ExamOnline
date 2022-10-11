import { App } from "vue";
import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import about from "./modules/about";
import home from "./modules/home";
import oidcRoutes from "./constant";

const routes: RouteRecordRaw[] = [about, home, ...oidcRoutes];

const router = createRouter({
  routes,
  history: createWebHistory(),
});

export function setupRouter(app: App) {
  app.use(router);
}
