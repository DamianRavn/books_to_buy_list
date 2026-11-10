<script lang="ts" setup>
  import {ref, computed, onMounted} from "vue";
  import BookForm from "./BookForm.vue";
  import BookList from "./BookList.vue";
  import FilterButton from "./FilterButton.vue";
  import type {Book, BookFilter} from "@/types.ts";
  import BookService from "@/services/book-service.ts";


  // Prepare the book service
  const bookService = new BookService();

  const header = ref("Book Overview");
  // Existing books
  const books = ref < Book[] > ([]);
  const filter = ref < BookFilter > ("all");

  const loading = ref(true);
  const fetchError = ref(null);

  // fetch data onMount
  onMounted(async () => {
    try {
      await getAllBooks();
    } catch (e) {
      fetchError.value = e.message;
    } finally {
      loading.value = false;
    }
  });


  // Calculates the amount of "done" books
  const totalDone = computed(() => books.value.reduce((total, book) => book.done ? total + 1 : total, 0));

  async function getAllBooks() {

    const res = await bookService.getAllBooks();
    books.value = res;
  }

  async function addBook(title: string, author: string) {
    let book: Book =
    {
      title: title,
      author: author,
    };

    const res = await bookService.addNewBook(book);
    books.value.push(res);
  }



  async function removeBook(id: number) {

    await bookService.deleteBook(id);
    await getAllBooks();

  }


  function setFilter(value: BookFilter) {
    filter.value = value;
  }
  function toggleDone(id: string) {
    const book = books.value.find((book) => book.id === id);
    if (book) {
      book.done = !book.done;
    }
  }
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

</script>

<template>
  <main>
    <p v-if="loading">Loading products...</p>
    <p v-else-if="fetchError">Could not load products: {{ fetchError }}</p>
    <div v-else>
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
    </div>
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