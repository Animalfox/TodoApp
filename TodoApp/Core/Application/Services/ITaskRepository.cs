using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.Services;

public interface ITaskRepository
{
  void AddTask(TaskEntity task);
  void UpdateTask(TaskEntity task);
  void DeleteTask(int taskId);
  TaskEntity GetTaskById(int taskId);
  IEnumerable<TaskEntity> GetAllTasks();
}
