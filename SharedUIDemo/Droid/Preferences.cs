using System;
using Android.Content;
using Xamarin.Forms;
using SharedUIDemo.Droid;
using System.Collections.ObjectModel;

[assembly: Dependency (typeof(Preferences))]
namespace SharedUIDemo.Droid
{
	public class Preferences : IPlatformPreferences
	{
		private const string PREFS_NAME = "SharedUIDemo";
		private const string NOTES = "NOTES";

		private ISharedPreferences getPreferences ()
		{
			Context context = MainActivity.APPLICATION_CONTEXT;
			return context.GetSharedPreferences (PREFS_NAME, FileCreationMode.Private);
		}

		public Collection<string> getNotes ()
		{
			ISharedPreferences preferences = getPreferences ();
			string prefNotes = preferences.GetString (NOTES, "");
			Collection<string> notes = new Collection<string> ();

			string[] arrayNotes = prefNotes.Split (new char[]{ '|' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string note in arrayNotes) {
				notes.Add (note);
			}

			return notes;
		}

		public void saveNotes (Collection<string> notes)
		{
			string prefNotes = "";
			foreach (string note in notes) {
				prefNotes += note + "|";
			}

			ISharedPreferences preferences = getPreferences ();
			ISharedPreferencesEditor editor = preferences.Edit ();
			editor.PutString (NOTES, prefNotes);
			editor.Commit ();
		}

		public void clearNotes ()
		{
			ISharedPreferences preferences = getPreferences ();
			ISharedPreferencesEditor editor = preferences.Edit ();
			editor.Remove (NOTES);
			editor.Commit ();
		}
	}
}

