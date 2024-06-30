using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class AddTaskUseCase(ITaskRepository taskRepository)
{
  public void Execute(TaskEntity task)
  {
    taskRepository.AddTask(task);
  }
}