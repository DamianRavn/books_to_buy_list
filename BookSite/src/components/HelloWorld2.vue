<script lang="ts" setup>
  import {ref, computed} from "vue";
  import TaskForm from "./TaskForm.vue";
  import TaskList from "./TaskList.vue";
  import FilterButton from "./FilterButton.vue";
  import type {Task, TaskFilter} from "../types.ts";


  const header = ref("Book Tasks");
  const tasks = ref < Task[] > ([]);
  const filter = ref < TaskFilter > ("all");

  const totalDone = computed(() => tasks.value.reduce((total, task) => task.done ? total + 1 : total, 0));

  const filteredTasks = computed(() => {
    switch (filter.value) {
      case "all":
        return tasks.value;
      case "todo":
        return tasks.value.filter((task) => !task.done);
      case "done":
        return tasks.value.filter((task) => task.done);
    }

    return tasks.value;
  });

  function addTask(task: string) {
    tasks.value.push(
      {
        id: crypto.randomUUID(),
        title: task,
        done: false,
      }
    );
  }

  function toggleDone(id: string) {
    const task = tasks.value.find((task) => task.id === id);
    if (task) {
      task.done = !task.done;
    }
  }


  function removeTask(id: string) {
    const index = tasks.value.findIndex((task) => task.id === id);
    if (index !== -1) {
      tasks.value.splice(index, 1);
    }
  }


  function setFilter(value: TaskFilter) {
    filter.value = value;
  }

</script>

<template>
  <main>
    <h1>{{ header }}</h1>
    <TaskForm @add-task="addTask" />
    <h3 v-if="!tasks.length">Add a Book to get started</h3>
    <h3 v-else>{{ totalDone }} / {{tasks.length}} Books bought</h3>
    <div v-if="tasks.length" class="button-container">
      <FilterButton :currentFilter="filter" filter="all" @set-filter="setFilter" />
      <FilterButton :currentFilter="filter" filter="todo" @set-filter="setFilter" />
      <FilterButton :currentFilter="filter" filter="done" @set-filter="setFilter" />
    </div>
    <TaskList :tasks="filteredTasks" @toggle-done="toggleDone" @remove-task="removeTask" />
  </main>
</template>

<style>
  main {
    max-width: 1080px;
    margin: 1rem auto;
  }

  .task-list {
    margin-top: 1rem;
  }

  .button-container {
    display: flex;
    justify-content: end;
    gap: 0.5rem
  }
</style>