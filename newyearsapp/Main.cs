using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class Main : ContentPage
    {
        public Main()
        {

            Label appTitle = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Welcome to GluvBox",
                //TextColor = Color.White,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            Label orText = new Label
            {
                Text = "OR",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            var usernameEntry = new Entry { Placeholder = "Email" };
            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };
            var accessCode = new Entry
            {
                Placeholder = "Access Code / VIN"
            };
            Button loginButton = new Button
            {
                BackgroundColor = Color.Aqua,
                Text = "LOG IN",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            loginButton.Clicked += LoginButtonClicked;

            Button registerButton = new Button
            {
                BackgroundColor = Color.White,
                Text = "Register",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 0                
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };
            registerButton.Clicked += RegisterButtonClicked;

            Button forgotPWButton = new Button
            {
                BackgroundColor = Color.White,
                Text = "Forgot Password",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 0
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };
            forgotPWButton.Clicked += ForgotPWButton_Clicked;
            
            Title = "GluvBox"; // DashLight, Dash, DashBoard
            Content = new StackLayout
            {                
                VerticalOptions = LayoutOptions.Center,
                Children = {
                        appTitle,usernameEntry,passwordEntry,orText,accessCode,loginButton, forgotPWButton, registerButton
                    }
            };
        }

        async void ForgotPWButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPW(), false);
        }

        async void RegisterButtonClicked(object sender, EventArgs e)
        {
            // validate email address and password and check whether go to regular login or oAuth login
            //MainPage = new Register();
            await Navigation.PushAsync(new Register(), false);

        }
        async void LoginButtonClicked(object sender, EventArgs e)
        {
            // validate email address and password and check whether go to regular login or oAuth login
            //MainPage = new Register();
            //await Navigation.PushAsync(new Dashboard(), false);
            // insertpagebefore
            //await Navigation.PopToRootAsync();         // will still be in navigationpage structure

            // see https://forums.xamarin.com/discussion/26870/changing-root-from-a-navigation-page for login pattern
            //break out of navigationpage    
            App.Current.MainPage = new Dashboard();
        }

    }
}
