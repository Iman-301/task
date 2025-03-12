// using Application.Repositories;
// using Infrastructure.Persistence;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;

// namespace Infrastructure
// {
//     public static class DependencyInjection
//     {
//         public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
//         {
//             // Register PostgreSQL Database Context
//             services.AddDbContext<TaskDbContext>(options =>
//                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

//             // Register Repository
//             services.AddScoped<ITaskRepository, TaskRepository>();

//             return services;
//         }
//     }
// }
