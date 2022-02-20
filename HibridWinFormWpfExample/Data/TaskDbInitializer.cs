using HibridWinFormWpfExample.Data.Entities;
using System;
using System.Data.Entity;

namespace HibridWinFormWpfExample.Data
{
    public class TaskDbInitializer: CreateDatabaseIfNotExists<TaskDbContext>
    {
        protected override void Seed(TaskDbContext context)
        {
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 1", TaskDiscription = "Описание задачи 1" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 2", TaskDiscription = "Описание задачи 2" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 3", TaskDiscription = "Описание задачи 3" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 4", TaskDiscription = "Описание задачи 4" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 5", TaskDiscription = "Описание задачи 5" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 6", TaskDiscription = "Описание задачи 6" });
            context.Tasks.Add(new TaskEntity { CreateDate = DateTime.Now, DueDate = DateTime.Now, TaskTitle = "Задача 7", TaskDiscription = "Описание задачи 7" });
            base.Seed(context);
        }
    }
}
