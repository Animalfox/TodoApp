using System.Windows;
using TodoApp.Core.Domain.Entities;
using TodoApp.Presentation.Controllers;

namespace TodoApp.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly TaskController _taskController;
    
    public MainWindow(TaskController taskController)
    {
        _taskController = taskController;
        InitializeComponents();
    }
    
    private static void InitializeComponents()
    {
        // Инициализация компонентов UI
    }
    
    private void OnAddTask(object sender, EventArgs e)
    {
        // Добавление задачи
        var task = new TaskEntity
        {
            Title = "New Task",
            IsUrgent = false,
            IsImportant = false
        };
        _taskController.AddTask(task);
        RefreshTaskList();
    }

    private void OnEditTask(object sender, EventArgs e)
    {
        // Редактирование задачи
    }

    private void OnDeleteTask(object sender, EventArgs e)
    {
        // Удаление задачи
    }

    private void OnMarkTaskAsCompleted(object sender, EventArgs e)
    {
        // Отметка задачи как выполненной
    }

    private void OnReturnTaskToCurrent(object sender, EventArgs e)
    {
        // Возврат задачи в текущие
    }

    private void OnSearchTask(object sender, EventArgs e)
    {
        // Поиск задач
    }

    private void RefreshTaskList()
    {
        var tasks = _taskController.ViewTasks();
        // Обновление списка задач в UI
    }
}