using Foundation;
using System;
using System.IO;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace LittleVictories.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            string dbPath = FileAccessHelper.GetLocalFilePath("LittleVictories.db3");
			Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
        public class FileAccessHelper
        {
            public static string GetLocalFilePath(string filename)
            {
                string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                string dbPath = Path.Combine(libFolder, filename);

                CopyDatabaseIfNotExists(dbPath);

                return dbPath;
            }

            private static void CopyDatabaseIfNotExists(string dbPath)
            {
                if (!File.Exists(dbPath))
                {
                    var existingDb = NSBundle.MainBundle.PathForResource("LittleVictories", "db3");
                    File.Copy(existingDb, dbPath);
                }
            }
        }
    }
}