using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class ForgotPW : ContentPage
    {
        Entry email = new Entry
        {
            Placeholder = "Enter your email"
        };
        Button submitButton = new Button
        {
            BackgroundColor = Color.Aqua,
            Text = "Reset Password",
            Font = Font.SystemFontOfSize(NamedSize.Large),
            BorderWidth = 1,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };        
        public ForgotPW()
        {
            submitButton.Clicked += SubmitButton_Clicked;
            Content = new StackLayout
            {
                Children = {
                    email, submitButton
                }
            };
        }

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            // show modal popup saying they will receive a temporary password by email
            await DisplayAlert("Alert", "You will receive a tempoarary password by email", "OK");
            await Navigation.PopAsync();
        }
    }
}
