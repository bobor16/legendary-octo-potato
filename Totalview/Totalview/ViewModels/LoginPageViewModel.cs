using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Totalview.Models;
using Totalview.View;
using Xamarin.Forms;

namespace Totalview.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        public Action DisplayInvalidLoginPrompt;

        private UserModel userModel;
        public LoginPageViewModel()
        {
            userModel = new UserModel();
            LoginCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MyStatePage());
                NotifyPropertyChanged();
            });
        }

        public void OnSubmit()
        {
            if (Username != "ffs" || Password != "123")
            {
                DisplayInvalidLoginPrompt();
            }
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