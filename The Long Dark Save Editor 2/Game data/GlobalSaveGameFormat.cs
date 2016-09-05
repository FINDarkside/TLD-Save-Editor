using Newtonsoft.Json;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
	public class GlobalSaveGameFormat
	{
		public int m_Version { get; set; }
		public string m_GameManagerSerialized { get; set; }
		public string m_HudManagerSerialized { get; set; }
		public string m_TimeOfDay_Serialized { get; set; }
		public string m_Wind_Serialized { get; set; }
		public string m_Weather_Serialized { get; set; }
		public string m_WeatherTransition_Serialized { get; set; }
		public string m_Condition_Serialized { get; set; }
		public string m_Encumber_Serialized { get; set; }
		public string m_Hunger_Serialized { get; set; }
		public string m_Thirst_Serialized { get; set; }
		public string m_Fatigue_Serialized { get; set; }
		public string m_Freezing_Serialized { get; set; }
		public string m_Willpower_Serialized { get; set; }
		public string m_Inventory_Serialized { get; set; }
		public string m_SandboxManagerSerialized { get; set; }
		public string m_StoryManagerSerialized { get; set; }
		public string m_PlayerManagerSerialized { get; set; }
		public string m_PlayerClimbRopeSerialized { get; set; }
		public string m_PlayerSkillsSerialized { get; set; }
		public string m_PlayerGameStatsSerialized { get; set; }
		public string m_HypothermiaSerialized { get; set; }
		public string m_FoodPoisoningSerialized { get; set; }
		public string m_DysenterySerialized { get; set; }
		public string m_SprainedAnkleSerialized { get; set; }
		public string m_SprainedWristSerialized { get; set; }
		public string m_SprainedWristMajorSerialized { get; set; }
		public string m_BurnsSerialized { get; set; }
		public string m_BloodLossSerialized { get; set; }
		public string m_InfectionSerialized { get; set; }
		public string m_InfectionRiskSerialized { get; set; }
		public string m_LogSerialized { get; set; }
		public string m_RestSerialized { get; set; }
		public string m_FlyOverSerialized { get; set; }
		public string m_AchievementManagerSerialized { get; set; }
		public string m_ExperienceModeManagerSerialized { get; set; }
		public string m_AuroraManagerSerialized { get; set; }
		public string m_CacheManagerSerialized { get; set; }
		public string m_PlayerMovementSerialized { get; set; }
		public string m_PlayerStruggleSerialized { get; set; }
		public string m_UserDefinedSaveSlotName { get; set; }
		public string m_PanelStatsSerialized { get; set; }
		public string m_EmergencyStimSerialized { get; set; }
		public string m_MusicEventManagerSerialized { get; set; }
		public string m_ChimneyDataSerialized { get; set; }
		public string m_CabinFeverSerialized { get; set; }
		public string m_IntestinalParasitesSerialized { get; set; }
		public string m_SnowPatchManagerSerialized { get; set; }
		public string m_PlayerAnimationSerialized { get; set; }
		public string m_SkillsManagerSerialized { get; set; }
	}

	public class GlobalSaveGameData
	{
		public int Version { get; set; }
		public SceneTransitionData SceneTransistion { get; set; }
		public HudManagerSaveDataProxy HudManager { get; set; }
		public TimeOfDaySaveDataProxy TimeOfDay { get; set; }
		public WindSaveDataProxy Wind { get; set; }
		public WeatherSaveDataProxy Weather { get; set; }
		public WeatherTransitionSaveDataProxy WeatherTransistion { get; set; }
		public ConditionSaveDataProxy Condition { get; set; }
		public EncumberSaveDataProxy Encumber { get; set; }
		public HungerSaveDataProxy Hunger { get; set; }
		public ThirstSaveDataProxy Thirst { get; set; }
		public FatigueSaveDataProxy Fatigue { get; set; }
		public FreezingSaveDataProxy Freezing { get; set; }
		public WillpowerSaveDataProxy Willpower { get; set; }
		public Inventory Inventory { get; set; }
		public MissionServicesManagerSaveProxy SandboxManager { get; set; }
		public MissionServicesManagerSaveProxy StoryManager { get; set; }
		public PlayerManagerSaveDataProxy PlayerManager { get; set; }
		public PlayerClimbRopeProxy PlayerClimbRope { get; set; }
		[System.Obsolete("Use SkillsManager")]
		public PlayerSkillsSaveData PlayerSkills { get; set; } 
		public PlayerGameStatsProxy PlayerGameStats { get; set; }
		public HypothermiaSaveDataProxy Hypothermia { get; set; }
		public FoodPoisoningSaveDataProxy FoodPoisoning { get; set; }
		public DysenterySaveDataProxy Dysentery { get; set; }
		public SprainedAnkleSaveDataProxy SprainedAnkle { get; set; }
		public SprainedWristSaveDataProxy SprainedWrist { get; set; }
		public SprainedWristMajorSaveDataProxy SprainedWristMajor { get; set; }
		public BurnsSaveDataProxy Burns { get; set; }
		public BloodLossSaveDataProxy BloodLoss { get; set; }
		public InfectionSaveDataProxy Infection { get; set; }
		public InfectionRiskSaveDataProxy InfectionRisk { get; set; }
		public LogSaveDataProxy Log { get; set; }
		public RestSaveDataProxy Rest { get; set; }
		public FlyoverDataProxy FlyOver { get; set; }
		public AchievementSaveData AchievementManager { get; set; }
		public ExperienceModeManagerSaveDataProxy ExperienceModeManager { get; set; }
		public string AuroraManager { get; set; }
		public CacheManagerSaveData CacheManager { get; set; }
		public PlayerMovementSaveDataProxy PlayerMovement { get; set; }
		public string PlayerStruggle { get; set; }
		public string UserDefinedSaveSlotName { get; set; }
		public string PanelStats { get; set; } // StatContainer
		public EmergencyStimParams EmergencyStim { get; set; }
		public MusicEventSaveData MusicEventManager { get; set; }
		public ChimneySaveList ChimneyData { get; set; }
		public CabinFeverSaveDataProxy CabinFever { get; set; }
		public IntestinalParasitesSaveDataProxy IntestinalParasites { get; set; }
		public SnowfallManagerSaveDataProxy SnowPatchManager { get; set; }
		public PlayerAnimationSaveData PlayerAnimation { get; set; }
		public SkillsManager SkillsManager { get; set; }

		public GlobalSaveGameData(string data)
		{
			System.Diagnostics.Debug.WriteLine(data);
			var proxy = JsonConvert.DeserializeObject<GlobalSaveGameFormat>(data);

			Version = proxy.m_Version;
			SceneTransistion = Util.DeserializeObject<SceneTransitionData>(proxy.m_GameManagerSerialized);
			HudManager = Util.DeserializeObject<HudManagerSaveDataProxy>(proxy.m_HudManagerSerialized);
			TimeOfDay = Util.DeserializeObject<TimeOfDaySaveDataProxy>(proxy.m_TimeOfDay_Serialized);
			Wind = Util.DeserializeObject<WindSaveDataProxy>(proxy.m_Wind_Serialized);
			Weather = Util.DeserializeObject<WeatherSaveDataProxy>(proxy.m_Weather_Serialized);
			WeatherTransistion = Util.DeserializeObject<WeatherTransitionSaveDataProxy>(proxy.m_WeatherTransition_Serialized);
			Condition = Util.DeserializeObject<ConditionSaveDataProxy>(proxy.m_Condition_Serialized);
			Encumber = Util.DeserializeObject<EncumberSaveDataProxy>(proxy.m_Encumber_Serialized);
			Hunger = Util.DeserializeObject<HungerSaveDataProxy>(proxy.m_Hunger_Serialized);
			Thirst = Util.DeserializeObject<ThirstSaveDataProxy>(proxy.m_Thirst_Serialized);
			Fatigue = Util.DeserializeObject<FatigueSaveDataProxy>(proxy.m_Fatigue_Serialized);
			Freezing = Util.DeserializeObject<FreezingSaveDataProxy>(proxy.m_Freezing_Serialized);
			Willpower = Util.DeserializeObject<WillpowerSaveDataProxy>(proxy.m_Willpower_Serialized);
			Inventory = new Inventory(proxy.m_Inventory_Serialized);
			SandboxManager = Util.DeserializeObject<MissionServicesManagerSaveProxy>(proxy.m_SandboxManagerSerialized);
			StoryManager = Util.DeserializeObject<MissionServicesManagerSaveProxy>(proxy.m_StoryManagerSerialized);
			PlayerManager = Util.DeserializeObject<PlayerManagerSaveDataProxy>(proxy.m_PlayerManagerSerialized);
			PlayerClimbRope = Util.DeserializeObject<PlayerClimbRopeProxy>(proxy.m_PlayerClimbRopeSerialized);
			PlayerSkills = Util.DeserializeObject<PlayerSkillsSaveData>(proxy.m_PlayerSkillsSerialized);
			PlayerGameStats = Util.DeserializeObject<PlayerGameStatsProxy>(proxy.m_PlayerGameStatsSerialized);
			Hypothermia = Util.DeserializeObject<HypothermiaSaveDataProxy>(proxy.m_HypothermiaSerialized);
			FoodPoisoning = Util.DeserializeObject<FoodPoisoningSaveDataProxy>(proxy.m_FoodPoisoningSerialized);
			Dysentery = Util.DeserializeObject<DysenterySaveDataProxy>(proxy.m_DysenterySerialized);
			SprainedAnkle = Util.DeserializeObject<SprainedAnkleSaveDataProxy>(proxy.m_SprainedAnkleSerialized);
			SprainedWrist = Util.DeserializeObject<SprainedWristSaveDataProxy>(proxy.m_SprainedWristSerialized);
			SprainedWristMajor = Util.DeserializeObject<SprainedWristMajorSaveDataProxy>(proxy.m_SprainedWristMajorSerialized);
			Burns = Util.DeserializeObject<BurnsSaveDataProxy>(proxy.m_BurnsSerialized);
			BloodLoss = Util.DeserializeObject<BloodLossSaveDataProxy>(proxy.m_BloodLossSerialized);
			Infection = Util.DeserializeObject<InfectionSaveDataProxy>(proxy.m_InfectionSerialized);
			InfectionRisk = Util.DeserializeObject<InfectionRiskSaveDataProxy>(proxy.m_InfectionRiskSerialized);
			Log = Util.DeserializeObject<LogSaveDataProxy>(proxy.m_LogSerialized);
			Rest = Util.DeserializeObject<RestSaveDataProxy>(proxy.m_RestSerialized);
			FlyOver = Util.DeserializeObject<FlyoverDataProxy>(proxy.m_FlyOverSerialized);
			AchievementManager = Util.DeserializeObject<AchievementSaveData>(proxy.m_AchievementManagerSerialized);
			ExperienceModeManager = Util.DeserializeObject<ExperienceModeManagerSaveDataProxy>(proxy.m_ExperienceModeManagerSerialized);
			AuroraManager = proxy.m_AuroraManagerSerialized;
			CacheManager = Util.DeserializeObject<CacheManagerSaveData>(proxy.m_CacheManagerSerialized);
			PlayerMovement = Util.DeserializeObject<PlayerMovementSaveDataProxy>(proxy.m_PlayerMovementSerialized);
			PlayerStruggle = proxy.m_PlayerStruggleSerialized;
			UserDefinedSaveSlotName = proxy.m_UserDefinedSaveSlotName;
			
			// Do not deserialize, invalid JSON (integers as keys)
			PanelStats = proxy.m_PanelStatsSerialized;

			EmergencyStim = Util.DeserializeObject<EmergencyStimParams>(proxy.m_EmergencyStimSerialized);
			MusicEventManager = Util.DeserializeObject<MusicEventSaveData>(proxy.m_MusicEventManagerSerialized);
			ChimneyData = Util.DeserializeObject<ChimneySaveList>(proxy.m_ChimneyDataSerialized);
			CabinFever = Util.DeserializeObject<CabinFeverSaveDataProxy>(proxy.m_CabinFeverSerialized);
			IntestinalParasites = Util.DeserializeObject<IntestinalParasitesSaveDataProxy>(proxy.m_IntestinalParasitesSerialized);
			SnowPatchManager = Util.DeserializeObject<SnowfallManagerSaveDataProxy>(proxy.m_SnowPatchManagerSerialized);
			PlayerAnimation = Util.DeserializeObject<PlayerAnimationSaveData>(proxy.m_PlayerAnimationSerialized);
			SkillsManager = new SkillsManager(proxy.m_SkillsManagerSerialized);

		}

		public string Serialize()
		{
			var proxy = new GlobalSaveGameFormat();
			proxy.m_Version = Version;
			proxy.m_GameManagerSerialized = Util.SerializeObject(SceneTransistion);
			proxy.m_HudManagerSerialized = Util.SerializeObject(HudManager);
			proxy.m_TimeOfDay_Serialized = Util.SerializeObject(TimeOfDay);
			proxy.m_Wind_Serialized = Util.SerializeObject(Wind);
			proxy.m_Weather_Serialized = Util.SerializeObject(Weather);
			proxy.m_WeatherTransition_Serialized = Util.SerializeObject(WeatherTransistion);
			proxy.m_Condition_Serialized = Util.SerializeObject(Condition);
			proxy.m_Encumber_Serialized = Util.SerializeObject(Encumber);
			proxy.m_Hunger_Serialized = Util.SerializeObject(Hunger);
			proxy.m_Thirst_Serialized = Util.SerializeObject(Thirst);
			proxy.m_Fatigue_Serialized = Util.SerializeObject(Fatigue);
			proxy.m_Freezing_Serialized = Util.SerializeObject(Freezing);
			proxy.m_Willpower_Serialized = Util.SerializeObject(Willpower);
			proxy.m_Inventory_Serialized = Inventory.Serialize();
			proxy.m_SandboxManagerSerialized = Util.SerializeObject(SandboxManager);
			proxy.m_StoryManagerSerialized = Util.SerializeObject(StoryManager);
			proxy.m_PlayerManagerSerialized = Util.SerializeObject(PlayerManager);
			proxy.m_PlayerClimbRopeSerialized = Util.SerializeObject(PlayerClimbRope);
			proxy.m_PlayerSkillsSerialized = Util.SerializeObject(PlayerSkills);
			proxy.m_PlayerGameStatsSerialized = Util.SerializeObject(PlayerGameStats);
			proxy.m_HypothermiaSerialized = Util.SerializeObject(Hypothermia);
			proxy.m_FoodPoisoningSerialized = Util.SerializeObject(FoodPoisoning);
			proxy.m_DysenterySerialized = Util.SerializeObject(Dysentery);
			proxy.m_SprainedAnkleSerialized = Util.SerializeObject(SprainedAnkle);
			proxy.m_SprainedWristSerialized = Util.SerializeObject(SprainedWrist);
			proxy.m_SprainedWristMajorSerialized = Util.SerializeObject(SprainedWristMajor);
			proxy.m_BurnsSerialized = Util.SerializeObject(Burns);
			proxy.m_BloodLossSerialized = Util.SerializeObject(BloodLoss);
			proxy.m_InfectionSerialized = Util.SerializeObject(Infection);
			proxy.m_InfectionRiskSerialized = Util.SerializeObject(InfectionRisk);
			proxy.m_LogSerialized = Util.SerializeObject(Log);
			proxy.m_RestSerialized = Util.SerializeObject(Rest);
			proxy.m_FlyOverSerialized = Util.SerializeObject(FlyOver);
			proxy.m_AchievementManagerSerialized = Util.SerializeObject(AchievementManager);
			proxy.m_ExperienceModeManagerSerialized = Util.SerializeObject(ExperienceModeManager);
			proxy.m_AuroraManagerSerialized = AuroraManager;
			proxy.m_CacheManagerSerialized = Util.SerializeObject(CacheManager);
			proxy.m_PlayerMovementSerialized = Util.SerializeObject(PlayerMovement);
			proxy.m_PlayerStruggleSerialized = PlayerStruggle;
			proxy.m_UserDefinedSaveSlotName = UserDefinedSaveSlotName;

			proxy.m_PanelStatsSerialized = PanelStats;

			proxy.m_EmergencyStimSerialized = Util.SerializeObject(EmergencyStim);
			proxy.m_MusicEventManagerSerialized = Util.SerializeObject(MusicEventManager);
			proxy.m_ChimneyDataSerialized = Util.SerializeObject(ChimneyData);
			proxy.m_CabinFeverSerialized = Util.SerializeObject(CabinFever);
			proxy.m_IntestinalParasitesSerialized = Util.SerializeObject(IntestinalParasites);
			proxy.m_SnowPatchManagerSerialized = Util.SerializeObject(SnowPatchManager);
			proxy.m_PlayerAnimationSerialized = Util.SerializeObject(PlayerAnimation);
			proxy.m_SkillsManagerSerialized = SkillsManager.Serialize();

			return Util.SerializeObject(proxy);
		}
	}
}
