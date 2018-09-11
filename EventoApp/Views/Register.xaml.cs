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
using EventoApp.Models;
using Windows.UI.Core;
using Windows.UI.Popups;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        Database db;
        public Register()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private async void SignupSignup_Click(object sender, RoutedEventArgs e)
        {
            //Validating Username
            if (!Regex.IsMatch(TxtSignupUsername.Text.Trim(), @"^[A-Za-z_][a-zA-Z0-9_\s]*$"))

            {
                var message = new MessageDialog("Invalid UserName. Username should only contain letters and numbers only");
                await message.ShowAsync();

            }
            //Validating Email
            else if (!Regex.IsMatch(TxtSignupEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))

            {

                var message = new MessageDialog("Invalid Email. Please enter a valid email");
                await message.ShowAsync();
            }
            //Validating Password
            else if (TxtSignupPassword.Password.Length < 6)

            {
                var message = new MessageDialog("Password length should be minimum of 6 characters!");
                await message.ShowAsync();
            }
           
            else{

                //Cross checking with DB
                int code = db.Register(new Models.User()
                {
                    UserName = TxtSignupUsername.Text.Trim(),
                    Email = TxtSignupEmail.Text.Trim(),
                    Password = TxtSignupPassword.Password
                });

                if (code == -1)
                {
                    var message = new MessageDialog("Registration failed");
                    await message.ShowAsync();
                }
                else
                {
                    var message = new MessageDialog("Registration Successful");
                    Frame.Navigate(typeof(Login));
                    await message.ShowAsync();
                    
                }
            }

        }

        private void SignupLogin_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));

            
        }
    }

        
            
}
