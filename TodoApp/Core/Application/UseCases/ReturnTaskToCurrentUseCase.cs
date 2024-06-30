using TodoApp.Core.Application.Services;

namespace TodoApp.Core.Application.UseCases;

public class ReturnTaskToCurrentUseCase(ITaskRepository taskRepository)
{
  public void Execute(int taskId)
  {
    var task = taskRepository.GetTaskById(taskId);
    if (!task.IsCompleted) return;
    task.IsCompleted = false;
    taskRepository.UpdateTask(task);
    // logic to discount points
  }
}