// Domain Layer (New Interface)
using Domain;
namespace Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITaskRepository
{
    Task<List<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(Guid id);
    Task AddTaskAsync(TaskEntity task);
    Task UpdateTaskAsync(TaskEntity task);
    Task DeleteTaskAsync(Guid id);
}
