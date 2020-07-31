using LittleVictories.Models;
using System;
using Xamarin.Forms;

namespace LittleVictories
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        /* protected override async void OnAppearing()
         {
             base.OnAppearing();x
         } */

        async void OnVictoryAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVictory()
            {
                BindingContext = new TheVictory()
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