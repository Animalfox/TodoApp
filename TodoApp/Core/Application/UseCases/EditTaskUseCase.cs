using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class EditTaskUseCase(ITaskRepository taskRepository)
{
  public void Execute(TaskEntity task)
  {
    taskRepository.UpdateTask(task);
  }
}