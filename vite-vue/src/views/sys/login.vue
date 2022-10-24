<route>
  {
    name:"login",
    meta:{
      title:"登录",
      keepAlive:true,
      componentName:"login",
      requiredAuth:false,
      description:"登录页面"
    }
  }
</route>
<template>
  <div>
    LOGIN
    <button @click="count++">{{ count }}</button>
  </div>
</template>

<script lang="ts" setup name="login">
import { ref, onActivated } from "vue";
let count = ref(1);
</script>

<style lang="scss" scoped></style>
