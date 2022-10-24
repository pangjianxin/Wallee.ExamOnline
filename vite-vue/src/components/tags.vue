<template>
  <div class="shadow-lg m-0">
    <el-tag
      v-for="(item, index) in items"
      :key="index"
      :type="tagType(item.path)"
      effect="dark"
      size="large"
      class="m-1"
      closable
      @close="onTagClose(index)"
    >
      <router-link :to="item.path" class="link">
        <el-icon> <component is="Link"></component></el-icon>{{ item.title }}
      </router-link>
    </el-tag>
  </div>
</template>

<script setup lang="ts">
import useTagsStore from "/@/store/modules/useTagsStore";
import { storeToRefs } from "pinia";
import { useRoute } from "vue-router";
const tagsStore = useTagsStore();
let route = useRoute();
let { items } = storeToRefs(tagsStore);
function onTagClose(index: number) {
  tagsStore.deleteItem(index);
}

function tagType(value: string): string {
  return value === route.path ? "success" : "";
}
</script>

<style scoped>
a {
  text-decoration: none;
  color: #333;
  font-family: sans-serif;
  font-size: 12px;
}
.link {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}
</style>
