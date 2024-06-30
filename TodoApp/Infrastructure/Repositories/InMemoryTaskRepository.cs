using TodoApp.Core.Domain.Entities;
using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
  private readonly List<TaskEntity> _tasks = [];
  
  private int NextTaskId { get; set; } = 0;

  private int GenerateTaskId()
  {
    return NextTaskId++;
  }

  public void AddTask(TaskEntity task)
  {
    task.Id = GenerateTaskId();
    _tasks.Add(task);
  }

  public void UpdateTask(TaskEntity task)
  {
    var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
    if (existingTask == null) return;
    existingTask.Title = task.Title;
    existingTask.ParentTaskIds = task.ParentTaskIds;
    existingTask.IsUrgent = task.IsUrgent;
    existingTask.IsImportant = task.IsImportant;
    existingTask.IsCompleted = task.IsCompleted;
  }

  public void DeleteTask(int taskId)
  {
    var task = _tasks.FirstOrDefault(t => t.Id == taskId);
    if (task != null)
    {
      _tasks.Remove(task);
    }
  }

  public TaskEntity? GetTaskById(int taskId)
  {
    var task = _tasks.FirstOrDefault(t => t.Id == taskId);
    return task;
  }

  public IEnumerable<TaskEntity> GetAllTasks()
  {
    return _tasks;
  }
}