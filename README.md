# Taalam E-learning platform
## Technologies Used:

-  Backend: .NET Core (Three-Tier Architecture), ASP.NET Identity for authentication and authorization, Entity Framework for database connection, and Paymob integration for secure payment processing.
-  Frontend: Angular for a responsive and dynamic user interface.

## key features
- User Wishlist: Add courses to your wishlist for future purchase.
- Secure Payments: Buy courses safely with integrated Paymob payment gateway.
- Admin Dashboard: Manage courses, users, and content efficiently through a comprehensive admin panel.
- Progress Tracking: Monitor your progress within each course, ensuring a structured learning experience.
- Certification: Receive a certificate upon course completion to validate your achievements

## Architectural Highlights:
- Three-Tier Architecture: The application follows a modular design with clear separation of concerns (Presentation Layer, Business Logic Layer, and Data Access Layer).
- Scalable & Maintainable: Built using industry-standard practices for future growth and ease of maintenance.

### starting the backend
#### Prerequisites:
- Install .NET SDK (.NET 7).
- Install an SQL Server instance (if using a local database).
- Set up environment variables for sensitive data like connection strings and Paymob keys.

#### Steps:
- clone the project :
```
$ git clone git@github.com:mohammadyasser99/taalam.git
cd taalam/backend
```
- and Navigate to the backend folder :
```
cd backend
```
- Restore NuGet packages:
```
dotnet restore
```
- Apply database migrations :
```
dotnet ef database update
```
- Run the application:
```
dotnet run
```



