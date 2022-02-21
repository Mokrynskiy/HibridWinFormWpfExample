using DevExpress.Mvvm;
using HibridWinFormWpfExample.Data;
using HibridWinFormWpfExample.Data.Repositories;
using HibridWinFormWpfExample.Mappers;
using HibridWinFormWpfExample.Models;
using System;
using System.Windows.Forms;
using System.Windows.Input;

namespace HibridWinFormWpfExample.ViewModels
{
    public class TaskEditViewModel: ViewModelBase
    {
        private TaskRepository _repository;      
        public TasksViewModel TasksViewModel { get; set; }
        public TaskModel EditableTask { get; set; }       
        public TaskEditViewModel()
        {
            _repository = new TaskRepository(new TaskDbContext());
            Messenger.Default.Register<TasksViewModel>(this, action => GetTask(action));
        }
        private void GetTask(TasksViewModel tasksViewModel)
        {
            TasksViewModel = tasksViewModel;            
            if (!TasksViewModel.IsAdd)
                EditableTask = (TaskModel)TasksViewModel.SelectedTask.Clone();
            else
                EditableTask = new TaskModel{ CreateDate = DateTime.Now, DueDate = DateTime.Now};            
                       
        }
        public ICommand SaveCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (TasksViewModel.IsAdd)
                    {
                        var editableTask = _repository.Add(EditableTask.ToEntity()).ToModel();
                        TasksViewModel.Tasks.Add(editableTask);
                        TasksViewModel.SelectedTask = editableTask;
                        _repository.Save();
                        Form.ActiveForm.Close();
                    }
                    else
                    {
                        var taskEntity = _repository.GetById(EditableTask.Id);
                        taskEntity.CreateDate = EditableTask.CreateDate;
                        taskEntity.DueDate = EditableTask.DueDate;
                        taskEntity.CompletionDate = EditableTask.CompletionDate;
                        taskEntity.TaskTitle = EditableTask.TaskTitle;
                        taskEntity.TaskDiscription = EditableTask.TaskDiscription;
                        _repository.Save();                        
                        TasksViewModel.SelectedTask.Id = EditableTask.Id;
                        TasksViewModel.SelectedTask.TaskTitle = EditableTask.TaskTitle;
                        TasksViewModel.SelectedTask.TaskDiscription = EditableTask.TaskDiscription;
                        TasksViewModel.SelectedTask.CreateDate = EditableTask.CreateDate;
                        TasksViewModel.SelectedTask.DueDate = EditableTask.DueDate;
                        TasksViewModel.SelectedTask.CompletionDate = EditableTask.CompletionDate;     
                        Form.ActiveForm.Close();
                    }
                });
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Form.ActiveForm.Close();                    
                });
            }
        }
    }
}
