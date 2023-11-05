using System;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using TraVeL.Core.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using TraVeL.Core.Services;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using TraVeL.Views;
using TraVeL.Helpers;

namespace TraVeL.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private string username;
        private string password;

        private MainDataService mainDataService = new MainDataService();
        private MessageDialogBox messageDialog = new MessageDialogBox();
        private Frame rootFrame = Window.Current.Content as Frame;


        public MainViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        public ICommand LoginCommand { get; private set; }

        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        private void Login()
        {
            AccountDetails account = new AccountDetails
            {
                Username = Username,
                Password = Password
            };

            if (mainDataService.IsUserCredentialsCorrect(account))
            {
                rootFrame.Navigate(typeof(ContentGridPage));
            }
            else
            {
                messageDialog.ShowMessage("Login Failed! Incorrect username or password.");
            }
        }
    }
}
