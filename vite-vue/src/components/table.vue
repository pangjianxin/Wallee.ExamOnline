<template>
  <div>
    <el-table :data="users" style="height: 100%">
      <el-table-column prop="name" label="名字"></el-table-column>
      <el-table-column prop="age" label="年龄"></el-table-column>
      <el-table-column prop="sex" label="性别"></el-table-column>
      <el-table-column fixed="right" prop="date" label="日期"></el-table-column>
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
</script>

<style scoped></style>
