import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoService } from '../todo.service';
import { Todo, CreateTodoDto } from '../todo.model';
import { NavbarComponent } from '../../shared/navbar/navbar.component';
import { TodoFormComponent } from '../todo-form.component/todo-form.component';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, TodoFormComponent, NavbarComponent],
  templateUrl: './todo-list.component.html'
})
export class TodoListComponent implements OnInit {
  todos: Todo[] = [];
  isLoading = false;
  errorMessage = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.isLoading = true;
    this.todoService.getAll().subscribe({
      next: (todos) => {
        this.todos = todos;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Failed to load todos.';
        this.isLoading = false;
      }
    });
  }

  onTodoCreated(dto: CreateTodoDto): void {
    this.todoService.create(dto).subscribe({
      next: (newTodo) => {
        this.todos.unshift(newTodo); // add to top of list
      },
      error: () => {
        this.errorMessage = 'Failed to create todo.';
      }
    });
  }

  toggleComplete(todo: Todo): void {
    const dto = {
      title: todo.title,
      description: todo.description,
      isCompleted: !todo.isCompleted,
      dueDate: todo.dueDate
    };

    this.todoService.update(todo.id, dto).subscribe({
      next: () => {
        todo.isCompleted = !todo.isCompleted;
      },
      error: () => {
        this.errorMessage = 'Failed to update todo.';
      }
    });
  }

  deleteTodo(id: number): void {
    this.todoService.delete(id).subscribe({
      next: () => {
        this.todos = this.todos.filter(t => t.id !== id);
      },
      error: () => {
        this.errorMessage = 'Failed to delete todo.';
      }
    });
  }
}
