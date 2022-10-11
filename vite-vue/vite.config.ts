import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import { resolve } from "path";

// https://vitejs.dev/config/
// export default defineConfig({
//   plugins: [vue()]
// })
function pathResolve(dir: string) {
  return resolve(process.cwd(), ".", dir);
}
export default defineConfig(({ command, mode }) => {
  return {
    plugins: [vue()],
    resolve: {
      alias: [
        {
          find: /\/@\//,
          replacement: pathResolve("src") + "/",
        },
        // /#/xxxx => types/xxxx
        {
          find: /\/#\//,
          replacement: pathResolve("types") + "/",
        },
      ],
    },
    server: {
      host: true,
      https: false,
      port: 3100,
    },
  };
});
