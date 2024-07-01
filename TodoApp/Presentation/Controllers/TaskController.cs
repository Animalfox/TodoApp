using TodoApp.Core.Application.UseCases;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Presentation.Controllers;

public class TaskController(
  AddTaskUseCase addTaskUseCase,
  DeleteTaskUseCase deleteTaskUseCase,
  EditTaskUseCase editTaskUseCase,
  MarkTaskAsCompletedUseCase markTaskAsCompletedUseCase,
  ReturnTaskToCurrentUseCase returnTaskToCurrentUseCase,
  SearchTasksUseCase searchTasksUseCase,
  ViewActiveTasksUseCase viewActiveTasksUseCase,
  ViewAllTasksUseCase viewAllTasksUseCase,
  ViewCompletedTasksUseCase viewCompletedTasksUseCase)
{
  public void AddTask(TaskEntity task)
  {
    addTaskUseCase.Execute(task);
  }

  public void DeleteTask(int taskId)
  {
    deleteTaskUseCase.Execute(taskId);
  }

  public void EditTask(TaskEntity task)
  {
    editTaskUseCase.Execute(task);
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

  public IEnumerable<TaskEntity> ViewActiveTasks()
  {
    return viewActiveTasksUseCase.Execute();
  }

  public IEnumerable<TaskEntity> ViewTasks()
  {
    return viewAllTasksUseCase.Execute();
  }

  public IEnumerable<TaskEntity> ViewCompletedTasks()
  {
    return viewCompletedTasksUseCase.Execute();
  }
}