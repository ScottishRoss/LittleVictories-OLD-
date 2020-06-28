using System;
using System.IO;
using Xamarin.Forms;
using LittleVictories.Data;

namespace LittleVictories
{
    public partial class App : Application
    {
        static LittleVictoriesDatabase database;

        public static LittleVictoriesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LittleVictoriesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new YourVictories());
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