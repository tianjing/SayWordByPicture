using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Xna.Framework;
using Android.Content.PM;
using Android.Views.InputMethods;
using System;

namespace SayWordByPicture
{
	[Activity(Label = "SayWordByPicture",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@style/Theme.NoTitleBar",
	ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape,
        LaunchMode = Android.Content.PM.LaunchMode.SingleInstance,
	          WindowSoftInputMode= SoftInput.AdjustPan,
	          // don`t Destroy Activity1
	          ConfigurationChanges =
	          ConfigChanges.Orientation)]
	public class Activity1 : AndroidGameActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create our OpenGL view, and display it
			Game1.Activity = this;
			var g = new Game1 ();
			SetContentView (g.Window);
			g.Run ();
		//	g.Window.KeyPress += new EventHandler<View.KeyEventArgs>(Activity_KeyPress);
		}
		//ConfigurationChanges code
		public override void OnConfigurationChanged (Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
		}
	//	void Activity_KeyPress(object sender, View.KeyEventArgs e) {
			
	//		char c = (char)e.Event.UnicodeChar;
			
	//		if (e.Event.Action == KeyEventActions.Down)
	//			System.Diagnostics.Debug.WriteLine("Key: " + c);
	//	}
	}
}
