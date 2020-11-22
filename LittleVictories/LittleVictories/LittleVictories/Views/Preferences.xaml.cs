using System;
using Xamarin.Forms.Xaml;

namespace LittleVictories.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preferences
    {
        public Preferences()
        {
            InitializeComponent();
        }

        async void OnQuickVictoriesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesQuick());
        }
    }
}