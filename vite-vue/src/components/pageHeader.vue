<template>
  <el-page-header @back="onBack">
    <template #breadcrumb>
      <el-breadcrumb separator="/">
        <el-breadcrumb-item :to="'/'"> 回到首页 </el-breadcrumb-item>
        <el-breadcrumb-item>{{ title }}</el-breadcrumb-item>
      </el-breadcrumb>
    </template>
    <template #content>
      <div class="flex items-center">
        <el-avatar class="mr-3" :size="20" src="/src/assets/img/boc.png" />
        <span class="text-large font-600 mr-3"> {{ title }} </span>
        <el-tag>{{ description }}</el-tag>
      </div>
    </template>
    <template #extra>
      <slot name="actions"></slot>
    </template>
  </el-page-header>
</template>
<script lang="ts" setup>
import { useRouter, useRoute } from "vue-router";
type PageHeaderProps = {
  title: string;
  description: string;
};
defineProps<PageHeaderProps>();
let router = useRouter();
let route = useRoute();
function onBack() {
  router.back();
}
</script>
