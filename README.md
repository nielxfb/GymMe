# GymMe

This README provides an overview of the project, setup instructions, and other useful information.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction

This project is an ASP.NET Web Application built using the .NET Framework 4.7.2 and Visual Studio. It serves as a template for building web applications with ASP.NET Web Forms. The project is designed to be scalable, maintainable, and easy to deploy.

## Features

- User Authentication and Authorization
- Controller-Handler-Repository Architecture
- Entity Framework for database management
- Dependency Injection
- Logging and Error Handling

## Prerequisites

Before you begin, ensure you have the following installed:

- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/vs/)
- [.NET Framework 4.7.2 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net472-developer-pack-offline-installer)

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/nielxfb/GymMe.git
   cd GymMe
   ```

2. **Open the project in Visual Studio:**
   - Launch Visual Studio.
   - Select `Open a project or solution`.
   - Navigate to the cloned repository folder and select the `.sln` file.

3. **Restore NuGet packages:**
   - In Visual Studio, go to `Tools` > `NuGet Package Manager` > `Package Manager Console`.
   - Run the following command:
     ```bash
     Update-Package -reinstall
     ```

4. **Update the database:**
   - Open `Package Manager Console` and run:
     ```bash
     Update-Database
     ```

## Running the Application

1. **Build the solution:**
   - Press `Ctrl+Shift+B` or go to `Build` > `Build Solution`.

2. **Run the application:**
   - Press `F5` or click on the `IIS Express` button.

3. **Access the application:**
   - Open your web browser and navigate to `http://localhost:port` (where `port` is the port number configured in Visual Studio).

## Project Structure

```
GymMe/
├── Controllers/        # Controllers for handling requests
├── Factories/          # Factories for instantiating objects (.cs)
├── Handlers/           # Handlers for business logic validation
├── Models/             # Data models and Entity Framework context
├── Modules/            # Utility classes used for modules
├── Properties/         # Assembly information and settings
├── Repositories/       # Repositories for DDL actions
├── Views/              # Web Forms pages (.aspx)
├── GymMe.csproj        # C# project file
├── Web.config          # Configuration settings
└── packages.config     # NuGet packages
```

## Configuration

- **Web.config:** Contains configuration settings for the application such as database connection strings, authentication settings, and more.
- **AppSettings:** Custom application settings can be added to the Web.config file under the `<appSettings>` section.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a new Pull Request.

---
