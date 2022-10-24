import { defineStore } from "pinia";

export default defineStore("sidebar", {
  state: () => {
    return {
      collapse: false,
    };
  },
  getters: {},
  actions: {
    handleCollapse() {
      this.collapse = !this.collapse;
    },
  },
});
