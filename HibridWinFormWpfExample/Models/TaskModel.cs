using System;

namespace HibridWinFormWpfExample.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDiscription { get; set; }
    }
}
