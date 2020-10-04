using System;
using LittleVictories.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LittleVictories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestNotification : ContentPage
    {
        readonly INotificationManager _notificationManager;
        int _notificationNumber = 0;

        public TestNotification()
        {
            InitializeComponent();

            _notificationManager = DependencyService.Get<INotificationManager>();
            _notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }
        void OnScheduleClick(object sender, EventArgs e)
        {
            _notificationNumber++;
            var title = $"Local Notification #{_notificationNumber}";
            var message = $"You have now received {_notificationNumber} notifications!";
            _notificationManager.ScheduleNotification(title, message);
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                stackLayout.Children.Add(msg);
            });
        }
    }
}