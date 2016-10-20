using System;
using System.Collections.Generic;
using System.IO;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;
using System.Diagnostics;

namespace The_Long_Dark_Save_Editor_2
{
	public class Profile
	{
		private string path;

		public List<string> RewiredKeyboardMap { get; set; }
		public List<string> RewiredMouseMap { get; set; }
		public List<object> SandboxRecords { get; set; } // <SandboxRecord> Invalid json!
		public List<UpSell> UpsellsViewed { get; set; }
		public int Version { get; set; }
		public bool ShowTimeOfDaySlider { get; set; }
		public bool ShowFrametime { get; set; }
		public float MasterVolume { get; set; }
		public float SoundVolume { get; set; }
		public float MusicVolume { get; set; }
		public float VoiceVolume { get; set; }
		public int QualityLevel { get; set; }
		public GraphicsMode GraphicsMode { get; set; }
		public Resolution Resolution { get; set; }
		public bool SSAOEnabled { get; set; }
		public MeasurementUnits Units { get; set; }
		public HudPref HudPref { get; set; }
		public bool InvertY { get; set; }
		public bool InvertX { get; set; }
		public bool EnableGamepad { get; set; }
		[Obsolete("Use MouseSensitivityPercentage instead")]
		public float[] MouseSensitivity { get; set; }
		[Obsolete("Use ZoomSensitivityPercentage instead")]
		public float[] ZoomSensitivity { get; set; }
		[Obsolete("Use GamepadCameraSensitivityPercentage instead")]
		public float[] AnalogSticksSensitivity { get; set; }
		public float MouseSensitivityPercentage { get; set; }
		public float ZoomSensitivityPercentage { get; set; }
		public float GamepadCameraSensitivityPercentage { get; set; }
		public bool ConsoleUnlocked { get; set; }
		public float FieldOfView { get; set; }
		public int NumGamesPlayed { get; set; }
		public bool ToggleRun { get; set; }
		public VoicePersona VoicePersona { get; set; }
		public GameRegion StartRegion { get; set; }
		public bool TwelveHourClock { get; set; }
		public Dictionary<string, string> KeyBindings { get; set; }
		public bool VsyncEnabled { get; set; }
		public SubtitlesState SubtitlesState { get; set; }
		public LanguageState LanguageState { get; set; }
		public string Language { get; set; }
		public ExperienceModeType ExperienceMode { get; set; }
		public bool CoastalRegionLocked { get; set; }
		public bool RuralRegionLocked { get; set; }
		public bool WhalingStationRegionLocked { get; set; }
		public bool CrashMountainRegionLocked { get; set; }
		public bool FrameDumperUnlocked { get; set; }
		public bool HasSeenIntroVideo { get; set; }
		public bool NoResumeSave { get; set; }
		public string AllTimeStats { get; set; }
		public bool HasDoneWorldExploreCheck { get; set; }
		public bool HasDoneWorldExploreCheckXbox { get; set; }
		public float BestTimeHunted { get; set; }
		public float BestTimeRescue { get; set; }
		public float BestTimeWhiteout { get; set; }
		public float BestTimeNomad { get; set; }
		public ExperienceModeType MostRecentSandboxMode { get; set; }
		public ExperienceModeType MostRecentChallengeMode { get; set; }
		public float Brightness { get; set; }
		public bool DoneBrightnessAdjustment { get; set; }
		public List<string> UnlockedBadgesViewed { get; set; }
		public FeatsManager Feats { get; set; }

		public Profile(string path)
		{
			this.path = path;

			var bytes = File.ReadAllBytes(path);
			var json = EncryptString.DecompressBytesToString(bytes);
			Debug.WriteLine(json);
			var proxy = Util.DeserializeObject<OptionsState>(json);
			if (proxy == null)
				return;

			RewiredKeyboardMap = proxy.m_RewiredKeyboardMap;
			RewiredMouseMap = proxy.m_RewiredMouseMap;
			SandboxRecords = proxy.m_SandboxRecords;
			UpsellsViewed = proxy.m_UpsellsViewed;
			Version = proxy.m_Version;
			ShowTimeOfDaySlider = proxy.m_ShowTimeOfDaySlider;
			ShowFrametime = proxy.m_ShowFrametime;
			MasterVolume = proxy.m_MasterVolume;
			SoundVolume = proxy.m_SoundVolume;
			MusicVolume = proxy.m_MusicVolume;
			VoiceVolume = proxy.m_VoiceVolume;
			QualityLevel = proxy.m_QualityLevel;
			GraphicsMode = proxy.m_GraphicsMode;
			Resolution = proxy.m_Resolution;
			SSAOEnabled = proxy.m_SSAOEnabled;
			Units = proxy.m_Units;
			HudPref = proxy.m_HudPref;
			InvertY = proxy.m_InvertY;
			InvertX = proxy.m_InvertX;
			EnableGamepad = proxy.m_EnableGamepad;
			MouseSensitivity = proxy.m_MouseSensitivity;
			ZoomSensitivity = proxy.m_ZoomSensitivity;
			AnalogSticksSensitivity = proxy.m_AnalogSticksSensitivity;
			MouseSensitivityPercentage = proxy.m_MouseSensitivityPercentage;
			ZoomSensitivityPercentage = proxy.m_ZoomSensitivityPercentage;
			GamepadCameraSensitivityPercentage = proxy.m_GamepadCameraSensitivityPercentage;
			ConsoleUnlocked = proxy.m_ConsoleUnlocked;
			FieldOfView = proxy.m_FieldOfView;
			NumGamesPlayed = proxy.m_NumGamesPlayed;
			ToggleRun = proxy.m_ToggleRun;
			VoicePersona = proxy.m_VoicePersona;
			StartRegion = proxy.m_StartRegion;
			TwelveHourClock = proxy.m_TwelveHourClock;
			KeyBindings = proxy.m_KeyBindings;
			VsyncEnabled = proxy.m_VsyncEnabled;
			SubtitlesState = proxy.m_SubtitlesState;
			LanguageState = proxy.m_LanguageState;
			Language = proxy.m_Language;
			ExperienceMode = proxy.m_ExperienceMode;
			CoastalRegionLocked = proxy.m_CoastalRegionLocked;
			RuralRegionLocked = proxy.m_RuralRegionLocked;
			WhalingStationRegionLocked = proxy.m_WhalingStationRegionLocked;
			CrashMountainRegionLocked = proxy.m_CrashMountainRegionLocked;
			FrameDumperUnlocked = proxy.m_FrameDumperUnlocked;
			HasSeenIntroVideo = proxy.m_HasSeenIntroVideo;
			NoResumeSave = proxy.m_NoResumeSave;
			AllTimeStats = proxy.m_AllTimeStats;
			HasDoneWorldExploreCheck = proxy.m_HasDoneWorldExploreCheck;
			HasDoneWorldExploreCheckXbox = proxy.m_HasDoneWorldExploreCheckXbox;
			BestTimeHunted = proxy.m_BestTimeHunted;
			BestTimeRescue = proxy.m_BestTimeRescue;
			BestTimeWhiteout = proxy.m_BestTimeWhiteout;
			BestTimeNomad = proxy.m_BestTimeNomad;
			MostRecentSandboxMode = proxy.m_MostRecentSandboxMode;
			MostRecentChallengeMode = proxy.m_MostRecentChallengeMode;
			Brightness = proxy.m_Brightness;
			DoneBrightnessAdjustment = proxy.m_DoneBrightnessAdjustment;
			UnlockedBadgesViewed = proxy.m_UnlockedBadgesViewed;
			Feats = new FeatsManager(proxy.m_FeatsSerialized);
		}

		public void Save()
		{
			var proxy = new OptionsState();

			proxy.m_RewiredKeyboardMap = RewiredKeyboardMap;
			proxy.m_RewiredMouseMap = RewiredMouseMap;
			proxy.m_SandboxRecords = SandboxRecords;
			proxy.m_UpsellsViewed = UpsellsViewed;
			proxy.m_Version = Version;
			proxy.m_ShowTimeOfDaySlider = ShowTimeOfDaySlider;
			proxy.m_ShowFrametime = ShowFrametime;
			proxy.m_MasterVolume = MasterVolume;
			proxy.m_SoundVolume = SoundVolume;
			proxy.m_MusicVolume = MusicVolume;
			proxy.m_VoiceVolume = VoiceVolume;
			proxy.m_QualityLevel = QualityLevel;
			proxy.m_GraphicsMode = GraphicsMode;
			proxy.m_Resolution = Resolution;
			proxy.m_SSAOEnabled = SSAOEnabled;
			proxy.m_Units = Units;
			proxy.m_HudPref = HudPref;
			proxy.m_InvertY = InvertY;
			proxy.m_InvertX = InvertX;
			proxy.m_EnableGamepad = EnableGamepad;
			proxy.m_MouseSensitivity = MouseSensitivity;
			proxy.m_ZoomSensitivity = ZoomSensitivity;
			proxy.m_AnalogSticksSensitivity = AnalogSticksSensitivity;
			proxy.m_MouseSensitivityPercentage = MouseSensitivityPercentage;
			proxy.m_ZoomSensitivityPercentage = ZoomSensitivityPercentage;
			proxy.m_GamepadCameraSensitivityPercentage = GamepadCameraSensitivityPercentage;
			proxy.m_ConsoleUnlocked = ConsoleUnlocked;
			proxy.m_FieldOfView = FieldOfView;
			proxy.m_NumGamesPlayed = NumGamesPlayed;
			proxy.m_ToggleRun = ToggleRun;
			proxy.m_VoicePersona = VoicePersona;
			proxy.m_StartRegion = StartRegion;
			proxy.m_TwelveHourClock = TwelveHourClock;
			proxy.m_KeyBindings = KeyBindings;
			proxy.m_VsyncEnabled = VsyncEnabled;
			proxy.m_SubtitlesState = SubtitlesState;
			proxy.m_LanguageState = LanguageState;
			proxy.m_Language = Language;
			proxy.m_ExperienceMode = ExperienceMode;
			proxy.m_CoastalRegionLocked = CoastalRegionLocked;
			proxy.m_RuralRegionLocked = RuralRegionLocked;
			proxy.m_WhalingStationRegionLocked = WhalingStationRegionLocked;
			proxy.m_CrashMountainRegionLocked = CrashMountainRegionLocked;
			proxy.m_FrameDumperUnlocked = FrameDumperUnlocked;
			proxy.m_HasSeenIntroVideo = HasSeenIntroVideo;
			proxy.m_NoResumeSave = NoResumeSave;
			proxy.m_AllTimeStats = AllTimeStats;
			proxy.m_HasDoneWorldExploreCheck = HasDoneWorldExploreCheck;
			proxy.m_HasDoneWorldExploreCheckXbox = HasDoneWorldExploreCheckXbox;
			proxy.m_BestTimeHunted = BestTimeHunted;
			proxy.m_BestTimeRescue = BestTimeRescue;
			proxy.m_BestTimeWhiteout = BestTimeWhiteout;
			proxy.m_BestTimeNomad = BestTimeNomad;
			proxy.m_MostRecentSandboxMode = MostRecentSandboxMode;
			proxy.m_MostRecentChallengeMode = MostRecentChallengeMode;
			proxy.m_Brightness = Brightness;
			proxy.m_DoneBrightnessAdjustment = DoneBrightnessAdjustment;
			proxy.m_UnlockedBadgesViewed = UnlockedBadgesViewed;
			proxy.m_FeatsSerialized = Feats.Serialize();
			File.WriteAllBytes(path, EncryptString.CompressStringToBytes(Util.SerializeObject(proxy)));

		}
	}
}
