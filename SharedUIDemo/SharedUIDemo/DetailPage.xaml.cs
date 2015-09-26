using Xamarin.Forms;

namespace SharedUIDemo
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage (string note)
		{
			InitializeComponent ();
			noteLabel.Text = note;
		}
	}
}

