<template>
  <div>Login</div>
  <div>
    <button @click="signin">SignIn</button>
    <button @click="printUser">PrintUserInState</button>
    <button @click="printUserInUserManager">printUserInUserMnager</button>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from "vue-router";
import { onMounted } from "vue";
import { useAuth } from "/@/hooks/oidc/useAuth";
import { useOidcStore } from "/@/store/modules/useOidcStore";

const router = useRouter();

const oidcStore = useOidcStore();

const { autoAuthenticate, signinRedirect } = useAuth();
const signin = () => {
  signinRedirect();
};

const printUser = () => {
  console.log(oidcStore.user);
};
const printUserInUserManager = async () => {
  console.log(await oidcStore.getUserManager.getUser());
};
</script>

<style scoped></style>
