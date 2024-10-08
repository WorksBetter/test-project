# SecurePrivacy Project

The SecurePrivacy project is a full-stack application built using Angular for the frontend and .NET Core for the backend. It integrates MongoDB for data management and considers GDPR compliance in both the backend and frontend implementations.

## Project Structure

- **SecurePrivacyUI**: This is the Angular-based frontend.
    - **How to run**:
      ```bash
      cd SecurePrivacyUI
      ng serve
      ```
    - This part of the project implements a simple UI to interact with the backend API, performing CRUD operations on a MongoDB database. It also includes features for GDPR compliance.

- **SecurePrivacyAPI**: This is the .NET Core-based API backend.
    - **How to run**:
      ```bash
      cd SecurePrivacyAPI
      dotnet run
      ```
    - This backend provides API endpoints for CRUD operations, and integrates with MongoDB to store and retrieve data. It also ensures GDPR compliance with the necessary data privacy measures.

## Functionality

The SecurePrivacy project is built with the following features:
- **CRUD Operations**: Implements basic Create and Read functionalities for entities such as User or Product.
- **MongoDB Integration**: Uses MongoDB for data storage with compound indexes for efficient querying.
- **GDPR Compliance**: Incorporates basic GDPR requirements at both the code and user-interface levels.

## Testing

Ensure to have MongoDB running locally or remotely to test the complete functionality of the project.