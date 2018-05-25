using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomlyForms.Views;

using Xamarin.Forms;

namespace MomlyForms
{
    public partial class App : Application
	{
        public event Action ShouldTakePicture = () => { };
        public Command commandTakePicture;
        public static App Instance;

        public App ()
		{
			InitializeComponent();
            Instance = this;
            commandTakePicture = new Command(o => ShouldTakePicture());
            MainPage = new NavigationPage(new MainMenuPage());
            
		}

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
