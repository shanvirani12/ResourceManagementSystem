using ResourceManagementSystem.Data;
using ResourceManagementSystem.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlServer<ResourceManagementContext>(conString);

var app = builder.Build();

app.MapResourcesEndpoints();
app.MapLocationsEndpoints();

app.MigrateDb();

app.Run();
