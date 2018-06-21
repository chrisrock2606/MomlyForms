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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            Title = "Log ind";
			InitializeComponent ();
		}

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainMenuPage(), this);
            await Navigation.PopAsync();
        }
    }
}