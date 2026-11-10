<script lang="ts" setup>
  import {ref, computed} from "vue";
  import BookForm from "./BookForm.vue";
  import BookList from "./BookList.vue";
  import FilterButton from "./FilterButton.vue";
  import type {Book, BookFilter} from "../types.ts";


  const header = ref("Book Overview");
  const books = ref < Book[] > ([]);
  const filter = ref < BookFilter > ("all");

  // Calculates the amount of "done" books
  const totalDone = computed(() => books.value.reduce((total, book) => book.done ? total + 1 : total, 0));

  // Filters the books based on the filter
  const filteredBooks = computed(() => {
    switch (filter.value) {
      case "all":
        return books.value;
      case "todo":
        return books.value.filter((book) => !book.done);
      case "done":
        return books.value.filter((book) => book.done);
    }

    return books.value;
  });

  function addBook(title: string, author: string) {
    books.value.push(
      {
        id: crypto.randomUUID(),
        title: title,
        author: author,
        done: false,
      }
    );
  }

  function toggleDone(id: string) {
    const book = books.value.find((book) => book.id === id);
    if (book) {
      book.done = !book.done;
    }
  }


  function removeBook(id: string) {
    const index = books.value.findIndex((book) => book.id === id);
    if (index !== -1) {
      books.value.splice(index, 1);
    }
  }


  function setFilter(value: BookFilter) {
    filter.value = value;
  }

</script>

<template>
  <main>
    <h1>{{ header }}</h1>
    <BookForm @add-book="addBook" />
    <h3 v-if="!books.length">Add a Book to get started</h3>
    <h3 v-else>{{ totalDone }} / {{books.length}} Books bought</h3>
    <div v-if="books.length" class="button-container">
      <FilterButton :currentFilter="filter" filter="all" @set-filter="setFilter" />
      <FilterButton :currentFilter="filter" filter="todo" @set-filter="setFilter" />
      <FilterButton :currentFilter="filter" filter="done" @set-filter="setFilter" />
    </div>
    <BookList :books="filteredBooks" @toggle-done="toggleDone" @remove-book="removeBook" />
  </main>
</template>

<style>
  main {
    max-width: 1080px;
    margin: 1rem auto;
  }

  .book-list {
    margin-top: 1rem;
  }

  .button-container {
    display: flex;
    justify-content: end;
    gap: 0.5rem
  }
</style>