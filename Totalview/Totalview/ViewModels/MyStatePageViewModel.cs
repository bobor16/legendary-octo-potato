using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Totalview.Models;
using Xamarin.Forms;

namespace Totalview.ViewModels
{
    class MyStatePageViewModel : INotifyPropertyChanged
    {

        private String state = "Default State";
        public event PropertyChangedEventHandler PropertyChanged;
        public UserModel _userModel = new UserModel();

        private String currentName;

        public ICommand NrStateCommand { get; }
        public ICommand InStateCommand { get; }
        public ICommand HomeStateCommand { get; }
        public ICommand OutStateCommand { get; }
        public ICommand BusyStateCommand { get; }

        public MyStatePageViewModel()
        {
            NrStateCommand = new Command(NrState);
            InStateCommand = new Command(InState);
            HomeStateCommand = new Command(HomeState);
            OutStateCommand = new Command(OutState);
            BusyStateCommand = new Command(BusyState);
            Console.WriteLine("Kom så! " + CurrentUserModel.CurrentUserName);
            loadInfo();
        }

        public string CurrentName
        {
            get { return currentName; }
            set
            {
                currentName = value;
                NotifyPropertyChanged();
            }
        }

        public void loadInfo()
        {
            currentName = CurrentUserModel.CurrentUserName;
            NotifyPropertyChanged(nameof(CurrentName));
        }

        public String State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyPropertyChanged();
            }
        }

        public void NrState()
        {
            state = "Not Registered";
            NotifyPropertyChanged(nameof(State));
        }

        public void InState()
        {
            state = "In";
            NotifyPropertyChanged(nameof(State));
        }

        public void HomeState()
        {
            state = "Home";
            NotifyPropertyChanged(nameof(State));
        }

        public void OutState()
        {
            state = "Out";
            NotifyPropertyChanged(nameof(State));
        }

        public void BusyState()
        {
            state = "Busy";
            NotifyPropertyChanged(nameof(State));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}