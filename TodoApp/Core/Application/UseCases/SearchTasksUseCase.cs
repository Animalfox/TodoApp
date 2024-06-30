using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class SearchTasksUseCase(ITaskService taskService)
{
  public IEnumerable<TaskEntity> Execute(string query)
  {
    var tasks = taskService.GetAllTasks();
    var result = tasks.Where(t => t.Title.Contains(query));
    return result;
  }
}