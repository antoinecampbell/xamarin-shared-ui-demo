using Foundation;
using Xamarin.Forms;
using SharedUIDemo.iOS;
using System.Collections.ObjectModel;

[assembly: Dependency (typeof(Preferences))]
namespace SharedUIDemo.iOS
{
	public class Preferences : IPlatformPreferences
	{
		private const string NOTES = "NOTES";

		public Collection<string> getNotes ()
		{
			Collection<string> notes = new Collection<string> ();
			NSObject[] arrayNotes = NSUserDefaults.StandardUserDefaults.ArrayForKey (NOTES);
			if (arrayNotes != null) {
				foreach (NSObject arrayNote in arrayNotes) {
					notes.Add (arrayNote.ToString ());
				}
			}

			return notes;
		}

		public void saveNotes (Collection<string> notes)
		{
			NSMutableArray arrayNotes = new NSMutableArray ();
			for (int i = 0; i < notes.Count; i++) {
				arrayNotes.Add (new NSString (notes [i]));
			}
			NSUserDefaults.StandardUserDefaults.SetValueForKey (arrayNotes, new NSString (NOTES));
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}

		public void clearNotes ()
		{
			NSUserDefaults.StandardUserDefaults.RemoveObject (NOTES);
			NSUserDefaults.StandardUserDefaults.Synchronize ();
		}
	}
}

