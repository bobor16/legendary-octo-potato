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
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        public Command ClearEntry { get; }
        public Command OpenServerSettings { get; }
        private UserModel userModel;
        private DataHandler d = new DataHandler();

        public LoginPageViewModel()
        {
            userModel = new UserModel();
            LoginCommand = new Command(Login);
            OpenServerSettings = new Command(ServerSettings);
        }
        private void WrongCredentials()
        {
            CrossToastPopUp.Current.ShowToastWarning("Wrong username or password, please try again");
        }

        public async void Login()
        {

            //if (!Username.Equals(d.Username) || !Password.Equals(d.Password))
            //{
              //  WrongCredentials();
                //clearEntry();
            //}
            //else
            //{
                await Application.Current.MainPage.Navigation.PushAsync(new MyStatePage());
              //  clearEntry();
                NotifyPropertyChanged();
            //}
        }
        public void clearEntry()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        public async void ServerSettings()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ChooseServer());
        }


        public string Username
        {
            get { return userModel.Username; }
            set
            {

                userModel.Username = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get { return userModel.Password; }
            set
            {
                userModel.Password = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}