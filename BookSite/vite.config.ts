// Source - https://stackoverflow.com/a/67676242
// Posted by Roland, modified by community. See post 'Timeline' for change history
// Retrieved 2026-11-10, License - CC BY-SA 4.0

import { fileURLToPath, URL } from "url";

import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
  },
});
