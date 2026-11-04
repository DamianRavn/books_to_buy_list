using BookSite.Data;
using BookSite.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("booksite.dev") ?? throw new InvalidOperationException("can't find connectionstring");
builder.Services.AddDbContext<BookSiteDbContext>(opts => {
    opts.EnableDetailedErrors();
    opts.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .WithOrigins(
        "http://localhost:8080"
    )
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.MapControllers();

app.Run();

