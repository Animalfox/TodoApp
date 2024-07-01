using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Core.Application.UseCases;

public class MarkTaskAsUncompletedUseCase(ITaskRepository taskRepository)
{
  public void Execute(int taskId)
  {
    var task = taskRepository.GetTaskById(taskId);
    switch (task)
    {
      case { IsCompleted: false }:
      case null:
        return;
      default:
        task.IsCompleted = false;
        taskRepository.UpdateTask(task);

        // logic to discount points
        break;
    }
  }
}