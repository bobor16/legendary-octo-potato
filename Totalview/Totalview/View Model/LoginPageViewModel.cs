using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Totalview.View;
using Xamarin.Forms;
using Totalview.Model;
using System.Net;
using System.Collections.ObjectModel;

namespace Totalview.View_Model
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }

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