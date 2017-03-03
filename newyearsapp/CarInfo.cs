using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace newyearsapp
{
    //car info page (edit, transfer, button) and for sale slider
    class CarInfo : ContentPage
    {
        Switch forSaleSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };
        Button transferButton = new Button { Text = "Transfer"};

        public CarInfo()
        {

            StackLayout s = new StackLayout
            {
                Children =
                {
                    forSaleSwitch, transferButton
                }
            };
            Content = s;
        }
    }
}
