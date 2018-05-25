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
        public WalkPage()
        {
            InitializeComponent();
            AddPins();

        }

        public async void AddPins()
        {
            RestService restService = new RestService();
            momlyFriends = await restService.RefreshMomlyFriends();

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

            builder.Append("\n" + friend.UserName + " ønsker en at gå tur med " + friend.PlannedWalk.ToString("ddd kl. HH:mm"));

            return builder.ToString();
        }

        private string GetDateString(DateTime dateTime)
        {
            string text = "Går tur " + dateTime.ToString("ddd kl. HH:mm");
            return text;
        }
    }
}