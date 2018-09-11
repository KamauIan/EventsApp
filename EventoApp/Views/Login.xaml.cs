using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using EventoApp.Models;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        Database db;
        public Login()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void LoginLogin_Click(object sender, RoutedEventArgs e)
        {
            //Validating Username
            if (!Regex.IsMatch(TxtLoginUsername.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))

            {
                var message = new MessageDialog("Invalid UserName. Username should only contain letters and numbers only");
                await message.ShowAsync();

            }
            //Validating Password
            else if (TxtLoginPassword.Password.Length < 6)

            {
                var message = new MessageDialog("Password length should be minimum of 6 characters!");
                await message.ShowAsync();
            }

            if (db.Login(TxtLoginUsername.Text, TxtLoginPassword.Password))
            {
                var message = new MessageDialog("Login success");
                Frame.Navigate(typeof(EventsView));
                await message.ShowAsync();
                //Frame.Navigate(typeof(CreateEventView));
            }

            else
            {
                var message = new MessageDialog("Login failed.");
                await message.ShowAsync();
            }
        }

        private void LoginSignup_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Register));
        }


        private void CreateEventViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEventView));
        }
    }
}
