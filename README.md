# Portfolio API

Deze backend is voor het maken van project en blogpost die CRUD endpoint gebruiken om in SQL server opslagen.
Nathaniel Rasmijn
23003421

## :
.NET 10 (net 10.0, SDK 10.0.401)
ASP.NET Core Web Api
Entity Framework Core 10.0.14 with SQL Server-provider
SQL Server Express
Swashbuckle.AspNetCore 6.6.2

Ik heb controller gekozen en niet Minimal API, omdat HTTP-afhandeling is anders. De routes staan in een attribuut in een klasse met controllers en in minimal api staan ze direct in de app. Ook is de code bij controller meer gestructureerd en in minimal api meer compacter.

## Map
Backend
	Controllers - hier zit de presentatie lag (user interface)
	Services - hier zit de business logic laag
	Data - Hier zit DBContext (data access)
	Models - De EF entities
	DTOs - Een soort contract met de client
	Migrations - hoort bij de data access laag
	Program.cs - opstarten en service registreren
	appsettings.json - connectie configuratie
De omzetting van entity naar DTO vindt plaats in de ToResponse functie in de controllers.

## Vereisten
- .NET 10 SDK
- SQL Server
- SSMS
- dotnet-ef tool (dotnet tool install --global dotnet-ef

In appsetting.json onder ConnectionStrings is de naam van de database PortfolioDB.
Server=localhost\SQLEXPRESS - De SQL Server Express instantie in eigen pc
Database=PortfolioDB - De naam van de database
Trusted_Connection=True - Inloggen met windows account zonder een password
TrustServerCertificate=True - Accepteer het locale certificaat van SQL Server

## Database Aanmaken
1. Gaat naar Backend map (cd Backend)
2. Migration commando uitvoeren (dotnet ef database update)
3.De PortfolioDB met de 2 tabellen Projects en Blogposts worden aangemaakt.
4. Controleren in SSMS als er onder databases een PortfolioDB staan en kijken onder Tables als de tabellen daar staan.

## Applicatie Starten
1. Het dotnet opstarten met de https profile (dotnet run --launch-profile https)
2. https://localhost:7194/swagger dit in de browser plakken
3. Https gekozen omdat met Http de browser stuurt de POST naar een andere adres en de CORS blokkeert dit en Swagger toont Failed to Fetch.
4. dotnet dev-certs https --trust om het certificaat te vertrouwen.

## Endpoints
Blogposts:
[HttpGet]
    public async Task<ActionResult<IEnumerable<BlogpostResponse>>> GetAllBlogposts()

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostResponse>> GetBlogpostById(int id)

    [HttpPost]
    public async Task<ActionResult<BlogpostResponse>> CreateBlogpost(CreateBlogpostRequest request)

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBlogpost(int id, UpdateBlogpostRequest request)

Projects
[HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAllProjects()

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponse>> GetProjectById(int id)

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> CreateProject(CreateProjectRequest request)
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProject(int id, UpdateProjectRequest request)

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProject(int id)
