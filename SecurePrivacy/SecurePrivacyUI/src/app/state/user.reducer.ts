import { createReducer, on } from '@ngrx/store';
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
import { UserState, initialState } from './user.state';

export const userReducer = createReducer(
  initialState,
  on(loadUsers, (state) => ({
    ...state,
    loading: true,
  })),
  on(loadUsersSuccess, (state, { users }) => ({
    ...state,
    users: users,
    loading: false,
  })),
  on(loadUsersFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
  on(createUser, (state) => ({
    ...state,
    loading: true,
  })),
  on(createUserSuccess, (state, { user }) => ({
    ...state,
    users: [...state.users, user],
    loading: false,
  })),
  on(createUserFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error: error,
  })),
  on(updateUser, (state) => ({
    ...state,
    loading: true,
  })),
  on(updateUserSuccess, (state, { user }) => ({
    ...state,
    users: state.users.map((u) => (u.id === user.id ? user : u)),
    loading: false,
  })),
  on(updateUserFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  })),
  on(deleteUser, (state) => ({
    ...state,
    loading: true,
  })),
  on(deleteUserSuccess, (state, { userId }) => ({
    ...state,
    users: state.users.filter((u) => u.id !== userId),
    loading: false,
  })),
  on(deleteUserFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
