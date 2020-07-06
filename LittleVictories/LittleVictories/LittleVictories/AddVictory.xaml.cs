using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.Threading.Tasks;
using LittleVictories.Models;

namespace LittleVictories
{
    public partial class AddVictory : ContentPage
    {
        public event EventHandler<TheVictory> SaveVictory;

        TheVictory Victory { get; set; }

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
                Details = details.Text ?? "No details entered.",
                Date = DateTime.UtcNow
            };

            await App.Database.SaveVictoryAsync(victory);
            await Navigation.PopAsync();
        }

    }
}