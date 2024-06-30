using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class DeleteTaskUseCase(ITaskService taskService)
{
  public void Execute(int taskId)
  {
    taskService.DeleteTask(taskId);
  }
}