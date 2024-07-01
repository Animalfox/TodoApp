using System.Windows;
using TodoApp.Core.Domain.Entities;
using TodoApp.Presentation.Controllers;

namespace TodoApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  private const string AddTaskPlaceholderText = "Enter task title";
  private readonly TaskController _taskController;

  public MainWindow(TaskController taskController)
  {
    _taskController = taskController;
    InitializeComponent();
    RefreshTaskLists();
  }

  private void OnAddTask(object sender, RoutedEventArgs e)
  {
    var taskTitle = TaskTitleBox.Text;

    if (string.IsNullOrWhiteSpace(taskTitle) || taskTitle == AddTaskPlaceholderText)
    {
      MessageBox.Show("Please enter a task title.");
      return;
    }

    var task = new TaskEntity()
    {
      Title = taskTitle,
      IsUrgent = false,
      IsImportant = false
    };
    _taskController.AddTask(task);
    RefreshTaskLists();
    TaskTitleBox.Clear();
    TaskTitleBox.Text = AddTaskPlaceholderText;
  }

  private void OnEditTask(object sender, RoutedEventArgs e)
  {
    if (ActiveTaskList.SelectedItem is TaskEntity selectedTask)
    {
      selectedTask.Title = "Edited Task";
      _taskController.EditTask(selectedTask);
      RefreshTaskLists();
    }
    else if (CompletedTaskList.SelectedItem is TaskEntity selectedCompletedTask)
    {
      selectedCompletedTask.Title = "Edited Task";
      _taskController.EditTask(selectedCompletedTask);
      RefreshTaskLists();
    }
    else
    {
      MessageBox.Show("Please select a task to edit.");
    }
  }

  private void OnDeleteTask(object sender, RoutedEventArgs e)
  {
    if (ActiveTaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.DeleteTask(selectedTask.Id);
      RefreshTaskLists();
    }
    else if (CompletedTaskList.SelectedItem is TaskEntity selectedCompletedTask)
    {
      _taskController.DeleteTask(selectedCompletedTask.Id);
      RefreshTaskLists();
    }
    else
    {
      MessageBox.Show("Please select a task to delete.");
    }
  }

  private void OnMarkTaskAsCompleted(object sender, RoutedEventArgs e)
  {
    if (ActiveTaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.MarkTaskAsCompleted(selectedTask.Id);
      RefreshTaskLists();
    }
    else
    {
      MessageBox.Show("Please select a task to mark as completed.");
    }
  }

  private void OnReturnTaskToCurrent(object sender, RoutedEventArgs e)
  {
    if (CompletedTaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.ReturnTaskToCurrent(selectedTask.Id);
      RefreshTaskLists();
    }
    else
    {
      MessageBox.Show("Please select a task to return to current.");
    }
  }

  private void OnSearchTask(object sender, RoutedEventArgs e)
  {
    var query = SearchBox.Text;
    var tasks = _taskController.SearchTasks(query);
    ActiveTaskList.ItemsSource = tasks;
    CompletedTaskList.ItemsSource = tasks;
  }

  private void RefreshTaskLists()
  {
    var activeTasks = _taskController.ViewActiveTasks();
    ActiveTaskList.ItemsSource = activeTasks;

    var completedTasks = _taskController.ViewCompletedTasks();
    CompletedTaskList.ItemsSource = completedTasks;
  }

  private void TaskTitleBox_GotFocus(object sender, RoutedEventArgs e)
  {
    if (TaskTitleBox.Text == AddTaskPlaceholderText) TaskTitleBox.Text = "";
  }

  private void TaskTitleBox_LostFocus(object sender, RoutedEventArgs e)
  {
    if (string.IsNullOrWhiteSpace(TaskTitleBox.Text)) TaskTitleBox.Text = AddTaskPlaceholderText;
  }
}