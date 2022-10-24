<template>
  <div class="mt-3">
    <el-row>
      <el-col :span="24">
        <el-form
          label-width="auto"
          label-position="left"
          ref="choiceQuestionForm"
          :rules="choiceQuestionModelRules"
          :model="choiceQuestionModel"
        >
          <el-form-item prop="category">
            <template #label> 选择题类型 </template>
            <el-select
              placeholder="选择选择题类型"
              v-model="choiceQuestionModel.category"
              clearable
              style="width: 100%"
            >
              <el-option :label="'单选题'" :value="ChoiceQuestionCategory._1">
                <span style="float: left">单选题</span>
              </el-option>
              <el-option :label="'多选题'" :value="ChoiceQuestionCategory._2">
                <span style="float: left">多选题</span>
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item prop="title" label="题目">
            <el-input
              v-model="choiceQuestionModel.title"
              type="text"
              prefix-icon="EditPen"
              placeholder="输入该题的题目..."
            >
            </el-input>
          </el-form-item>
          <el-form-item prop="comment" label="试题注释">
            <el-input
              v-model="choiceQuestionModel.comment"
              type="text"
              prefix-icon="Comment"
              placeholder="输入该题的释义，可选..."
            >
            </el-input>
          </el-form-item>
        </el-form>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="24">
        <el-form
          label-width="auto"
          label-position="left"
          ref="choiceQuestionOptionForm"
          :model="choiceQuestionOptionsModel"
        >
          <template v-if="choiceQuestionOptionsModel.options?.length">
            <template
              v-for="(item, index) in choiceQuestionOptionsModel.options"
              :key="index"
            >
              <el-row>
                <el-col :span="24">
                  <el-form-item
                    :label="`选项-${ChoiceQuestionOptionIndex[item.index as number]}`"
                    :prop="`options[${index}].content`"
                    :rules="contentValidator"
                  >
                    <el-input
                      type="text"
                      :autosize="true"
                      v-model="item.content"
                      prefix-icon="Open"
                    >
                    </el-input>
                  </el-form-item>
                </el-col>
              </el-row>
              <el-row justify="end" align="middle">
                <el-form-item :prop="`options[${index}].isAnswer`">
                  <el-switch
                    v-model="item.isAnswer"
                    inline-prompt
                    active-text="正确"
                    inactive-text="错误"
                    size="large"
                    width="100px"
                  />
                </el-form-item>
                <el-form-item style="margin-left: 10px">
                  <el-button
                    type="primary"
                    plain
                    @click="removeOption(index)"
                    icon="delete"
                    :disabled="
                      choiceQuestionOptionsModel.options.length != index + 1
                    "
                    >删除该选项</el-button
                  >
                </el-form-item>
              </el-row>
            </template>
          </template>
          <el-form-item>
            <el-button icon="Check" type="primary" @click="submitForm"
              >提交表单
            </el-button>
            <el-button @click="addOption" icon="CirclePlus" type="success"
              >添加选项
            </el-button>
          </el-form-item>
        </el-form>
      </el-col>
    </el-row>
  </div>
</template>
<script setup lang="ts">
import {
  CreateChoiceQuestionDto,
  CreateChoiceQuestionOptionDto,
  ChoiceQuestionService,
  ChoiceQuestionCategory,
  ChoiceQuestionOptionIndex,
  ApiError,
} from "/@/openapi/index";
import { FormInstance, FormItemRule, FormRules } from "element-plus";
import { reactive, ref } from "vue";
import { showError } from "/@/utils/app";

//指数用于推算下一个选项是什么。
//因为目前系统设计选择题是一种Flag（可以进行位运算的枚举）的枚举，每一个值都是以2为底的指数
let exponent = ref<number>(1);

let choiceQuestionForm = ref<FormInstance>();
let choiceQuestionOptionForm = ref<FormInstance>();
//
let choiceQuestionModel = reactive<CreateChoiceQuestionDto>({
  category: ChoiceQuestionCategory._1,
  title: null,
  comment: null,
  options: [],
});
let choiceQuestionModelRules = reactive<FormRules>({
  title: [
    { required: true, message: "问题标题必填", trigger: "blur" },
    { min: 1, max: 100, message: "长度超限", trigger: "blur" },
  ],
  comment: [{ min: 1, max: 100, message: "长度超限", trigger: "blur" }],
  category: [{ required: true, message: "必填", trigger: "change" }],
});
let choiceQuestionOptionsModel = reactive<{
  options: CreateChoiceQuestionOptionDto[];
}>({
  options: [
    {
      index: ChoiceQuestionOptionIndex.A,
      content: null,
      isAnswer: false,
    },
  ],
});

let contentValidator: FormItemRule = {
  required: true,
  message: "内容不能为空",
  trigger: "blur",
};

async function submitForm() {
  try {
    //校验选择题表单
    await choiceQuestionForm.value?.validate();
    //校验选项，分为两步，首先校验内容完整，
    await choiceQuestionOptionForm.value?.validate();
    //然后校验内容是否符合要求：
    //①校验条目数是否大于2条
    let optionsCount = choiceQuestionOptionsModel.options.length;
    if (optionsCount < 2) {
      showError("选择题的选项不能少于2个");
      return;
    }
    let category = choiceQuestionModel.category;
    let answerCount = choiceQuestionOptionsModel.options.filter(
      (it) => it.isAnswer
    ).length;

    if (category === ChoiceQuestionCategory._1) {
      if (answerCount != 1) {
        showError("单选题有且只有一个正确答案");
        return;
      }
    }
    if (category === ChoiceQuestionCategory._2) {
      if (answerCount <= 1) {
        showError("多选题必须拥有大于1个的正确答案");
        return;
      }
    }
    choiceQuestionModel.options = choiceQuestionOptionsModel.options;
    let res = await ChoiceQuestionService.choiceQuestionCreate(
      choiceQuestionModel
    );
  } catch (error: any) {
    if (error instanceof ApiError) {
      showError(`${error.message}`);
    }
  }
}
//添加一个选项
function addOption() {
  choiceQuestionOptionsModel.options.push({
    content: null,
    index: Math.pow(2, exponent.value++),
    isAnswer: false,
  });
}
//删除一个选项
function removeOption(index: number) {
  choiceQuestionOptionsModel.options.splice(index, 1);
  --exponent.value;
}
</script>
<script lang="ts">
export default {
  name: "CraeteChoiceQuestion",
};
</script>
