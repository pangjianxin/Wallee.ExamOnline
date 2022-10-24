import { App } from "vue";
import {
  createRouter,
  createWebHistory,
  RouteRecordRaw,
  createWebHashHistory,
} from "vue-router";
import useAppConfigStore from "../store/modules/useApplicationConfigStore";
import useTagsStore from "/@/store/modules/useTagsStore";
import { setupLayouts } from "virtual:generated-layouts";
import generatedRoutes from "~pages";

const routes = setupLayouts(generatedRoutes);

// const routeModules = import.meta.glob<RouteRecordRaw>(
//   "/src/router/modules/*.ts",
//   {
//     import: "default",
//     eager: true,
//   }
// );
// const asyncRoutes: RouteRecordRaw[] = [];
// * 处理路由表
// Object.keys(routes).forEach((key) => {
//   const mod = routeModules[key];
//   const modList = Array.isArray(mod) ? [...mod] : [mod];
//   asyncRoutes.push(...modList);
// });

// routes.push(...asyncRoutes);

const router = createRouter({
  routes,
  history: createWebHistory(),
});

router.beforeEach((to, from, next) => {
  if (to.meta.requiredAuth) {
    const isAuthenticated = useAppConfigStore().isAuthenticated;
    if (!isAuthenticated && to.path != "/login") {
      next("/login");
    } else {
      const tagsStore = useTagsStore();
      if (to.meta.keepAlive) {
        tagsStore.addItem({
          title: to.meta.title as string,
          componentName: to.meta.componentName as string,
          path: to.fullPath,
        });
      }
      next();
    }
  } else {
    next();
  }
});

export function setupRouter(app: App) {
  app.use(router);
}

export function loadRotes() {}
