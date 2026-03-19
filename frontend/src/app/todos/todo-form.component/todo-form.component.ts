import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CreateTodoDto } from '../todo.model';

@Component({
  selector: 'app-todo-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './todo-form.component.html'
})
export class TodoFormComponent {
  @Output() todoCreated = new EventEmitter<CreateTodoDto>();

  todoForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.todoForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(200)]],
      description: ['', Validators.maxLength(1000)],
      dueDate: [null]
    });
  }

  onSubmit(): void {
    if (this.todoForm.invalid) return;
    this.todoCreated.emit(this.todoForm.value);
    this.todoForm.reset();
  }
}
