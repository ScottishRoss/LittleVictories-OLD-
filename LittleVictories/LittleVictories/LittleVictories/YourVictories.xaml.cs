using System;
using System.Collections.Generic;
using Xamarin.Forms;
using LittleVictories.Models;

[assembly: ExportFont("blackjack-webfont.ttf", Alias = "BlackJack")]

namespace LittleVictories
{
    public partial class YourVictories : ContentPage
    {
        public YourVictories()
        {
            InitializeComponent();
        }
        public class ExportFont
        {
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            VictoryListView.ItemsSource = await App.Database.GetVictoriesAsync();
        }

        async void OnVictoryAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVictory()
            {
                BindingContext = new TheVictory()
            });


        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ViewVictory()
                {
                    BindingContext = e.SelectedItem as TheVictory
                });
            }
        }
        
    }
}