using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleVictories.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LittleVictories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewVictory : ContentPage
    {
        public ViewVictory()
        {
            InitializeComponent();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var victory = (Victory)BindingContext;
            await App.Database.DeleteVictoryAsync(victory);
            await Navigation.PopAsync();
        }
    }
}