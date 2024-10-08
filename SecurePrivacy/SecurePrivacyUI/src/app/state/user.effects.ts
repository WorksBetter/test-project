import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';
import {
  loadUsers,
  loadUsersSuccess,
  loadUsersFailure,
  createUser,
  createUserSuccess,
  createUserFailure,
  updateUser,
  updateUserSuccess,
  updateUserFailure,
  deleteUser,
  deleteUserSuccess,
  deleteUserFailure,
} from './user.actions';
import { UserService } from '../services/user.service';

@Injectable()
export class UserEffects {
  loadUsers$;
  createUser$;
  updateUser$;
  deleteUser$;

  constructor(private actions$: Actions, private userService: UserService) {
    this.loadUsers$ = createEffect(() =>
      this.actions$.pipe(
        ofType(loadUsers),
        mergeMap(() =>
          this.userService.getUsers().pipe(
            map((users) => loadUsersSuccess({ users })),
            catchError((error) =>
              of(loadUsersFailure({ error: error.message }))
            )
          )
        )
      )
    );

    this.createUser$ = createEffect(() =>
      this.actions$.pipe(
        ofType(createUser),
        mergeMap(({ user }) =>
          this.userService.createUser(user).pipe(
            map((newUser) => createUserSuccess({ user: newUser })),
            catchError((error) =>
              of(createUserFailure({ error: error.message }))
            )
          )
        )
      )
    );

    this.updateUser$ = createEffect(() =>
      this.actions$.pipe(
        ofType(updateUser),
        mergeMap(({ user }) =>
          this.userService.updateUser(user).pipe(
            map((updatedUser) => updateUserSuccess({ user: updatedUser })),
            catchError((error) =>
              of(updateUserFailure({ error: error.message }))
            )
          )
        )
      )
    );

    this.deleteUser$ = createEffect(() =>
      this.actions$.pipe(
        ofType(deleteUser),
        mergeMap(({ userId }) =>
          this.userService.deleteUser(userId).pipe(
            map(() => deleteUserSuccess({ userId })),
            catchError((error) =>
              of(deleteUserFailure({ error: error.message }))
            )
          )
        )
      )
    );
  }
}
