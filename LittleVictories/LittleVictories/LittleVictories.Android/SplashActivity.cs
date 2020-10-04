using Android.App;
using AndroidX.AppCompat.App;
using Android.OS;

namespace LittleVictories.Droid

{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + nameof(SplashActivity);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
            OverridePendingTransition(0, 0);
        }

        protected override void OnResume()
        {
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }
    }
}