using TodoApp.Core.Application.UseCases;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Presentation.Controllers;

public class TaskController(
  AddTaskUseCase addTaskUseCase,
  EditTaskUseCase editTaskUseCase,
  DeleteTaskUseCase deleteTaskUseCase,
  ViewTasksUseCase viewTasksUseCase,
  MarkTaskAsCompletedUseCase markTaskAsCompletedUseCase,
  ReturnTaskToCurrentUseCase returnTaskToCurrentUseCase,
  SearchTasksUseCase searchTasksUseCase)
{
  public void AddTask(TaskEntity task)
  {
    addTaskUseCase.Execute(task);
  }

  public void EditTask(TaskEntity task)
  {
    editTaskUseCase.Execute(task);
  }

  public void DeleteTask(int taskId)
  {
    deleteTaskUseCase.Execute(taskId);
  }
  
  public IEnumerable<TaskEntity> ViewTasks()
  {
    return viewTasksUseCase.Execute();
  }

  public void MarkTaskAsCompleted(int taskId)
  {
    markTaskAsCompletedUseCase.Execute(taskId);
  }

  public void ReturnTaskToCurrent(int taskId)
  {
    returnTaskToCurrentUseCase.Execute(taskId);
  }

  public IEnumerable<TaskEntity> SearchTasks(string query)
  {
    return searchTasksUseCase.Execute(query);
  }
}