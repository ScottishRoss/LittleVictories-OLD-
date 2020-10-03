using LittleVictories.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Waiting some time
            await Task.Delay(2000);

            // Start animation
            await Task.WhenAll(
                SplashGrid.FadeTo(0, 2000),
                Logo.ScaleTo(10, 2000)
            );
        }

        async void OnVictoryAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVictory()
            {
                BindingContext = new TheVictory()
            });
        }

        async void OnPreferencesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Preferences()
            {
            });
        }

        async void OnViewVictoriesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YourVictories()
            {
            });
        }

    }
}