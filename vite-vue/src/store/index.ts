import { App } from "vue";
import { createPinia } from "pinia";
import piniaPluginPersistedstate from "pinia-plugin-persistedstate";

let pinia = createPinia();

pinia.use(piniaPluginPersistedstate);

export function setupStore(app: App) {
  app.use(pinia);
}
