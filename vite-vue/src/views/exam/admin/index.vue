<route>
    {
        name:"exam-admin-index",
        meta:{
            requiredAuth:true,
            title:"试题管理",
            description:"题型管理",
            keepAlive:true,
            componentName:"exam-admin"
        }
    }
</route>
<template>
  <div>
    <page-header title="考试管理" description="考试索引">
      <template #actions>
        <el-button
          type="primary"
          @click="openChoiceQuestionDrawer('CraeteChoiceQuestion')"
          icon="CirclePlus"
        >
          创建选择题
        </el-button>
        <el-button
          type="warning"
          @click="openChoiceQuestionDrawer('CreateEssayQuestion')"
          icon="CirclePlus"
        >
          创建论述题
        </el-button>
        <el-button
          type="danger"
          @click="openChoiceQuestionDrawer('CreateTrueOrFalseQuestion')"
          icon="CirclePlus"
        >
          创建判断题
        </el-button>
        <el-button icon="Edit" @click="getList">getlist</el-button>
      </template>
    </page-header>
    <el-drawer
      v-model="drawerOpen"
      :direction="'rtl'"
      size="50%"
      :before-close="confirmDrawerClose"
    >
      <template #header>
        <h4>表单</h4>
      </template>
      <template #default>
        <KeepAlive include="CraeteChoiceQuestion">
          <component :is="componnets[currentOptComponent]"></component>
        </KeepAlive>
      </template>
    </el-drawer>
    <Table></Table>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import "element-plus/es/components/message-box/style/css";
import CraeteChoiceQuestion from "./components/craeteChoiceQuestion.vue";
import CreateEssayQuestion from "./components/createEssayQuestion.vue";
import CreateTrueOrFalseQuestion from "./components/createTrueOrFalseQuestion.vue";
import { ElMessageBox } from "element-plus";
import PageHeader from "/@/components/pageHeader.vue";

import Table from "/@/components/table.vue";
import {
  ChoiceQuestionService,
  PagedResultDtoOfChoiceQuestionDto,
} from "/@/openapi/index";
let componnets: { [key: string]: any } = {
  CraeteChoiceQuestion: CraeteChoiceQuestion,
  CreateEssayQuestion: CreateEssayQuestion,
  CreateTrueOrFalseQuestion: CreateTrueOrFalseQuestion,
};
let drawerOpen = ref<boolean>(false);
let currentOptComponent = ref<string>("");
function confirmDrawerClose(done: () => void) {
  ElMessageBox.confirm(`确认关闭?`)
    .then(() => {
      done();
    })
    .catch(() => {
      console.log(drawerOpen.value);
    });
}
function openChoiceQuestionDrawer(component: string) {
  currentOptComponent.value = component;
  drawerOpen.value = true;
}
async function getList() {
  let res: PagedResultDtoOfChoiceQuestionDto =
    await ChoiceQuestionService.choiceQuestionGetList();
  console.log(res);
}
</script>
<script lang="ts">
export default {
  name: "exam-admin",
};
</script>

<style scoped></style>
