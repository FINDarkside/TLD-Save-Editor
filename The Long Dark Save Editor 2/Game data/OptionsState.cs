using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
	public class OptionsState
	{
		public List<string> m_RewiredKeyboardMap = new List<string>();
		public List<string> m_RewiredMouseMap = new List<string>();
		public List<SandBoxRecord> m_SandboxRecords; //SandboxRecord
		public List<UpSell> m_UpsellsViewed = new List<UpSell>();
		public int m_Version;
		public bool m_ShowTimeOfDaySlider;
		public bool m_ShowFrametime;
		public float m_MasterVolume;
		public float m_SoundVolume;
		public float m_MusicVolume;
		public float m_VoiceVolume;
		public int m_QualityLevel;
		public GraphicsMode m_GraphicsMode;
		public Resolution m_Resolution;
		public bool m_SSAOEnabled;
		public MeasurementUnits m_Units;
		public HudPref m_HudPref;
		public bool m_InvertY;
		public bool m_InvertX;
		public bool m_EnableGamepad;
		[Obsolete("Use m_MouseSensitivityPercentage instead")]
		public float[] m_MouseSensitivity;
		[Obsolete("Use m_ZoomSensitivityPercentage instead")]
		public float[] m_ZoomSensitivity;
		[Obsolete("Use m_GamepadCameraSensitivityPercentage instead")]
		public float[] m_AnalogSticksSensitivity;
		public float m_MouseSensitivityPercentage;
		public float m_ZoomSensitivityPercentage;
		public float m_GamepadCameraSensitivityPercentage;
		public bool m_ConsoleUnlocked;
		public float m_FieldOfView;
		public int m_NumGamesPlayed;
		public bool m_ToggleRun;
		public VoicePersona m_VoicePersona;
		public GameRegion m_StartRegion;
		public bool m_TwelveHourClock;
		public Dictionary<string, string> m_KeyBindings;
		public bool m_VsyncEnabled;
		public SubtitlesState m_SubtitlesState;
		public LanguageState m_LanguageState;
		public string m_Language;
		public ExperienceModeType m_ExperienceMode;
		public bool m_CoastalRegionLocked;
		public bool m_RuralRegionLocked;
		public bool m_WhalingStationRegionLocked;
		public bool m_CrashMountainRegionLocked;
		public bool m_FrameDumperUnlocked;
		public bool m_HasSeenIntroVideo;
		public bool m_NoResumeSave;
		public string m_AllTimeStats;
		public bool m_HasDoneWorldExploreCheck;
		public bool m_HasDoneWorldExploreCheckXbox;
		public float m_BestTimeHunted;
		public float m_BestTimeRescue;
		public float m_BestTimeWhiteout;
		public float m_BestTimeNomad;
		public ExperienceModeType m_MostRecentSandboxMode;
		public ExperienceModeType m_MostRecentChallengeMode;
		public float m_Brightness;
		public bool m_DoneBrightnessAdjustment;
		public List<string> m_UnlockedBadgesViewed;
		public string m_FeatsSerialized;

		[Serializable]
		public class MaineMenuViewedState
		{
			public bool m_ChallengesMenuViewed;
			public bool m_LogsMenuViewed;
		}
	}

	public class Resolution
	{
		public int m_Width { get; set; }
		public int m_Height { get; set; }
		public int m_RefreshRate { get; set; }
	}

	public class FeatsManagerSaveData
	{
		public string m_Feat_BookSmartsSerialized { get; set; }
		public string m_Feat_ColdFusionSerialized { get; set; }
		public string m_Feat_EfficientMachineSerialized { get; set; }
		public string m_Feat_FireMasterSerialized { get; set; }
		public string m_Feat_FreeRunnerSerialized { get; set; }
		public string m_Feat_SnowWalkerSerialized { get; set; }
	}

	public class FeatsManager
	{

		public Feat_BookSmartsSaveData BookSmarts { get; set; }
		public Feat_ColdFusionSaveData ColdFusion { get; set; }
		public Feat_EfficientMachineSaveData EfficientMachine { get; set; }
		public Feat_FireMasterSaveData FireMaster { get; set; }
		public Feat_FreeRunnerSaveData FreeRunner { get; set; }
		public Feat_SnowWalkerSaveData SnowWalker { get; set; }


		public FeatsManager(string json)
		{
			var proxy = Util.DeserializeObject<FeatsManagerSaveData>(json);
			if (proxy == null)
				return;


			BookSmarts = Util.DeserializeObjectOrDefault<Feat_BookSmartsSaveData>(proxy.m_Feat_BookSmartsSerialized);
			ColdFusion = Util.DeserializeObjectOrDefault<Feat_ColdFusionSaveData>(proxy.m_Feat_ColdFusionSerialized);
			EfficientMachine = Util.DeserializeObjectOrDefault<Feat_EfficientMachineSaveData>(proxy.m_Feat_EfficientMachineSerialized);
			FireMaster = Util.DeserializeObjectOrDefault<Feat_FireMasterSaveData>(proxy.m_Feat_FireMasterSerialized);
			FreeRunner = Util.DeserializeObjectOrDefault<Feat_FreeRunnerSaveData>(proxy.m_Feat_FreeRunnerSerialized);
			SnowWalker = Util.DeserializeObjectOrDefault<Feat_SnowWalkerSaveData>(proxy.m_Feat_SnowWalkerSerialized);
		}

		public string Serialize()
		{
			var proxy = new FeatsManagerSaveData();

			proxy.m_Feat_BookSmartsSerialized = Util.SerializeObject(BookSmarts);
			proxy.m_Feat_ColdFusionSerialized = Util.SerializeObject(ColdFusion);
			proxy.m_Feat_EfficientMachineSerialized = Util.SerializeObject(EfficientMachine);
			proxy.m_Feat_FireMasterSerialized = Util.SerializeObject(FireMaster);
			proxy.m_Feat_FreeRunnerSerialized = Util.SerializeObject(FreeRunner);
			proxy.m_Feat_SnowWalkerSerialized = Util.SerializeObject(SnowWalker);

			return Util.SerializeObject(proxy);
		}
	}

	public class Feat_BookSmartsSaveData
	{
		public int m_HoursResearch { get; set; }
	}

	public class Feat_ColdFusionSaveData
	{
		public float m_ElapsedDays { get; set; }
		public float m_HoursAccumulator { get; set; }
	}

	public class Feat_EfficientMachineSaveData
	{
		public float m_ElapsedHours { get; set; }
		public float m_HoursAccumulator { get; set; }
	}

	public class Feat_FireMasterSaveData
	{
		public int m_NumFiresStarted { get; set; }
	}

	public class Feat_FreeRunnerSaveData
	{
		public float m_ElapsedKilometers { get; set; }
		public float m_MetersAccumulator { get; set; }
	}

	public class Feat_SnowWalkerSaveData
	{
		public float m_ElapsedKilometers { get; set; }
		public float m_MetersAccumulator { get; set; }
	}

	public class SandBoxRecord
	{
		public string m_SandboxName { get; set; }
		public float m_ElapsedHours { get; set; }
		public DateTime m_EndDate { get; set; }
		public GameRegion m_StartRegion { get; set; }
		public string m_EndRegion { get; set; }
		public ExperienceModeType m_ExperienceModeType { get; set; }
		public VoicePersona m_VoicePersona { get; set; }
		public string m_CauseOfDeathLocId { get; set; }
		public string m_GeneralNotes { get; set; }
		public List<LogDayInfo> m_LogDayInfoList { get; set; }
		// Currently seems to always be empty
		public List<object> m_CollectibleList { get; set; }
		public StatContainer m_Stats { get; set; }
	}

	public class StatContainer
	{
		public Dictionary<int, string> m_StatsDictionary { get; set; }
		public int m_NumBurntHousesInCoastal { get; set; }
		public bool m_HasDoneCoastalBurntHouseCheck { get; set; }
		public bool m_HasDoneCorrectBurntHouseCheck { get; set; }
	}
}
