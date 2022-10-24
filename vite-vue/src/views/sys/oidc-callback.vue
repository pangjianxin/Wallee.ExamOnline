<script setup lang="ts">
import { computed, onMounted, unref } from "vue";
import { useRouter } from "vue-router";
import useOidcStore from "/@/store/modules/useOidcStore";

const oidcStore = useOidcStore();
const router = useRouter();

/**
 * manually handle login and will save user to state
 * 手动处理登录并将用户保存到state
 */
onMounted(async () => {
  let user = (await oidcStore.getUserManager?.signinRedirectCallback()) || null;
  await oidcStore.store(user!);
  router.push("/login");
});
</script>

<template>
  <div>
    <h1>OIDC-CALLBACK</h1>
  </div>
</template>

<style lang="less" scoped></style>
