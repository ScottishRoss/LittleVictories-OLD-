using LittleVictories.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Globalization;

namespace LittleVictories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesQuick : ContentPage
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
                    "Delete Confirmation",
                        "Are you sure you want to delete your Victory?",
                        "Yes",
                        "No"
                    );

                if (answer)
                {
                    var quickVictory = (QuickVictories)BindingContext;

                    await App.Database.DeleteQuickVictoryAsync(quickVictory);
                    await Navigation.PushAsync(new PreferencesQuick()
                    {
                    });
                };

            }
        }

        async void OnAddQuickVictoryClicked(object sender, System.EventArgs e)
        {
            string desc = await DisplayPromptAsync("Add Quick Victory", "Enter the Quick Victory here.");
            TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;

            if (string.IsNullOrWhiteSpace(desc))
            {
                await DisplayAlert("Error", "Please enter a value.", "Ok");
            }
            else
            {
                var quickVictory = new QuickVictories()
                {
                    Desc = textInfo.ToTitleCase(desc)
                };

                await App.Database.SaveQuickVictoryAsync(quickVictory);

                await Navigation.PushAsync(new PreferencesQuick()
                {
                });
            }
        }
    }
}