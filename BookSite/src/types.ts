export interface Book
{
  id: number;
  title: string;
  author: string;
  done: boolean;
  createdOn: string;
  updatedOn: string;
}

export type BookFilter = "all"|"todo"|"done";
