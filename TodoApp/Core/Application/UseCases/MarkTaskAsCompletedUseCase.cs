using TodoApp.Core.Application.Services;

namespace TodoApp.Core.Application.UseCases;

public class MarkTaskAsCompletedUseCase(ITaskRepository taskRepository)
{
  public void Execute(int taskId)
  {
    var task = taskRepository.GetTaskById(taskId);
    task.IsCompleted = true;
  }
}