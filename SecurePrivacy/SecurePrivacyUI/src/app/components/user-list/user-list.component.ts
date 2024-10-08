import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { User } from '../../models/user.model';
import { loadUsers, deleteUser } from '../../state/user.actions';
import { UserState } from '../../state/user.state';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule], // CommonModule is needed for *ngFor and *ngIf
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users$: Observable<User[]>; // Observable of users from the store

  constructor(
    private store: Store<{ user: UserState }>,
    private router: Router
  ) {
    // Select the users from the store
    this.users$ = this.store.select((state) => state.user.users);
  }

  ngOnInit(): void {
    // Dispatch the action to load users
    this.store.dispatch(loadUsers());
  }

  navigateToCreateUser(): void {
    this.router.navigate(['/create-user']);
  }

  // Method to delete a user
  deleteUser(userId: string): void {
    this.store.dispatch(deleteUser({ userId })); // Dispatch delete user action
  }

  // Navigate to edit user form
  editUser(user: User): void {
    this.router.navigate(['/create-user'], { queryParams: { id: user.id } });
  }
}
