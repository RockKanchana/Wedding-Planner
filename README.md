# Wedding Planner 🎉

**Wedding Planner** is an ASP.NET Core MVC application designed to help couples manage all aspects of their wedding — including guest lists, vendor coordination, event schedules, and more — from a single web platform.

## Features

- 👰 **Guest Management**: Add, edit, delete, and view wedding guests with table assignment.
- 🗓️ **Wedding Timeline**: Plan and visualize the entire wedding day with categorized event status (Planned, Confirmed, Completed, Cancelled).
- 🛍️ **Vendor Management**: Organize and manage vendors with filters by category and status.
- 💌 **Modern UI**: Clean, intuitive design using Razor views and Bootstrap styling.

## Tech Stack

- **Framework**: ASP.NET Core MVC
- **Frontend**: Razor Views, Bootstrap, JavaScript
- **Backend**: C#, Entity Framework Core
- **Database**: SQL Server (configured via `appsettings.json`)
- **Project Structure**:
  - `Controllers/` - MVC Controllers
  - `Models/` - Entity models and DTOs
  - `Services/` - Application logic
  - `Views/` - Razor views for UI
  - `wwwroot/` - Static assets

## Getting Started

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- Visual Studio 2022 (or later) or Visual Studio Code

### Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/Wedding-Planner.git
   cd Wedding-Planner

**Run the Application**
dotnet ef database update
dotnet run

