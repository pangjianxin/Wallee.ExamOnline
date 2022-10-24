<template>
  <el-container>
    <el-header class="bg-blue p-0 m-0">
      <Header />
    </el-header>
    <el-container>
      <el-aside :width="sideWidth">
        <SideBar></SideBar>
      </el-aside>
      <el-main style="padding: 0">
        <v-tags></v-tags>
        <el-main>
          <router-view>
            <template #default="{ Component, route }">
              <transition name="move" mode="out-in">
                <keep-alive v-if="isEnabled" :include="cachedComponentsName">
                  <component :is="Component" :key="route.fullPath"></component>
                </keep-alive>
                <component v-else :is="Component" :key="route.fullPath">
                </component>
              </transition>
            </template>
          </router-view>
        </el-main>
      </el-main>
    </el-container>
  </el-container>
</template>
<script lang="ts" setup>
import { computed } from "vue";
import useTagStore from "/@/store/modules/useTagsStore";
import Header from "/@/components/Header.vue";
import vTags from "/@/components/tags.vue";
import SideBar from "/@/components/side-bar.vue";
import useAppSettingsStore from "/@/store/modules/useAppSettingsStore";
import { storeToRefs } from "pinia";
import PageHeader from "/@/components/pageHeader.vue";
const appSettingStore = useAppSettingsStore();
const { sideCollapse } = storeToRefs(appSettingStore);
let sideWidth = computed(() => {
  if (sideCollapse) {
    return "auto";
  }
  return "200px";
});
const { isEnabled, cachedComponentsName } = storeToRefs(useTagStore());
</script>
<style scoped>
.move-enter-active,
.move-leave-active {
  transition: opacity 0.1s ease;
}

.move-enter-from,
.move-leave-to {
  opacity: 0;
}
</style>
