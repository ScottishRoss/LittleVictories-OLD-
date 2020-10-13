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
            string quickVictory;

            if (quickPicker.SelectedItem == null)
            {
                quickVictory = "N/A";
            } else
            {
                var selectedQuickVictory = quickPicker.SelectedItem as QuickVictories;
                quickVictory = selectedQuickVictory.Desc;
            }

            var victoryTitle = CapitalizeFirstLetterOfString(title.Text) ?? quickVictory ?? "No title";
            var victoryDetails = CapitalizeFirstLetterOfString(details.Text) ?? "No details were entered.";

            var victory = new TheVictory()
            {
                Title = victoryTitle,
                Quick = quickVictory,
                Details = victoryDetails,
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

        public string CapitalizeFirstLetterOfString(string String)
        {
            if (String.Length == 1)
                String = char.ToUpper(String[0]).ToString();
            else
                String = char.ToUpper(String[0]) + String.Substring(1);

            return String;
        }
    }
}