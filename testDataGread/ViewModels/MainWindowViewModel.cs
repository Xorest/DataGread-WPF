using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using testDataGread.Infrastructure.Commands;
using testDataGread.Models;
using testDataGread.ViewModels.Beas;

namespace testDataGread.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public ObservableCollection<Person> Data { get; set; }
        #region Title Windows
        private string _Title = "Test Progect";
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region SelectedPerson
        private Person _SelectedPerson;
        public Person SelectedPerson 
        {
            get=> _SelectedPerson;
            set=> Set(ref _SelectedPerson, value);
        }
        #endregion

        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p) 
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region AddPersonCommand
        public ICommand AddPersonCommand { get; }
        private bool CanAddPersonCommandExecute(object p) => true;
        private void OnAddPersonCommandExecuted(object p)
        {
            int max_index = Data.Count + 1;
            Person person = new Person 
            { 
                Name=$"Name {max_index}", 
                Birthgey= DateTime.Now, 
                Description = "New Person"
            };
            Data.Add(person);
        }
        #endregion

        #region RemovePersonCommand
        public ICommand RemovePersonCommand { get; }
        private bool CanRemovePersonCommandExecute(object p) => p is Person person && Data.Contains(person);
        private void OnRemovePersonCommandExecuted(object p)
        {
            if (!(p is Person person)) return;
            Data.Remove(person);
        }
        #endregion

        #endregion

        public MainWindowViewModel() 
        {
            #region
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            AddPersonCommand = new LambdaCommand(OnAddPersonCommandExecuted, CanAddPersonCommandExecute);
            RemovePersonCommand = new LambdaCommand(OnRemovePersonCommandExecuted, CanRemovePersonCommandExecute);
            #endregion

            Data = new ObservableCollection<Person>
            {
                new Person{
                    Name = "Tom",
                    Birthgey = DateTime.Now,
                    Description = "soso"},
                new Person{
                    Name = "Bob",
                    Birthgey = DateTime.Now,
                    Description = "soso"
                },
                new Person
                {
                    Name = "Sam",
                    Birthgey = DateTime.Now,
                    Description = "soso"
                },
                new Person
                {
                    Name = "Peet",
                    Birthgey = DateTime.Now,
                    Description = "soso"
                }
            };
        }
        
    }
}
