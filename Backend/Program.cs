using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Portfolio API", Version = "v1"});
});

builder.Services.AddDbContext<PortfolioDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDb"));
});
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IBlogpostService, BlogpostService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();