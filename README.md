# Teams API
<sub>C# · ASP.NET CORE · POSTGRESQL · ENTITY FRAMEWORK CORE</sub>

A compact backend project modelling racing teams, drivers and media records. Follow an HTTP request through a controller, repository and unit of work into a relational database.

[Request walkthrough](docs/api-walkthrough.md) · [HTTP examples](requests.http) · [Database model](Data/ApiDbContext.cs)

## What to inspect

| Area | Start here |
| --- | --- |
| HTTP contract | [TeamsController](Controllers/TeamsController.cs) — list, look up and create teams |
| Relationships | [ApiDbContext](Data/ApiDbContext.cs) — one-to-many teams/drivers and one-to-one driver/media |
| Persistence | [UnitOfWork](Services/UnitOfWork.cs) and [GenericRepository](Services/GenericRepository.cs) |
| Schema history | [Migrations](Migrations/) — PostgreSQL integer identity keys |
| Build automation | [.NET workflow](.github/workflows/build.yml) |

The [walkthrough](docs/api-walkthrough.md) includes a data diagram and explains the current implementation choices and their tradeoffs.

## Run locally

The project targets .NET 6 and EF Core 7. Use compatible development tooling and a local PostgreSQL database. Set `ConnectionStrings__SampleDbConnection` through your shell or development secret store.

```bash
dotnet restore
dotnet build
# With a compatible dotnet-ef tool installed:
dotnet ef database update
dotnet run
```

Use the address printed by the server. Swagger is available at `/swagger` in Development. Update `@baseUrl` in [requests.http](requests.http) to that address.

`POST /Teams` accepts `name` and `year` as query parameters; the examples use that actual contract.

## Scope

Historical learning project. It implements team list/lookup/create endpoints; generic update/delete operations are incomplete. There is no application test project. The existing workflow checks compilation, not PostgreSQL integration or production readiness. The runtime and dependencies need a separate modernisation change before operational use.
