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
		public bool m_ExperimentalMode { get; set; }
	}

	public class WindSaveDataProxy
	{
		// Has Container class
		public int m_Version { get; set; }
		public WindDirection m_windDirectionProxy { get; set; }
		public WindStrength m_windStrengthProxy { get; set; }
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
		public WeatherStage m_WeatherStageProxy { get; set; }
		public float m_UniStormElapsedHoursProxy { get; set; }
		public float m_UniStormNextWeatherChangeElapsedHoursProxy { get; set; }
		public bool m_UseMinAirTemperature { get; set; }
		public int m_MinAirTemperature { get; set; }
	}

	public class WeatherTransitionSaveDataProxy
	{
		public bool m_UseUnmanagedWeatherStage;
		public WeatherStage m_UnmanagedWeatherStage;
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
		public bool m_CanPlayNearDeathMusic { get; set; }
		public ConditionLevel m_ConditionLevelForPreviousVoiceOver { get; set; }
	}

	public class EncumberSaveDataProxy
	{
		public bool m_EncumberedInLog { get; set; }
		public float m_NumSecondsSinceLastVoiceOver { get; set; }
		public EncumberLevel m_EcumberLevelForPreviousVoiceOver { get; set; }
	}

	public class HungerSaveDataProxy
	{
		public float m_CurrentReserveCaloriesProxy { get; set; }
		public float m_NumSecondsSinceLastVoiceOver { get; set; }
		public bool m_StarvingInLog { get; set; }
		public float m_NumHoursStarving { get; set; }
		public float m_FatiguePenalty { get; set; }
		public HungerLevel m_HungerLevelForPreviousVoiceOver { get; set; }
		public float m_CaloriesEatenToday { get; set; }
	}

	public class ThirstSaveDataProxy
	{
		public float m_CurrentThirstProxy { get; set; }
		public float m_NumSecondsSinceLastVoiceOver { get; set; }
		public bool m_DehydratedInLog { get; set; }
		public ThirstLevel m_ThirstLevelForPreviousVoiceOver { get; set; }
	}

	public class FatigueSaveDataProxy
	{
		public float m_CurrentFatigueProxy { get; set; }
		public float m_NumSecondsSinceLastVoiceOver { get; set; }
		public bool m_ExhaustedInLog { get; set; }
		public FatigueLevel m_FatigueLevelForPreviousVoiceOver { get; set; }
	}

	public class FreezingSaveDataProxy
	{
		public float m_CurrentFreezingProxy { get; set; }
		public float m_NumSecondsSinceLastVoiceOver { get; set; }
		public bool m_FreezingInLog { get; set; }
		public FreezingLevel m_FreezingLevelForPreviousVoiceOver { get; set; }
		public float m_TemperatureBonusFromRunning { get; set; }
	}

	public class WillpowerSaveDataProxy
	{
		public float m_TimeRemainingSecondsProxy { get; set; }
	}

	#region Inventory

	public class Inventory
	{

		public ObservableCollection<InventoryItem> Items { get; set; }
		public int[] QuickSelectInstanceIDs { get; set; }
		public bool m_ForceOverrideWeight { get; set; }
		public float m_OverridedWeight { get; set; }

		public string json;

		public Inventory(string json)
		{
			this.json = json;

			if (json == null)
				return;

			var proxy = JsonConvert.DeserializeObject<InventorySaveDataProxy>(json);

			Items = new ObservableCollection<InventoryItem>();
			foreach (var item in proxy.m_SerializedItems)
			{
				Items.Add(new InventoryItem(item));
			}
			QuickSelectInstanceIDs = proxy.m_QuickSelectInstanceIDs;
			m_ForceOverrideWeight = proxy.m_ForceOverrideWeight;
			m_OverridedWeight = proxy.m_OverridedWeight;
		}

		public string Serialize()
		{
			//return json;
			var proxy = new InventorySaveDataProxy();
			proxy.m_QuickSelectInstanceIDs = QuickSelectInstanceIDs;
			if (!Items.Any(item => item.PrefabName.ToLower() == "gear_watersupplynotpotable"))
			{
				Items.Add(new InventoryItem() { WaterSupply = new WaterSupplySaveDataProxy(), PrefabName = "GEAR_WaterSupplyNotPotable" });
			}
			if (!Items.Any(item => item.PrefabName.ToLower() == "gear_watersupplypotable"))
			{
				Items.Add(new InventoryItem() { WaterSupply = new WaterSupplySaveDataProxy(), PrefabName = "GEAR_WaterSupplyPotable" });

			}

			proxy.m_SerializedItems = new List<InventoryItemSaveData>(Items.Count);
			foreach (var item in Items)
			{
				proxy.m_SerializedItems.Add(item.Serialize());
			}
			proxy.m_ForceOverrideWeight = m_ForceOverrideWeight;
			proxy.m_OverridedWeight = m_OverridedWeight;
			return Util.SerializeObject(proxy);
		}
	}

	public class InventorySaveDataProxy
	{
		public List<InventoryItemSaveData> m_SerializedItems { get; set; }
		public int[] m_QuickSelectInstanceIDs { get; set; }
		public bool m_ForceOverrideWeight { get; set; }
		public float m_OverridedWeight { get; set; }
	}

	public class InventoryItemSaveData
	{
		public string m_PrefabName;
		public string m_SerializedGear;
	}

	public class InventoryItem : INotifyPropertyChanged
	{
		public string PrefabName { get; set; }
		public ItemCategory Category { get { return ItemDictionary.GetCategory(PrefabName); } }
		public string InGameName { get { return ItemDictionary.GetInGameName(PrefabName); } }

		public float HoursPlayed { get; set; }
		public float[] Position { get; set; }
		public float[] Rotation { get; set; }
		public int InstanceIDProxy { get; set; }
		private float currentHPProxy;
		public float CurrentHPProxy { get; set; }
		private float normalizedCondition;
		public float NormalizedCondition
		{
			get { return normalizedCondition; }
			set
			{
				SetPropertyField(ref normalizedCondition, value);
			}
		}
		public bool BeenInPlayerInventory { get; set; }
		public bool BeenInContainer { get; set; }
		public bool BeenInspected { get; set; }
		public bool ItemLooted { get; set; }
		public bool RolledSpawnChance { get; set; }
		public bool WornOut { get; set; }
		public StackableItemSaveDataProxy StackableItem { get; set; }
		public FoodItemSaveDataProxy FoodItem { get; set; }
		public LiquidItemSaveDataProxy LiquidItem { get; set; }
		public FlareItemSaveDataProxy FlareItem { get; set; }
		public KeroseneLampItemSaveDataProxy KeroseneLampItem { get; set; }
		public ClothingItemSaveDataProxy ClothingItem { get; set; }
		public GunItemSaveDataProxy WeaponItem { get; set; }
		public WaterSupplySaveDataProxy WaterSupply { get; set; }
		public BedSaveDataProxy Bed { get; set; }
		public SmashableItemSaveDataProxy SmashableItem { get; set; }
		public MatchesItemSaveDataProxy MatchesItem { get; set; }
		public SnareItemSaveDataProxy SnareItem { get; set; }
		public InProgressCraftItemSaveDataProxy InProgressItem { get; set; }
		public TorchItemSaveDataProxy TorchItem { get; set; }
		public CollectibleNoteItemProxy CollectibleNote { get; set; }
		public EvolveItemSaveData EvolveItem { get; set; }
		public ResearchItemSaveData ResearchItem;
		public string ObjectGuid { get; set; }
		public string MissionObject { get; set; }
		public float WeightKG { get; set; }
		public bool HarvestedByPlayer { get; set; }

		public InventoryItem()
		{
			Rotation = new float[4];
			Position = new float[3];
			BeenInPlayerInventory = true;
			NormalizedCondition = 1;
			WornOut = false;
			HoursPlayed = MainWindow.Instance.CurrentSave.Global.TimeOfDay.m_HoursPlayedNotPausedProxy;
		}

		public InventoryItem(InventoryItemSaveData data)
		{
			PrefabName = data.m_PrefabName;

			if (data.m_SerializedGear == null)
				return;

			var proxy = JsonConvert.DeserializeObject<GearItemSaveDataProxy>(data.m_SerializedGear);
			HoursPlayed = proxy.m_HoursPlayed;
			Position = proxy.m_Position;
			Rotation = proxy.m_Rotation;
			InstanceIDProxy = proxy.m_InstanceIDProxy;
			CurrentHPProxy = proxy.m_CurrentHPProxy;
			NormalizedCondition = proxy.m_NormalizedCondition;
			BeenInPlayerInventory = proxy.m_BeenInPlayerInventoryProxy;
			BeenInContainer = proxy.m_BeenInContainerProxy;
			BeenInspected = proxy.m_BeenInspectedProxy;
			ItemLooted = proxy.m_ItemLootedProxy;
			RolledSpawnChance = proxy.m_RolledSpawnChanceProxy;
			WornOut = proxy.m_WornOut;
			StackableItem = Util.DeserializeObject<StackableItemSaveDataProxy>(proxy.m_StackableItemSerialized);
			FoodItem = Util.DeserializeObject<FoodItemSaveDataProxy>(proxy.m_FoodItemSerialized);
			LiquidItem = Util.DeserializeObject<LiquidItemSaveDataProxy>(proxy.m_LiquidItemSerialized);
			FlareItem = Util.DeserializeObject<FlareItemSaveDataProxy>(proxy.m_FlareItemSerialized);
			KeroseneLampItem = Util.DeserializeObject<KeroseneLampItemSaveDataProxy>(proxy.m_KeroseneLampItemSerialized);
			ClothingItem = Util.DeserializeObject<ClothingItemSaveDataProxy>(proxy.m_ClothingItemSerialized);
			WeaponItem = Util.DeserializeObject<GunItemSaveDataProxy>(proxy.m_WeaponItemSerialized);
			WaterSupply = Util.DeserializeObject<WaterSupplySaveDataProxy>(proxy.m_WaterSupplySerialized);
			Bed = Util.DeserializeObject<BedSaveDataProxy>(proxy.m_BedSerialized);
			SmashableItem = Util.DeserializeObject<SmashableItemSaveDataProxy>(proxy.m_SmashableItemSerialized);
			MatchesItem = Util.DeserializeObject<MatchesItemSaveDataProxy>(proxy.m_MatchesItemSerialized);
			SnareItem = Util.DeserializeObject<SnareItemSaveDataProxy>(proxy.m_SnareItemSerialized);
			InProgressItem = Util.DeserializeObject<InProgressCraftItemSaveDataProxy>(proxy.m_InProgressItemSerialized);
			TorchItem = Util.DeserializeObject<TorchItemSaveDataProxy>(proxy.m_TorchItemSerialized);
			CollectibleNote = Util.DeserializeObject<CollectibleNoteItemProxy>(proxy.m_CollectibleNoteSerialized);
			EvolveItem = Util.DeserializeObject<EvolveItemSaveData>(proxy.m_EvolveItemSerialized);
			ResearchItem = Util.DeserializeObject<ResearchItemSaveData>(proxy.m_ResearchItemSerialized);
			ObjectGuid = proxy.m_ObjectGuidSerialized;
			MissionObject = proxy.m_MissionObjectSerialized;
			WeightKG = proxy.m_WeightKG;
			HarvestedByPlayer = proxy.m_HarvestedByPlayer;
		}

		public InventoryItemSaveData Serialize()
		{
			var proxy = new GearItemSaveDataProxy();
			proxy.m_HoursPlayed = HoursPlayed;
			proxy.m_Position = Position;
			proxy.m_Rotation = Rotation;
			proxy.m_InstanceIDProxy = InstanceIDProxy;
			proxy.m_CurrentHPProxy = CurrentHPProxy;
			proxy.m_NormalizedCondition = NormalizedCondition;
			proxy.m_BeenInPlayerInventoryProxy = BeenInPlayerInventory;
			proxy.m_BeenInContainerProxy = BeenInContainer;
			proxy.m_BeenInspectedProxy = BeenInspected;
			proxy.m_ItemLootedProxy = ItemLooted;
			proxy.m_RolledSpawnChanceProxy = RolledSpawnChance;
			proxy.m_WornOut = WornOut;
			proxy.m_StackableItemSerialized = Util.SerializeObject(StackableItem);
			proxy.m_FoodItemSerialized = Util.SerializeObject(FoodItem);
			proxy.m_LiquidItemSerialized = Util.SerializeObject(LiquidItem);
			proxy.m_FlareItemSerialized = Util.SerializeObject(FlareItem);
			proxy.m_KeroseneLampItemSerialized = Util.SerializeObject(KeroseneLampItem);
			proxy.m_ClothingItemSerialized = Util.SerializeObject(ClothingItem);
			proxy.m_WeaponItemSerialized = Util.SerializeObject(WeaponItem);
			proxy.m_WaterSupplySerialized = Util.SerializeObject(WaterSupply);
			proxy.m_BedSerialized = Util.SerializeObject(Bed);
			proxy.m_SmashableItemSerialized = Util.SerializeObject(SmashableItem);
			proxy.m_MatchesItemSerialized = Util.SerializeObject(MatchesItem);
			proxy.m_SnareItemSerialized = Util.SerializeObject(SnareItem);
			proxy.m_InProgressItemSerialized = Util.SerializeObject(InProgressItem);
			proxy.m_TorchItemSerialized = Util.SerializeObject(TorchItem);
			proxy.m_CollectibleNoteSerialized = Util.SerializeObject(CollectibleNote);
			proxy.m_EvolveItemSerialized = Util.SerializeObject(EvolveItem);
			proxy.m_ResearchItemSerialized = Util.SerializeObject(ResearchItem);
			proxy.m_ObjectGuidSerialized = ObjectGuid;
			proxy.m_MissionObjectSerialized = MissionObject;
			proxy.m_WeightKG = WeightKG;
			proxy.m_HarvestedByPlayer = HarvestedByPlayer;

			var proxy2 = new InventoryItemSaveData();
			proxy2.m_PrefabName = PrefabName;
			proxy2.m_SerializedGear = Util.SerializeObject(proxy);

			return proxy2;
		}

		protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, newValue))
			{
				field = newValue;
				PropertyChangedEventHandler handler = PropertyChanged;
				if (handler != null)
					handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class GearItemSaveDataProxy
	{
		public float m_HoursPlayed { get; set; }
		public float[] m_Position { get; set; }
		public float[] m_Rotation { get; set; }
		public int m_InstanceIDProxy { get; set; }
		public float m_CurrentHPProxy { get; set; }
		public float m_NormalizedCondition { get; set; }
		public bool m_BeenInPlayerInventoryProxy { get; set; }
		public bool m_BeenInContainerProxy { get; set; }
		public bool m_BeenInspectedProxy { get; set; }
		public bool m_ItemLootedProxy { get; set; }
		public bool m_RolledSpawnChanceProxy { get; set; }
		public bool m_WornOut { get; set; }
		public string m_StackableItemSerialized { get; set; }
		public string m_FoodItemSerialized { get; set; }
		public string m_LiquidItemSerialized { get; set; }
		public string m_FlareItemSerialized { get; set; }
		public string m_KeroseneLampItemSerialized { get; set; }
		public string m_ClothingItemSerialized { get; set; }
		public string m_WeaponItemSerialized { get; set; }
		public string m_WaterSupplySerialized { get; set; }
		public string m_BedSerialized { get; set; }
		public string m_SmashableItemSerialized { get; set; }
		public string m_MatchesItemSerialized { get; set; }
		public string m_SnareItemSerialized { get; set; }
		public string m_InProgressItemSerialized { get; set; }
		public string m_TorchItemSerialized { get; set; }
		public string m_CollectibleNoteSerialized { get; set; }
		public string m_EvolveItemSerialized { get; set; }
		public string m_ObjectGuidSerialized { get; set; }
		public string m_MissionObjectSerialized { get; set; }
		public string m_ResearchItemSerialized { get; set; }
		public float m_WeightKG { get; set; }
		public bool m_HarvestedByPlayer { get; set; }
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
	}

	public class LiquidItemSaveDataProxy
	{
		public float m_LiquidLitersProxy { get; set; }
		public LiquidQuality m_LiquidQuality { get; set; }
	}

	public class FlareItemSaveDataProxy
	{
		public float m_HoursPlayed { get; set; }
		public FlareState m_StateProxy { get; set; }
		public float m_ElapsedBurnMinutesProxy { get; set; }
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
		public BedRollState m_BedRollState { get; set; }
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
		public SnareState m_State { get; set; }
	}

	public class InProgressCraftItemSaveDataProxy
	{
		public float m_PercentComplete { get; set; }
		public float m_Weight { get; set; }
	}

	public class TorchItemSaveDataProxy
	{
		public float m_HoursPlayed { get; set; }
		public TorchState m_StateProxy { get; set; }
		public float m_ElapsedBurnMinutesProxy { get; set; }
	}

	public class CollectibleNoteItemProxy
	{
		public string m_CacheLocatorGuid { get; set; }
	}

	public class EvolveItemSaveData
	{
		public float m_HoursPlayed { get; set; }
		public float m_TimeSpentEvolvingGameHours { get; set; }
	}

	public class MissionObjectIdentifierSaveProxy
	{
		public string m_Id;
		public MissionObjectClass m_ObjectClass;
		public string m_ActivityTags;
		public bool m_DestroyAfterMission;
	}

	public class ResearchItemSaveData
	{
		public float m_ElapsedHours;
	}

	#endregion

	public class PlayerManagerSaveDataProxy
	{
		public List<int> m_KnownCodes { get; set; }
		public float[] m_SaveGamePosition { get; set; }
		public float[] m_SaveGameRotation { get; set; }
		public bool m_StartGearAppliedProxy { get; set; }
		public int m_ItemInHandsInstanceID { get; set; }
		public int m_LastUnequippedItemInstanceID { get; set; }
		public bool m_InRunMode { get; set; }
		public bool m_Ghost { get; set; }
		public bool m_CheatsUsed { get; set; }
		public VoicePersona m_VoicePersona { get; set; }
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
		public float m_FireStartingSkill { get; set; }
		public float m_RepairSkill { get; set; }
		public float m_CleanSkill { get; set; }
		public float m_SharpenSkill { get; set; }
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
		public bool m_Bandaged { get; set; }
		public bool m_AntisepticTaken { get; set; }
		public float m_CommentTime;
		public float m_CurrentInfectionChance { get; set; }
		public string[] m_CausesLocIDs { get; set; }
		public int[] m_Locations { get; set; }
		public float[] m_ElapsedHoursList { get; set; }
		public float[] m_DurationHoursList { get; set; }
		public bool[] m_BandagedList { get; set; }
		public bool[] m_AntisepticTakenList { get; set; }
		public float[] m_CurrentInfectionChanceList { get; set; }
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
		public List<AfflictionType> m_Afflictions { get; set; }
		public List<string> m_LocationLocIDs { get; set; }
		public List<string> m_RegionLocIDs { get; set; }
		public List<string> m_RegionSceneNames { get; set; }
	}

	#endregion

	public class RestSaveDataProxy
	{
		public int m_LastDisplayedDayNumberOnAwake { get; set; }
		public int[] m_LastTwentyFourHoursOfSleep { get; set; }
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
	}

	public class ExperienceModeManagerSaveDataProxy
	{
		public ExperienceModeType m_CurrentModeType { get; set; }
	}

	public class PlayerMovementSaveDataProxy
	{
		public float m_SprintStamina { get; set; }
	}

	public class MusicEventSaveData
	{
		public float m_HappySuccessLastPlayTime { get; set; }
		public float m_SorrowLastPlayTime { get; set; }
		public float m_RopeClimbStressLastPlayTime { get; set; }
		public float m_BeingStalkedLastPlayTime { get; set; }
		public float m_NumHoursWithAffliction { get; set; }
	}

	public class ChimneySaveList
	{
		public List<LinkedChimneySaveData> m_SerializedChimneyData { get; set; }
	}

	public class LinkedChimneySaveData
	{
		public float m_LifetimeMinutes { get; set; }
		public string m_ChimneyGuid { get; set; }
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
		public List<CustomManagedObjectState> m_CustomManagedObjectStates { get; set; }
		public string m_SerializedGlobalBlackboard;
		public string m_VisibleMissionTimer { get; set; }
	}

	public class PlayerAnimationSaveData
	{
		public bool m_EnableFirstPersonHands { get; set; }
	}

	public class SkillsManagerSaveData
	{
		public string m_Skill_FirestartingSerialized { get; set; }
		public string m_Skill_CarcassHarvestingSerialized { get; set; }
		public string m_Skill_CookingSerialized { get; set; }
		public string m_Skill_IceFishingSerialized { get; set; }
		public string m_Skill_RifleSerialized { get; set; }
		public string m_Skill_ArcherySerialized { get; set; }
		public string m_Skill_ClothingRepairSerialized { get; set; }
	}

	public class SkillsManager
	{
		public Skill_FirestartingSaveData FireStartingSkill { get; set; }
		public Skill_CarcassHarvestingSaveData CarcassHarvestingSkill { get; set; }
		public Skill_CookingSaveData CookingSkill { get; set; }
		public Skill_IceFishingSaveData IceFishingSkill { get; set; }
		public Skill_RifleSaveData RifleSkill { get; set; }
		public Skill_ArcherySaveData ArcherySkill { get; set; }
		public Skill_ClothingRepairSaveData ClothingRepairSkill { get; set; }

		public SkillsManager(string json)
		{
			var proxy = Util.DeserializeObject<SkillsManagerSaveData>(json);
			if (proxy == null)
				return;

			FireStartingSkill = Util.DeserializeObject<Skill_FirestartingSaveData>(proxy.m_Skill_FirestartingSerialized);
			CarcassHarvestingSkill = Util.DeserializeObject<Skill_CarcassHarvestingSaveData>(proxy.m_Skill_CarcassHarvestingSerialized);
			CookingSkill = Util.DeserializeObject<Skill_CookingSaveData>(proxy.m_Skill_CookingSerialized);
			IceFishingSkill = Util.DeserializeObject<Skill_IceFishingSaveData>(proxy.m_Skill_IceFishingSerialized);
			RifleSkill = Util.DeserializeObject<Skill_RifleSaveData>(proxy.m_Skill_RifleSerialized);
			ArcherySkill = Util.DeserializeObject<Skill_ArcherySaveData>(proxy.m_Skill_ArcherySerialized);
			ClothingRepairSkill = Util.DeserializeObject<Skill_ClothingRepairSaveData>(proxy.m_Skill_ClothingRepairSerialized);


		}

		public string Serialize()
		{
			var proxy = new SkillsManagerSaveData();

			proxy.m_Skill_FirestartingSerialized = Util.SerializeObject(FireStartingSkill);
			proxy.m_Skill_CarcassHarvestingSerialized = Util.SerializeObject(CarcassHarvestingSkill);
			proxy.m_Skill_CookingSerialized = Util.SerializeObject(CookingSkill);
			proxy.m_Skill_IceFishingSerialized = Util.SerializeObject(IceFishingSkill);
			proxy.m_Skill_RifleSerialized = Util.SerializeObject(RifleSkill);
			proxy.m_Skill_ArcherySerialized = Util.SerializeObject(ArcherySkill);
			proxy.m_Skill_ClothingRepairSerialized = Util.SerializeObject(ClothingRepairSkill);

			return Util.SerializeObject(proxy);
		}

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
		public List<FeatType> m_FeatsEnabledThisSandbox;
	}

}
