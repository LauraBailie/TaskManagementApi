namespace TaskManagementApi.Repositories;

using TaskManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}