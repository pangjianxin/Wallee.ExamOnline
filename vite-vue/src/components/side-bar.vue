<template>
  <el-menu :default-active="onRoutes" :collapse="sideCollapse" router>
    <template v-for="item in items">
      <el-menu-item v-if="!item.children?.length" :index="item.path">
        <el-icon>
          <component :is="item.icon"></component>
        </el-icon>
        <template #title>
          <span>{{ item.title }}</span>
        </template>
      </el-menu-item>
      <el-sub-menu v-else :index="item.title ?? item.path">
        <template #title>
          <el-icon>
            <component :is="item.icon"></component>
          </el-icon>
          <span>{{ item.title }}</span>
        </template>
        <tree :items="item.children"></tree>
      </el-sub-menu>
    </template>
  </el-menu>
</template>
<script setup lang="ts">
import useAppConfigStore from "/@/store/modules/useApplicationConfigStore";
import { useRouter, RouteRecordRaw } from "vue-router";
import { storeToRefs } from "pinia";
import useAppSettingStore from "/@/store/modules/useAppSettingsStore";
import { computed } from "vue";
import { useRoute } from "vue-router";
import { MenuItem } from "/#/menu";
import tree from "./tree.vue";
const { isAuthenticated } = storeToRefs(useAppConfigStore());
const router = useRouter();

const appSettingStore = useAppSettingStore();
let { sideCollapse } = storeToRefs(appSettingStore);

const items: MenuItem[] = [
  {
    icon: "Odometer",
    path: "/about",
    title: "关于我们",
  },
  {
    icon: "Calendar",
    path: "/login",
    title: "登录首页",
  },
  {
    icon: "DocumentCopy",
    path: "/exam",
    title: "考试",
    children: [
      { icon: "Odometer", path: "/exam/admin", title: "试题管理" },
      { icon: "Odometer", path: "/choice-questions", title: "选择题" },
      {
        icon: "Odometer",
        path: "/true-or-false-questions",
        title: "判断题",
        children: [
          {
            path: "/true-or-false-questions/yes",
            icon: "Odometer",
            title: "判断题索引",
          },
        ],
      },
      { icon: "Odometer", path: "/essay-questions", title: "论述题" },
    ],
  },
];

const route = useRoute();
const onRoutes = computed(() => {
  return route.path;
});
</script>

<style scoped></style>
