
<script lang="ts" setup>
  import {ref} from "vue";

  const task = ref("");
  const error = ref("");

  const emit = defineEmits<
  {
    addTask: [task: string]
  }>();

  function formSubmitted() {
  let val = task.value.trim();
  if (val){

    emit("addTask", val);
    task.value = "";
  }
  else
  {
    error.value = "Book cannot be empty!";
  }

  }
</script>

<template>
    <form @submit.prevent="formSubmitted">
      <label>
        Books To Buy
        <input v-model="task" name="books_to_buy" :aria-invalid="!!error || undefined" @input="error = ''">
      </label>
    <small v-if="error" id="invalid-helper">
{{error}}
    </small>
      <div class="button-container">
        <button>Add Book</button>
      </div>
    </form>
    </template>

