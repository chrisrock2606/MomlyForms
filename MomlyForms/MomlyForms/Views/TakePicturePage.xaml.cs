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
	public partial class TakePicturePage : ContentPage
	{
        public static TakePicturePage Instance;
        ImageSource ImageSource;

        public TakePicturePage ()
		{
			InitializeComponent ();
            Instance = this;
            Title = "Kalorietæller";
            takePictureButton.Command = App.Instance.commandTakePicture;
            foodImage.Source = ImageSource.FromResource("MomlyForms.Assets.Images.food.jpg", typeof(TakePicturePage));
        }

        public void ShowImage(string filepath)
        {
            ImageSource = ImageSource.FromFile(filepath);
            foodImage.Source = ImageSource;
        }
    }
}