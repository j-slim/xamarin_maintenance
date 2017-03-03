using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class AccountPage : ContentPage
    {

        public AccountPage()
        {
            Button saveButton = new Button { Text = "Save"};
            saveButton.Clicked += SaveButton_Clicked;
            // defined a layout for a custom viewcell containing image and text
            var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            layout.Children.Add(new Image() { Source = "icon.png" });
            layout.Children.Add(new Label()
            {
                Text = "left",
                TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center
            });
            layout.Children.Add(new Label()
            {
                Text = "right",
                TextColor = Color.FromHex("#503026"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
            });
            layout.Children.Add(saveButton);

            var pwLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };            
            pwLayout.Children.Add(new Label()
            {
                Text = "Password:",
                //TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center                
            });
            pwLayout.Children.Add(new Entry()
            {
                //VerticalOptions = LayoutOptions.Center,
                Placeholder = "PW",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            });

            var newPWLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            pwLayout.Children.Add(new Label()
            {
                Text = "New Password:",
                //TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center
            });
            newPWLayout.Children.Add(new Entry()
            {
                //VerticalOptions = LayoutOptions.Center,
                Placeholder = "New PW",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            });

            var confirmPWLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            pwLayout.Children.Add(new Label()
            {
                Text = "Confirm Password:",
                //TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center
            });
            confirmPWLayout.Children.Add(new Entry()
            {
                //VerticalOptions = LayoutOptions.Center,
                Placeholder = "Confirm PW",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            });

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Account Settings" },
                        new TableView {
                            Root = new TableRoot {
                                new TableSection ("Section Title") { //TableSection constructor takes title as an optional parameter
                                    //new SwitchCell {Text = "New Voice Mail"},
                                    new EntryCell { Text = "Existing Country", Label="Country: " },
                                    new EntryCell { Text = "Existing Province", Label="Province: " },
                                    new EntryCell { Text = "Existing City", Label="City: " },
                                    new EntryCell { Text = "Existing Email", Label="Email: " },
                                    new ViewCell() { View = pwLayout },
                                    new ViewCell() { View = newPWLayout },
                                    new ViewCell() { View = confirmPWLayout },
                                    new ViewCell() {View = layout}
                                }
                            },
                            Intent = TableIntent.Settings
                        }
                }
            };
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert","Your preferences have been saved","OK");
        }
    }
}
