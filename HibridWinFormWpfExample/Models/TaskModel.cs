using DevExpress.Mvvm;
using System;

namespace HibridWinFormWpfExample.Models
{
    public class TaskModel: ViewModelBase, ICloneable
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDiscription { get; set; }

        public object Clone()
        {
            return new TaskModel { Id = Id, CreateDate = CreateDate, DueDate = DueDate, CompletionDate = CompletionDate, TaskTitle = TaskTitle, TaskDiscription = TaskDiscription };
        }
    }
}
