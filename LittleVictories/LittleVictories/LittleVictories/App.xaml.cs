using LittleVictories.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class App : Application
    {
        static LittleVictoriesDatabase database;

        public static LittleVictoriesDatabase Database
        {
            get
            {
                return database ?? (database = new LittleVictoriesDatabase(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "LittleVictories.db3")));
            }
        }
        public App()
        {
            InitializeComponent();
            var splashPage = new NavigationPage(new SplashPage());
            MainPage = splashPage;
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