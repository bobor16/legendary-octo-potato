using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Totalview.View_Model
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(() =>
            {

            });
        }



        public Command LoginCommand { get; }

    }
}