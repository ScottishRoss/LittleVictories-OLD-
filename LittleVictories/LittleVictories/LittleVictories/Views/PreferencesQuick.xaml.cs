using System;
using System.Collections.Generic;
using LittleVictories.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LittleVictories.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesQuick
    {
        public PreferencesQuick()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            QuickVictoriesListView.ItemsSource = await App.Database.GetQuickVictoriesEditableAsync();

            if (((List<QuickVictories>)QuickVictoriesListView.ItemsSource).Count == 0)
            {
                QuickVictoriesListView.IsVisible = false;
                EmptyMessage.IsVisible = true;
            }
            else
            {
                QuickVictoriesListView.IsVisible = true;
                EmptyMessage.IsVisible = false;
            }
        }
        async void OnQVListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                BindingContext = e.SelectedItem as QuickVictories;

                bool answer = await DisplayAlert(
                    "Are you sure you want to delete?",
                        "Are you sure you want to delete this Quick Victory?",
                        "Delete",
                        "No"
                    );

                if (answer)
                {
                    var quickVictory = (QuickVictories)BindingContext;

                    await App.Database.DeleteQuickVictoryAsync(quickVictory);
                    await Navigation.PushAsync(new PreferencesQuick());
                };

            }
        }

        async void OnAddQuickVictoryClicked(object sender, EventArgs e)
        {
            string desc = await DisplayPromptAsync("Add Quick Victory", "What's the name of the Quick Victory?", "Save", "Cancel");

            if (string.IsNullOrWhiteSpace(desc))
            {
                await DisplayAlert("Please enter a value", "We didn't catch that :(", "Okay");
            }
            else
            {
                var quickVictory = new QuickVictories
                {
                    Desc = CapitalizeFirstLetterOfString(desc)
                };

                await App.Database.SaveQuickVictoryAsync(quickVictory);

                await Navigation.PushAsync(new PreferencesQuick());
            }
        }

        private string CapitalizeFirstLetterOfString(string String)
        {
            if (!String.IsNullOrEmpty(String))
            {
                if (String.Length == 1)
                {
                    String = char.ToUpper(String[0]).ToString();
                }
                else
                {
                    String = char.ToUpper(String[0]) + String.Substring(1);
                }
            }

            return String;
        }
    }
}