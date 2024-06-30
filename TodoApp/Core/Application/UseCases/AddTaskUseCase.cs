using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class AddTaskUseCase(ITaskService taskService)
{
  public void Execute(TaskEntity task)
  {
    taskService.AddTask(task);
  }
}