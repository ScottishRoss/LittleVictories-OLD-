using System;
using System.Globalization;
using Xamarin.Forms;

namespace LittleVictories.Behaviors
{    public class LimitedLengthEntryBehavior : Behavior<Entry>
    {
        public int TextLength { get; set; } = 140;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            if (e.NewTextValue.Length >= TextLength)
                ((Entry)sender).Text = e.OldTextValue;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
        }
    }
    public class TextLengthValidationValueConverter : IValueConverter
    {
        int _wordCount = 139;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? value : _wordCount - System.Convert.ToInt32(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}