using HibridWinFormWpfExample.Data.Entities;
using System.Data.Entity;

namespace HibridWinFormWpfExample.Data
{
    public class TaskDbContext: DbContext
    {
        static TaskDbContext()
        {
            Database.SetInitializer(new TaskDbInitializer());
        }
        public TaskDbContext(): base("DefaultConnection")
        {            
        }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
