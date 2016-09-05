using System.Collections.Generic;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
	public static class SaveGameManager
	{
		public class SaveInfo
		{
			public string Name { get; set; }
			public string Path { get; set; }
		}

		public static List<SaveInfo> Saves { get; set; }
	}
}
