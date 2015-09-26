using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SharedUIDemo.Droid
{
	[Activity (Label = "SharedUIDemo.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		public static Context APPLICATION_CONTEXT;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			APPLICATION_CONTEXT = ApplicationContext;

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

