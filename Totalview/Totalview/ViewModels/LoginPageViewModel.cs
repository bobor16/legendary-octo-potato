using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Totalview.Models;
using Xamarin.Forms;
using Totalview.Services;
using Totalview.View;

namespace Totalview.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        private UserModel userModel;

        public LoginPageViewModel()
        {
            userModel = new UserModel();
            LoginCommand = new Command(Login);

        }

        public async void Login()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MyStatePage());
            Console.WriteLine(ServerConnection.RefreshDataAsync());
            //ServerConnection s = new ServerConnection();
            //s.MakeConnection();
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