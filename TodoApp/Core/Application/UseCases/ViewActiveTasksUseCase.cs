using TodoApp.Core.Domain.Entities;
using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Core.Application.UseCases;

public class ViewActiveTasksUseCase(ITaskRepository taskRepository)
{
  public IEnumerable<TaskEntity> Execute()
  {
    var tasks = taskRepository.GetAllTasks();
    var result = tasks.Where(t => !t.IsCompleted);
    var sortedTasks = result
      .OrderBy(t => t.CreatedAt)
      .ThenBy(t => t.ParentTaskIds.Count != 0 ? t.ParentTaskIds.Max() : t.Id)
      .ThenBy(t => t.IsUrgent)
      .ThenBy(t => t.IsImportant);
    return sortedTasks;
  }
}