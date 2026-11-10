<script lang="ts" setup>
  import type {Book} from "../types.ts";

  const props = defineProps <
    {books: Book[]}
    > ();

  const emits = defineEmits
    <
  {
    toggleDone: [id: string];
    removeBook: [id: string];
  }
    > ();

</script>


<template>
  <TransitionGroup class="book-list" name="list" tag="div">
    <article class="book" v-for="book in props.books" :key="book.id">
      <label>
        <input @input="emits('toggleDone', book.id)" :checked="book.done" type="checkbox">
        <span :class="{done:book.done}">{{ book.title }} by {{ book.author }}</span>
      </label>
      <button class="outline" @click="emits('removeBook', book.id)">
        Remove
      </button>
    </article>
  </TransitionGroup>
</template>


<style>
  .done {

    text-decoration: line-through;
  }

  .book {
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
