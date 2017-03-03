using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class SettingsPage : ContentPage
    {
        public SettingsPage()
        {


            // UNITS
            Picker distance = new Picker { Title = "Distance Units", VerticalOptions = LayoutOptions.CenterAndExpand };
            distance.Items.Add("Kilometres");
            distance.Items.Add("Miles");

            Picker fuel = new Picker { Title = "Fuel Volume Units", VerticalOptions = LayoutOptions.CenterAndExpand };
            fuel.Items.Add("Litres");
            fuel.Items.Add("Gallons");

            Picker currency = new Picker { Title = "Currency", VerticalOptions = LayoutOptions.CenterAndExpand };
            currency.Items.Add("CAD");
            currency.Items.Add("USD");
            currency.Items.Add("Euro");
            currency.Items.Add("Pound");
            currency.Items.Add("Peso");
            currency.Items.Add("Renminbi");
            currency.Items.Add("Yen");

            var unitsLayout = new StackLayout {
                Orientation = StackOrientation.Horizontal
            };
            unitsLayout.Children.Add(distance);
            unitsLayout.Children.Add(fuel);
            unitsLayout.Children.Add(currency);

            // REMINDERS

            Stepper distAdvance = new Stepper
            {
                Value = 15,
                Minimum = 0,
                Maximum = 1000,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
                        
            Stepper daysAdvance = new Stepper
            {
                Value = 15,
                Minimum = 0,
                Maximum = 365,
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            
            TimePicker reminderTimeOfDay = new TimePicker { Time = new TimeSpan(17, 0, 0) };

            var remindersLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            remindersLayout.Children.Add(distAdvance);
            remindersLayout.Children.Add(daysAdvance);
            remindersLayout.Children.Add(reminderTimeOfDay);

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "App Preferences" },
                                       new TableView {
                            Root = new TableRoot {
                            new TableSection ("Units") { //TableSection constructor takes title as an optional parameter
                                new ViewCell { View=unitsLayout }
                        //new SwitchCell {Text = "New Voice Mail"},
                        //new SwitchCell {Text = "New Mail", On = true}
                    },
                           new TableSection ("Reminders")
                            {
                               new ViewCell { View=remindersLayout }
                            }
                            },
                    Intent = TableIntent.Settings
                    }
                }
            };
        }
    }
}
