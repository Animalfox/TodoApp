using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class DeleteTaskUseCase(ITaskRepository taskRepository)
{
  public void Execute(int taskId)
  {
    taskRepository.DeleteTask(taskId);
  }
}