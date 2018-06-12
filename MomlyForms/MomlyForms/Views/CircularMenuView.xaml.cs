using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CircularMenuView : ContentView
	{
        private bool isAnimating = false;
        private uint scaleSize = 80;
        private uint animationDelay = 200;

        public CircularMenuView()
        {
            InitializeComponent();
            LoadImages();
            ShowMenuOptions();

            InitializeMenuOptions();

            bmiLabel.Text = "BMI: \n23,54";
        }

        private void InitializeMenuOptions()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {

                var sender = (Image)s;
                var source = sender.Source;

                if (source.Equals(SW.Source))                
                    Navigation.PushAsync(new TakePicturePage());                

                else if (source.Equals(NE.Source))
                    Navigation.PushAsync(new NursePage());

                else if (source.Equals(SE.Source))
                    Navigation.PushAsync(new WalkPage());

                else if (source.Equals(NW.Source))
                    Navigation.PushAsync(new CheckListPage());                
            };

            NW.GestureRecognizers.Add(tapGestureRecognizer);
            NE.GestureRecognizers.Add(tapGestureRecognizer);
            SW.GestureRecognizers.Add(tapGestureRecognizer);
            SE.GestureRecognizers.Add(tapGestureRecognizer);
            N.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void AnimateWhenTapped(Image sender)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                sender.RotateTo(720, 300);
            });
        }

        private async void ShowMenuOptions()
        {
            isAnimating = true;

            Device.BeginInvokeOnMainThread(() =>
            {
                 circle.ScaleTo(120, animationDelay*5, Easing.BounceOut);
                 bmiLabel.FadeTo(1, animationDelay*5);
            });

            await N.ScaleTo(scaleSize, animationDelay, Easing.BounceOut);
            await NE.ScaleTo(scaleSize, animationDelay, Easing.BounceOut);
            await SE.ScaleTo(scaleSize, animationDelay, Easing.BounceOut);
            await SW.ScaleTo(scaleSize, animationDelay, Easing.BounceOut);
            await NW.ScaleTo(scaleSize, animationDelay, Easing.BounceOut);
            isAnimating = false;
        }


        private void LoadImages()
        {
            NW.Source = ImageSource.FromResource("MomlyForms.Assets.Images.assignment.png", typeof(CircularMenuView));
            NE.Source = ImageSource.FromResource("MomlyForms.Assets.Images.child.png", typeof(CircularMenuView));
            SW.Source = ImageSource.FromResource("MomlyForms.Assets.Images.camera.png", typeof(CircularMenuView));
            SE.Source = ImageSource.FromResource("MomlyForms.Assets.Images.walk.png", typeof(CircularMenuView));
            N.Source = ImageSource.FromResource("MomlyForms.Assets.Images.person.png", typeof(CircularMenuView));
            circle.Source = ImageSource.FromResource("MomlyForms.Assets.Images.circle.png", typeof(CircularMenuView));
        }
    }
}