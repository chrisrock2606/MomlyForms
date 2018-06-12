using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomlyForms.Data;
using MomlyForms.Models;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WalkPage : ContentPage
	{
        List<MomlyFriend> momlyFriends = new List<MomlyFriend>();
        public static double[] CurrentLocation { get; set; }
        public WalkPage()
        {
            Title = "Aktiviteter";
            InitializeComponent();
            GetCurrentLocation();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddPins();
        }

        public async void AddPins()
        {
            RestService restService = new RestService();
            momlyFriends = await restService.RefreshMomlyFriends();

            walkMap.Pins.Clear();
            foreach (var friend in momlyFriends)
            {
                var position = new Position(friend.Latitude, friend.Longtitude); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = friend.UserName,
                    Address = GetDateString(friend.PlannedWalk)
                };
                walkMap.Pins.Add(pin);
                pin.Clicked += Pin_Clicked;
            }
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            var pin = (Pin)sender;

            await descriptionLabel.FadeTo(0, 300);
            descriptionLabel.Text = GetText(pin.Label);
            await descriptionLabel.FadeTo(1, 300);
        }

        private string GetText(string userName)
        {
            MomlyFriend friend = momlyFriends.Where(x => x.UserName == userName).FirstOrDefault();

            StringBuilder builder = new StringBuilder();
            builder.Append($"{friend.UserName} er {friend.Age} år. ");
            if (friend.BabyAgeInMonth > -1)
                builder.Append($"Hendes baby er {friend.BabyAgeInMonth} måneder.");

            string time = " kl. " + friend.PlannedWalk.ToString("HH:mm");
            string date = friend.PlannedWalk.ToString("ddd") + "dag";

            string dateTimeString = date + time;
            builder.Append("\n" + friend.UserName + " ønsker en at gå tur med " + dateTimeString);

            return builder.ToString();
        }

        private string GetDateString(DateTime dateTime)
        {
            string text = "Går tur " + dateTime.ToString("ddd kl. HH:mm");
            return text;
        }

        private void PlusIcon_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateWalkPage());
        }

        public async void GetCurrentLocation()
        {
            if (CurrentLocation == null)
            {
                CurrentLocation = await Location.GetLastKnownLocation();
            }
            CurrentLocation = await Location.GetLocation();
        }
    }
}