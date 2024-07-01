using TodoApp.Core.Domain.Entities;
using TodoApp.Core.Domain.Interfaces;

namespace TodoApp.Core.Application.UseCases;

public class AddTaskUseCase(ITaskRepository taskRepository)
{
  public void Execute(TaskEntity task)
  {
    taskRepository.AddTask(task);
  }
}