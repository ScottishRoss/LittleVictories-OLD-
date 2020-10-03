using LittleVictories.Models;
using System;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class ViewVictory : ContentPage
    {
        public ViewVictory()
        {
            InitializeComponent();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert(
                    "Delete Confirmation",
                    "Are you sure you want to delete your Victory?",
                    "Yes",
                    "No"
                );

            if (answer)
            {
                var victory = (TheVictory)BindingContext;

                await App.Database.DeleteVictoryAsync(victory);
                await Navigation.PopAsync();
            };
        }
    }
}