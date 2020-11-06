using Totalview.View_Model;
using Xamarin.Forms;
using System;
using Totalview.Model;
using System.Diagnostics;
using Totalview.View;

namespace Totalview
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            //BindingContext = this;
            BindingContext = new LoginPageViewModel();

            InitializeComponent();
        }

        async public void OnLoginButtonClicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Username = "test";

            var txt = usernameEntry.Text;

            if (!user.Username.Equals(txt))
            {
                await DisplayAlert("Alert", "Wrong!", "OK");
            }
            else
            {
                Debug.WriteLine("Test!");
            }
        }
    }
}
