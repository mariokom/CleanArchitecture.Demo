# Unic.Demo

<br>

## How to use
### 1. Run the Unic.Demo project
### 2. Go to the swagger UI
### 3. Seed the database using the migrations controller
### 4. Generate an JWT using the authentication controller
    - For students: Use john, jane, bob, alice 
    - For lecturers: use eric, kevin, mark
    - For academic periods: use 'Fall 2023' or 'Spring 2024'
### 5. Use the generated JWT to 'login' in the swagger UI
### 6. Start calling the APIs

<br/>

## Implementation details
### 1. Solution structure: Clean Arcitecture
    - Domain layer
    - Core layer
    - Infrastructure layer
### 2. Design patterns
    - Mediator for CQRS and module decoupling
    - Repository-like pattern for data access encapsulation
### 3. API
    - Restful API
    - Swagger documentation - Swashbuckle
### 4. Database
    - SQL server express
    - Automatic migration using EF migration feature
    - Datbase Schema:
### 5. Authentication/authorization
    - Implemented a dummy JWT authentication mechanism (did not digitally signed the token)
    - Users are preloaded using the 'seeding' endpoint.
    - Using the authorization endpoint a user can generate a JWT token.
    - The token should be used in the HTTP request to authenticate and authorize the request.
