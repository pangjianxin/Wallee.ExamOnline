<template>
  <div>Home</div>
  <div>
    <button @click="incrementRate">incrementRate</button>
  </div>
  <Rate :rate="rateNum" :theme="'red'" @on-change="getTheme"></Rate>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Rate from "./rate.vue";
let rateNum = ref(4);
const incrementRate = () => {
  if (rateNum.value < 5) {
    rateNum.value++;
  }
};

const getTheme = (theme: string) => {
  console.log("theme is ", theme);
};
</script>

<style scoped></style>
