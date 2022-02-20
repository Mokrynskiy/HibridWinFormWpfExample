using HibridWinFormWpfExample.Data.Abstract;
using HibridWinFormWpfExample.Data.Entities;

namespace HibridWinFormWpfExample.Data.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity>
    {
        public TaskRepository(TaskDbContext context) : base(context)
        {            
        }
    }
}
