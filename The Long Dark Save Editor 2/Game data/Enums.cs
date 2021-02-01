using System.ComponentModel;

namespace The_Long_Dark_Save_Editor_2.Game_data
{

    // ----- My enums

    public enum ItemCategory
    {
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

    public enum RegionsWithMap
    {
        CoastalRegion,
        LakeRegion,
        WhalingStationRegion,
        RuralRegion,
        CrashMountainRegion,
        MarshRegion,
        RavineTransitionZone,
        HighwayTransitionZone,
        TracksRegion,
        RiverValleyRegion,
        MountainTownRegion,
        CanneryRegion,
        AshCanyonRegion
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
        ClearAurora = 8,
        Num = 9,
        Undefined = 9,
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
        Wet
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
        Wet
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

    public enum SprayColor
    {
        Orange
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
        FrostbiteDamage,
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
        FrostbiteRisk,
        BurnsElectric,
        BrokenRib,
        WellFed
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
        Custom,
        StoryFresh,
        StoryHardened,
        FourDaysOfNight,
        ChallengeArchivist,
        ChallengeDeadManWalk,
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
        Frostbite,
        HoursInMarshRegion,
        HoursInTracksRegion,
        BrokenRib,
        EpisodeProgress,
        HoursInMountainTownRegion,
        MooseEncountersSurvived,
        MooseKilled,
        HoursInRiverValleyRegion,
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
        WhalingStationRegion,
        RuralRegion,
        CrashMountainRegion,
        MarshRegion,
        RandomRegion,
        FutureRegion,
        MountainTownRegion,
        TracksRegion,
        RiverValleyRegion,
        CanneryRegion,
        AshCanyonRegion
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

    public enum ForcedMovement
    {
        None,
        ForceCrouch,
        ForceWalk,
        ForceLimp,
        ForceLimpSlow,
    }

    public enum KnowledgeCateogry
    {
        Unknown,
        People,
        Places,
        Things,
        Actions,
    }

    public enum MissionObjectiveCountType
    {
        NoUnits,
        Weight,
        Volume,
    }

    public enum SaveSlotType
    {
        UNKNOWN,
        CHALLENGE,
        CHECKPOINT,
        SANDBOX,
        STORY,
        AUTOSAVE,
    }

    public enum Episode
    {
        One,
        Two,
        Three,
        Four,
        Five,
    }

    public enum Achievement
    {
        Survival_10_Days = 1,
        Survival_50_Days = 6,
        LakeCoastalInteriors = 7,
        Harvest_10_Deer = 8,
        Survival_1_Night = 9,
        Survival_3_Nights = 10,
        NoGun_50_Days = 11,
        NoKill_25_Days = 12,
        Wrapped_Fur = 13,
        Big_Fish = 14,
        Living_Off_Land = 15,
        Natural_Healer = 16,
        Happy_Harvester = 17,
        Survival_1_Days = 18,
        Survival_100_Days = 20,
        Survival_500_Days = 22,
        StoneAgeSniper = 23,
        SkilledSurvivor = 24,
        TasteTheImpossible = 25,
        WellNourished = 26,
        FaithfulCartographer = 27,
        ResoluteOutfitter = 28,
        PenitentScholar = 29,
        TimberwolfMountain = 30,
        DesolationPoint = 31,
        DeepForest = 32,
        EP1_YourJourneyBegins = 33,
        EP1_ParadiseLost = 34,
        EP1_TheLongWinter = 35,
        EP1_LosingAChildIsLike = 36,
        EP1_LeavingTheOldWorldBehind = 37,
        EP2_TheOldTrapper = 38,
        EP2_LightsInTheSky = 39,
        EP2_GraduationDay = 40,
        EP2_FreightTrainOfHateAndHunger = 41,
        EP2_YouWillBeWithHerSoon = 42,
        SM_UnlockAllMiltonDepositBoxes = 43,
        SM_FoundAllForestTalkerCaches = 44,
        SM_FoundAllHiddenCaches = 45,
        ChallengeMastery = 46,
    }

    public enum DamageSide
    {
        DamageSideNone = -1,
        DamageSideLeft = 0,
        DamageSideRight = 1,
    }

    public enum HudSize
    {
        Small,
        Regular,
        Large,
    }

    public enum HudType
    {
        Off,
        Contextual,
        AlwaysOn,
    }

    public enum AfflictionBodyArea
    {
        Head,
        Neck,
        ArmLeft,
        HandLeft,
        ArmRight,
        HandRight,
        Chest,
        Stomach,
        LegLeft,
        FootLeft,
        LegRight,
        FootRight,
    }
}
