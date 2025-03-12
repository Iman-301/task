using Application.Tasks.Commands;
using Application.Tasks.Queries;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Domain.Repositories; 

using Presentation.Controllers; // Ensure this is included

// Add this to recognize controllers

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddMediatR(typeof(CreateTaskCommand).Assembly); // Register once


builder.Services.AddControllers()
    .AddApplicationPart(typeof(TasksController).Assembly); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();

// Middlewareg
app.UseSwagger();
app.UseSwaggerUI();
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
