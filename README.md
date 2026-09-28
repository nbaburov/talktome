# TalkToMe

A Twitter-style social platform in C#/.NET 8: an ASP.NET Core Razor Pages site for users and a Windows Forms app for moderators, sharing one layered class library over SQL Server.

Fontys University of Applied Sciences coursework (2024). Project documents: [plan](https://nbaburov.notion.site/Project-Plan-732637bd90a94150a1662be638237721?pvs=74), [ideation](https://nbaburov.notion.site/Ideation-Document-ee79cab293794befa53e475b85680081?pvs=74), [requirements, test plan and report](https://nbaburov.notion.site/User-Requirements-Specification-URS-Document-Test-Plan-85e757cede2e4483b8059a48b87864d6?pvs=74).

> Shared as a reference. Not actively maintained for external contributions.

## What it does

| App | Features |
|---|---|
| Web (`talktomeweb`) | register and log in, profile with photo, posts with an image in categories, likes, comments, search for posts and users, flag posts, comments and users for review |
| Admin (`talktomeadmin`, Windows) | review flagged posts, comments and users; remove posts and comments; ban and unban users; manage admin accounts and their permissions |

Passwords are stored as salted PBKDF2 hashes (`Rfc2898DeriveBytes`, 10,000 iterations, SHA-1 default). That was fine for coursework; current OWASP guidance calls for SHA-256 and far more iterations.

## Quickstart

Requires the .NET 8 SDK and a SQL Server instance. The admin app builds on Windows only.

```bash
git clone https://github.com/nixxxo/talktome.git
cd talktome
export ConnectionStrings__DefaultConnection="Server=localhost;Database=talktome;User Id=<user>;Password=<password>;TrustServerCertificate=true"
dotnet run --project talktomeweb
dotnet test talktometest
```

Tables are created on first start. There is no seed data: register users through the site. Admins are created from the admin app by an existing admin, so insert the first one directly in the database.

## Architecture

```
talktomeweb    (Razor Pages)      talktomeadmin   (Windows Forms)
        \                              /
         SharedLibrary: Services -> Repositories -> Data (ADO.NET, System.Data.SqlClient)
                                        |
                                   SQL Server
```

| Project | Responsibility |
|---|---|
| `SharedLibrary` | models, services with business rules, repositories, data classes with hand-written SQL, password hashing |
| `talktomeweb` | user-facing pages; uploads go to `wwwroot/images/users` and `wwwroot/images/posts` |
| `talktomeadmin` | moderation dashboard |
| `talktometest` | MSTest + Moq unit tests for the auth and user services |

Database design and class diagram:

![Database diagram](https://github.com/user-attachments/assets/023f53db-b0ac-47f2-ac8e-2223205ee803)
![UML class diagram](https://github.com/user-attachments/assets/3f6d1cdd-1783-465a-a697-577ede790b00)

## Configuration

Both apps read `ConnectionStrings:DefaultConnection` from their `appsettings.json`, which ships with a placeholder. The web app also accepts the `ConnectionStrings__DefaultConnection` environment variable (standard ASP.NET Core configuration); the admin app reads only its `appsettings.json`, so set it there locally and do not commit it.

## License

MIT: see [LICENSE](LICENSE).
