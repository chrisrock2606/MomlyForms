using System;
using MomlyForms.Views;
using MomlyForms.Models;
using System.Threading.Tasks;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Java.IO;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android;
using System.IO;

namespace MomlyForms.Droid
{
    [Activity(Label = "MomlyForms", Icon = "@drawable/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static string StatusbarColor { get; set; }
        internal static readonly Java.IO.File imgFile = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new App());

            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#75b41b"));

        }

        public static readonly int TakePictureId = 1000;

        public TaskCompletionSource<Stream> TakePictureTaskCompletionSource { set; get; }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == TakePictureId)
            {
                if (resultCode == Result.Ok)
                {
                    Android.Net.Uri uri = Android.Net.Uri.FromFile(imgFile);

                    Stream stream = ContentResolver.OpenInputStream(uri);
                    TakePictureTaskCompletionSource.SetResult(stream);
                }
                else
                {
                    TakePictureTaskCompletionSource.SetResult(null);
                }
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (ContextCompat.CheckSelfPermission(this, "ACCESS_FINE_LOCATION") != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Permission Granted!!!");
            }
        }
    }
}

