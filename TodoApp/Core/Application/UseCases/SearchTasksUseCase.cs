using TodoApp.Core.Domain.Entities;
using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Core.Application.UseCases;

public class SearchTasksUseCase(ITaskRepository taskRepository)
{
  public IEnumerable<TaskEntity> Execute(string query)
  {
    var tasks = taskRepository.GetAllTasks();
    var result = tasks.Where(t => t.Title.Contains(query));
    return result;
  }
}