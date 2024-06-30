﻿using TodoApp.Core.Application.Services;
using TodoApp.Core.Domain.Entities;

namespace TodoApp.Core.Application.UseCases;

public class ViewTasksUseCase(ITaskService taskService)
{
  public IEnumerable<TaskEntity> Execute()
  {
    var tasks = taskService.GetAllTasks();
    var sortedTasks = tasks
      .OrderBy(t => t.CreatedAt)
      .ThenBy(t => t.ParentTaskIds.Count != 0 ? t.ParentTaskIds.Max() : t.Id)
      .ThenBy(t => t.IsUrgent)
      .ThenBy(t => t.IsImportant);
    return sortedTasks;
  }
}