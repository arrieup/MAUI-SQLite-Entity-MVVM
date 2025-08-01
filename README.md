# 🔹 MAUI SQLite Entity MVVM App

This project is a cross-platform application template built using [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui), designed to demonstrate clean integration between a local **SQLite database**, the **MVVM architectural pattern**, and **Entity Framework Core**. The app is lightweight, fully offline, and ideal for small to mid-scale data-driven mobile solutions.

---

## 🚀 Purpose

The app was developed as a template for apps that needs to:

* Store and manage local data using **SQLite** via **Entity Framework Core**
* Apply the **MVVM** pattern for maintainable and testable UI logic
* Create a seamless **cross-platform experience** with MAUI (Android, iOS, Windows)

---

## 📏 Key Features

* 🔄 Full **CRUD** support (Create, Read, Update, Delete)
* ✅ **Local SQLite** storage
* 🌐 **Cross-platform UI** with .NET MAUI
* ⚖️ **MVVM** architecture: Views, ViewModels, and Commands
* 🛠️ Dependency Injection for data services

---

## 🏗️ Architecture Overview

```
📁 App
 ├ 📁 Platforms      → Target specific docs (manifests, start point...)
 ├ 📁 Resources      → Files that will be used by the app (images, fonts)
 ├ 📁 Services       → Services used in the App or in the Core
 ├ 📁 Views          → XAML UI pages and controls
 ├ 📄 App            → App startup
 ├ 📄 AppShell       → Navigation
 └ 📄 MauiProgram    → App builder, DI configuration
 
 
 📁 Core
 ├ 📁 Models         → Entity classes (e.g., Note.cs, TaskItem.cs)
 ├ 📁 Repositories   → Repository layer for data access
 ├ 📁 Services       → Services (DB, Navigation)
 ├ 📁 ViewModels     → UI logic and data binding

 📁 Tests
```


## 🛠️ How to Run It

### Prerequisites

* [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* Visual Studio 2022/2025 with **MAUI** installed

### Launching the App

1. Clone the repository:

   ```bash
   git clone https://github.com/arrieup/MAUI-SQLite-Entity-MVVM.git
   cd MAUI-SQLite-Entity-MVVM
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Run on Windows/Android/iOS depending on your setup

---

## 📊 Data Persistence

The app uses **SQLite** via **Entity Framework Core**:

* Database file is created locally on the device (`.db` file)
* Entities are mapped via `DbSet<T>` in the `AppDbContext`
* Migrations can be added if needed using EF tools

---

## 👤 Author

**Pablo Arrieumerlou**
Apprentice .NET developer @ Pixience
Built with a passion for clean architecture and maintainable mobile solutions.

[LinkedIn](https://www.linkedin.com/in/pablo-arrieumerlou/) • [GitHub](https://github.com/arrieup)

---

## 📄 License

GNU Affero General Public License v3.0. See the [LICENSE](LICENSE.txt) file for details.


