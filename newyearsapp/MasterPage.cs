using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace newyearsapp
{
    class MasterPage : ContentPage
    {
  
        public ListView listView;
        public TextCell logoffCell = new TextCell { Text = "Logoff" };
        
        public MasterPage()
        {
            
            List<MasterPageItem> people = new List<MasterPageItem>
            {
                new MasterPageItem("Home", new DateTime(1975, 1, 15), Color.Aqua, "icon.png", typeof(HomePage)),
                new MasterPageItem("Account", new DateTime(1976, 2, 20), Color.Black, "icon.png", typeof(AccountPage)),
                // ...etc.,...
                new MasterPageItem("Preferences", new DateTime(1987, 1, 10), Color.Purple, "icon.png", typeof(SettingsPage)),
                new MasterPageItem("Tools", new DateTime(1988, 2, 5), Color.Red, "icon.png", typeof(ToolsPage)),
                new MasterPageItem("Test REST", new DateTime(1977, 2, 5), Color.Green, "icon.png", typeof(TodoListPage))
            };

            List<MasterPageItem> masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem("Home", new DateTime(1975, 1, 15), Color.Aqua, "icon.png", typeof(HomePage)));
            masterPageItems.Add(new MasterPageItem("Account", new DateTime(1976, 2, 20), Color.Black, "icon.png", typeof(AccountPage)));
            // home, account, preferences, tools

            // last three are to do
            /*
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Leaderboards",
                IconSource = "todo.png",
                TargetType = typeof(LeaderboardsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Rewards Center",
                IconSource = "reminders.png",
                TargetType = typeof(RewardsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Share",
                //IconSource = "reminders.png"                
                TargetType = typeof(MarketPlace)
            });
            */

            /*
            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Name");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");                                        
                    return imageCell;
                    
                    //var textCell = new TextCell();
                    //textCell.SetBinding(TextCell.TextProperty, "Name");
                    //textCell.SetBinding(TextCell.DetailProperty, "Title");
                    //textCell.Text = "text value";
                    //textCell.Detail = "TextCell Detail";
                    //return textCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };            
    */
            
            // Create the ListView.
            listView = new ListView
            {
                // Source of data items.
                ItemsSource = people,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty,
                        new Binding("Birthday", BindingMode.OneWay,
                            null, null, "Born {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                }
                        }
                    };
                })
            };
            
            Padding = new Thickness(0, 40, 0, 0);
            Icon = "icon.png";
            Title = "Personal Organiser";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                listView,
                new TableView {
                            Root = new TableRoot {
                                new TableSection () { //TableSection constructor takes title as an optional parameter
                                    //new SwitchCell {Text = "New Voice Mail"},
                                    logoffCell
                                }
                            },
                            Intent = TableIntent.Menu,                                                       
                        },
                new Label { Text="hello" }
                
                }            
            };
        }        
    }
}
    