using Microsoft.EntityFrameworkCore;
using YogaCommerce.EntityFramework.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var cnnStr = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(cnnStr));

app.Run();
