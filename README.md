# 📚 TechdioApp

**TechdioApp** is a powerful, cross-platform learning application built using **.NET MAUI**, offering students and tutors a seamless experience to connect, learn, and grow.

It’s not just an app — it’s a modern learning hub packed with features, elegant UI, and solid architecture.

---

## ✨ Key Features

✅ **Firebase Authentication**\
Sign up or sign in securely with Firebase.

✅ **Interactive Dashboard**\
A central place to explore courses, tutors, and user tools.

✅ **Course Browsing**\
Explore detailed course catalogs with titles, categories, modules, tutor info, and pricing.

✅ **Course Detail View**\
Access full details of each course before joining or enrolling.

✅ **Tutor Profiles**\
Browse and get to know the tutors available in the system.

✅ **Profile Management**\
View and edit user profile info from a dedicated screen.

✅ **Custom Flyout Navigation**\
Smooth .NET MAUI Shell navigation with a custom FlyoutHeader.

✅ **Modern UI & Animations**\
Includes animated modals like `ComingSoonPopup`, custom forms, and splash screen.

✅ **Forms to Interact**

- Hire a tutor
- Join a waitlist
- Request a custom course

✅ **Offline Data Support**\
Lightweight **LiteDB** integration for embedded local storage.

✅ **Raw File Support**\
Access and use raw text/data assets bundled in the app.

---

## 🧠 Tech Stack

- **.NET MAUI** – Cross-platform UI
- **C# & XAML** – Application logic and UI
- **MVVM Architecture** – Using `CommunityToolkit.Mvvm`
- **Firebase** – For Auth and Data storage
- **LiteDB** – Embedded NoSQL database

---

## 🛠️ Getting Started

### 📦 Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (latest supported for .NET MAUI)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) with MAUI workload

### 🔧 Setup Instructions

```bash
git clone https://github.com/abm1119/TechdioApp.git
cd TechdioApp
```

Open the solution file in Visual Studio:

```
TechdioApp/TechdioApp.sln
```

Restore dependencies:

```bash
dotnet restore
```

### 🔑 Configure Firebase

Edit `MauiProgram.cs` to insert your Firebase credentials:

- API Key
- Auth Domain
- Database URL

Example:

```csharp
options.ApiKey = "YOUR_API_KEY";
options.AuthDomain = "your-app.firebaseapp.com";
options.DatabaseUrl = "https://your-app.firebaseio.com";
```

### ▶️ Run the App

Choose a platform (Android, iOS, Windows) and start debugging with a device/emulator.

---

## 🗂️ Project Structure

```text
TechdioApp/
├── App.xaml / App.xaml.cs               → Global styling and lifecycle
├── AppShell.xaml / AppShell.xaml.cs     → Shell routing & Flyout menu
├── MauiProgram.cs                       → DI, services, Firebase config
├── TechdioApp.sln / TechdioApp.csproj   → Project and solution files
├── Platforms/                           → Platform-specific logic
│   └── Android/, iOS/, MacCatalyst/, Windows/, Tizen/
├── Resources/                           → Fonts, Images, Splash, Raw
│   └── Raw/ → AboutAssets.txt
├── Controls/                            → FlyoutHeader UI control
├── Dashboard/
│   ├── Pages/                           → Home, Courses, Profile, Tutors
│   ├── Models/                          → Course, Tutor, User
│   └── ViewModels/                      → CoursePageVM, LoadingVM
├── Pages/                               → Auth & Utility Pages
│   └── SignInView, SignUpView, About, Forms
├── Services/                            → Firebase integration logic
│   └── FirebaseAuthService, FirebaseService
├── Models/                              → MenuItemModel, UserProfile
└── Properties/                          → launchSettings.json
```

---

## 🧱 MVVM Architecture

The app uses **Model-View-ViewModel (MVVM)**:

```
View         ←→ ViewModel ←→ Services
(XAML UI)        (Logic)       (Data/Auth Layer)
```

📌 *[You can add a diagram here if needed to visualize MVVM + Shell navigation]*

---

## 📱 Download the APK

[**⬇️ Download APK**](insert_apk_link_here)\
*Try it instantly on your Android device!*

---


## 🖼️ Screenshots
![Splash Screen](./AppScreens/Splash.jpg) ![Info Screen](./AppScreens/Info.jpg) ![Sign-Up Screen](./AppScreens/SignUp.jpg)
![Info Screen](./AppScreens/Info.jpg)
![Sign-Up Screen](./AppScreens/SignUp.jpg)
![Sign-In Screen](./AppScreens/Signin.jpg)
![Home Screen](./AppScreens/Home.jpg)
![Flyout Sidebar](./AppScreens/Flyout.jpg)
![Courses Screen](./AppScreens/Courses.jpg)
![Tutors Screen](./AppScreens/Tutors.jpg)
![Profile Screen](./AppScreens/Profile.jpg)
![Edit Profile Screen](./AppScreens/Edit_Profile.jpg)
![Custom Courses Form](./AppScreens/Custom_Course.jpg)
![Join Waitlist Form](./AppScreens/Join_Waitlist.jpg)
![Oppertunities Pop-Up](./AppScreens/Pop-up.jpg)

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you'd like to change or improve.

---

## 📄 License

Licensed under the **Apache License 2.0**.\
See [LICENSE.txt](./LICENSE.txt) for details.

---

Made with ❤️ by Abdul Basit Memon ([@abm1119](https://github.com/abm1119))
