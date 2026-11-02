<script lang="ts" setup>
  import type {Task} from "../types.ts";

  const props = defineProps <
    {tasks: Task[]}
    > ();

  const emits = defineEmits
    <
  {
    toggleDone: [id: string];
    removeTask: [id: string];
  }
    > ();

</script>


<template>
  <TransitionGroup class="task-list" name="list" tag="div">
    <article class="task" v-for="task in props.tasks" :key="task.id">
      <label>
        <input @input="emits('toggleDone', task.id)" :checked="task.done" type="checkbox">
        <span :class="{done:task.done}">{{ task.title }}</span>
      </label>
      <button class="outline" @click="emits('removeTask', task.id)">
        Remove
      </button>
    </article>
  </TransitionGroup>
</template>


<style>
  .done {

    text-decoration: line-through;
  }

  .task {
    display: flex;
    justify-content: space-between;
    align-items: center;
  }

  .list-enter-active,
  .list-leave-active {
    transition: all 0.5s ease;
  }

  .list-enter-from,
  .list-leave-to {
    opacity: 0;
    transform: translateX(300px);
  }
</style>