<template>
  <div class="flex flex-row flex-nowrap justify-between items-center h-full">
    <div class="flex flex-row flex-nowrap justify-start items-center h-full">
      <h1 class="font-5xl font-bold text-white text-stroke-sm">在线考试系统</h1>
      <a
        href="#"
        @click.prevent="handleSideBarCollapse"
        class="flex items-center p-0 ml-3"
      >
        <el-icon v-if="getSideCollapse" :size="25" color="white">
          <Expand />
        </el-icon>
        <el-icon v-else :size="25" color="white">
          <Fold />
        </el-icon>
      </a>
    </div>
    <div class="flex flex-row flex-nowrap justify-center items-center h-full">
      <el-avatar class="user-avator" :size="30" :src="imgurl" />
      <!-- 用户名下拉菜单 -->
      <el-dropdown class="ml-1" trigger="click" @command="handleCommand">
        <span class="text-white">
          {{ currentUser?.name }}
          <el-icon class="el-icon--right">
            <arrow-down />
          </el-icon>
        </span>
        <template #dropdown>
          <el-dropdown-menu>
            <el-dropdown-item v-if="isAuthenticated" command="logout"
              >注销</el-dropdown-item
            >
            <el-dropdown-item v-else divided command="login"
              >登录</el-dropdown-item
            >
          </el-dropdown-menu>
        </template>
      </el-dropdown>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { Expand, Fold } from "@element-plus/icons-vue";
import useAppConfigStore from "/@/store/modules/useApplicationConfigStore";
import { storeToRefs } from "pinia";
import { useOidc } from "/@/hooks/oidc/useOidc";
import imgurl from "/@/assets/img/img.jpg";
import useAppSettingsStore from "/@/store/modules/useAppSettingsStore";

const { signinRedirect, signoutRedirect } = useOidc();
const appSettingStore = useAppSettingsStore();
let { getSideCollapse } = storeToRefs(appSettingStore);
const appConfigStore = useAppConfigStore();
const { currentUser, isAuthenticated } = storeToRefs(appConfigStore);
const handleCommand = (command: string) => {
  if (command === "logout") {
    signoutRedirect({
      post_logout_redirect_uri:
        origin + import.meta.env["VITE_OIDC_LOGINOUT_REDIRECT_URI"],
    });
  }
  if (command === "login") {
    signinRedirect();
  }
};
const handleSideBarCollapse = () => {
  appSettingStore.handleCollapse();
};
</script>

<style scoped></style>
