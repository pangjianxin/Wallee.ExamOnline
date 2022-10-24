<route>
  {
    name:"exam",
    meta:{
      title:"考试系统",
      componentName:"exam",
      keepAlive:true,
      requiredAuth:true,
      description:"索引页"
    }
  }
</route>
<template>
  <div>
    <div>exam</div>
    <div>
      <button @click="count++">{{ count }}</button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
let count = ref(1);
</script>
<script lang="ts">
export default {
  name: "exam",
};
</script>
<style scoped></style>
