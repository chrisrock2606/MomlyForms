using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using MomlyForms.Models;
using MomlyForms.Data;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateWalkPage : ContentPage
	{
        double moveValue = 0.001d;
        public double[] Location;
        public CreateWalkPage ()
		{
			InitializeComponent ();
            Title = "Opret aktivitet";

            Location = WalkPage.CurrentLocation;

            AddPin();
        }

        private async void AddPin()
        {
            if (Location== null || Location[0] + Location[1] == 0)
            {
                Location = await Data.Location.GetLocation();
                WalkPage.CurrentLocation = Location;
            }

            var position = new Position(Location[0], Location[1]); // Latitude, Longitude
            var pin = new Pin
            {
                Label = "Dig",
                Type = PinType.Place,
                Position = position,
            };
            walkMap.Pins.Add(pin);
            walkMap.MoveToRegion(MapSpan.FromCenterAndRadius((position), new Distance(1000)));
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (Location == null)
                return;

            Button button = (Button)sender;
            if (button.Id.Equals(downBtn.Id))
            { Location[0] -= moveValue; }

            else if (button.Id.Equals(upBtn.Id))
            { Location[0] += moveValue; }

            else if (button.Id.Equals(leftBtn.Id))
            { Location[1] -= moveValue; }

            else if (button.Id.Equals(rightBtn.Id))
            { Location[1] += moveValue; }

            var position = new Position(Location[0], Location[1]);
            walkMap.Pins.Clear();
            var pin = new Pin
            {
                Label = "Dig",
                Type = PinType.Place,
                Position = position,
            };
            walkMap.Pins.Add(pin);
            walkMap.MoveToRegion(MapSpan.FromCenterAndRadius((position), new Distance(1000)));
        }

        private async void submitBtn_Clicked(object sender, EventArgs e)
        {
            TimeSpan t = timePicker.Time;
            DateTime d = datePicker.Date;
            DateTime appointmentTime = d + t;

            string time = appointmentTime.ToString("HH:mm");
            string date = appointmentTime.ToString("ddd");
            string dateTimeString = date + "dag kl. " + time;


            var selection = await DisplayAlert("Ny aftale?", "Ønsker du at oprette en aftale " + dateTimeString + "?", "OK", "Annuller");

            if (selection == true)
            {
                MomlyFriend momlyFriend = new MomlyFriend();
                momlyFriend.Age = 35;
                momlyFriend.BabyAgeInMonth = 8;
                momlyFriend.UserName = "TestUser";
                momlyFriend.PlannedWalk = appointmentTime;
                momlyFriend.Latitude = Location[0];
                momlyFriend.Longtitude = Location[1];

                RestService restService = new RestService();
                string response = await restService.CreateMomlyActivity(momlyFriend);

                await Navigation.PopAsync();
            }

            if (selection == false)
                return;
        }
    }
}