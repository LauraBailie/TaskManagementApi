using TaskManagementApi.Data;
using TaskManagementApi.DTOs;
using TaskManagementApi.Models;
using TaskManagementApi.Repositories;


namespace TaskManagementApi.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
    {
        var tasks = await _repository.GetAllAsync();
        return tasks.Select(MapToDto);
    }

    public async Task<TaskItemDto?> GetByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        return task == null ? null : MapToDto(task);
    }

    public async Task<TaskItemDto> CreateAsync(CreateTaskDto dto)
    {
        // You can add more business rules/validation here if desired
        var task = new TaskItem
        {
            Title = dto.Title.Trim(),
            Description = dto.Description?.Trim(),
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();

        return MapToDto(task);
    }

    public async Task<TaskItemDto?> UpdateAsync(int id, CreateTaskDto dto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null)
        {
            return null;
        }

        task.Title = dto.Title.Trim();
        task.Description = dto.Description?.Trim();
        
        await _repository.UpdateAsync(task);           // usually just marks entity as modified
        await _repository.SaveChangesAsync();

        return MapToDto(task);
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Task with ID {id} not found");
        }

        await _repository.DeleteAsync(id);
        await _repository.SaveChangesAsync();
        
    }

    // ────────────────────────────────────────────────
    //              Mapping helper (manual)
    // ────────────────────────────────────────────────
    private static TaskItemDto MapToDto(TaskItem task)
    {
        return new TaskItemDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt
        };
    }
}