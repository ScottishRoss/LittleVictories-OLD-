using System.Collections.Generic;
using LittleVictories.Models;
using Xamarin.Forms;

namespace LittleVictories.Views
{
    public partial class YourVictories
    {
        public YourVictories()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            VictoryListView.ItemsSource = await App.Database.GetVictoriesAsync();

            if (((List<TheVictory>)VictoryListView.ItemsSource).Count == 0)
            {
                VictoryListView.IsVisible = false;
                EmptyMessage.IsVisible = true;
            }
            else
            {
                VictoryListView.IsVisible = true;
                EmptyMessage.IsVisible = false;
            }
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