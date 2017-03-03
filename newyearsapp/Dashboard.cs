using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class Dashboard : MasterDetailPage
    {
        MasterPage masterPage;
        public Dashboard()
        {
            this.Icon = "icon.png";
            Label header = new Label
            {
                Text = "MasterDetailPage",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            masterPage =  new MasterPage();            
            masterPage.listView.ItemSelected += OnItemSelected;
            masterPage.logoffCell.Tapped += LogoffCell_Tapped;
            Master = masterPage;
            
            Detail = new NavigationPage(new HomePage());            
            MasterBehavior = MasterBehavior.SplitOnLandscape;
        }

        private void LogoffCell_Tapped(object sender, EventArgs e)
        {
            //Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Main)));
            App.Current.MainPage = new NavigationPage(new Main());
            masterPage.listView.SelectedItem = null;
            IsPresented = false;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }            
        }
        
    }
}
