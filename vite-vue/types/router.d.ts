// typings.d.ts or router.ts
import "vue-router";

declare module "vue-router" {
  interface RouteMeta {
    requiredAuth?: boolean; //该路由是否需要认证
    title?: string; //该路由的友好名称
    description?: string; //该路由的描述
    icon?: string; //该路由的图标
    hidden?: boolean; //是否隐藏该路由
    order?: number; //该路由的顺序号
    keepAlive?: boolean; //是否需要keep-valive
    componentName?: string; //该路由对应的组件名称（在keepAlive的情况下生效）
  }
}
