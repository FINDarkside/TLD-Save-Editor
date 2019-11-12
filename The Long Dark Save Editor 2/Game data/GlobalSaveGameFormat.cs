using The_Long_Dark_Save_Editor_2.Serialization;

namespace The_Long_Dark_Save_Editor_2.Game_data
{

    public class GlobalSaveGameFormat
    {
        public int m_Version { get; set; }
        [Deserialize("m_GameManagerSerialized", true)]
        public GameManagerData GameManagerData { get; set; }
        [Deserialize("m_HudManagerSerialized", true)]
        public HudManagerSaveDataProxy HudManager { get; set; }
        [Deserialize("m_TimeOfDay_Serialized", true)]
        public TimeOfDaySaveDataProxy TimeOfDay { get; set; }
        [Deserialize("m_Wind_Serialized", true)]
        public WindSaveDataProxy Wind { get; set; }
        [Deserialize("m_Weather_Serialized", true)]
        public WeatherSaveDataProxy Weather { get; set; }
        [Deserialize("m_WeatherTransition_Serialized", true)]
        public WeatherTransitionSaveDataProxy WeatherTransition { get; set; }
        [Deserialize("m_Condition_Serialized", true)]
        public ConditionSaveDataProxy Condition { get; set; }
        [Deserialize("m_Encumber_Serialized", true)]
        public EncumberSaveDataProxy Encumber { get; set; }
        [Deserialize("m_Hunger_Serialized", true)]
        public HungerSaveDataProxy Hunger { get; set; }
        [Deserialize("m_Thirst_Serialized", true)]
        public ThirstSaveDataProxy Thirst { get; set; }
        [Deserialize("m_Fatigue_Serialized", true)]
        public FatigueSaveDataProxy Fatigue { get; set; }
        [Deserialize("m_Freezing_Serialized", true)]
        public FreezingSaveDataProxy Freezing { get; set; }
        [Deserialize("m_Willpower_Serialized", true)]
        public WillpowerSaveDataProxy WillPower { get; set; }
        [Deserialize("m_Inventory_Serialized", true)]
        public InventorySaveDataProxy Inventory { get; set; }
        public string m_SandboxManagerSerialized { get; set; }
        public string m_StoryManagerSerialized { get; set; }
        [Deserialize("m_PlayerManagerSerialized", true)]
        public PlayerManagerSaveDataProxy PlayerManager { get; set; }
        [Deserialize("m_PlayerClimbRopeSerialized", true)]
        public PlayerClimbRopeProxy PlayerClimbRope { get; set; }
        [Deserialize("m_PlayerSkillsSerialized", true)]
        public PlayerSkillsSaveData PlayerSkills { get; set; }
        [Deserialize("m_PlayerGameStatsSerialized", true)]
        public PlayerGameStatsProxy PlayerGameStats { get; set; }
        [Deserialize("m_HypothermiaSerialized", true)]
        public HypothermiaSaveDataProxy Hypothermia { get; set; }
        [Deserialize("m_WellFedSerialized", true)]
        public WellFedSaveDataProxy WellFed { get; set; }
        [Deserialize("m_FrostbiteSerialized", true)]
        public FrostbiteSaveDataProxy FrostBite { get; set; }
        [Deserialize("m_FoodPoisoningSerialized", true)]
        public FoodPoisoningSaveDataProxy FoodPoisoning { get; set; }
        [Deserialize("m_DysenterySerialized", true)]
        public DysenterySaveDataProxy Dysentery { get; set; }
        [Deserialize("m_SprainedAnkleSerialized", true)]
        public SprainedAnkleSaveDataProxy SprainedAnkle { get; set; }
        [Deserialize("m_SprainedWristSerialized", true)]
        public SprainedWristSaveDataProxy SprainedWrist { get; set; }
        [Deserialize("m_BurnsSerialized", true)]
        public BurnsSaveDataProxy Burns { get; set; }
        [Deserialize("m_BurnsElectricSerialized", true)]
        public BurnsElectricSaveDataProxy BurnsElectric { get; set; }
        [Deserialize("m_BloodLossSerialized", true)]
        public BloodLossSaveDataProxy BloodLoss { get; set; }
        [Deserialize("m_BrokenRibSerialized", true)]
        public BrokenRibSaveDataProxy BrokenRibs { get; set; }
        [Deserialize("m_InfectionSerialized", true)]
        public InfectionSaveDataProxy Infection { get; set; }
        [Deserialize("m_InfectionRiskSerialized", true)]
        public InfectionRiskSaveDataProxy InfectionRisk { get; set; }
        [Deserialize("m_LogSerialized", true)]
        public LogSaveDataProxy Log { get; set; }
        [Deserialize("m_RestSerialized", true)]
        public RestSaveDataProxy Rest { get; set; }
        [Deserialize("m_FlyOverSerialized", true)]
        public FlyoverDataProxy FlyOver { get; set; }
        [Deserialize("m_AchievementManagerSerialized", true)]
        public AchievementSaveData AchievementManager { get; set; }
        [Deserialize("m_ExperienceModeManagerSerialized", true)]
        public ExperienceModeManagerSaveDataProxy ExperienceModeManager { get; set; }
        [Deserialize("m_PlayerMovementSerialized", true)]
        public PlayerMovementSaveDataProxy PlayerMovement { get; set; }
        public string m_PlayerStruggleSerialized { get; set; }
        public string m_PanelStatsSerialized { get; set; }
        [Deserialize("m_EmergencyStimSerialized", true)]
        public EmergencyStimParams EmergencyStim { get; set; }
        public string m_MusicEventManagerSerialized { get; set; }
        public string m_ChimneyDataSerialized { get; set; }
        [Deserialize("m_CabinFeverSerialized", true)]
        public CabinFeverSaveDataProxy CabinFever { get; set; }
        [Deserialize("m_IntestinalParasitesSerialized", true)]
        public IntestinalParasitesSaveDataProxy IntestinalParasites { get; set; }
        public string m_SnowPatchManagerSerialized { get; set; }
        public string m_PlayerAnimationSerialized { get; set; }
        [Deserialize("m_SkillsManagerSerialized", true)]
        public SkillsManagerSaveData SkillsManager { get; set; }
        public string m_LockCompanionsSerialized { get; set; }
        [Deserialize("m_FeatsEnabledSerialized", true)]
        public FeatEnabledTrackerSaveData FeatsEnabled { get; set; }
        /*public string m_TrustManagerSerialized { get; set; }
        public string m_WorldMapDataSerialized { get; set; }
        public string m_MapDataSerialized { get; set; }
        public string m_BearHuntSerialized { get; set; }
        public string m_BearHuntReduxSerialized { get; set; }
        public string m_KnowledgeManagerSerialized { get; set; }
        public string m_UnlockedBlueprintsSerialized { get; set; }
        public string m_CollectionManagerSerialized { get; set; }
        public string m_AuroraScreenManagerSerialized { get; set; }
        public string m_StoryMissionDataSerialized { get; set; }
        public bool m_CurrentEpisodeComplete { get; set; }*/
    }
}
