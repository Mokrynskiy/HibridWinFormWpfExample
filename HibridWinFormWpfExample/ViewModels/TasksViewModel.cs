using DevExpress.Mvvm;
using HibridWinFormWpfExample.Data;
using HibridWinFormWpfExample.Data.Repositories;
using HibridWinFormWpfExample.Mappers;
using HibridWinFormWpfExample.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HibridWinFormWpfExample.ViewModels
{
    public class TasksViewModel: ViewModelBase
    {
        private TaskRepository _repository;
        public ObservableCollection<TaskModel> Tasks { get; set; }
        public TaskModel SelectedTask { get; set; }
        public TasksViewModel()
        {
            Tasks = new ObservableCollection<TaskModel>();
            SelectedTask = null;
            _repository = new TaskRepository(new TaskDbContext());
            LoadData();
        }
        private void LoadData()
        {
            foreach (var task in _repository.GetAll())
            {
                Tasks.Add(task.ToModel());
            }
            SelectedTask = Tasks.FirstOrDefault();
        }
        
    }
}
