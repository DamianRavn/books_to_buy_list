<script lang="ts" setup>
  import {ref} from "vue";

  const title = ref("");
  const author = ref("");
  const title_error = ref("");
  const author_error = ref("");

  const emit = defineEmits <
  {
    addBook: [title: string, author: string]
  } > ();

  function formSubmitted() {
    let clean_title = title.value.trim();
    let clean_author = author.value.trim();
    if (clean_title && clean_author) {

      emit("addBook", clean_title, clean_author);
      title.value = "";
      author.value = "";
    }
    else {
      if (!clean_title) {

        title_error.value = "Title cannot be empty!";
      }
      if (!clean_author) {

        author_error.value = "Author cannot be empty!";
      }
    }

  }
</script>

<template>
  <form @submit.prevent="formSubmitted">
    <label>
      Books To Buy
      <input v-model="title" name="title_of_book" placeholder="Title" :aria-invalid="!!title_error || undefined"
        @input="title_error = ''">
      <small v-if="title_error" id="invalid-helper">
        {{title_error}}
      </small>
      <input v-model="author" name="author_of_book" placeholder="Author" :aria-invalid="!!author_error || undefined"
        @input="author_error = ''">
      <small v-if="author_error" id="invalid-helper">
        {{author_error}}
      </small>
    </label>
    <div class="button-container">
      <button>Add Book</button>
    </div>
  </form>
</template>