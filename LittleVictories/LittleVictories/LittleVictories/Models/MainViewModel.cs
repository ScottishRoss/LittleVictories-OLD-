using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LittleVictories.Models
{
    class MainViewModel
    {
        public class QuickVictoriesViewModel
        {
            public ObservableCollection<QuickVictories> QuickVictories { get; set; }

            public QuickVictories SelectedDesc { get; set; }
        }
    }
}
