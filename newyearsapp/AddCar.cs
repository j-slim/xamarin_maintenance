using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class AddCar : ContentPage
    {
        Button addCarButton = new Button { Text = "Add" };        
        public AddCar()
        {

            Entry profileName = new Entry { Placeholder="Choose a name to identify this car"};

            DateTime now = new DateTime();
            int currentYear = now.Year;

            Stepper modelYear = new Stepper {
                Value = currentYear,//get the current year
                Minimum = 1908,
                Maximum = currentYear,//get the current year
                Increment = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Picker brands = new Picker { Title = "Choose manufacturer", VerticalOptions = LayoutOptions.CenterAndExpand };
            brands.Items.Add("Honda");
            brands.Items.Add("Toyota");
            brands.SelectedIndexChanged += Brands_SelectedIndexChanged;

            Picker models = new Picker { Title = "Choose model", VerticalOptions = LayoutOptions.CenterAndExpand };
            models.Items.Add("Pilot");
            models.Items.Add("CR-V");
            models.Items.Add("Civic");
            models.Items.Add("Accord");
            models.SelectedIndexChanged += Models_SelectedIndexChanged;

            Picker trim = new Picker { Title = "Choose trim", VerticalOptions = LayoutOptions.CenterAndExpand };
            trim.Items.Add("EX");
            trim.Items.Add("EX-L");
            trim.Items.Add("LX");

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Add Car" },
                    profileName,brands,models,trim,modelYear,
                    new TableView {
                            Root = new TableRoot {
                            new TableSection ("Identification") { //TableSection constructor takes title as an optional parameter
                                new EntryCell { Placeholder="License Plate", Label="Enter License Plate", Text="Existing License Plate" },
                                new EntryCell { Placeholder="VIN", Label="Enter VIN", Text="Existing VIN" }
                        //new SwitchCell {Text = "New Voice Mail"},                        
                    }                            
                            },                            
                    Intent = TableIntent.Form
                    },
                    addCarButton
                }            
            };
            addCarButton.Clicked += AddCarButton_Clicked;
        }

        private void Models_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load appropriate trims from DB
            //throw new NotImplementedException();
        }

        private void Brands_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load appropriate models from DB, clear trim
            //throw new NotImplementedException();
        }

        async void AddCarButton_Clicked(object sender, EventArgs e)
        {
            // validation - check selectedindex for brand,model,trim != -1

            await Navigation.PopAsync();
        }
    }
}
