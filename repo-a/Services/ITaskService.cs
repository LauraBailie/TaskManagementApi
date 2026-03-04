using TaskManagementApi.DTOs;
public interface ITaskService
{
    Task<IEnumerable<TaskItemDto>> GetAllAsync();
    Task<TaskItemDto?> GetByIdAsync(int id);
    Task<TaskItemDto> CreateAsync(CreateTaskDto dto);
    Task<TaskItemDto?> UpdateAsync(int id, CreateTaskDto dto);
    Task DeleteAsync(int id);
}