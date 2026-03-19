export interface Todo {
    id: number;
    title: string;
    description: string;
    isCompleted: boolean;
    dueDate: string | null;
    createdAt: string;
    updatedAt: string;
  }
  
  export interface CreateTodoDto {
    title: string;
    description: string;
    dueDate: string | null;
  }
  
  export interface UpdateTodoDto {
    title: string;
    description: string;
    isCompleted: boolean;
    dueDate: string | null;
  }
  