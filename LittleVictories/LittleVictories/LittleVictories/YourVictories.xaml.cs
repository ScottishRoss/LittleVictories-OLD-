using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using LittleVictories.Models;

namespace LittleVictories
{
    public partial class YourVictories : ContentPage
    {
        public YourVictories()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            victoryView.ItemsSource = await App.Database.GetVictoriesAsync();
        }

        async void OnVictoryAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVictory
            {
                BindingContext = new Victory()
            });
        }

        async void OnVictoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ViewVictory
                {
                    BindingContext = e.SelectedItem as Victory
                });
            }
        }
    }
}