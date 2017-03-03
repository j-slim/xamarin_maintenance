using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class ToolsPage : ContentPage
    {
        public ToolsPage()
        {

            var buttonLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            buttonLayout.Children.Add(new Button()
            {
                Text = "Transfer",
                //TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center
            });

            Content = new StackLayout
            {
                Children = {                    
                    new Label { Text = "Export CSV" },
                    new TableView {
                        Root = new TableRoot {
                            new TableSection ("Section 1") { //TableSection constructor takes title as an optional parameter
                                new TextCell {Text = "Import"}
                                //new SwitchCell {Text = "New Mail", On = true}
                            },
                            new TableSection ("Car transfer") { //TableSection constructor takes title as an optional parameter
                                new TextCell {Text = "Transfer"},
                                // select car
                                new EntryCell { Placeholder="Email of person to transfer to" },
                                // after button clicked, show a code to give to receiver
                                new ViewCell { View = buttonLayout }
                                //new SwitchCell {Text = "New Mail", On = true}
                            }
                        },
                        Intent = TableIntent.Settings
                    }
                }
            };
        }
    }
}
