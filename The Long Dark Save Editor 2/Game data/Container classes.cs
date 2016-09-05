using Newtonsoft.Json;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
	public class WindSaveData
	{
		public int m_Version { get; set; }
		public WindDirection m_windDirectionProxy { get; set; }
		public WindStrength m_windStrengthProxy { get; set; }
		public float m_windMPHProxy { get; set; }
		public bool m_FirstPhaseSetProxy { get; set; }
		public float m_PhaseElapsedTODSecondsProxy { get; set; }
		public float m_PhaseDurationHoursProxy { get; set; }
		public float m_TransitionTimeTODSecondsProxy { get; set; }
		public ActiveWindSettings m_ActiveSettings { get; set; }
		public ActiveWindSettings m_SourceSettings { get; set; }
		public ActiveWindSettings m_TargetSettings { get; set; }

		public WindSaveData(string data)
		{
			var proxy = JsonConvert.DeserializeObject<WindSaveDataProxy>(data);
			m_Version = proxy.m_Version;
			m_windDirectionProxy = proxy.m_windDirectionProxy;
			m_windMPHProxy = proxy.m_windMPHProxy;
			m_FirstPhaseSetProxy = proxy.m_FirstPhaseSetProxy;
			m_PhaseElapsedTODSecondsProxy = proxy.m_PhaseElapsedTODSecondsProxy;
			m_PhaseDurationHoursProxy = proxy.m_PhaseDurationHoursProxy;
			m_TransitionTimeTODSecondsProxy = proxy.m_TransitionTimeTODSecondsProxy;
			m_ActiveSettings = JsonConvert.DeserializeObject<ActiveWindSettings>(proxy.m_ActiveSettingsSerialized);
			m_SourceSettings = JsonConvert.DeserializeObject<ActiveWindSettings>(proxy.m_SourceSettingsSerialized);
			m_TargetSettings = JsonConvert.DeserializeObject<ActiveWindSettings>(proxy.m_TargetSettingsSerialized);
		}

		public string Serialize()
		{
			var proxy = new WindSaveDataProxy();
			proxy.m_Version = m_Version;
			proxy.m_windDirectionProxy = m_windDirectionProxy;
			proxy.m_windMPHProxy = m_windMPHProxy;
			proxy.m_FirstPhaseSetProxy = m_FirstPhaseSetProxy;
			proxy.m_PhaseElapsedTODSecondsProxy = m_PhaseElapsedTODSecondsProxy;
			proxy.m_PhaseDurationHoursProxy = m_PhaseDurationHoursProxy;
			proxy.m_TransitionTimeTODSecondsProxy = m_TransitionTimeTODSecondsProxy;
			proxy.m_ActiveSettingsSerialized = Util.SerializeObject(m_ActiveSettings);
			proxy.m_ActiveSettingsSerialized = Util.SerializeObject(m_ActiveSettings);
			proxy.m_ActiveSettingsSerialized = Util.SerializeObject(m_ActiveSettings);
			return Util.SerializeObject(this);
		}
	}
}
