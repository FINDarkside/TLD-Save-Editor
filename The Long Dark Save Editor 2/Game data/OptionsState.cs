using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    public class ProfileState
    {
        public List<string> m_RewiredKeyboardMap { get; set; }
        public List<string> m_RewiredMouseMap { get; set; }
        public List<SandboxRecord> m_SandboxRecords { get; set; }
        public List<UpSell> m_UpsellsViewed { get; set; }
        public int m_Version { get; set; }
        public bool m_ShowTimeOfDaySlider { get; set; }
        public bool m_ShowFrametime { get; set; }
        public float m_MasterVolume { get; set; }
        public float m_SoundVolume { get; set; }
        public float m_MusicVolume { get; set; }
        public float m_VoiceVolume { get; set; }
        public int m_QualityLevel { get; set; }
        public GraphicsMode m_GraphicsMode { get; set; }
        public int m_DisplayNumber { get; set; }
        public Resolution m_Resolution { get; set; }
        public bool m_SSAOEnabled { get; set; }
        public MeasurementUnits m_Units { get; set; }
        public HudPref m_HudPref { get; set; }
        public bool m_InvertY { get; set; }
        public bool m_InvertX { get; set; }
        public bool m_LockMouseToScreen { get; set; }
        public bool m_EnableGamepad { get; set; }
        [Obsolete("Use m_MouseSensitivityPercentage instead")]
        public float[] m_MouseSensitivity { get; set; }
        [Obsolete("Use m_ZoomSensitivityPercentage instead")]
        public float[] m_ZoomSensitivity { get; set; }
        [Obsolete("Use m_GamepadCameraSensitivityPercentage instead")]
        public float[] m_AnalogSticksSensitivity { get; set; }
        public float m_MouseSensitivityPercentage { get; set; }
        public float m_ZoomSensitivityPercentage { get; set; }
        public float m_GamepadCameraSensitivityPercentage { get; set; }
        public bool m_ConsoleUnlocked { get; set; }
        public float m_FieldOfView { get; set; }
        public int m_NumGamesPlayed { get; set; }
        public VoicePersona m_VoicePersona { get; set; }
        public GameRegion m_StartRegion { get; set; }
        public Dictionary<string, string> m_KeyBindings { get; set; }
        public bool m_VsyncEnabled { get; set; }
        public SubtitlesState m_SubtitlesState { get; set; }
        public LanguageState m_LanguageState { get; set; }
        public string m_Language { get; set; }
        public bool m_CoastalRegionLocked { get; set; }
        public bool m_RuralRegionLocked { get; set; }
        public bool m_WhalingStationRegionLocked { get; set; }
        public bool m_CrashMountainRegionLocked { get; set; }
        public bool m_FrameDumperUnlocked { get; set; }
        public bool m_HasSeenIntroVideo { get; set; }
        public bool m_NoResumeSave { get; set; }
        public string m_AllTimeStats { get; set; }
        public float m_BestTimeHunted { get; set; }
        public float m_BestTimeRescue { get; set; }
        public float m_BestTimeWhiteout { get; set; }
        public float m_BestTimeNomad { get; set; }
        public float m_BestTimeHunted2 { get; set; }
        public ExperienceModeType m_MostRecentSandboxMode { get; set; }
        public ExperienceModeType m_MostRecentChallengeMode { get; set; }
        public ExperienceModeType m_MostRecentEpisodeMode { get; set; }
        public float m_Brightness { get; set; }
        public bool m_DoneBrightnessAdjustment { get; set; }
        public List<string> m_UnlockedBadgesViewed { get; set; }
        public HashSet<string> m_CinematicsViewed { get; set; }
        public string m_FeatsSerialized { get; set; }
        public string m_EpisodeManagerSerialized { get; set; }
        public string m_QualityLevelSettingsSerialized { get; set; }
        public bool m_DisableClickHold { get; set; }
        public int m_AutosaveMinutes { get; set; }
        public string m_NewGameCustomModeString { get; set; }
        public bool m_FoundAllCachesEpisodeOne { get; set; }
        public bool m_FoundAllCachesEpisodeTwo { get; set; }
        public List<Achievement> m_UnlockedAchievements { get; set; }
        public bool m_ReduceCameraMotion { get; set; }
        [Serializable]
        public class MaineMenuViewedState
        {
            public bool m_ChallengesMenuViewed { get; set; }
            public bool m_LogsMenuViewed { get; set; }
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
        public List<string> m_CollectibleNotesList { get; set; }
        public List<CairnInfo> m_CollectibleCairnInfoList { get; set; }
        public List<AuroraScreenInfo> m_CollectibleAuroraScreenInfoList { get; set; }

    }

    public class StatContainer
    {
        public int[] m_CachedHashIds { get; set; }
        public Dictionary<int, string> m_StatsDictionary { get; set; }
        public int m_NumBurntHousesInCoastal { get; set; }
        public bool m_HasDoneCoastalBurntHouseCheck { get; set; }
        public bool m_HasDoneCorrectBurntHouseCheck { get; set; }
    }
}
