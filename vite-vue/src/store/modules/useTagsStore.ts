import { defineStore } from "pinia";

interface ListItem {
  componentName: string; //缓存的组件名称
  path: string; //路由路径
  title: string; //标签
}
/**
 * 用于存储有缓存需求的页面
 *
 */
export default defineStore("tags", {
  state: () => {
    return {
      items: <ListItem[]>[],
      enabled: true,
    };
  },
  getters: {
    isEnabled(): boolean {
      return this.enabled;
    },
    show(): boolean {
      return this.items.length > 0;
    },
    cachedComponentsName(): string[] {
      return this.items.map((item) => item.componentName);
    },
  },
  actions: {
    deleteItem(index: number) {
      this.items.splice(index, 1);
    },
    addItem(data: ListItem) {
      const existed = this.items.some(
        (it) => it.componentName === data.componentName
      );
      if (!existed) {
        this.items.push(data);
      }
    },
    clearItems() {
      this.items = [];
    },
    closeCurrentTag(data: any) {
      for (let i = 0, len = this.items.length; i < len; i++) {
        const item = this.items[i];
        if (item.path === data.$route.fullPath) {
          if (i < len - 1) {
            data.$router.push(this.items[i + 1].path);
          } else if (i > 0) {
            data.$router.push(this.items[i - 1].path);
          } else {
            data.$router.push("/");
          }
          this.items.splice(i, 1);
          break;
        }
      }
    },
  },
});
