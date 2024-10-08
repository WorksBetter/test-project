import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { User } from '../../models/user.model';
import { UserState } from '../../state/user.state';
import { createUser, loadUsers, updateUser } from '../../state/user.actions';
import { CommonModule } from '@angular/common';
import { take } from 'rxjs/operators'; // Import take operator

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css'],
})
export class UserFormComponent implements OnInit {
  user: User = new User(); // Initialize an empty user
  isEditMode: boolean = false;

  constructor(
    private store: Store<{ user: UserState }>,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Check query params to determine if editing an existing user
    this.route.queryParams.subscribe((params) => {
      const userId = params['id'];
      if (userId) {
        this.isEditMode = true;
        // Fetch the user from the state for editing
        this.store
          .select((state) => state.user.users)
          .pipe(take(1)) // Ensure the subscription completes after the first value
          .subscribe((users) => {
            const existingUser = users.find((u) => u.id === userId);
            if (existingUser) {
              this.user = { ...existingUser }; // Clone the user object once
            }
          });
      }
    });
  }

  onSubmit(): void {
    if (this.isEditMode) {
      console.log('Updating user', this.user);
      // Dispatch update user action
      this.store.dispatch(updateUser({ user: this.user }));
    } else {
      console.log('Creating user', this.user);
      // Dispatch create user action
      this.store.dispatch(createUser({ user: this.user }));
    }
    // Dispatch loadUsers to refresh the user list in the store
    this.store.dispatch(loadUsers());
    this.router.navigate(['/user-list']); // Redirect to the user list
  }
}
