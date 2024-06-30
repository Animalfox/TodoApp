using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Domain.Interfaces;

public interface ITaskRepository : Application.Services.ITaskRepository
{
  new void AddTask(TaskEntity task);
  new void UpdateTask(TaskEntity task);
  new void DeleteTask(int taskId);
  new TaskEntity? GetTaskById(int taskId);
  new IEnumerable<TaskEntity> GetAllTasks();
}