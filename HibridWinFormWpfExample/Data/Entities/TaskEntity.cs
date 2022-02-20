using HibridWinFormWpfExample.Data.Abstract;
using System;

namespace HibridWinFormWpfExample.Data.Entities
{
    public class TaskEntity: EntityBase
    {
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDiscription { get; set; }
    }
}
