import axios from 'axios';
import type Book from "@/types.ts";

export default class BookService {
  API_URL = "http://localhost:5051/api";

  public async getAllBooks(): Promise<Book[]> {
    let result = await axios.get(`${this.API_URL}/books/`);
    return result.data;
  }

  public async addNewBook(book: Book) {
    let result = await axios.post(`${this.API_URL}/books/`, book);
    return result.data;
  }

  public async deleteBook(id: number) {
    let result = await axios.delete(`${this.API_URL}/books/${id}`);
        return result.data;
    }

}
