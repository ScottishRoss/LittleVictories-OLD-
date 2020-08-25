using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using System;
using System.IO;

namespace LittleVictories.Droid
{
    [Activity(Label = "LittleVictories", Icon = "@drawable/icon", Theme = "@style/MainTheme",
        MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("LittleVictories.db3");
            base.OnCreate(savedInstanceState);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            
            MobileAds.Initialize(ApplicationContext, "ca-app-pub-7100257291492276~4761790441");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public class FileAccessHelper
        {
            public static string GetLocalFilePath(string filename)
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string dbPath = Path.Combine(path, filename);

                CopyDatabaseIfNotExists(dbPath);

                return dbPath;
            }

            private static void CopyDatabaseIfNotExists(string dbPath)
            {
                try
                {
                    if (!File.Exists(dbPath))
                    {
                        using (var br = new BinaryReader(Application.Context.Assets.Open("LittleVictories.db3")))
                        {
                            using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                            {
                                byte[] buffer = new byte[2048];
                                int length = 0;
                                while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    bw.Write(buffer, 0, length);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}