using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.Services;

public interface ITaskService
{
  void AddTask(TaskEntity task);
  void UpdateTask(TaskEntity task);
  void DeleteTask(int taskId);
  Task GetTaskById(int taskId);
  IEnumerable<Task> GetAllTasks();
}
