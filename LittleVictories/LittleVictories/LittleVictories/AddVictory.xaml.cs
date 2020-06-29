using System;
using LittleVictories.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LittleVictories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVictory : ContentPage
    {

        public AddVictory()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var victory = (Victory)BindingContext;
            victory.Date = DateTime.UtcNow;
            await App.Database.SaveVictoryAsync(victory);
            await Navigation.PopAsync();
        }
    }
}