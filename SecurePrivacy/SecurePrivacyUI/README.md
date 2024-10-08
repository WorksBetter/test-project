# SecurePrivacyUI

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 18.2.7.

## Installation

While on `test_project` folder, execute below commands:

`cd SecurePrivacy/SecurePrivacyUI/`

Run `npm install` to install all the relevant node packages.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code Explanation

SecurePrivacyUI is a user interface application built with Angular that provides a robust user management system, integrated with NgRx for state management. It allows users to create, update, and delete user profiles, while maintaining application-wide state using the NgRx Store. This app communicates with a backend API to persist user data.

## Key Features

- **User Management**: Create, update, and delete users with basic information (name, email, and consent status).
- **State Management**: Utilizes NgRx Store for managing the application state, with actions and reducers for loading, creating, updating, and deleting users.
- **Asynchronous Operations**: Uses NgRx Effects to handle asynchronous operations, such as fetching user data from an API or sending user data to the backend.
- **Routing**: Includes Angular Router for navigation between user creation, editing, and list views.
- **DevTools Support**: Integrated with NgRx Store DevTools for debugging the application state.

## Application Structure

### Core Components

- **UserListComponent**: Displays a list of all users retrieved from the store. Provides options to edit or delete users.
- **UserFormComponent**: A form component for creating a new user or editing an existing one. Depending on the mode, it dispatches actions to either create or update a user.

### State Management

- **NgRx Store**: The app's state is centralized in the NgRx Store. This includes the user state (list of users, loading, and error).
- **NgRx Actions**: Actions represent the different types of changes that can be made to the state, such as loading users, creating, updating, and deleting them.
- **NgRx Effects**: Handles side effects such as API calls to fetch or modify user data in the backend.
- **NgRx Reducer**: Defines how the state transitions between actions, updating the user list, handling loading states, and errors.

### Services

- **UserService**: Provides the HTTP logic for interacting with the backend API. It performs CRUD operations (Create, Read, Update, Delete) on user data.

## How it Works

1. **Loading Users**: When the user list component initializes, it dispatches the `loadUsers` action. The corresponding effect listens for this action, makes an API call to retrieve the users, and dispatches `loadUsersSuccess` or `loadUsersFailure` based on the result.
2. **Creating/Updating Users**: The user form component handles both creating and updating users. Upon form submission, it dispatches either the `createUser` or `updateUser` action depending on whether a user is being edited or created.
3. **Deleting Users**: The user list provides an option to delete a user. When the delete button is clicked, the `deleteUser` action is dispatched, triggering an API call to remove the user from the backend and updating the state on success.

