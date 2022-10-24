import { defineConfig } from "vite";
import { resolve } from "path";
import vue from "@vitejs/plugin-vue";
import vueJsx from "@vitejs/plugin-vue-jsx";
import { Plugin } from "vite";
import AutoImport from "unplugin-auto-import/vite";
import Components from "unplugin-vue-components/vite";
import { ElementPlusResolver } from "unplugin-vue-components/resolvers";
import Layout from "vite-plugin-vue-layouts";
import Pages, { PageResolver } from "vite-plugin-pages";
import Unocss from "unocss/vite";
import { presetWind } from "unocss";

function pathResolve(dir: string) {
  return resolve(process.cwd(), ".", dir);
}
export default defineConfig(({ command, mode }) => {
  return {
    plugins: [
      // have to
      vue(),
      // have to
      vueJsx(),
      AutoImport({
        resolvers: [ElementPlusResolver()],
      }),
      Components({
        resolvers: [ElementPlusResolver()],
      }),
      Pages({
        dirs: [
          {
            dir: "src/views",
            baseRoute: "",
          },
          {
            dir: "src/views/sys",
            baseRoute: "",
          },
        ],
        extensions: ["vue", "ts", "js"], //this is the default value
        importMode: "async",
        moduleId: "~pages",
        // extendRoute: (route, parent) => {
        //   return route;
        // },
        exclude: ["**/components/*"],
      }),
      Layout({
        defaultLayout: "home",
        layoutsDirs: ["src/layouts"],
      }),
      Unocss({
        presets: [presetWind()],
      }),
    ],
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
