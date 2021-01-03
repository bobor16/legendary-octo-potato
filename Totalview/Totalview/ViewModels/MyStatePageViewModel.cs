using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Totalview.Models;
using Totalview.Services;
using Xamarin.Forms;

namespace Totalview.ViewModels
{
    /// <summary>
    /// MyStatePageViewModel hold the logic to bind and command the MyStatePage.
    /// </summary>
    public class MyStatePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
            LoadCurrentUserInfo();
        }

        /*
         Sets the current user to the user found in the json object in the LoginPageViewModel.
        The method is invoked as soon as the constructor is.
         */
        public void LoadCurrentUserInfo()
        {
            currentName = CurrentUserModel.CurrentUserName;
            currentState = CurrentUserModel.CurrentState;
            currentId = CurrentUserModel.CurrentId;
            currentPassword = CurrentUserModel.CurrentPassword;
        }

        /*
         Updates the user state, the username, id, 
         */
        public async void UpdateState(string username, string state, string id, string password)
        {
            FirebaseHelper f = new FirebaseHelper();
            await f.UpdateDatabase(username, state, id, password);

        }

        public String CurrentId
        {
            get { return currentId; }
            set
            {
                currentId = value;
                NotifyPropertyChanged();
            }
        }

        public String CurrentPassword
        {
            get { return currentPassword; }
            set
            {
                currentPassword = value;
                NotifyPropertyChanged();
            }
        }
        public String CurrentName
        {
            get { return currentName; }
            set
            {
                currentName = value;
                NotifyPropertyChanged();
            }
        }
        public String CurrentState
        {
            get { return currentState; }
            set
            {
                currentState = value;
                NotifyPropertyChanged();
            }
        }
        /*
         Binds the states to the MyStatePage via commands
         */
        public void NrState()
        {
            currentState = "Not Registered";
            UpdateState(CurrentName, CurrentState, CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(CurrentState));
        }
        /*
         Binds the states to the MyStatePage via commands
         */
        public void InState()
        {
            currentState = "In";
            UpdateState(CurrentName, CurrentState, CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(CurrentState));
        }
        /*
         Binds the states to the MyStatePage via commands
         */
        public void HomeState()
        {
            currentState = "Home";
            UpdateState(CurrentName, CurrentState, CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(CurrentState));
        }
        /*
         Binds the states to the MyStatePage via commands
         */
        public void OutState()
        {
            currentState = "Out";
            UpdateState(CurrentName, CurrentState, CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(CurrentState));
        }
        /*
         Binds the states to the MyStatePage via commands
         */
        public void BusyState()
        {
            currentState = "Busy";
            UpdateState(CurrentName, CurrentState, CurrentId, CurrentPassword);
            NotifyPropertyChanged(nameof(CurrentState));
        }
        /*
         Method for notifyring the view, that it has changed.
         */
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}