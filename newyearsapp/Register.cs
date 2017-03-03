using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class Register : ContentPage
    {
        public Register()
        {
            Entry email = new Entry { Placeholder="Email"};
            Entry password = new Entry { Placeholder="Password"};
            Entry pwConfirm = new Entry { Placeholder = "Confirm Password"};
            Button registerButton = new Button { Text = "Register"};
            registerButton.Clicked += RegisterButton_Clicked;
            Content = new StackLayout
            {
                
                Children = {
                    new Label { Text = "Register" }, email, password, pwConfirm, registerButton
                }
            };
        }

        async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert","Thank you for registering!","OK");
            await Navigation.PopAsync();
        }
    }
}
