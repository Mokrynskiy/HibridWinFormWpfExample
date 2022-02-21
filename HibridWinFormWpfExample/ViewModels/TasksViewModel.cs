using DevExpress.Mvvm;
using HibridWinFormWpfExample.Data;
using HibridWinFormWpfExample.Data.Repositories;
using HibridWinFormWpfExample.Mappers;
using HibridWinFormWpfExample.Models;
using HibridWinFormWpfExample.WpfViews;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;

namespace HibridWinFormWpfExample.ViewModels
{
    public class TasksViewModel: ViewModelBase
    {
        private TaskRepository _repository;
        public ObservableCollection<TaskModel> Tasks { get; set; }
        public TaskModel SelectedTask { get; set; }
        public bool IsAdd { get; set; }
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
        public ICommand AddCommand
        {
            get { return new DelegateCommand(() =>
            {    
                IsAdd = true;
                Form editForm = new Form();
                editForm.Size = new System.Drawing.Size(800, 450);
                ElementHost host = new ElementHost();
                host.Dock = DockStyle.Fill;                
                host.Child = new TaskEditView();
                editForm.Controls.Add(host);    
                editForm.Show();
                Messenger.Default.Send(this);
            }
            );}
        }
        public ICommand EditCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    IsAdd = false;
                    Form editForm = new Form();
                    editForm.Size = new System.Drawing.Size(800, 450);
                    ElementHost host = new ElementHost();
                    host.Dock = DockStyle.Fill;
                    host.Child = new TaskEditView();
                    editForm.Controls.Add(host);
                    editForm.Show();
                    Messenger.Default.Send(this);
                }
          );
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                if (MessageBox.Show($"Вы действительно хотите удалить {SelectedTask.TaskTitle}?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            _repository.Delete(SelectedTask.Id);
                            Tasks.Remove(SelectedTask);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }                    
                }
          );
            }
        }
    }
}
