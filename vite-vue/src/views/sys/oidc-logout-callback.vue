<script lang="ts" setup>
import { computed, onMounted } from "vue";
import { useRouter } from "vue-router";
import { useOidc } from "/@/hooks/oidc/useOidc";
import useOidcStore from "/@/store/modules/useOidcStore";
const router = useRouter();

const oidcStore = useOidcStore();

/**
 * manually login will be redirected to the callback route
 * 手动登录会被重定向到回调路由
 */
const { signinRedirect } = useOidc();

const popup = () => {
  oidcStore.getUserManager?.signinPopup();
};

onMounted(() => {
  oidcStore.oidcLogout();
  router.push("/login");
});
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
