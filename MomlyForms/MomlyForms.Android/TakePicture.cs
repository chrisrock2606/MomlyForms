using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MomlyForms.Droid;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using System.Threading.Tasks;
using Android.Provider;

[assembly: Dependency(typeof(TakePicture))]
namespace MomlyForms.Droid
{
    public class TakePicture : IPicture
    {
        public Task<Stream> GetImageStreamAsync()
        {

            Intent intent = new Intent(MediaStore.ActionImageCapture);

            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(MainActivity.imgFile));

            MainActivity.Instance.StartActivityForResult(intent, MainActivity.TakePictureId);

            MainActivity.Instance.TakePictureTaskCompletionSource = new TaskCompletionSource<Stream>();

            return MainActivity.Instance.TakePictureTaskCompletionSource.Task;
        }
    }
}