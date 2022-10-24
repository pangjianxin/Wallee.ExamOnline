import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";
import { App } from "vue";
import usePermissStore from "/@/store/permission";
import Home from "/@/views/sys/home.vue";

const routes: RouteRecordRaw[] = [
  // {
  //   path: "/",
  //   redirect: "/dashboard",
  // },
  {
    path: "/",
    name: "Home",
    component: Home,
    children: [
      {
        path: "/dashboard",
        name: "dashboard",
        meta: {
          title: "系统首页",
          permiss: "1",
        },
        component: () =>
          import(
            /* webpackChunkName: "dashboard" */ "/@/views/sys/dashboard.vue"
          ),
      },

      {
        path: "/tabs",
        name: "tabs",
        meta: {
          title: "tab标签",
          permiss: "3",
        },
        component: () =>
          import(/* webpackChunkName: "tabs" */ "/@/views/sys/tabs.vue"),
      },
      {
        path: "/user",
        name: "user",
        meta: {
          title: "个人中心",
        },
        component: () =>
          import(/* webpackChunkName: "user" */ "/@/views/sys/user.vue"),
      },
    ],
  },
  {
    path: "/login",
    name: "Login",
    meta: {
      title: "登录",
    },
    component: () =>
      import(/* webpackChunkName: "login" */ "/@/views/sys/login.vue"),
  },
  {
    path: "/403",
    name: "403",
    meta: {
      title: "没有权限",
    },
    component: () =>
      import(/* webpackChunkName: "403" */ "/@/views/sys/403.vue"),
  },
];

export function setupRouter(app: App) {
  const router = createRouter({
    history: createWebHashHistory(),
    routes,
  });

  router.beforeEach((to, from, next) => {
    document.title = `${to.meta.title} | vue-manage-system`;
    const role = localStorage.getItem("ms_username");
    const permiss = usePermissStore();
    if (!role && to.path !== "/login") {
      next("/login");
    } else if (to.meta.permiss && !permiss.key.includes(to.meta.permiss)) {
      // 如果没有权限，则进入403
      next("/403");
    } else {
      next();
    }
  });

  app.use(router);
  return app;
}
