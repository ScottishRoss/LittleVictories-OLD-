using LittleVictories.Models;
using System;

namespace LittleVictories
{
    public partial class AddVictory
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

        async void IsTitleOrPickerEmpty(object sender, EventArgs e)
        {
            if (title.Text == null && quickPicker.SelectedItem == null)
            {
                await DisplayAlert(
                    "Please enter some details",
                    "Enter a Victory Title or select a Quick Victory.",
                    "Okay"
                );
            }
            else
            {
                OnSaveButtonClicked(sender, e);
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            string quickVictory;

            if (quickPicker.SelectedItem == null)
            {
                quickVictory = "N/A";
            }
            else
            {
                var selectedQuickVictory = quickPicker.SelectedItem as QuickVictories;
                quickVictory = selectedQuickVictory.Desc;
            }

            var victoryTitle = CapitalizeFirstLetterOfString(title.Text);
            var victoryDetails = CapitalizeFirstLetterOfString(details.Text);

            var victory = new TheVictory()
            {
                Title = victoryTitle ?? quickVictory ?? "No title",
                Quick = quickVictory,
                Details = victoryDetails ?? "No details were entered.",
                Date = DateTime.UtcNow
            };

            await App.Database.SaveVictoryAsync(victory);

            await DisplayAlert(
                "You have just celebrated a Victory!",
                "Your Victory has been saved for future celebration.",
                "Woohoo!"
            );

            await Navigation.PopAsync();
        }

        // TODO: Need to move this method somewhere where PreferenceQuick can access it.
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