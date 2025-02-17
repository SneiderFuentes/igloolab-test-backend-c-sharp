using Microsoft.EntityFrameworkCore;
using IgloobalTestBackendCSharp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers();
var app = builder.Build();
app.UseCors("AllowFrontend");
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
