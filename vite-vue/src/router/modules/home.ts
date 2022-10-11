import { RouteRecordRaw } from "vue-router";

const home: RouteRecordRaw = {
  path: "/",
  redirect: "/home",
  children: [
    { path: "home", component: () => import("/@/views/home/Index.vue") },
  ],
};

export default home;
