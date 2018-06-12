using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MomlyForms.Data;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TakePicturePage : ContentPage
	{
        public static TakePicturePage Instance;
        ImageSource ImageSource;
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        public TakePicturePage ()
		{
			InitializeComponent ();
            Instance = this;
            Title = "Kalorietæller";
            takePictureButton.Command = App.Instance.commandTakePicture;
            foodImage.Source = ImageSource.FromResource("MomlyForms.Assets.Images.food.jpg", typeof(TakePicturePage));
        }

        private async void Evaluation()
        {
            await evaluationLabel.FadeTo(0, 300);
            evaluationLabel.Text = "Billedet evalueres...";
            await evaluationLabel.FadeTo(1, 300);

            RestService restService = new RestService();
            string responseText = await restService.RefreshPictureEvaluation();

            await evaluationLabel.FadeTo(0, 300);
            evaluationLabel.Text = responseText;
            await evaluationLabel.FadeTo(1, 300);

            if (!evaluationLabel.GestureRecognizers.Contains(tapGestureRecognizer))            
                AddTapFunctionality();           
        }

        private void AddTapFunctionality()
        {
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Evaluation();
            };
            evaluationLabel.GestureRecognizers.Add(tapGestureRecognizer);
        }

        public void ShowImage(string filepath)
        {
            ImageSource = ImageSource.FromFile(filepath);
            foodImage.Source = ImageSource;
            Evaluation();
        }
    }
}