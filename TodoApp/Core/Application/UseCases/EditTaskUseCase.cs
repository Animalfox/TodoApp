using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class EditTaskUseCase(ITaskService taskService)
{
  public void Execute(TaskEntity task)
  {
    taskService.UpdateTask(task);
  }
}