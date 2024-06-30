using TodoApp.Core.Application.Services;

namespace TodoApp.Core.Application.UseCases;

public class ReturnTaskToCurrentUseCase(ITaskService taskService)
{
  public void Execute(int taskId)
  {
    var task = taskService.GetTaskById(taskId);
    if (!task.IsCompleted) return;
    task.IsCompleted = false;
    taskService.UpdateTask(task);
    // logic to discount points
  }
}