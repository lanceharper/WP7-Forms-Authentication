using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace TestMembershipClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        private CookieContainer cc;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            MvcWebAppReference.AuthenticationServiceClient authService =
                new MvcWebAppReference.AuthenticationServiceClient();
            cc = new CookieContainer();
            authService.CookieContainer = cc;
            authService.LoginCompleted +=
              new EventHandler<MvcWebAppReference.LoginCompletedEventArgs>(
            authService_LoginCompleted);
            authService.LoginAsync(userName.Text, password.Text, "", true);
        }

        void authService_LoginCompleted(object sender, MvcWebAppReference.LoginCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Login failed, you Jackwagon.");
            }
            else
            {
                AspNetMvcRealReference.HelloServiceClient helloService =
                 new AspNetMvcRealReference.HelloServiceClient();
                helloService.CookieContainer = cc;
                helloService.HelloWorldCompleted +=
                new EventHandler<AspNetMvcRealReference.HelloWorldCompletedEventArgs>(
                  helloService_HelloWorldCompleted);
                helloService.HelloWorldAsync();
            }
        }

        void helloService_HelloWorldCompleted(object sender, AspNetMvcRealReference.HelloWorldCompletedEventArgs e)
        {
            MessageBox.Show("You're logged in, results from svc: " + e.Result);
        }
    }
}