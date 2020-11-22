using System;
using LittleVictories.Models;

namespace LittleVictories.Views
{
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
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