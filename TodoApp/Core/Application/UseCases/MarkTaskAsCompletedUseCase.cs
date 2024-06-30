using TodoApp.Core.Application.Services;

namespace TodoApp.Core.Application.UseCases;

public class MarkTaskAsCompletedUseCase(ITaskService taskService)
{
  public void Execute(int taskId)
  {
    var task = taskService.GetTaskById(taskId);
    task.IsCompleted = true;
  }
}