
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
	public class BootSaveGameFormat : BindableBase
	{
		private string _sceneName;
		public string m_SceneName
		{
			get { return _sceneName; }
			set
			{
				SetProperty(ref _sceneName, value);
			}
		}
		public int m_Version { get; set; }
	}
}
