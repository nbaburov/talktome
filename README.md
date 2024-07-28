# TalkToMe - A Social Platform Remake
![Logo](https://github.com/user-attachments/assets/e4c64e44-5a52-4b49-ac14-99f3e07b9a67)

Welcome to the TalkToMe project! This repository showcases a professional, feature-rich social platform inspired by Twitter. It demonstrates the application of SOLID principles in C# and object-oriented design, with a comprehensive focus on both user interaction through a web application and administrative control via a Windows Forms application.

## Table of Contents

1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Architecture and Design](#architecture-and-design)
4. [Screenshots and Diagrams](#screenshots-and-diagrams)
5. [Getting Started](#getting-started)
6. [Usage](#usage)
7. [Contributing](#contributing)
8. [License](#license)

## Project Overview

- **Project Plan**: [File]([https://i530788.luna.fhict.nl/](https://nbaburov.notion.site/Project-Plan-732637bd90a94150a1662be638237721?pvs=74))

### Project Name: TalkToMe

TalkToMe is a dynamic social platform designed to facilitate community interaction and engagement. Users can share their thoughts, insights, and experiences through text, images, and videos. The platform is categorized to streamline content discovery and foster targeted discussions.

### Application Overview

- **Tweets**: Post messages with a 256-character limit, enriched with multimedia content.
- **Categories**: Organized content into various categories such as News, Technology, Lifestyle, Entertainment, and Education.
- **Comments and Likes**: Engage with posts through comments and likes.
- **Administrative Control**: A Windows Forms application for content moderation and user management.

## Features

- **Ideation Document**: [File]([https://i530788.luna.fhict.nl/](https://nbaburov.notion.site/Ideation-Document-ee79cab293794befa53e475b85680081?pvs=74))

### User Features

- **Account Management**: Register, login, and manage user profiles.
- **Post Creation**: Create posts with text, images, or videos.
- **Categorized Content**: Browse and post in specific categories.
- **Interaction**: Like and comment on posts.
- **Search**: Find posts and profiles using keywords.
- **Flag Content**: Report offensive content for review.

### Administrative Features

- **Dashboard**: Overview of platform activity including user registrations and flagged content.
- **User Management**: Manage user accounts, including suspensions and bans.
- **Content Moderation**: Review, flag, and remove inappropriate posts and comments.
- **Category Management**: Add, edit, or remove content categories.

## Architecture and Design

- **URS & Test Plan & Test Report**: [File]([https://i530788.luna.fhict.nl/](https://nbaburov.notion.site/User-Requirements-Specification-URS-Document-Test-Plan-85e757cede2e4483b8059a48b87864d6?pvs=74))

### System Architecture

The application follows a three-layer architecture:

1. **Presentation Layer**: ASP.NET for the web application, Windows Forms for the admin application.
2. **Business Logic Layer**: Implements the core functionality and business rules.
3. **Data Layer**: Microsoft SQL Server for data management.

### Design Principles

- **SOLID Principles**: Ensuring a robust, scalable, and maintainable codebase.
- **Object-Oriented Design**: Facilitating modularity and reusability.

## Screenshots and Diagrams

### Database Design
![6_DatabaseDiagram](https://github.com/user-attachments/assets/023f53db-b0ac-47f2-ac8e-2223205ee803)

### UML Class Diagram
![UMLClassDiagram](https://github.com/user-attachments/assets/3f6d1cdd-1783-465a-a697-577ede790b00)

### Application Wireframes
![WireframeWebsiteTalkToMe](https://github.com/user-attachments/assets/0e8822b7-665f-4be2-a356-5eb01e9e72df)

### Sitemap
![Untitled](https://github.com/user-attachments/assets/eb3fcb43-3d72-43cd-b4c6-2488298b3351)

### App Showcase
#### Web Application
![FireShot_Capture_013_-__-_localhost](https://github.com/user-attachments/assets/63ae7620-19ba-4c40-8f90-c35fffa47c36)
![FireShot_Capture_014_-__-_localhost](https://github.com/user-attachments/assets/34f93dfd-e0ce-4191-9dc0-58b2ac3efbda)
![FireShot_Capture_012_-_TalkToMe_-_localhost](https://github.com/user-attachments/assets/87365c39-56f8-42c6-acd0-4f4b19af169c)
![FireShot_Capture_015_-__-_localhost](https://github.com/user-attachments/assets/a5c01470-07dd-4e96-a0f4-2cd5f1093160)
![FireShot_Capture_016_-__-_localhost](https://github.com/user-attachments/assets/26b03701-ad60-4af5-aa83-ef82fbca88bc)
![FireShot_Capture_017_-_Category_-_localhost](https://github.com/user-attachments/assets/658af747-f9b9-49e0-9f2a-112067365c98)
![FireShot_Capture_018_-__-_localhost](https://github.com/user-attachments/assets/439a8d93-f5b3-4db8-9a03-43a860a290ea)
![FireShot_Capture_019_-_Edit_Profile_-_localhost](https://github.com/user-attachments/assets/eab10657-9ea4-44d6-8a63-7584a5eb1d37)

#### WinForms Application
![Screenshot_2024-06-02_192442](https://github.com/user-attachments/assets/4ab2d195-2eb9-48e2-8d91-e5d0ea340d4b)
![Screenshot_2024-06-02_192528](https://github.com/user-attachments/assets/4b95b66f-4f6b-4673-ab4c-cb5163154b4c)
![Screenshot_2024-06-02_192540](https://github.com/user-attachments/assets/f7e245a4-2637-47ab-8215-428ad8ea9e4f)
![Screenshot_2024-06-02_192549](https://github.com/user-attachments/assets/195a5c53-33ae-419e-a46a-0ab75ed1fa69)
![Screenshot_2024-06-02_192601](https://github.com/user-attachments/assets/0df304eb-2495-4e72-962d-a40c5c9fc337)
![Screenshot_2024-06-02_192753](https://github.com/user-attachments/assets/fbd1b0a3-ac0e-4494-ada7-e725a40b0f7b)
![Screenshot_2024-06-02_192824](https://github.com/user-attachments/assets/4ea8b993-4464-4cde-91fe-4f54067a98ff)
![Screenshot_2024-06-02_193020](https://github.com/user-attachments/assets/9f129884-ffa2-469c-8dfe-91043bb48543)
![Screenshot_2024-06-02_193034](https://github.com/user-attachments/assets/de9eaf52-9acd-4ac2-a1c8-4a730b96f0bb)
![Screenshot_2024-06-02_193044](https://github.com/user-attachments/assets/8395afbb-c3d4-4d70-a7fc-d55fe15f2000)
![Screenshot_2024-06-02_193101](https://github.com/user-attachments/assets/cc0ccc54-a990-46d5-96bf-c329a6fb7446)

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server

### Installation

1. Clone the repository:
   ```bash
   git clone https://git.fhict.nl/I530788/talktome.git
   ```
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Update the database connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=talktome;User Id=talktome;Password=CHANGE_ME;TrustServerCertificate=true"
   }
   ```
5. Run the migrations to create the database schema:
   ```bash
   Update-Database
   ```

## Usage

### User Credentials

**Clients:**
- `nick@gmail.com`
- `stefi@gmail.com`
- `bart@gmail.com`
- `mike@gmail.com`

**Admins:**
- `admin@email.com`
- `mod@email.com`
- `support@email.com`

**Password for all**: `123456`

### Access the Application

- **Web Application**: [TalkToMe Website](https://i530788.luna.fhict.nl/)
- **Windows Forms Application**: Run the project in Visual Studio to access admin functionalities.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature-name`).
5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

This README is designed to impress with comprehensive documentation, demonstrating a thorough understanding of software development principles, and showcasing the full scope of the TalkToMe project. For more details, visit the project repository on [GitLab](https://git.fhict.nl/I530788/talktome).
