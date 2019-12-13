using System;
using System.Collections.Generic;
using The_Long_Dark_Save_Editor_2.Serialization;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    public class ProfileState
    {
        public List<string> m_RewiredKeyboardMap { get; set; }
        public List<string> m_RewiredMouseMap { get; set; }
        public List<SandboxRecord> m_SandboxRecords { get; set; }
        public List<EnumWrapper<UpSell>> m_UpsellsViewed { get; set; }
        public List<bool> m_DaysCompleted4DON { get; set; }
        public List<bool> m_DaysCompleted4DON2019 { get; set; }
        public int m_Version { get; set; }
        public bool m_ShowTimeOfDaySlider { get; set; }
        public bool m_ShowFrametime { get; set; }
        public float m_MasterVolume { get; set; }
        public float m_SoundVolume { get; set; }
        public float m_MusicVolume { get; set; }
        public float m_VoiceVolume { get; set; }
        public int m_QualityLevel { get; set; }
        public EnumWrapper<GraphicsMode> m_GraphicsMode { get; set; }
        public int m_DisplayNumber { get; set; }
        public Resolution m_Resolution { get; set; }
        public bool m_SSAOEnabled { get; set; }
        public EnumWrapper<MeasurementUnits> m_Units { get; set; }
        public EnumWrapper<HudPref> m_HudPref { get; set; }
        public EnumWrapper<HudSize> m_HudSize { get; set; }
        public EnumWrapper<HudType> m_HudType { get; set; }
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
        public EnumWrapper<VoicePersona> m_VoicePersona { get; set; }
        public EnumWrapper<GameRegion> m_StartRegion { get; set; }
        public Dictionary<string, string> m_KeyBindings { get; set; }
        public bool m_VsyncEnabled { get; set; }
        public EnumWrapper<SubtitlesState> m_SubtitlesState { get; set; }
        public EnumWrapper<LanguageState> m_LanguageState { get; set; }
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
        public float m_BestTimeArchivist { get; set; }
        public EnumWrapper<ExperienceModeType> m_MostRecentSandboxMode { get; set; }
        public EnumWrapper<ExperienceModeType> m_MostRecentChallengeMode { get; set; }
        public EnumWrapper<ExperienceModeType> m_MostRecentEpisodeMode { get; set; }
        public float m_Brightness { get; set; }
        public bool m_DoneBrightnessAdjustment { get; set; }
        public List<string> m_UnlockedBadgesViewed { get; set; }
        public HashSet<string> m_CinematicsViewed { get; set; }
        [Deserialize("m_FeatsSerialized", true)]
        public FeatsManagerSaveData Feats { get; set; }
        public string m_EpisodeManagerSerialized { get; set; }
        public string m_QualityLevelSettingsSerialized { get; set; }
        public bool m_DisableClickHold { get; set; }
        public int m_AutosaveMinutes { get; set; }
        public string m_NewGameCustomModeString { get; set; }
        public bool m_FoundAllCachesEpisodeOne { get; set; }
        public bool m_FoundAllCachesEpisodeTwo { get; set; }
        public List<EnumWrapper<Achievement>> m_UnlockedAchievements { get; set; }
        public bool m_ReduceCameraMotion { get; set; }
        public bool m_LargeSubtitles { get; set; }
        public HashSet<string> m_ViewedNotifications { get; set; }
    }

    public class Resolution
    {
        public int m_Width { get; set; }
        public int m_Height { get; set; }
        public int m_RefreshRate { get; set; }
    }

    public class FeatsManagerSaveData
    {
        [Deserialize("m_Feat_BookSmartsSerialized", true)]
        public Feat_BookSmartsSaveData BookSmarts { get; set; }
        [Deserialize("m_Feat_ColdFusionSerialized", true)]
        public Feat_ColdFusionSaveData ColdFusion { get; set; }
        [Deserialize("m_Feat_EfficientMachineSerialized", true)]
        public Feat_EfficientMachineSaveData EfficientMachine { get; set; }
        [Deserialize("m_Feat_FireMasterSerialized", true)]
        public Feat_FireMasterSaveData FireMaster { get; set; }
        [Deserialize("m_Feat_FreeRunnerSerialized", true)]
        public Feat_FreeRunnerSaveData FreeRunner { get; set; }
        [Deserialize("m_Feat_SnowWalkerSerialized", true)]
        public Feat_SnowWalkerSaveData SnowWalker { get; set; }
        [Deserialize("m_Feat_ExpertTrappererialized", true)]
        public Feat_ExpertTrapperSaveData ExpertTrapper { get; set; }
        [Deserialize("m_Feat_StraightToHeartSerialized", true)]
        public Feat_StraightToHeartSaveData StraightToHeart { get; set; }
        [Deserialize("m_Feat_BlizzardWalkerSerialized", true)]
        public Feat_BlizzardWalkerSaveData BlizzardWalker { get; set; }
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

    public class Feat_ExpertTrapperSaveData
    {
        public int m_RabbitSnaredCount { get; set; }
    }
    public class Feat_StraightToHeartSaveData
    {
        public int m_ItemConsumedCount { get; set; }
    }
    public class Feat_BlizzardWalkerSaveData
    {
        public float m_BlizzardHoursOutside { get; set; }
        public float m_BlizzardHoursOutsideAccumulator { get; set; }
    }

    public class StatContainer
    {
        public int[] m_CachedHashIds { get; set; }
        public Dictionary<string, string> m_StatsDictionary { get; set; }
        public int m_NumBurntHousesInCoastal { get; set; }
        public bool m_HasDoneCoastalBurntHouseCheck { get; set; }
        public bool m_HasDoneCorrectBurntHouseCheck { get; set; }
    }

    public class SandboxRecord
    {
        public string m_SandboxName { get; set; }
        public float m_ElapsedHours { get; set; }
        public string m_EndDate { get; set; }
        public EnumWrapper<GameRegion> m_StartRegion { get; set; }
        public string m_EndRegion { get; set; }
        public EnumWrapper<ExperienceModeType> m_ExperienceModeType { get; set; }
        public EnumWrapper<VoicePersona> m_VoicePersona { get; set; }
        public string m_CauseOfDeathLocId { get; set; }
        public string m_GeneralNotes { get; set; }
        public List<LogDayInfo> m_LogDayInfoList { get; set; }
        // TODO: check if dynamic works correctly
        public List<dynamic> m_CollectibleList { get; set; }
        public List<string> m_CollectibleNotesList { get; set; }
        public List<CairnInfo> m_CollectibleCairnInfoList { get; set; }
        public StatContainer m_Stats { get; set; }
    }
}
