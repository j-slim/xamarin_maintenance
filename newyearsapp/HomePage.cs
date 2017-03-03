using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class HomePage : ContentPage
    {
        //dashboard - drop down to select car.Store selected car.On selection or if car selected on load, show some car info with record list
        //show a metro style tile menu at top with selected tile disabled
        Button addCarButton = new Button
        {
            BackgroundColor = Color.White,
            Text = "Add a car",
            Font = Font.SystemFontOfSize(NamedSize.Large),
            BorderWidth = 0
            //HorizontalOptions = LayoutOptions.Center,
            //VerticalOptions = LayoutOptions.CenterAndExpand
        };                
        public HomePage()
        {
            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            //controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    //Url = "http://192.168.0.3:3000/photo",
                    Url = "https://sheltered-mountain-13217.herokuapp.com/photo"                                  
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            
            Content = new StackLayout
            {
                // row of buttons
                // content area at bottom for lists. Switch list in cell depending on button pressed
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    
                    addCarButton,
                        new Entry { Text="Existing odometer",Placeholder="Odometer"},
                        new Label { Text = "Maintenance records, parts, fillups, reports"}
                    }
            };
            addCarButton.Clicked += AddCarButton_Clicked;
            Content = webView;
        }

        async void AddCarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCar(), false);
        }
    }
}
