using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Totalview.Models;
using Xamarin.Forms;
using Totalview.Services;
using Totalview.View;
using Plugin.Toast;
using Totalview.Views;

namespace Totalview.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        public Command ClearEntry { get; }
        public Command OpenServerSettings { get; }
        public Root root { get; set; }
        private bool success;
        private string _username;
        private string _password;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
            OpenServerSettings = new Command(ServerSettings);
            root = new Root();
        }
        /*
         * 
         Display 
         */
        private void WrongCredentialsMessage()
        {
            CrossToastPopUp.Current.ShowToastWarning("Wrong username or password, please try again");
        }

        /*
        Ensures DataHandler has gathered the data for a user to login by awaiting the getDataAsync(),
        secondly there will be controlled if the user has entered artibrary text into the entryfields
        (e.g. username or password). The user is then authenticated by comparing the entered text is 
        equivilant to the username and password gathered from the DataHandler().
        Lastly, if authenticated, the view is replaced with MyStatePage().
         */
        public async void Login()
        {
            success = false;
            DataHandler d = new DataHandler(this);
            await d.getDataAsync();

            if (!string.IsNullOrEmpty(UsernameBinding) || !string.IsNullOrEmpty(PasswordBinding))
            {
                for (int i = 0; i < root.UserList.Count; i++)
                {
                    if (UsernameBinding.Equals(root.UserList[i].username) && PasswordBinding.Equals(root.UserList[i].password))
                    {
                        CurrentUserModel.CurrentUserName = UsernameBinding;
                        CurrentUserModel.CurrentState = root.UserList[i].state;
                        CurrentUserModel.CurrentId = root.UserList[i].id;
                        CurrentUserModel.CurrentPassword = PasswordBinding;
                        clearEntry();
                        await Application.Current.MainPage.Navigation.PushAsync(new MyStatePage());
                        NotifyPropertyChanged();
                        success = true;
                    }
                }

                if (!success)
                {
                    clearEntry();
                    WrongCredentialsMessage();
                    NotifyPropertyChanged();
                }
            }

            else
            {
                clearEntry();
                WrongCredentialsMessage();
                NotifyPropertyChanged();
            }
        }

        public void clearEntry()
        {
            UsernameBinding = string.Empty;
            PasswordBinding = string.Empty;
        }

        /*
         Opens a new the ChooseServerPage
         */
        public async void ServerSettings()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ChooseServer());
        }

        /*
        Sets the binding for the username and password         
         */
        public string UsernameBinding
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        public string PasswordBinding
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}