import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { setupRouter } from "./router";
import { setupStore } from "./store";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";

let app = createApp(App);

setupRouter(app);
setupStore(app);
app.use(ElementPlus);

app.mount("#app");
