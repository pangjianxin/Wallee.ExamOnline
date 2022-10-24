import { defineStore } from "pinia";

export default defineStore("appSettings", {
  state: () => {
    return { sideCollapse: true };
  },
  getters: {
    getSideCollapse(): boolean {
      return this.sideCollapse;
    },
  },
  actions: {
    handleCollapse() {
      this.sideCollapse = !this.sideCollapse;
      console.log(this.sideCollapse);
    },
  },
});
