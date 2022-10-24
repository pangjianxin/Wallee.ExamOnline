import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { setupRouter } from "./router";
import { setupStore } from "./store";
import * as ElementPlusIconsVue from "@element-plus/icons-vue";
import "uno.css";

let app = createApp(App);
setupStore(app);
setupRouter(app);
//element plus icon
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
  app.component(key, component);
}

app.mount("#app");
