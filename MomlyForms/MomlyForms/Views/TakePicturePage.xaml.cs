using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MomlyForms.Data;
using System.IO;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TakePicturePage : ContentPage
	{
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        public TakePicturePage ()
		{
			InitializeComponent ();
            Title = "Kalorietæller";
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

        private async void takePictureButton_Clicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPicture>().GetImageStreamAsync();

            if (stream != null)
                foodImage.Source = ImageSource.FromStream(() => stream); //expression lambda

            Evaluation();
        }
    }
}