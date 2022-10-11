import { RouteRecordRaw } from "vue-router";

const about: RouteRecordRaw = {
  path: "/about",
  component: () => import("/@/views/about/Index.vue"),
};

export default about;
