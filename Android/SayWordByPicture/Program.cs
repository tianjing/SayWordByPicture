using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;

namespace SayWordByPicture
{
    [Activity(Label = "SayWordByPicture",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@style/Theme.NoTitleBar",
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape,
        LaunchMode = Android.Content.PM.LaunchMode.SingleInstance,
        ConfigurationChanges = Android.Content.PM.ConfigChanges.KeyboardHidden)]
    public class Activity1 : AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create our OpenGL view, and display it
            Game1.Activity = this;
            var g = new Game1();
            SetContentView(g.Window);
            g.Run();
        }
    }
}
