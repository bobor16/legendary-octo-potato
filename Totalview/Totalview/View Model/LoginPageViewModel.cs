using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Totalview.View;
using Xamarin.Forms;

namespace Totalview.View_Model
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new MyStatePage());
                NotifyPropertyChanged();
            });
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}