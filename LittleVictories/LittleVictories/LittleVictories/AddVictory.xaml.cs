using LittleVictories.Models;
using System;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class AddVictory : ContentPage
    {
        public AddVictory()
        {
            InitializeComponent();   

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            quickPicker.ItemsSource = await App.Database.GetQuickVictoriesAsync();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var selectedQuickVictory = quickPicker.SelectedItem as QuickVictories;
            var quickVictory = selectedQuickVictory.Desc;

            var victory = new TheVictory()
            {
                Title = title.Text ?? quickVictory ?? "No title",
                Quick = quickVictory ?? "N/A",
                Details = details.Text ?? "No details were entered.",
                Date = DateTime.UtcNow
            };

            await App.Database.SaveVictoryAsync(victory);

            await DisplayAlert(
                "You have just celebrated a Victory!",
                "Your Victory has been saved for future celebrations.",
                "Woohoo!"
            );

            await Navigation.PopAsync();
        }

    }
}