# SecurePrivacy API with GDPR Compliance

This API is designed to manage users in a MongoDB database while ensuring compliance with GDPR (General Data Protection Regulation). It allows for typical CRUD (Create, Read, Update, Delete) operations with a specific focus on user data protection, logical deletion, and data access.

## Features

### 1. **Read Users**  
- **Endpoint**: `GET /api/users`  
- **Description**: Retrieves all users who are not logically deleted. Users who have been logically deleted (i.e., `DeletedAt` field is set) will not be returned in the response.

### 2. **Create User**  
- **Endpoint**: `POST /api/users`  
- **Description**: Adds a new user to the database.

### 3. **GDPR - Delete User**  
- **Endpoint**: `DELETE /api/users/{id}`  
- **Description**: Deletes a user based on GDPR consent:
  - If the user has given consent (`ConsentGiven` is true), a **logical deletion** is performed by setting the `DeletedAt` field.
  - If the user has not given consent, a **physical deletion** is performed (user is permanently removed from the database).

### 4. **GDPR - Access and Portability**  
- **Endpoint**: `GET /api/users/{id}/data`  
- **Description**: Retrieves all data related to a user, providing it in a portable JSON format. This satisfies GDPR's **Right to Access**. The time of access is recorded in the `DataAccessedAt` field.

### 5. **GDPR - Update User (Rectification)**  
- **Endpoint**: `PUT /api/users/{id}`  
- **Description**: Updates user details. If the user's consent status changes from `true` to `false`, the user will be physically deleted if they were previously logically deleted. If consent changes from `false` to `true`, a logically deleted user will be restored (the `DeletedAt` field is cleared).

## GDPR Compliance

This API incorporates several GDPR compliance features:
- **Right to Access and Portability**: Users can retrieve all of their personal data in a portable format (`/api/users/{id}/data`).
- **Right to Rectification**: Users can update their personal information (`PUT /api/users/{id}`).
- **Right to be Forgotten (Erasure)**: Users can request their data to be deleted:
  - Logical deletion (marking data as deleted but not physically removing it).
  - Physical deletion if GDPR consent is not given or later revoked.
  
## Installation and Setup

### Prerequisites

- [.NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MongoDB](https://www.mongodb.com/try/download/community)

### Steps to Run

1. **Clone the Repository**
2. **Configure MongoDB Connection**

   In the `appsettings.json`, update the MongoDB connection string and database name. 

    ```json
    {
       "MongoDB": {
          "ConnectionString": "mongodb://localhost:27017",
          "DatabaseName": "SecurePrivacyDb",
          "CollectionName": "Users"
       }
    }
4. **Install Dependencies**
   In the project directory, run the following command to install necessary NuGet packages:

   `dotnet restore`
5. **Run the Application**

   `dotnet run`
   



