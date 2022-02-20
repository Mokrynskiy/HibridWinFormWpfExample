using HibridWinFormWpfExample.Data.Entities;
using HibridWinFormWpfExample.Models;

namespace HibridWinFormWpfExample.Mappers
{
    public static class TaskMapper
    {
        public static TaskEntity ToEntity(this TaskModel model)
        {
            return new TaskEntity { Id = model.Id, CreateDate = model.CreateDate, DueDate = model.DueDate, CompletionDate = model.CompletionDate, TaskTitle = model.TaskTitle, TaskDiscription = model.TaskDiscription };
        }
        public static TaskModel ToModel(this TaskEntity entity)
        {
            return new TaskModel { Id = entity.Id, CreateDate = entity.CreateDate, DueDate = entity.DueDate, CompletionDate = entity.CompletionDate, TaskTitle = entity.TaskTitle, TaskDiscription = entity.TaskDiscription };
        }
    }
}
