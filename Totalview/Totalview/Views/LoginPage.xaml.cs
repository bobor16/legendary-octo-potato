using Totalview.ViewModels;
using Xamarin.Forms;
using System;
using System.Security.Cryptography;

namespace Totalview
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            BindingContext = new LoginPageViewModel();
            InitializeComponent();
        }

        async public void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameEntry.Text) && !string.IsNullOrWhiteSpace(paswordEntry.Text))
            {
                await App.DataDummy.SaveUserAsync(new Models.UserModel
                {
                    Username = usernameEntry.Text,
                    Password = paswordEntry.Text
                });
                usernameEntry.Text = paswordEntry.Text = string.Empty;
            }
        }

    }
}
