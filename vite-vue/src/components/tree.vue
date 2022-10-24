<template>
  <div v-for="item in items" :key="item.path">
    <el-menu-item v-if="!item.children?.length" :index="item.path">
      <el-icon>
        <component :is="item.icon"></component>
      </el-icon>
      <template #title>
        <span>{{ item.title }}</span>
      </template>
    </el-menu-item>
    <el-sub-menu v-else :index="item.path">
      <template #title>
        <el-icon>
          <component :is="item.icon"></component>
        </el-icon>
        <span>{{ item.title }}</span>
      </template>
      <tree :items="item.children"></tree>
    </el-sub-menu>
  </div>
</template>

<script lang="ts" setup name="tree">
import { MenuItem } from "/#/menu";
type MenuItems = {
  items: MenuItem[];
};
defineProps<MenuItems>();
</script>
