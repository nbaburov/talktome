# Security

## Status

TalkToMe is an archived university project. It is not deployed anywhere and receives no feature work. It runs on .NET 8, whose long-term support ends in November 2026, and reaches SQL Server through `System.Data.SqlClient`, which Microsoft has deprecated in favour of `Microsoft.Data.SqlClient`.

The code also carries known weaknesses from the original project, listed under Known issues in the [README](README.md). The most important: the website identifies a signed-in user by a plain `UserEmail` cookie that nothing signs or checks, so anyone can sign in as any registered user by setting it.

Treat it as a local demo. Do not expose it to the internet.

## Secrets

No credentials are committed. Both apps read `ConnectionStrings:DefaultConnection` from `appsettings.json`, which ships with a placeholder, and the website also accepts it from the environment.

## Reporting a vulnerability

If you find a problem in the code that isn't already listed as a known issue, please report it privately through [GitHub's private vulnerability reporting](https://github.com/nbaburov/talktome/security/advisories/new) rather than opening a public issue. Expect an acknowledgement within a week. Advisories that only restate the known issues or the end-of-support status above will be closed with a pointer to this file.
