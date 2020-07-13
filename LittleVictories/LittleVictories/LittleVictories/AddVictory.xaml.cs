using System;
using Xamarin.Forms;
using LittleVictories.Models;

namespace LittleVictories
{
    public partial class AddVictory : ContentPage
    {
        public AddVictory()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var victory = new TheVictory()
            {
                Title = title.Text,
                Quick = (string)quick.SelectedItem ?? "N/A",
                Details = details.Text ?? "No details were entered.",
                Date = DateTime.UtcNow
            };

            await App.Database.SaveVictoryAsync(victory);
            await Navigation.PopAsync();
        }

    }
}