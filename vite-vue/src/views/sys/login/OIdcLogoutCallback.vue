<script lang="ts" setup>
import { computed } from "vue";
import { useRouter } from "vue-router";
import { useAuth } from "../../../hooks/oidc/useAuth";
import { useOidcStore } from "../../../store/modules/useOidcStore";
const router = useRouter();

const oidcStore = useOidcStore();

/**
 * manually login will be redirected to the callback route
 * 手动登录会被重定向到回调路由
 */
const { signinRedirect } = useAuth();

const popup = () => {
  oidcStore.userManager?.signinPopup();
};
</script>

<template>
  <div>
    <h1>暂未登录</h1>
    <button @click="router.push('/home')">Home</button>
    <button @click="signinRedirect!()">SignIn</button>
    <button @click="popup">Popup_SignIn</button>
  </div>
</template>

<style lang="less" scoped></style>
