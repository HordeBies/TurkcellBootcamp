# Kidega Book Store
Kidega is an e-commerce application built with ASP.NET Core MVC, using Entity Framework Core and Microsoft SQL Server as the backend technologies. The project uses ASP.NET Core Identity for authentication and authorization, and follows the repository pattern for data access and service for business logic. The project is structured using clean architecture, with separate projects for the web application, core, domain, and infrastructure.

[Click Here for Demo And ScreenShots](./Demo)

# Project Description
Kidega allows customers to browse and purchase books. The project is just a demonstration therefore every Customer is also considered an Admin. Customers can add products to the shopping cart, view and update the shopping cart, and complete orders. Admins have control over the entire operation, including categories, authors, books, and orders.

# Detailed Tech Stack
The project uses a variety of technologies:
- `ASP.NET Core 8 MVC`
- `Entity Framework (EF) Core`
- `Microsoft SQL`
- `ASP.NET Core Identity`

Also project uses several external technologies to enhance its functionality and user experience.

## External Technologies
Kidega uses DataTables for AJAX tables for data rendering and client side filtering, sorting and pagination with CRUD operations, Bootstrap for UI building and theming, Sweet Alert 2 for modal popup windows and toast notifications and AutoMapper for DTO - entity mappings.

## Session Management
Kidega uses session management to keep track of shopping cart. The project uses the ASP.NET Core built-in session middleware to create and manage user sessions.

## Caching
Kidega uses caching to load home page where all the books from database are shown. To achieve that the project uses the ASP.NET Core built-in in-memory caching services.

## Filter
Kidega uses exception handling filter to handle unhandled exceptions a customer can experience to provide a more user friendly experince. (We chose filter instead of a middleware is that we want to apply the filter to only customer related controllers, whereas admin controllers should throw the exception and admin should handle the error)

## Middleware
Kidega uses request tracking middleware that tracks and logs each incoming request, including the URL, HTTP method, request headers, and execution time. This can be useful for monitoring and analyzing traffic patterns.

## View Component
Kidega uses a custom view component to render shopping cart icon with total item in cart count on navbar.
