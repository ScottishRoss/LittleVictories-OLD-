
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LittleVictories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preferences : ContentPage
    {
        public Preferences()
        {
            InitializeComponent();
        }

        async void OnQuickVictoriesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesQuick()
            {
            });
        }
        async void OnTestNotificationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestNotification()
            {
            });
        }
    }
}