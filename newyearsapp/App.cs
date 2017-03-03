using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace newyearsapp
{
    public class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; } // for rest testing

        public static ITextToSpeech Speech { get; set; } // for rest testing
        public App()
        {
            //content.BackgroundColor = Color.Orange;
            TodoManager = new TodoItemManager(new RestService()); // for rest testing
            MainPage = new NavigationPage(new Main());

            //MainPage = new NavigationPage(new TodoListPage()); // for rest testing
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
