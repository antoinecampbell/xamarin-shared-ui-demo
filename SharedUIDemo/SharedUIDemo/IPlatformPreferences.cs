using System.Collections.ObjectModel;

namespace SharedUIDemo
{
	public interface IPlatformPreferences
	{
		Collection<string> getNotes ();

		void saveNotes (Collection<string> notes);

		void clearNotes ();
	}
}

