<template>
  <div :style="themeComp">
    {{ rateComp }}
  </div>
</template>

<script setup lang="ts">
import { computed, defineProps, defineEmits, onMounted } from "vue";
const props = defineProps({
  rate: {
    type: Number,
  },
  theme: {
    type: String,
    default: "red",
  },
});
const emit = defineEmits(["on-change"]);

const themeObj: {
  [T: string]: string;
} = {
  black: "#00",
  white: "#fff",
  red: "#f5222d",
  orange: "#fa541c",
  yellow: "#fadb14",
  green: "#73d13d",
  blue: "#40a9ff",
};
const rateComp = computed(() => {
  return "★★★★★☆☆☆☆☆".slice(5 - props.rate!, 10 - props.rate!);
});

const themeComp = computed(() => {
  return `color:${themeObj[props.theme]}`;
});

const onChnage = () => {
  emit("on-change", props.theme);
};
onMounted(() => {
  onChnage();
});
</script>

<style scoped></style>
