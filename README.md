E-Commerce Shop Platform — Full-Stack Blazor Server Application

A feature-rich E-Commerce Web Application built with Blazor Server and .NET 9. Solves Blazor's inherent DbContext lifetime challenges using IDbContextFactory to deliver isolated, thread-safe, and highly performant database operations.

🛠 Tech Stack

Framework: Blazor Server (.NET 9 C#)

UI & State: Reactive Blazor Component Architecture, Scoped Shopping Cart State Management

Database & Persistence: Entity Framework Core 9, MS SQL Server, IDbContextFactory pattern

Data Integrity: Explicit EF Core Database Transactions for Checkout operations

DevOps: Multi-container deployment using Docker Compose

✨ Key Features & Technical Highlights

🛍 Dynamic Product Catalog & Filtering: Real-time search, category filtering, and instant price updates without page reloads.

⚡ Blazor Scoped Concurrency Handling: Implemented IDbContextFactory.CreateDbContextAsync() to prevent DbContext concurrency conflicts across SignalR circuits.

💳 Transactional Checkout Engine: Atomic checkout operations that verify user balances, deduct inventory stock levels safely, and record orders within a single transaction.

📦 Dockerized Infrastructure: Fully reproducible setup bundling the Blazor App and MS SQL Server in isolated containers.

📐 Architecture Diagram

🚀 Getting Started (Docker Compose)

The entire application stack (Blazor Server + MS SQL Server) can be spun up in a single command.

Clone the repository:

git clone https://github.com/Denchik23083/Shop.git
cd Shop


Launch with Docker Compose:

docker-compose up -d


Open the Application:

Navigate to http://localhost:5000 in your web browser.

👤 Author

Denys Kudriavov
