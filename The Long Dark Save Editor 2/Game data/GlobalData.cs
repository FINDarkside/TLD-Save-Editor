using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using The_Long_Dark_Save_Editor_2.Helpers;
using System.Linq;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    public class SlotData
    {
        public string m_Name { get; set; }
        public string m_BaseName { get; set; }
        public string m_DisplayName { get; set; }
        public DateTime m_Timestamp { get; set; }
        public EnumWrapper<SaveSlotType> m_GameMode { get; set; }
        public uint m_GameId { get; set; }
        public EnumWrapper<Episode> m_Episode { get; set; }
        public Dictionary<string, byte[]> m_Dict { get; set; }
        public bool m_IsPS4Compliant { get; set; }
    }

    public class SceneTransitionData
    {
        public bool m_TeleportPlayerSaveGamePosition { get; set; }
        public string m_SpawnPointName { get; set; }
        public string m_SpawnPointAudio { get; set; }
        public string m_ForceSceneOnNextNavMapLoad { get; set; }
        public string m_ForceNextSceneLoadTriggerScene { get; set; }
        public float[] m_PosBeforeInteriorLoad { get; set; }
        public string m_SceneSaveFilenameCurrent { get; set; }
        public string m_SceneSaveFilenameNextLoad { get; set; }
        public string m_SceneLocationLocIDToShow { get; set; }
        public int m_GameRandomSeed { get; set; }
        public string m_Location { get; set; }
    }

    public class HudManagerSaveDataProxy
    {
        public bool m_ShowDebugInfo { get; set; }
    }

    public class TimeOfDaySaveDataProxy
    {
        public float m_TimeProxy { get; set; }
        public float m_HoursPlayedNotPausedProxy { get; set; }
        public int m_UniStormDayCounterProxy { get; set; }
        public int m_UniStormMoonPhaseIndexProxy { get; set; }
        public int m_UniStormDayNumberProxy { get; set; }
        public int m_DayLastDawnStingerAudioPlayed { get; set; }
        public int m_DayLastNightStingerAudioPlayed { get; set; }
        public int m_DayLastDawnVoiceOverPlayed { get; set; }
        public int m_DayLastNightVoiceOverPlayed { get; set; }
        public int m_4DONCurrentDay { get; set; }
        public bool m_LockedTOD { get; set; }
    }

    public class WindSaveDataProxy
    {
        // Has Container class
        public int m_Version { get; set; }
        public EnumWrapper<WindDirection> m_windDirectionProxy { get; set; }
        public EnumWrapper<WindStrength> m_windStrengthProxy { get; set; }
        public float m_windMPHProxy { get; set; }
        public bool m_FirstPhaseSetProxy { get; set; }
        public float m_PhaseElapsedTODSecondsProxy { get; set; }
        public float m_PhaseDurationHoursProxy { get; set; }
        public float m_TransitionTimeTODSecondsProxy { get; set; }
        public string m_ActiveSettingsSerialized { get; set; }
        public string m_SourceSettingsSerialized { get; set; }
        public string m_TargetSettingsSerialized { get; set; }
    }

    public class ActiveWindSettings
    {
        public float m_Angle { get; set; }
        public float m_Velocity { get; set; }
        public float m_Gustiness { get; set; }
        public float m_LateralBluster { get; set; }
        public float m_VerticalBluster { get; set; }
    }

    public class WeatherSaveDataProxy
    {
        public float m_PrevBodyTempProxy { get; set; }
        public float m_TempHighProxy { get; set; }
        public float m_TempLowProxy { get; set; }
        public EnumWrapper<WeatherStage> m_WeatherStageProxy { get; set; }
        public float m_UniStormElapsedHoursProxy { get; set; }
        public float m_UniStormNextWeatherChangeElapsedHoursProxy { get; set; }
        public bool m_UseMinAirTemperature { get; set; }
        public int m_MinAirTemperature { get; set; }
    }

    public class WeatherTransitionSaveDataProxy
    {
        public bool m_UseUnmanagedWeatherStage;
        public EnumWrapper<WeatherStage> m_UnmanagedWeatherStage;
        public string m_CurrentWeatherSetName { get; set; }
        public float m_CurrentWeatherSetProgressFrac { get; set; }
        public string m_CurrentWeatherSetSerialized { get; set; }
        public int m_CurrentWeatherSetType { get; set; }
        public int m_PreviousWeatherSetType { get; set; }
    }

    public class WeatherSetInstanceSaveData
    {
        public int m_CurrentIndex { get; set; }
        public float m_CurrentStageElapsedTime { get; set; }
        public float[] m_StageDurations { get; set; }
        public float[] m_StageTransitionTimes { get; set; }
    }

    public class ConditionSaveDataProxy
    {
        public float m_CurrentHPProxy { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public bool m_NeverDieProxy { get; set; }
        public bool m_Invulnerable { get; set; }
        public bool m_HideDamageEvents { get; set; }
        public bool m_FoceUncrouched { get; set; }
        public bool m_CanPlayNearDeathMusic { get; set; }
        public EnumWrapper<ConditionLevel> m_ConditionLevelForPreviousVoiceOver { get; set; }
        public bool m_SuppressVoiceOver { get; set; }
    }

    public class EncumberSaveDataProxy
    {
        public bool m_EncumberedInLog { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public EnumWrapper<EncumberLevel> m_EcumberLevelForPreviousVoiceOver { get; set; }
    }

    public class HungerSaveDataProxy
    {
        public float m_CurrentReserveCaloriesProxy { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public bool m_StarvingInLog { get; set; }
        public float m_NumHoursStarving { get; set; }
        public float m_FatiguePenalty { get; set; }
        public EnumWrapper<HungerLevel> m_HungerLevelForPreviousVoiceOver { get; set; }
        public float m_CaloriesEatenToday { get; set; }
        public bool m_SuppressVoiceOver { get; set; }
    }

    public class ThirstSaveDataProxy
    {
        public float m_CurrentThirstProxy { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public bool m_DehydratedInLog { get; set; }
        public EnumWrapper<ThirstLevel> m_ThirstLevelForPreviousVoiceOver { get; set; }
        public bool m_SuppressVoiceOver { get; set; }
    }

    public class FatigueSaveDataProxy
    {
        public float m_CurrentFatigueProxy { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public bool m_ExhaustedInLog { get; set; }
        public EnumWrapper<FatigueLevel> m_FatigueLevelForPreviousVoiceOver { get; set; }
        public bool m_SuppressVoiceOver { get; set; }
    }

    public class FreezingSaveDataProxy
    {
        public float m_CurrentFreezingProxy { get; set; }
        public float m_NumSecondsSinceLastVoiceOver { get; set; }
        public bool m_FreezingInLog { get; set; }
        public EnumWrapper<FreezingLevel> m_FreezingLevelForPreviousVoiceOver { get; set; }
        public float m_TemperatureBonusFromRunning { get; set; }
        public bool m_SuppressVoiceOver { get; set; }
    }

    public class WillpowerSaveDataProxy
    {
        public float m_TimeRemainingSecondsProxy { get; set; }
    }

    public class KnowledgeManagerSaveData
    {
        public string m_TrustDictSerialized { get; set; }
        public string m_KnowledgeDictSerialized { get; set; }
        public string m_NameRefDictSerialized { get; set; }
        public bool m_SnowSheltersUnlockedInStory { get; set; }
    }

    public class CollectionManagerSaveData
    {
        public string m_UnlockedCairnsDictSerialized { get; set; }
        public string m_UnlockedAuroraSetSerialized { get; set; }
    }

    #region Inventory

    public class InventorySaveDataProxy
    {
        [Deserialize("m_SerializedItems", false, true)]
        public List<InventoryItemSaveData> Items { get; set; }
        public int[] m_QuickSelectInstanceIDs { get; set; }
        public bool m_ForceOverrideWeight { get; set; }
        public float m_OverridedWeight { get; set; }
        public bool m_ConsumedCoffee { get; set; }
        public bool m_ConsumedRosehipTea { get; set; }
        public bool m_ConsumedReishiTea { get; set; }
        public bool m_ConsumedOldMansBeardDressing { get; set; }
        public bool m_SuppressScentIndicator { get; set; }
    }

    public class InventoryItemSaveData
    {
        public string m_PrefabName { get; set; }
        [Deserialize("m_SerializedGear", true)]
        public GearItemSaveDataProxy Gear { get; set; }

        [JsonIgnore]
        public ItemCategory Category { get { return ItemDictionary.GetCategory(m_PrefabName); } }
        [JsonIgnore]
        public string InGameName { get { return ItemDictionary.GetInGameName(m_PrefabName); } }
    }


    public class GearItemSaveDataProxy : BindableBase
    {
        [JsonIgnore]
        public float NormalizedCondition
        {
            get { return m_NormalizedCondition; }
            set
            {
                SetProperty(ref m_NormalizedCondition, value);
            }
        }

        public float m_HoursPlayed { get; set; }
        public float[] m_Position { get; set; }
        public float[] m_Rotation { get; set; }
        public int m_InstanceIDProxy { get; set; }
        public float m_CurrentHPProxy { get; set; }
        private float m_NormalizedCondition;
        public bool m_BeenInPlayerInventoryProxy { get; set; }
        public bool m_BeenInContainerProxy { get; set; }
        public bool m_BeenInspectedProxy { get; set; }
        public bool m_ItemLootedProxy { get; set; }
        public bool m_HasBeenOwnedByPlayer { get; set; }
        public bool m_RolledSpawnChanceProxy { get; set; }
        public bool m_WornOut { get; set; }
        [Deserialize("m_StackableItemSerialized", true)]
        public StackableItemSaveDataProxy StackableItem { get; set; }
        [Deserialize("m_FoodItemSerialized", true)]
        public FoodItemSaveDataProxy FoodItem { get; set; }
        [Deserialize("m_LiquidItemSerialized", true)]
        public LiquidItemSaveDataProxy LiquidItem { get; set; }
        [Deserialize("m_FlareItemSerialized", true)]
        public FlareItemSaveDataProxy FlareItem { get; set; }
        [Deserialize("m_FlashlightItemSerialized", true)]
        public FlashlightItemSaveDataProxy FlashLightItem { get; set; }
        [Deserialize("m_KeroseneLampItemSerialized", true)]
        public KeroseneLampItemSaveDataProxy KeroseneLampItem { get; set; }
        [Deserialize("m_ClothingItemSerialized", true)]
        public ClothingItemSaveDataProxy ClothingItem { get; set; }
        [Deserialize("m_WeaponItemSerialized", true)]
        public GunItemSaveDataProxy WeaponItem { get; set; }
        [Deserialize("m_WaterSupplySerialized", true)]
        public WaterSupplySaveDataProxy WaterSupply { get; set; }
        [Deserialize("m_BedSerialized", true)]
        public BedSaveDataProxy Bed { get; set; }
        [Deserialize("m_SmashableItemSerialized", true)]
        public SmashableItemSaveDataProxy SmashableItem { get; set; }
        [Deserialize("m_MatchesItemSerialized", true)]
        public MatchesItemSaveDataProxy MatchesItem { get; set; }
        [Deserialize("m_SnareItemSerialized", true)]
        public SnareItemSaveDataProxy SnareItem { get; set; }
        [Deserialize("m_InProgressItemSerialized", true)]
        public InProgressCraftItemSaveDataProxy InProgressItem { get; set; }
        [Deserialize("m_TorchItemSerialized", true)]
        public TorchItemSaveDataProxy TorchItem { get; set; }
        public string m_CollectibleNoteSerialized { get; set; }
        [Deserialize("m_EvolveItemSerialized", true)]
        public EvolveItemSaveData EvolveItem { get; set; }
        public string m_ObjectGuidSerialized { get; set; }
        public string m_MissionObjectSerialized { get; set; }
        [Deserialize("m_ResearchItemSerialized", true)]
        public ResearchItemSaveData ResearchItem { get; set; }
        public float m_WeightKG { get; set; }
        public bool m_HarvestedByPlayer { get; set; }
        public bool m_IsInSatchel { get; set; }
        public int m_SatchelIndex { get; set; }
        public string m_OwnershipOverrideSerialized { get; set; }
        [Deserialize("m_BodyHarvestSerialized", true)]
        public BodyHarvestSaveDataProxy BodyHarvest { get; set; }
        public bool m_LockedInContainer { get; set; }
        public int m_GearItemSaveVersion { get; set; }
        public string m_CookingPotItemSerialized { get; set; }
        public string m_PlacePointGuidSerialized { get; set; }
        public string m_PlacePointNameSerialized { get; set; }

        public static GearItemSaveDataProxy Create()
        {
            var item = new GearItemSaveDataProxy();
            item.m_Rotation = new float[4];
            item.m_Position = new float[3];
            item.m_BeenInPlayerInventoryProxy = true;
            item.NormalizedCondition = 1;
            item.m_WornOut = false;
            item.m_HoursPlayed = MainWindow.Instance.CurrentSave.Global.TimeOfDay.m_HoursPlayedNotPausedProxy;
            var r = new Random();
            var id = r.Next();
            while (MainWindow.Instance.CurrentSave.Global.Inventory.Items.Any(i => i.Gear.m_InstanceIDProxy == id))
                id = r.Next();
            item.m_InstanceIDProxy = id;
            return item;
        }
    }

    public class StackableItemSaveDataProxy
    {
        public int m_UnitsProxy { get; set; }
    }

    public class FoodItemSaveDataProxy
    {
        public float m_CaloriesRemainingProxy { get; set; }
        public float m_CaloriesTotal { get; set; }
        public bool m_Opened { get; set; }
        public float m_HeatPercent { get; set; }
        public float m_HoursPlayed { get; set; }
        public bool m_HarvestedByPlayer { get; set; }
        public int m_NumTimesHeatedUp { get; set; }
        public bool m_Packaged { get; set; }
    }

    public class LiquidItemSaveDataProxy
    {
        public float m_LiquidLitersProxy { get; set; }
        public EnumWrapper<LiquidQuality> m_LiquidQuality { get; set; }
    }

    public class FlareItemSaveDataProxy
    {
        public float m_HoursPlayed { get; set; }
        public EnumWrapper<FlareState> m_StateProxy { get; set; }
        public float m_ElapsedBurnMinutesProxy { get; set; }
    }

    public class FlashlightItemSaveDataProxy
    {
        public bool m_IsOn { get; set; }
        public bool m_IsHigh { get; set; }
        public float m_CurrentBatteryCharge { get; set; }
    }

    public class KeroseneLampItemSaveDataProxy
    {
        public float m_HoursPlayed { get; set; }
        public float m_CurrentFuelLitersProxy { get; set; }
        public bool m_OnProxy { get; set; }
    }

    public class ClothingItemSaveDataProxy
    {
        public bool m_WearingProxy { get; set; }
        public float m_PercentWet { get; set; }
        public float m_PercentFrozen { get; set; }
        public float m_HoursPlayed { get; set; }
        public float m_HoursRemainingOnCloseFire { get; set; }
        public bool m_DroppedIndoors { get; set; }
        public bool m_HasEquippedData { get; set; }
        public int m_EquippedLayerIndex { get; set; }
    }

    public class GunItemSaveDataProxy
    {
        public int m_RoundsInClipProxy { get; set; }
        public bool m_IsJammed { get; set; }
    }

    public class WaterSupplySaveDataProxy
    {
        public float m_VolumeProxy { get; set; }
    }

    public class BedSaveDataProxy
    {
        public EnumWrapper<BedRollState> m_BedRollState { get; set; }
    }

    public class SmashableItemSaveDataProxy
    {
        public bool m_HasBeenSmashed { get; set; }
    }

    public class MatchesItemSaveDataProxy
    {
        public float m_BurnTimeGametimeSeconds { get; set; }
        public float m_ElapsedBurnGametimeSeconds { get; set; }
        public bool m_Ignited { get; set; }
        public bool m_IsFresh { get; set; }
    }

    public class SnareItemSaveDataProxy
    {
        public float m_HoursPlayed { get; set; }
        public float m_HoursAtLastRoll { get; set; }
        public EnumWrapper<SnareState> m_State { get; set; }
    }

    public class InProgressCraftItemSaveDataProxy
    {
        public float m_PercentComplete { get; set; }
        public float m_Weight { get; set; }
    }

    public class TorchItemSaveDataProxy
    {
        public float m_HoursPlayed { get; set; }
        public EnumWrapper<TorchState> m_StateProxy { get; set; }
        public float m_ElapsedBurnMinutesProxy { get; set; }
    }

    public class EvolveItemSaveData
    {
        public float m_HoursPlayed { get; set; }
        public float m_TimeSpentEvolvingGameHours { get; set; }
        public bool m_ForceNoAutoEvolve;
    }

    public class MissionObjectIdentifierSaveProxy
    {
        public string m_Id { get; set; }
        public EnumWrapper<MissionObjectClass> m_ObjectClass { get; set; }
        public string m_ActivityTags { get; set; }
        public bool m_DestroyAfterMission { get; set; }
    }

    public class ResearchItemSaveData
    {
        public float m_ElapsedHours { get; set; }
    }

    public class BodyHarvestSaveDataProxy
    {
        public float m_MeatAvailableKG { get; set; }
        public int m_HideAvailableUnits { get; set; }
        public int m_GutAvailableUnits { get; set; }
        public bool m_Frozen { get; set; }
        public bool m_Ravaged { get; set; }
        public float m_Condition { get; set; }
        public bool m_RolledSpawnChance { get; set; }
        public bool m_AllowDecay { get; set; }
        public float m_HoursPlayed { get; set; }
        public float m_PercentFrozen { get; set; }
        public float m_HoursRemainingOnCloseFire { get; set; }
        public float m_DecimationKGPerHour { get; set; }
        public float m_DecimationHoursRemaining { get; set; }
        public float m_QuarterDurationMinutes { get; set; }
        public bool m_HasHarvested { get; set; }
        public float m_LastHarvestTimeHours { get; set; }
        public float m_QuarterBagWasteMultiplier { get; set; }
        public string m_MissionIdSerialized { get; set; }
        public string m_BearHuntAiSerialized { get; set; }
        public string m_BearHuntAiReduxSerialized { get; set; }
        public EnumWrapper<DamageSide> m_DamageSide { get; set; }
    }

    public class CookingPotItemSaveDataProxy
    {
        public string m_FireBeingUsedGUID { get; set; }
        public string m_GearItemBeingCookedGUID { get; set; }
        public float m_CookingElapsedHours { get; set; }
        public float m_GracePeriodElapsedHours { get; set; }
        public float m_FireBurningTimeTODHours { get; set; }
        public float m_HoursPlayedWhenSerialized { get; set; }
        public float m_LitersSnowBeingMelted { get; set; }
        public float m_LitersWaterBeingBoiled { get; set; }
        public bool m_CanOnlyWarmUpFood { get; set; }
    }

    #endregion

    public class PlayerManagerSaveDataProxy
    {
        public List<int> m_KnownCodes { get; set; }
        public ObservableCollection<float> m_SaveGamePosition { get; set; }
        public float[] m_SaveGameRotation { get; set; }
        public bool m_StartGearAppliedProxy { get; set; }
        public int m_ItemInHandsInstanceID { get; set; }
        public int m_LastUnequippedItemInstanceID { get; set; }
        public bool m_InRunMode { get; set; }
        public bool m_Ghost { get; set; }
        public bool m_God { get; set; }
        public bool m_CheatsUsed { get; set; }
        public EnumWrapper<VoicePersona> m_VoicePersona { get; set; }
        public float m_CaloriesHarvestedToday { get; set; }
        public float m_FreezingRateScale { get; set; }
        public float m_FatigueRateScale { get; set; }
        public float m_ConditonPercentBonus { get; set; }
        public float m_FatigueBuffHoursRemaining { get; set; }
        public float m_FreezingBuffHoursRemaining { get; set; }
        public float m_ConditionRestBuffHoursRemaining { get; set; }
        public string m_StartingRegionName { get; set; }
        public int m_SelectedBlueprintItemIndexWorkbench { get; set; }
        public int m_SelectedBlueprintItemIndexForge { get; set; }
        public bool m_PlayerInVehicle { get; set; }
        public float[] m_PlayerInVehicleCameraPos { get; set; }
        public bool m_PlayerInSnowShelter { get; set; }
        public float m_PumpkinPieBuffHoursRemaining { get; set; }
        public float m_PumpkinPieFreezingRateScale { get; set; }
        public SerializableBounds m_LimitCampfiresToBounds { get; set; }
        public bool m_StatusBarsLocked { get; set; }
    }

    public class PlayerClimbRopeProxy
    {
        public string m_RopeGuid { get; set; }
        public float m_SplineT { get; set; }
        public float m_NoStaminaTimerSeconds { get; set; }
        public float m_NextSlipRollSeconds { get; set; }
        public float m_NextSlipChance { get; set; }
        public float m_NextFallChance { get; set; }
    }

    public class PlayerSkillsSaveData
    {
        [Obsolete]
        public float m_FireStartingSkill { get; set; }
        [Obsolete]
        public float m_RepairSkill { get; set; }
        public float m_CleanSkill { get; set; }
        public float m_SharpenSkill { get; set; }
        [Obsolete]
        public float m_CraftingSkill { get; set; }
    }

    public class PlayerGameStatsProxy
    {
        public float m_CaloriesBurned { get; set; }
        public float m_CaloriesEaten { get; set; }
        public float m_BodyTempHigh { get; set; }
        public float m_BodyTempLow { get; set; }
        public float m_DistanceTravelledDay { get; set; }
        public float m_DistanceTravelledNight { get; set; }
        public float m_ConditionGained { get; set; }
        public float m_ConditionLost { get; set; }
        public float m_CaloriesExpendedToday { get; set; }
    }

    public class HypothermiaSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_ElapsedWarmTime { get; set; }
        public string m_CauseLocID { get; set; }
    }

    public class FrostBiteSaveDataProxy
    {
        public int[] m_LocationsWithActiveFrostbite { get; set; }
        public int[] m_LocationsWithFrostbiteRisk { get; set; }
        public float[] m_LocationsCurrentFrostbiteDamage { get; set; }
    }

    public class FoodPoisoningSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_AntibioticsTaken { get; set; }
        public float m_ElapsedRest { get; set; }
        public string m_CauseLocID { get; set; }
    }

    public class DysenterySaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_AntibioticsTaken { get; set; }
        public float m_ElapsedRest { get; set; }
        public float m_CleanWaterConsumedLiters { get; set; }
    }

    public class SprainedAnkleSaveDataProxy
    {
        [Obsolete]
        public bool m_Active { get; set; }
        [Obsolete]
        public float m_ElapsedHours { get; set; }
        [Obsolete]
        public float m_DurationHours { get; set; }
        [Obsolete]
        public bool m_PainKillersTaken { get; set; }
        [Obsolete]
        public float m_ElapsedRest { get; set; }
        public float m_SecondsSinceLastPainAudio { get; set; }
        public float m_SecondsUntilNextPainAudio { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedHoursList { get; set; }
        public float[] m_DurationHoursList { get; set; }
        public float[] m_ElapsedRestList { get; set; }
    }

    public class SprainedWristSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_PainKillersTaken { get; set; }
        public float m_ElapsedRest { get; set; }
        public float m_SecondsSinceLastPainAudio { get; set; }
        public float m_SecondsUntilNextPainAudio { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedHoursList { get; set; }
        public float[] m_DurationHoursList { get; set; }
        public float[] m_ElapsedRestList { get; set; }
        public bool m_IsNoSprainWristForced { get; set; }
    }

    public class SprainedWristMajorSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_PainKillersTaken { get; set; }
        public float m_ElapsedRest { get; set; }
        public float m_SecondsSinceLastPainAudio { get; set; }
        public float m_SecondsUntilNextPainAudio { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedRestList { get; set; }
    }

    public class BurnsSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_PainKillersTaken { get; set; }
        public bool m_BandageApplied { get; set; }
        public int m_NumBurnRemindersPlayed { get; set; }
        public float m_SecondsUntilNextBurnReminder { get; set; }
        public string m_CauseLocID;
    }

    public class BurnsElectricSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_PainKillersTaken { get; set; }
        public bool m_BandageApplied { get; set; }
        public int m_NumBurnRemindersPlayed { get; set; }
        public float m_SecondsUntilNextBurnReminder { get; set; }
    }

    public class BloodLossSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedHoursList { get; set; }
        public float[] m_DurationHoursList { get; set; }
    }

    public class BrokenRibSaveDataProxy
    {
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public int[] m_PainKillersTaken { get; set; }
        public int[] m_BandagesApplied { get; set; }
        public float[] m_ElapsedRestList { get; set; }
        public float[] m_NumHoursRestForCureList { get; set; }
    }

    public class InfectionSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_AntibioticsTaken { get; set; }
        public float m_ElapsedRest { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedHoursList { get; set; }
        public float[] m_DurationHoursList { get; set; }
        public bool[] m_AntibioticsTakenList { get; set; }
        public float[] m_ElapsedRestList { get; set; }
    }

    public class InfectionRiskSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHours { get; set; }
        public float m_DurationHours { get; set; }
        public bool m_AntisepticTaken { get; set; }
        public float m_CommentTime;
        public float m_CurrentInfectionChance { get; set; }
        public string[] m_CausesLocIDs { get; set; }
        public int[] m_Locations { get; set; }
        public float[] m_ElapsedHoursList { get; set; }
        public float[] m_DurationHoursList { get; set; }
        public bool[] m_AntisepticTakenList { get; set; }
        public float[] m_CurrentInfectionChanceList { get; set; }
        public int[] m_ConstantAfflictionIndices { get; set; }
    }

    public class CabinFeverSaveDataProxy
    {
        public bool m_Active { get; set; }
        public bool m_RiskActive { get; set; }
        public float m_ElapsedHours { get; set; }
        public float[] m_IndoorTimeTracked { get; set; }
        public int m_HourLastFrame { get; set; }
        public bool m_DoneHalloweenEventFix { get; set; }
    }

    public class IntestinalParasitesSaveDataProxy
    {
        public bool m_HasParasites { get; set; }
        public bool m_HasParasiteRisk { get; set; }
        public float m_CurrentInfectionChance { get; set; }
        public float m_ParasitesElapsedHours { get; set; }
        public float m_RiskElapsedHours { get; set; }
        public float m_RiskDurationHours { get; set; }
        public int m_NumDosesTaken { get; set; }
        public bool m_HasTakenDoseToday { get; set; }
        public int m_DayToAllowNextDose { get; set; }
        public int m_NumPiecesEatenThisRiskCycle { get; set; }
    }

    #region Log
    public class LogSaveDataProxy
    {
        public string m_GeneralNotes { get; set; }
        public List<LogDayInfo> m_LogDayInfoList { get; set; }
        public LogDayInfo m_TodayLogDayInfo { get; set; }
        public int m_DayToLogEndOfDayInfo { get; set; }
    }

    public class LogDayInfo
    {
        public int m_DayNumber { get; set; }
        public string m_Notes { get; set; }
        public int m_WorldExplored { get; set; }
        public int m_HoursRested { get; set; }
        public int m_ConditionLow { get; set; }
        public int m_ConditionHigh { get; set; }
        public int m_CaloriesBurned { get; set; }
        public List<EnumWrapper<AfflictionType>> m_Afflictions { get; set; }
        public List<string> m_LocationLocIDs { get; set; }
        public List<string> m_RegionLocIDs { get; set; }
        public List<string> m_RegionSceneNames { get; set; }
    }

    #endregion

    public class RestSaveDataProxy
    {
        public int m_LastDisplayedDayNumberOnAwake { get; set; }
        public int[] m_LastTwentyFourHoursOfSleep { get; set; }
        public bool m_PassTimeIsLocked { get; set; }
    }

    public class FlyoverDataProxy
    {
        public float m_SecondsSinceLastFlyover { get; set; }
        public float m_SecondsBetweenFlyovers { get; set; }
    }

    public class AchievementSaveData
    {
        public int m_Version { get; set; }
        public int m_NumDaysSurvived { get; set; }
        public int m_ConsecutiveNightsSurvived { get; set; }
        public int m_FullyHarvestedDeer { get; set; }
        public bool m_StartedNightOutside { get; set; }
        public bool m_WentInsideThisNight { get; set; }
        public bool m_HasFiredGun { get; set; }
        public bool m_HasKilledSomething { get; set; }
        public bool m_LakeRegionAllInteriors { get; set; }
        public bool m_CoastalRegionAllInteriors { get; set; }
        public int m_NumDaysLivingOffLand { get; set; }
        public bool m_UsedRosehipTea { get; set; }
        public bool m_UsedReishiTea { get; set; }
        public bool m_UsedOldMansBeardDressing { get; set; }
        public int m_NumRosehipPlantsHarvested { get; set; }
        public int m_NumReishiPlantsHarvested { get; set; }
        public int m_NumOldMansPlantsHarvested { get; set; }
        public int m_NumCatTailPlantsHarvested { get; set; }
        public int m_NumDaysCalorieStoreAboveZero { get; set; }
        public int m_NumArcheryBooksRead { get; set; }
        public int m_NumCarcassHarvestingBooksRead { get; set; }
        public int m_NumCookingBooksRead { get; set; }
        public int m_NumFireStartingBooksRead { get; set; }
        public int m_NumIceFishingBooksRead { get; set; }
        public int m_NumMendingBooksRead { get; set; }
        public int m_NumRifleFirearmAdvancedBooksRead { get; set; }
        public int m_NumRifleFirearmBooksRead { get; set; }
        public int m_NumImprovisedKnivesCrafted { get; set; }
        public int m_NumImprovisedHatchetsCrafted { get; set; }
        public int m_LongestBurningCampFire { get; set; }
        public bool m_FoundAllCachesEpisodeOne { get; set; }
        public bool m_FoundAllCachesEpisodeTwo { get; set; }
        public Dictionary<string, bool> m_MappedRegions { get; set; }
    }

    public class ExperienceModeManagerSaveDataProxy
    {
        public EnumWrapper<ExperienceModeType> m_CurrentModeType { get; set; }
        public string m_CustomModeString { get; set; }
    }

    public class PlayerMovementSaveDataProxy
    {
        public float m_SprintStamina { get; set; }
        public EnumWrapper<ForcedMovement> m_ForcedMovement { get; set; }
        public bool m_ForceNoSprain { get; set; }
        public bool m_IsCrouching { get; set; }
    }

    public class MusicEventSaveData
    {
        public float m_HappySuccessLastPlayTime { get; set; }
        public float m_SorrowLastPlayTime { get; set; }
        public float m_RopeClimbStressLastPlayTime { get; set; }
        public float m_BeingStalkedLastPlayTime { get; set; }
        public float m_NumHoursWithAffliction { get; set; }
    }

    public class EmergencyStimParams
    {
        public float m_LastUsageTimeInGameHours { get; set; }
        public float m_PlayCatchBreathSecondsAfterBegin { get; set; }
        public float m_HoursStimulatedWhenInjected { get; set; }
        public float m_MinHoursBetweenUsage { get; set; }
        public float m_StimPulseFrequencyStart { get; set; }
        public float m_StimPulseFrequencyEnd { get; set; }
        public float m_FatigueIncreaseWhenComplete { get; set; }
        public float m_StaminaDecreaseWhenComplete { get; set; }
        public uint m_AudioIDEmergencyStim { get; set; }
    }

    public class SnowfallManagerSaveDataProxy
    {
        public List<string> m_SceneNames { get; set; }
        public List<string> m_Records { get; set; }
    }

    public class SnowfallRecordSaveDataProxy
    {
        public float m_CurrentSnowDepth;
    }

    public class MissionServicesManagerSaveProxy
    {
        public List<string> m_SerializedMissions { get; set; }
        public List<string> m_SerializedConcurrentGraphs { get; set; }
        public List<string> m_SerializedTimers { get; set; }
        public List<string> m_MissionObjectFilterTags { get; set; }
        public List<string> m_CustomManagedObjects { get; set; }
        public List<EnumWrapper<CustomManagedObjectState>> m_CustomManagedObjectStates { get; set; }
        public string m_SerializedGlobalBlackboard;
        public string m_VisibleMissionTimer { get; set; }
    }

    public class TrustManagerSaveData
    {
        public Dictionary<string, int> m_TrustDictionary { get; set; }
        public Dictionary<string, int> m_StrikesDictionary { get; set; }
        public Dictionary<string, float> m_StrikeTimersDictionary { get; set; }
        public Dictionary<string, string> m_NeedTrackersSerialized { get; set; }
        public Dictionary<string, string> m_UnlockableTrackersSerialized { get; set; }
        public Dictionary<string, float> m_TrustDecayDictionary { get; set; }
        public Dictionary<string, float> m_GracePeriodTimersDictionary { get; set; }
        public Dictionary<string, float> m_GracePeriodValuesDictionary { get; set; }
    }

    public class MapDetailSaveData
    {
        public Dictionary<string, bool> m_MapDetailUnlockedStates { get; set; }
    }

    public class WorldMapSaveData
    {
        public List<string> m_UnlockedDetails { get; set; }
    }

    public class MapSaveData
    {
        public Dictionary<string, string> m_MapSaveDataDict { get; set; }
        public Dictionary<string, string> m_DetailSurveyPositions { get; set; }
        public Dictionary<string, float> m_DetailSurveyLastUpdateTimes { get; set; }
        public List<string> m_UnlockedRegionNames { get; set; }
    }

    public class SkillsManagerSaveData
    {
        [Deserialize("m_Skill_FirestartingSerialized", true)]
        public Skill_FirestartingSaveData Firestarting { get; set; }
        [Deserialize("m_Skill_CarcassHarvestingSerialized", true)]
        public Skill_CarcassHarvestingSaveData CarcassHarvesting { get; set; }
        [Deserialize("m_Skill_CookingSerialized", true)]
        public Skill_CookingSaveData Cooking { get; set; }
        [Deserialize("m_Skill_IceFishingSerialized", true)]
        public Skill_IceFishingSaveData IceFishing { get; set; }
        [Deserialize("m_Skill_RifleSerialized", true)]
        public Skill_RifleSaveData Rifle { get; set; }
        [Deserialize("m_Skill_ArcherySerialized", true)]
        public Skill_ArcherySaveData Archery { get; set; }
        [Deserialize("m_Skill_ClothingRepairSerialized", true)]
        public ClothingItemSaveDataProxy ClothingRepair { get; set; }
    }

    public class Skill_FirestartingSaveData
    {
        public int m_Points { get; set; }
    }

    public class Skill_CarcassHarvestingSaveData
    {
        public int m_Points { get; set; }
        public float m_NumHoursToConvertToSkillPoints { get; set; }
    }

    public class Skill_CookingSaveData
    {
        public int m_Points { get; set; }
    }

    public class Skill_IceFishingSaveData
    {
        public int m_Points { get; set; }
    }

    public class Skill_RifleSaveData
    {
        public int m_Points { get; set; }
    }

    public class Skill_ArcherySaveData
    {
        public int m_Points { get; set; }
    }

    public class Skill_ClothingRepairSaveData
    {
        public int m_Points { get; set; }
    }

    public class FeatEnabledTrackerSaveData
    {
        public List<EnumWrapper<FeatType>> m_FeatsEnabledThisSandbox { get; set; }
    }

    public class SandboxRecord
    {
        public string m_SandboxName { get; set; }
        public float m_ElapsedHours { get; set; }
        public DateTime m_EndDate { get; set; }
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
        public List<AuroraScreenInfo> m_CollectibleAuroraScreenInfoList;
        public StatContainer m_Stats { get; set; }
    }

    public class AuroraScreenInfo
    {
        public string m_PrefabName { get; set; }
    }

    public class CairnInfo
    {
        public string m_BackerLookupNum { get; set; }
        public int m_JournalEntryNumber { get; set; }
    }

    public class SerializedParams
    {
        public bool m_EnableFirstPersonHands { get; set; }
        public string m_HandMeshState { get; set; }
    }

    public class WellFedSaveDataProxy
    {
        public bool m_Active { get; set; }
        public float m_ElapsedHoursNotStarving { get; set; }
    }

    public class BoxCollider
    {
        public float[] center { get; set; }
        public float[] size { get; set; }
        public float[] extents { get; set; }
    }

    public class SerializableBounds
    {
        public float[] m_Center { get; set; }
        public float[] m_Size { get; set; }
    }

}
