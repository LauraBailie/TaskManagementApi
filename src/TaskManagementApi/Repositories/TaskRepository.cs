namespace TaskManagementApi.Repositories;

using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.Models;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
        => await _context.Tasks.ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(int id)
        => await _context.Tasks.FindAsync(id);

    public async Task AddAsync(TaskItem task)
        => await _context.Tasks.AddAsync(task);

    public async Task UpdateAsync(TaskItem task)
        => await _context.Tasks.Where(t => t.Id == task.Id).ExecuteUpdateAsync(s =>
            s.SetProperty(t => t.Title, task.Title)
             .SetProperty(t => t.Description, task.Description)
             .SetProperty(t => t.IsCompleted, task.IsCompleted));
    public async Task DeleteAsync(int id)
        => await _context.Tasks.ExecuteDeleteAsync();

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}