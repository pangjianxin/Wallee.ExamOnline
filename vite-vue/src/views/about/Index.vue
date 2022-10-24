<route>
  {
    name:"about",
    meta:{
      title:"关于我们",
      keepAlive:true,
      componentName:"about",
      requiredAuth:true,
      description:"作者信息"
    }
  }
</route>
<template>
  <div>
    <el-table :data="users" style="height: 600px; width: 600px">
      <el-table-column
        fixed
        prop="name"
        label="名字"
        width="200"
      ></el-table-column>
      <el-table-column prop="age" label="年龄" width="200"></el-table-column>
      <el-table-column prop="sex" label="性别" width="200"></el-table-column>
      <el-table-column prop="date" label="日期" width="300"> </el-table-column>
      <el-table-column fixed="right" label="Operations" width="120">
        <template #default>
          <el-button link type="primary" size="small" @click="handleClick"
            >Detail</el-button
          >
          <el-button link type="primary" size="small">Edit</el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script setup lang="ts">
let users = [
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
  { name: "wallee", age: 19, sex: 0, date: new Date() },
];
function handleClick() {
  console.log(Object.keys(obj));
}


let obj = {
  name: "wallee",
  address: {
    city: "baotou",
    index: 1,
    street: {
      a: 1,
      b: "b",
    },
  },
};
</script>
<script lang="ts">
export default {
  name: "about",
};
</script>

<style scoped></style>
