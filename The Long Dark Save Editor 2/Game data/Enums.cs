using System.ComponentModel;

namespace The_Long_Dark_Save_Editor_2.Game_data
{

	// ----- My enums

	public enum ItemCategory
	{
		[Description("First Aid")]
		FirstAid,
		Clothing,
		Food,
		Tools,
		Materials,
		Collectible,
		Books,
		Hidden,
		Unknown
	}

	// -----


	public enum WindDirection
	{
		North,
		South,
		West,
		East,
		NorthWest,
		NorthEast,
		SouthWest,
		SouthEast,
	}

	public enum WindStrength
	{
		Calm,
		SlightlyWindy,
		Windy,
		VeryWindy,
		Blizzard,
	}

	public enum WeatherStage
	{
		DenseFog = 0,
		LightSnow = 1,
		HeavySnow = 2,
		PartlyCloudy = 3,
		Clear = 4,
		Cloudy = 5,
		LightFog = 6,
		Blizzard = 7,
		Num = 8,
		Undefined = 8,
		ClearAurora = 8,
	}

	public enum ConditionLevel
	{
		NoInjuries,
		SlightlyInjured,
		Injured,
		VeryInjured,
		NearDeath,
	}

	public enum EncumberLevel
	{
		None,
		Low,
		Medium,
		High,
	}

	public enum HungerLevel
	{
		Full,
		SlightlyHungry,
		Hungry,
		VeryHungry,
		Starving,
	}

	public enum ThirstLevel
	{
		Hydrated,
		SlightlyThirsty,
		Thirsty,
		VeryThirsty,
		Dehydrated,
	}

	public enum FatigueLevel
	{
		Rested,
		SlightlyTired,
		Tired,
		VeryTired,
		Exhausted,
	}

	public enum FreezingLevel
	{
		Warm,
		SlightlyCold,
		Cold,
		VeryCold,
		Freezing,
	}

	public enum LiquidQuality
	{
		Potable,
		NonPotable,
	}

	public enum FlareState
	{
		Fresh,
		Burning,
		BurnedOut,
	}

	public enum BedRollState
	{
		Rolled,
		Placed,
	}

	public enum SnareState
	{
		Default,
		Set,
		Broken,
		WithRabbit,
	}

	public enum TorchState
	{
		Fresh,
		Burning,
		BlownOut,
		BurnedOut,
		Extinguished,
	}

	public enum MissionObjectClass
	{
		General,
		Trigger,
		Player,
		InteractiveNPC,
		InteractiveObject,
		Invalid,
	}

	public enum VoicePersona
	{
		Male,
		Female,
	}

	public enum AfflictionType
	{
		BloodLoss,
		Burns,
		Dysentery,
		Infection,
		FoodPoisioning,
		SprainedAnkle,
		InfectionRisk,
		SprainedWrist,
		Frostbite,
		Hypothermia,
		ReducedFatigue,
		ImprovedRest,
		WarmingUp,
		HypothermiaRisk,
		CabinFever,
		IntestinalParasitesRisk,
		IntestinalParasites,
		SprainedWristMajor,
		CabinFeverRisk,
	}

	public enum ExperienceModeType
	{
		Pilgrim,
		Voyageur,
		Stalker,
		Story,
		ChallengeRescue,
		ChallengeHunted,
		ChallengeWhiteout,
		ChallengeNomad,
		ChallengeHuntedPart2,
		Interloper,
		NUM_MODES,
	}

	public enum StatID
	{
		HoursSurvived,
		LocationsExplored,
		WorldExploredPercentage,
		TotalCaloriesExpended,
		AverageCaloriesPerDay,
		DistanceTravelled,
		HoursAwake,
		HoursAsleep,
		HoursIndoors,
		HoursOutdoors,
		TimeRestedOutdoors,
		HoursInMysteryLake,
		HoursInPleasantValley,
		HoursInCoastalHighway,
		HoursInDesolationPoint,
		HoursInCrashMountainRegion,
		SuccessfulRepairs,
		BowShot,
		SuccessfulHits_Bow,
		RifleShot,
		SuccessfulHits_Rifle,
		DistressPistolShot,
		SuccessfulHits_DistressPistol,
		WolfCloseEncounters,
		WolfStruggles,
		WolfStrugglesWon,
		WolvesKilled,
		WolvesDistactedByDecoys,
		BearEncountersSurvived,
		BearsKilled,
		StagsKilled,
		RabbitsKilled,
		RabbitsSnared,
		MeatConsumed,
		FishConsumed,
		FishCaught,
		MeatHarvested,
		GutsHarvested,
		HidesHarvested,
		ItemsLooted,
		ItemsCrafted,
		ItemsBrokenDown,
		PlantsHarvested,
		CansOpened,
		CanOpenersFound,
		FiresStarted,
		LongestBurningFire,
		Sprains_Wrist,
		Sprains_Ankle,
		FoodPoisoning,
		Dysentry,
		Infection,
		Hypothermia,
		BloodLoss,
		FallCount,
		Blizzards,
		NumRopeSlips,
		NumRopeFalls,
		DistanceTravelledOnRope,
		CabinFever,
		IntestinalParasites,
		NumStats,
	}

	public enum CustomManagedObjectState
	{
		InitialActive = 1,
		ManagedActive = 2,
		InitialUnknown = 4,
	}

	public enum GameRegion
	{
		LakeRegion,
		CoastalRegion,
		RuralRegion,
		WhalingStationRegion,
		CrashMountainRegion,
		RandomRegion,
		FutureRegion,
	}

	public enum UpSell
	{
		MainMenu_Challenges,
		MainMenu_Logs,
		MainMenu_Badges,
	}

	public enum GraphicsMode
	{
		Fullscreen,
		Window,
	}

	public enum MeasurementUnits
	{
		Metric,
		Imperial,
	}

	public enum HudPref
	{
		DebugInfo,
		Normal,
		Disabled,
	}

	public enum SubtitlesState
	{
		Off,
		On,
		ClosedCaptioning,
	}

	public enum LanguageState
	{
		English,
		German,
		Russian,
	}

	public enum FeatType
	{
		BookSmarts,
		ColdFusion,
		EfficientMachine,
		FireMaster,
		FreeRunner,
		SnowWalker,
	}

}
