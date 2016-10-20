using System.Collections.Generic;
using The_Long_Dark_Save_Editor_2.Game_data;

namespace The_Long_Dark_Save_Editor_2.Helpers
{

	public class ItemInfo
	{
		public string inGameName;
		public ItemCategory category;
		public string defaultSerialized;

		public override string ToString()
		{
			return inGameName;
		}
	}


	public static class ItemDictionary
	{
		public static Dictionary<string, ItemInfo> itemInfo = new Dictionary<string, ItemInfo>();

		private static void AddItemInfo(string itemID, string inGameName, ItemCategory category, string defaultSerialized)
		{
			itemInfo.Add(itemID, new ItemInfo { inGameName = inGameName, category = category, defaultSerialized = defaultSerialized });
		}

		public static string GetInGameName(string name)
		{
			if (itemInfo.ContainsKey(name))
				return itemInfo[name].inGameName;
			return name;
		}

		public static ItemCategory GetCategory(string name)
		{
			if (itemInfo.ContainsKey(name))
				return itemInfo[name].category;
			return ItemCategory.Unknown;
		}

		static ItemDictionary()
		{
			AddItemInfo("GEAR_BottleAntibiotics", "Antibiotics", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_BottleHydrogenPeroxide", "Antiseptic", ItemCategory.FirstAid, @"{""LiquidItem"": {""m_LiquidLitersProxy"": 1}}");
			AddItemInfo("GEAR_BottlePainKillers", "Painkillers", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_HeavyBandage", "Bandage", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_OldMansBeardDressing", "Old Man's Beard", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_WaterPurificationTablets", "Water Purification Tablets", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_EmergencyStim", "Emergency Stim", ItemCategory.FirstAid, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");

			AddItemInfo("GEAR_BasicBoots", "Basic Boots", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_BasicGloves", "Basic Gloves", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_BasicShoes", "Shoes", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_BasicWinterCoat", "Basic Winter Coat", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_BasicWoolHat", "Basic Wool Hat", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_CargoPants", "Cargo Pants", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_CottonSocks", "Cotton Socks", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_DeerSkinBoots", "Deerskin Boots", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_DeerSkinPants", "Deerskin Pants", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_DownSkiJacket", "Down Ski Jacket", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_SkiJacket", "Ski Jacket", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_DownVest", "Down West", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_FleeceSweater", "Fleece Sweater", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_HeavyWoolSweater", "Heavy Wool Sweater", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_Jeans", "Jeans", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_LongUnderwearWool", "Wool Long Johns", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_LongUnderwear", "Thermal underwear", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_Mittens", "Mittens", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_QualityWinterCoat", "Marine's Pea Coat", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_RabbitSkinMittens", "Rabbitskin Mitts", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_Toque", "Toque", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_WolfSkinCape", "Wolfskin Coat", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_WoolSocks", "Wool Socks", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_WoolSweater", "Thin Wool Sweater", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_WorkBoots", "Work Boots", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_BasicWoolScarf", "Basic Wool Scarf", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_InsulatedVest", "Insulated West", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_InsulatedBoots", "Insulated Boots", ItemCategory.Clothing, @"{""ClothingItem"": {}}");
			AddItemInfo("GEAR_PremiumWinterCoat", "Premium Winter Coat", ItemCategory.Clothing, @"{""ClothingItem"": {}}");

			AddItemInfo("GEAR_BeefJerky", "Beef Jerky", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 350}}");
			AddItemInfo("GEAR_CandyBar", "Candy Bar", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}}");
			AddItemInfo("GEAR_CannedBeans", "Pork and Beans", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 600}, ""SmashableItem"": {}}");
			AddItemInfo("GEAR_CannedSardines", "Tin of Sardines", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 300}, ""SmashableItem"": {}}");
			AddItemInfo("GEAR_CattailStalk", "Cat Tail Stalk", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 150}, ""StackableItem"":{""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_CoffeeTin", "Tin of Coffee", ItemCategory.Food, @"{""StackableItem"":{""m_UnitsProxy"": 6}}");
			AddItemInfo("GEAR_CondensedMilk", "Condensed Milk", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 750}}");
			AddItemInfo("GEAR_CookedLakeWhiteFish", "Lake Whitefish (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedMeatDeer", "Venison (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedMeatRabbit", "Rabbit (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedMeatWolf", "Wolf Meat (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedSmallMouthBass", "Smallmouth Bass (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedRainbowTrout", "Rainbow Trout (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_Crackers", "Salty Crackers", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 600}}");
			AddItemInfo("GEAR_DogFood", "Dog Food", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 500}, ""SmashableItem"": {}}");
			AddItemInfo("GEAR_EnergyBar", "Energy Bar", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 500}}");
			AddItemInfo("GEAR_GranolaBar", "Granola Bar", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 300}}");
			AddItemInfo("GEAR_GreenTeaCup", "Cup Of Herbal Tea", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 100}}");
			AddItemInfo("GEAR_GreenTeaPackage", "Herbal Tea", ItemCategory.Food, @"{""StackableItem"":{""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_MRE", "Military-Grade MRE", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 1750}}");
			AddItemInfo("GEAR_PeanutButter", "Peanut Butter", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 900}}");
			AddItemInfo("GEAR_PinnacleCanPeaches", "Pinnacle Peaches", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 450}, ""SmashableItem"": {}}");
			AddItemInfo("GEAR_RawLakeWhiteFish", "Lake Whitefish (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawMeatBear", "Bear Meat (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CookedMeatBear", "Bear Meat (Cooked)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawMeatDeer", "Venison (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawMeatRabbit", "Rabbit (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawMeatWolf", "Wolf Meat (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawSmallMouthBass", "Smallmouth Bass (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_Soda", "Summit Soda", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 250}}");
			AddItemInfo("GEAR_SodaGrape", "Stacy's Grape Soda", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 250}}");
			AddItemInfo("GEAR_SodaOrange", "Orange Soda", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 250}}");
			AddItemInfo("GEAR_TomatoSoupCan", "Tomato Soup", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 300}, ""SmashableItem"": {}}");
			AddItemInfo("GEAR_WaterSupplyNotPotable", "Unsafe Water", ItemCategory.Food, @"""WaterSupply"":{""m_VolumeProxy"": 1}");
			AddItemInfo("GEAR_WaterSupplyPotable", "Potable Water", ItemCategory.Food, @"""WaterSupply"":{""m_VolumeProxy"": 1}");
			AddItemInfo("GEAR_RawCohoSalmon", "Coho Salmon (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_RawRainbowTrout", "Rainbow Trout (Raw)", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 200}, WeightKG: 1}");
			AddItemInfo("GEAR_CoffeeCup", "Cup Of Coffee", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 100}}");
			AddItemInfo("GEAR_RoseHipTea", "Rose hip Tea", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 100}}");
			AddItemInfo("GEAR_ReishiTea", "Reishi Tea", ItemCategory.Food, @"{""FoodItem"": {""m_CaloriesRemainingProxy"": 100}}");

			//gear_bookmanual

			AddItemInfo("GEAR_Accelerant", "Accelerant", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Arrow", "Simple Arrow", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_ArrowShaft", "Arrow Shaft", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_BearSkinBedRoll", "Bear Skin Bedroll", ItemCategory.Tools, @"{""Bed"": {}}");
			AddItemInfo("GEAR_BedRoll", "Bedroll", ItemCategory.Tools, @"{""Bed"": {}}");
			AddItemInfo("GEAR_Bow", "Survival Bow", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_CanOpener", "Can Opener", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Firestriker", "Firestriker", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_FlareA", "Flare", ItemCategory.Tools, @"{""FlareItem"": {}}");
			AddItemInfo("GEAR_Hatchet", "Hatchet", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_HighQualityTools", "Quality Tools", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Hook", "Hook", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_HookAndLine", "Fishing Tackle", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_JerrycanRusty", "Jerry Can", ItemCategory.Tools, @"{""LiquidItem"": {""m_LiquidLitersProxy"": 1}}");
			AddItemInfo("GEAR_KeroseneLampB", "Storm Lantern", ItemCategory.Tools, @"{""KeroseneLampItem"": {""m_CurrentFuelLitersProxy"": 1}}");
			AddItemInfo("GEAR_Knife", "Hunting Knife", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_LampFuel", "Lantern Fuel", ItemCategory.Tools, @"{""LiquidItem"": {""m_LiquidLitersProxy"": 1}}");
			AddItemInfo("GEAR_Line", "Line", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_MagnifyingLens", "Magnifying Lens", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_NewsprintRoll", "Newsprint Roll", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_PackMatches", "Cardboard Matches", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 10}, ""MatchesItem"": {}}");
			AddItemInfo("GEAR_Prybar", "Prybar", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Rifle", "Hunting Rifle", ItemCategory.Tools, @"{""WeaponItem"": {""m_RoundsInClipProxy"": 10}}");
			AddItemInfo("GEAR_RifleAmmoBox", "Rifle Ammunition", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_RifleAmmoSingle", "Rifle Round", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_SewingKit", "Sewing Kit", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_SimpleTools", "Simple Tools", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Snare", "Snare", ItemCategory.Tools, @"{""SnareItem"": {}}");
			AddItemInfo("GEAR_Torch", "Torch", ItemCategory.Tools, @"{""TorchItem"": {}}");
			AddItemInfo("GEAR_Brand", "Brand", ItemCategory.Tools, @"{""TorchItem"": {}}"); //Check!!
			AddItemInfo("GEAR_WoodMatches", "Wood Matches", ItemCategory.Tools, @"{""StackableItem"": {""m_UnitsProxy"": 10}, ""MatchesItem"": {}}");
			AddItemInfo("GEAR_Hacksaw", "Hacksaw", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Hammer", "Heavy Hammer", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_HatchetImprovised", "Improvised Hatchet", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_KnifeImprovised", "Improvised Knife", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Flaregun", "Flare Gun", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_SharpeningStone", "Whetstone", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_Rope", "Rope", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_RifleCleaningKit", "Rifle Cleaning Kit", ItemCategory.Tools, @"{}");
			AddItemInfo("GEAR_FlareGunAmmoSingle", "Flare Gun Ammo", ItemCategory.Tools, @"{}");

			AddItemInfo("GEAR_ArrowHead", "Arrowhead", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""InProgressItem"": {""m_PercentComplete"": 100}}");
			AddItemInfo("GEAR_BearHide", "Fresh Black Bear Hide", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""EvolveItem"": {}}");
			AddItemInfo("GEAR_BearHideDried", "Cured Black Bear Hide", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_BirchSapling", "Green Birch Sapling", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""EvolveItem"": {}}");
			AddItemInfo("GEAR_BirchSaplingDried", "Cured Birch Sapling", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_BookC", "Book", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_CattailTinder", "Cat Tail Head", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Cloth", "Cloth", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_CrowFeather", "Crow Feather", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Firelog", "Firelog", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Gut", "Fresh Gut", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""EvolveItem"": {}}");
			AddItemInfo("GEAR_GutDried", "Cured Gut", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Hardwood", "Fir Firewood", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Leather", "Leather", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_LeatherDried", "Cured Leather", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_LeatherHide", "Fresh Deer Hide", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_LeatherHideDried", "Cured Deer Hide", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_MapleSapling", "Green Maple Sapling", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""EvolveItem"": {}}");
			AddItemInfo("GEAR_MapleSaplingDried", "Cured Maple Sapling", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Newsprint", "Newsprint", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_OldMansBeardHarvested", "Old Man's Beard Lichen", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_RabbitPelt", "Fresh Rabbit Pelt", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}, ""EvolveItem"": {}}");
			AddItemInfo("GEAR_ReclaimedWoodB", "Reclaimed Wood", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_ReishiMushroom", "Reishi Mushroom", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_RoseHip", "Rose Hip", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_ScrapMetal", "Scrap Metal", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Softwood", "Cedar Firewood", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Tinder", "Tinder Plug", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_WolfPelt", "Fresh Wolf Pelt", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_WolfPeltDried", "Cured Wolf Pelt", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_RabbitPeltDried", "Cured Rabbit Pelt", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Stick", "Stick", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_Coal", "Coal", ItemCategory.Materials, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");


			//Books
			AddItemInfo("GEAR_BookCarcassHarvesting", "Field Dressing Your Kill, vol. 1", ItemCategory.Books, @"{""ResearchItem"": {}}");
			AddItemInfo("GEAR_BookCooking", "Wilderness Kitchen", ItemCategory.Books, @"{""ResearchItem"": {}}");
			AddItemInfo("GEAR_BookFireStarting", "Survive The Outdoors!", ItemCategory.Books, @"{""ResearchItem"": {}}");
			AddItemInfo("GEAR_BookIceFishing", "The Frozen Angler", ItemCategory.Books, @"{""ResearchItem"": {}}");
			AddItemInfo("GEAR_BookRifleFirearm", "Frontier Shooting Guide", ItemCategory.Books, @"{""ResearchItem"": {}}");
			AddItemInfo("GEAR_BookRifleFirearmAdvanced", "Advanced Guns Guns Guns!", ItemCategory.Books, @"{""ResearchItem"": {}}");

			AddItemInfo("GEAR_ClimbersJournal", "Climbers Journal", ItemCategory.Collectible, @"{}");

			AddItemInfo("GEAR_Shovel", "Shovel", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_Fireaxe", "Fire Axe", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_Boltcutters", "Bolt Cutters", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_CollectibleNoteCommonReward", "Collectible Note Common", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_CollectibleNoteRareReward", "Collectible Note Common", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_FlintAndSteel", "Flint and Steel", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_CompressionBandage", "Compression Bandage", ItemCategory.Hidden, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_CarBattery", "Car Battery", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_AccelerantMedium", "Accelerant Medium", ItemCategory.Hidden, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_AccelerantKerosene", "Accelerant Kerosene", ItemCategory.Hidden, @"{""LiquidItem"": {""m_LiquidLitersProxy"": 1}}"); //Check!!
			AddItemInfo("GEAR_LeatherStrips", "Leather Strips", ItemCategory.Hidden, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_DamCodeNote", "Dam Code Note", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_DamControlRoomCodeNote", "Dam Control Room Code Note", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_DamOfficeKey", "Dam Office Key", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_HardCase", "Hard Case", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_Morphine", "Morphine", ItemCategory.Hidden, @"{""StackableItem"": {""m_UnitsProxy"": 1}}");
			AddItemInfo("GEAR_AstridBackPack", "Astrid Backpack", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_HikersBackPack", "Hiker's Backpack", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_EmergencyKitNote", "Emergency Kit Note", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_FarmerSalmanac", "Farmer Salmanac", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_FirstAidManual", "First Aid Manual", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_MountainTownFarmKey", "Mountain Town Farm Key", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_MountainTownFarmNote", "Mountain Town Farm Note", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_MountainTownLockBoxKey", "Mountain Town Lock Box Key", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_MountainTownMap", "Mountain Town Map", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_MountainTownStoreKey", "Mountain Town Store Key", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_OverpassBrochure", "Overpass Brochure", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_RicksJournal", "Rick's Journal", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_UtilitiesBill", "Utilities Bill", ItemCategory.Hidden, @"{}");
			AddItemInfo("GEAR_FishingLine", "Fishing Line", ItemCategory.Hidden, @"{}");


		}

	}
}
