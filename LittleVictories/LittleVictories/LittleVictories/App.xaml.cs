using System;
using System.Collections.Generic;
using System.IO;
using LittleVictories.Data;
using LittleVictories.Models;
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
                if (database == null)
                {
                    database = new LittleVictoriesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LittleVictories.db3"));
                }
                return database;
            }
        }
        public class ExportFont
        {
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