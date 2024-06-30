namespace TodoApp.Core.Domain.Entities;

public abstract class TaskEntity
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public bool IsUrgent { get; set; }
  public bool IsImportant { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public bool IsCompleted { get; set; }
  public List<int> ParentTaskIds { get; set; } = [];
}