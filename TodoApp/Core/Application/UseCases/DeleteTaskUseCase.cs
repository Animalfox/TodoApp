using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Core.Application.UseCases;

public class DeleteTaskUseCase(ITaskRepository taskRepository)
{
  public void Execute(int taskId)
  {
    taskRepository.DeleteTask(taskId);
  }
}