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
  }

  private void OnAddTask(object sender, EventArgs e)
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
    RefreshTaskList();
    TaskTitleBox.Clear();
    TaskTitleBox.Text = AddTaskPlaceholderText; // Restore placeholder text
  }

  private void OnEditTask(object sender, EventArgs e)
  {
    if (TaskList.SelectedItem is TaskEntity selectedTask)
    {
      selectedTask.Title = "Edited Task";
      _taskController.EditTask(selectedTask);
      RefreshTaskList();
    }
    else
    {
      MessageBox.Show("Please select a task to edit.");
    }
  }

  private void OnDeleteTask(object sender, EventArgs e)
  {
    if (TaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.DeleteTask(selectedTask.Id);
      RefreshTaskList();
    }
    else
    {
      MessageBox.Show("Please select a task to delete.");
    }
  }

  private void OnMarkTaskAsCompleted(object sender, EventArgs e)
  {
    if (TaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.MarkTaskAsCompleted(selectedTask.Id);
      RefreshTaskList();
    }
    else
    {
      MessageBox.Show("Please select a task to mark as completed.");
    }
  }

  private void OnReturnTaskToCurrent(object sender, EventArgs e)
  {
    if (TaskList.SelectedItem is TaskEntity selectedTask)
    {
      _taskController.ReturnTaskToCurrent(selectedTask.Id);
      RefreshTaskList();
    }
    else
    {
      MessageBox.Show("Please select a task to return to current.");
    }
  }

  private void OnSearchTask(object sender, EventArgs e)
  {
    var query = SearchBox.Text;
    var tasks = _taskController.SearchTasks(query);
    TaskList.ItemsSource = tasks;
  }

  private void RefreshTaskList()
  {
    var tasks = _taskController.ViewTasks();
    TaskList.ItemsSource = tasks;
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