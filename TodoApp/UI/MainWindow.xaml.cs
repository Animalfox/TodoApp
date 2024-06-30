using System.Windows;
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
        InitializeComponent();
    }
}