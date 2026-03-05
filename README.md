# 🎵 MusicStore

A desktop music store application built with **Avalonia UI** and the **MVVM** pattern, inspired by WPF-style development. This project was developed as a learning exercise following the official [Avalonia MusicStore tutorial](https://docs.avaloniaui.net/docs/tutorials/music-store-app/).

---

## ✨ Features

- 🔍 Search and browse music albums
- 🖼️ Display album cover art and artist information
- 🪟 Multi-window architecture with inter-window messaging
- 🔔 Toast notifications (Avalonia Notifications)
- 🏗️ Clean MVVM separation (Models / Views / ViewModels)

---

## 🛠️ Tech Stack

| Technology | Role |
|---|---|
| C# / .NET | Language & runtime |
| Avalonia UI | Cross-platform UI framework |
| CommunityToolkit.Mvvm | MVVM helpers (RelayCommand, ObservableObject, IMessenger) |
| Visual Studio 2022 | IDE |

---

## 📁 Project Structure
MusicStore/
├── Assets/ # Icons and static resources
├── Models/ # Data models (Album record)
├── ViewModels/ # MVVM ViewModels
├── Views/ # Avalonia AXAML views & windows
├── Messages/ # IMessenger message types
├── App.axaml
└── Program.cs

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or JetBrains Rider

### Run the app

```bash
git clone https://github.com/Mat8313/MusicStore.git
cd MusicStore
dotnet run

