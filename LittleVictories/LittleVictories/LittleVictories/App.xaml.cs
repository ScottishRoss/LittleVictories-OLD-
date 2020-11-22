using LittleVictories.Data;
using PCLStorage;
using System;
using System.IO;
using LittleVictories.Views;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class App
    {
        static LittleVictoriesDatabase database;

        public static LittleVictoriesDatabase Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        var dbName = "LittleVictories.db3";
                        var sqliteFilename = "LittleVictories.db3";

                        IFolder folder = FileSystem.Current.LocalStorage;
                        string path = PortablePath.Combine(folder.Path, sqliteFilename);
                        database = new LittleVictoriesDatabase(Path.Combine(path));
                    }
                return database;
                }
                catch (Exception ex)
                {
                    var dbName = "LittleVictories.db3";
                    var sqliteFilename = "LittleVictories.db3";

                    IFolder folder = FileSystem.Current.LocalStorage;
                    string path = PortablePath.Combine(folder.Path, sqliteFilename);
                    Directory.CreateDirectory(path);
                    database = new LittleVictoriesDatabase(Path.Combine(path));
                }
            return database;
            }
        }
           
        public App()
        {
            var splashPage = new NavigationPage(new SplashPage());
            MainPage = splashPage;

            InitializeComponent();
        }

        protected override void OnStart()
        {
            
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