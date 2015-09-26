using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace SharedUIDemo
{
	public partial class MainPage : ContentPage
	{
		ObservableCollection<string> notes;
		IPlatformPreferences prefs;

		public MainPage ()
		{
			InitializeComponent ();
			prefs = DependencyService.Get<IPlatformPreferences> ();
			if (prefs == null) {
				notes = new ObservableCollection<string> ();
			} else {
				notes = new ObservableCollection<string> (prefs.getNotes ());
			}

			listView.ItemsSource = notes;
			listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				if (e.SelectedItem == null)
					return;

				Navigation.PushAsync (new DetailPage (e.SelectedItem.ToString ()));
				listView.SelectedItem = null;
			};

			add.Clicked += (object sender, EventArgs e) => {
				notes.Add (note.Text);
				note.Text = "";
				if (prefs != null) {
					prefs.saveNotes (notes);
				}
			};
		}

		public void OnDelete (object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			string item = (string)mi.CommandParameter;
			notes.Remove (item);
		}

		public void OnClearNotes (object sender, EventArgs e)
		{
			notes.Clear ();
			if (prefs != null) {
				prefs.saveNotes (notes);
			}
		}
	}
}

