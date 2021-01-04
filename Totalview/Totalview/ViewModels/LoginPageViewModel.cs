using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Totalview.Models;
using Xamarin.Forms;
using Totalview.Services;
using Totalview.View;
using Plugin.Toast;
using Totalview.Views;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Totalview.ViewModels
{
    /// <summary>
    /// LoginPageViewModel authenticates the user and furthermore sets bindings and commands
    /// to the LoginPageView.
    /// </summary>
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        public Command OpenServerSettings { get; }
        public Root root { get; set; }
        private bool success;
        private string username;
        private string password;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login);
            OpenServerSettings = new Command(ServerSettings);
            root = new Root();
        }
        /*
         Display an error if user fails to be authenticated.
         */
        private void WrongCredentialsMessage()
        {
            CrossToastPopUp.Current.ShowToastWarning("Wrong username or password, please try again");
            clearEntry();
        }

        /*
        Ensures DataHandler has gathered the data for a user to login by awaiting the getDataAsync(),
        secondly there will be controlled if the user has entered artibrary text into the entryfields
        (e.g. username or password).
         */
        public async void Login()
        {
            success = false;
            DataHandler d = new DataHandler(this);
            await d.getDataAsync();

            if (!string.IsNullOrEmpty(UsernameBinding) || !string.IsNullOrEmpty(PasswordBinding))
            {
                await Authenticate();

                if (!success)
                {
                    WrongCredentialsMessage();
                    NotifyPropertyChanged();
                }
            } 
            
            else
            {
                WrongCredentialsMessage();
                NotifyPropertyChanged();
            }
        }

         /*
         The user is authenticated by comparing the entered text 
         to the username and password gathered from the DataHandler, by accessing the UserList from
         the Root class.
         Lastly, if authenticated, the view is replaced with MyStatePage().
         */
        public async Task Authenticate()
        {
            for (int i = 0; i < root.UserList.Count; i++)
            {
                if (UsernameBinding.Equals(root.UserList[i].username) && PasswordBinding.Equals(root.UserList[i].password))
                {
                    try
                    {
                        CurrentUserModel.CurrentUserName = UsernameBinding;
                        CurrentUserModel.CurrentState = root.UserList[i].state;
                        CurrentUserModel.CurrentId = root.UserList[i].id;
                        CurrentUserModel.CurrentPassword = PasswordBinding;
                        await Application.Current.MainPage.Navigation.PushAsync(new MyStatePage());
                        clearEntry();
                        NotifyPropertyChanged();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"Error: {e}");
                    }
                }
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
        Sets the binding for the username.          
         */
        public string UsernameBinding
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }

        /*
         Sets the binding for the password.
         */
        public string PasswordBinding
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }
        /*
         Method for notifyring the view, that it has changed.
         */
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}