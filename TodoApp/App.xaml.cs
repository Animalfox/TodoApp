using System.Configuration;
using System.Data;
using System.Windows;
using TodoApp.Core.Application.UseCases;
using TodoApp.Infrastructure.Repositories;
using TodoApp.Presentation.Controllers;
using TodoApp.UI;

namespace TodoApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  private void LoadMainWindow(object sender, StartupEventArgs e)
  {
    var taskRepository = new InMemoryTaskRepository();
    var taskController = new TaskController(
      new AddTaskUseCase(taskRepository),
      new DeleteTaskUseCase(taskRepository),
      new EditTaskUseCase(taskRepository),
      new MarkTaskAsCompletedUseCase(taskRepository),
      new ReturnTaskToCurrentUseCase(taskRepository),
      new SearchTasksUseCase(taskRepository),
      new ViewActiveTasksUseCase(taskRepository),
      new ViewCompletedTasksUseCase(taskRepository));
    var window = new MainWindow(taskController);
    window.Show();
  }
}