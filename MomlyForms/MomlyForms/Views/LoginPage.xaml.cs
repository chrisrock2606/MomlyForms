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
        bool authenticated = false;
		public LoginPage ()
		{
			InitializeComponent ();
		}


        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            //if (isEmailEmpty || isPasswordEmpty)
            //{

            //}
            //else
            //{
            Navigation.PushAsync(new MainMenuPage());
            //}
        }

        private void forgotPasswordButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}