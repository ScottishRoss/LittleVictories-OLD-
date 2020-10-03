using LittleVictories.Data;
using PCLStorage;
using System;
using System.IO;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class App : Application
    {
        static LittleVictoriesDatabase _database;

        public static LittleVictoriesDatabase Database
        {
            get
            {
                try
                {
                    if (_database == null)
                    {
                        var dbName = "LittleVictories.db3";
                        var sqliteFilename = "LittleVictories.db3";

                        IFolder folder = FileSystem.Current.LocalStorage;
                        var path = PortablePath.Combine(folder.Path, sqliteFilename);
                        _database = new LittleVictoriesDatabase(Path.Combine(path));
                    }
                    return _database;
                }
                catch (Exception ex)
                {
                    var sqliteFilename = "LittleVictories.db3";

                    IFolder folder = FileSystem.Current.LocalStorage;
                    var path = PortablePath.Combine(folder.Path, sqliteFilename);
                    Directory.CreateDirectory(path);
                    _database = new LittleVictoriesDatabase(Path.Combine(path));
                }
                return _database;
            }
        }
           
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());
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