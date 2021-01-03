using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Totalview.Models;
using Totalview.Services;
using Xamarin.Forms;

namespace Totalview.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MyStatePageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public UserModel _userModel = new UserModel();
        private String currentName, currentState, currentId, currentPassword;
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
            loadInfo();
        }

        public void loadInfo()
        {
            currentName = CurrentUserModel.CurrentUserName;
            currentState = CurrentUserModel.CurrentState;
            currentId = CurrentUserModel.CurrentId;
            currentPassword = CurrentUserModel.CurrentPassword;
        }
        public async void update(string username, string state, string id, string password)
        {
            FirebaseHelper f = new FirebaseHelper();
            await f.UpdatePerson(username, currentState, id, password);
        }

        public string CurrentId
        {
            get { return currentId; }
            set
            {
                currentId = value;
                NotifyPropertyChanged();
            }
        }

        public string CurrentPassword
        {
            get { return currentPassword; }
            set
            {
                currentPassword = value;
                NotifyPropertyChanged();
            }
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




        public String State
        {
            get { return currentState; }
            set
            {
                currentState = value;
                NotifyPropertyChanged();
            }
        }

        public void NrState()
        {
            currentState = "Not Registered";
            update(CurrentName, "Not Registered", CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(State));
        }
        public void InState()
        {
            currentState = "In";
            update(CurrentName, "In", CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(State));
        }

        public void HomeState()
        {
            currentState = "Home";
            update(CurrentName, "Home", CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(State));
        }

        public void OutState()
        {
            currentState = "Out";
            update(CurrentName, "Out", CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(State));
        }

        public void BusyState()
        {
            currentState = "Busy";
            update(CurrentName, "Busy", CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(State));
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}