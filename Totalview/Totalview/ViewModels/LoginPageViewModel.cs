using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Totalview.Models;
using Xamarin.Forms;
using Totalview.Services;
using Totalview.View;
using Plugin.Toast;
using Totalview.Views;
using System.Diagnostics;
using System.Collections.Generic;

namespace Totalview.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        public Command ClearEntry { get; }
        public Command OpenServerSettings { get; }
        public Root root { get; set; }
        private bool success;


        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
            OpenServerSettings = new Command(ServerSettings);
            root = new Root();
        }
        private void WrongCredentialsMessage()
        {
            CrossToastPopUp.Current.ShowToastWarning("Wrong username or password, please try again");
        }

        public async void Login()
        {
            success = false;
            DataHandler d = new DataHandler(this);
            await d.getDataAsync();

            if (!string.IsNullOrEmpty(UsernameBinding) || !string.IsNullOrEmpty(PasswordBinding))
            {
                for (int i = 0; i < root.UserList.Count; i++)
                {
                    if (UsernameBinding.Equals(root.UserList[i].username) || PasswordBinding.Equals(root.UserList[i].password))
                    {
                        Debug.WriteLine("The username is here somewhere!");
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

        public async void ServerSettings()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ChooseServer());
        }
        private string _username;
        public string UsernameBinding
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }
        private string _password;
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