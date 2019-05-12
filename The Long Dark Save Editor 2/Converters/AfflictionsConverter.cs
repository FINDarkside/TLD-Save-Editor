using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Converters
{
    public class AfflictionsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var afflictions = new Afflictions();
            foreach (object value in values)
            {
                if (value is HypothermiaSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(HypothermiaSaveDataProxy), value);
                    ConvertHypothermia((HypothermiaSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is FrostbiteSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(FrostbiteSaveDataProxy), value);
                    ConvertFrostbite((FrostbiteSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is FoodPoisoningSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(FoodPoisoningSaveDataProxy), value);
                    ConvertFoodPoisoning((FoodPoisoningSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is DysenterySaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(DysenterySaveDataProxy), value);
                    ConvertDysentery((DysenterySaveDataProxy)value, afflictions.Negative);
                }
                else if (value is SprainedAnkleSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(SprainedAnkleSaveDataProxy), value);
                    ConvertSprainedAnkle((SprainedAnkleSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is SprainedWristSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(SprainedWristSaveDataProxy), value);
                    ConvertSprainedWrist((SprainedWristSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is BurnsSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(BurnsSaveDataProxy), value);
                    ConvertBurns((BurnsSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is BurnsElectricSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(BurnsElectricSaveDataProxy), value);
                    ConvertBurnsElectric((BurnsElectricSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is BloodLossSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(BloodLossSaveDataProxy), value);
                    ConvertBloodLoss((BloodLossSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is InfectionSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(InfectionSaveDataProxy), value);
                    ConvertInfection((InfectionSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is InfectionRiskSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(InfectionRiskSaveDataProxy), value);
                    ConvertInfectionRisk((InfectionRiskSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is CabinFeverSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(CabinFeverSaveDataProxy), value);
                    ConvertCabinFever((CabinFeverSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is IntestinalParasitesSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(IntestinalParasitesSaveDataProxy), value);
                    ConvertIntestinalParasites((IntestinalParasitesSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is BrokenRibSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(BrokenRibSaveDataProxy), value);
                    ConvertBrokenRib((BrokenRibSaveDataProxy)value, afflictions.Negative);
                }
                else if (value is WellFedSaveDataProxy)
                {
                    afflictions.proxies.Add(typeof(WellFedSaveDataProxy), value);
                    ConvertWellFed((WellFedSaveDataProxy)value, afflictions.Positive);
                }
                else
                {
                    throw new Exception("Unknown affliction type " + value.GetType().Name);
                }
            }
            throw new NotImplementedException();
        }

        private void ConvertHypothermia(HypothermiaSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new Hypothermia(negative)
                {
                    AfflictionType = AfflictionType.Hypothermia,
                    Location = 6,
                    ElapsedHours = proxy.m_ElapsedHours,
                    ElapsedWarmHours = proxy.m_ElapsedHours,
                    Cause = proxy.m_CauseLocID,
                });
            }
            else if (proxy.m_ElapsedHours > 0)
            {
                negative.Add(new Hypothermia(negative)
                {
                    AfflictionType = AfflictionType.HypothermiaRisk,
                    Location = 6,
                    ElapsedHours = proxy.m_ElapsedHours,
                    ElapsedWarmHours = proxy.m_ElapsedHours,
                    Cause = proxy.m_CauseLocID,
                });
            }
        }

        private void ConvertFrostbite(FrostbiteSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            foreach (int bodyArea in proxy.m_LocationsWithActiveFrostbite)
            {
                negative.Add(new Frostbite(negative)
                {
                    AfflictionType = AfflictionType.Frostbite,
                    Location = bodyArea,
                    Damage = proxy.m_LocationsCurrentFrostbiteDamage[bodyArea],
                });
            }
            foreach (int bodyArea in proxy.m_LocationsWithFrostbiteRisk)
            {
                negative.Add(new Frostbite(negative)
                {
                    AfflictionType = AfflictionType.FrostbiteRisk,
                    Location = bodyArea,
                    Damage = proxy.m_LocationsCurrentFrostbiteDamage[bodyArea],
                });
            }
        }

        private void ConvertFoodPoisoning(FoodPoisoningSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new FoodPoisoning(negative)
                {
                    AfflictionType = AfflictionType.FoodPoisioning,
                    Location = 6,
                    AntibioticsTaken = proxy.m_AntibioticsTaken,
                    Cause = proxy.m_CauseLocID,
                    DurationHours = proxy.m_DurationHours,
                    ElapsedHours = proxy.m_ElapsedHours,
                    ElapsedRest = proxy.m_ElapsedHours,
                });
            }
        }

        private void ConvertDysentery(DysenterySaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new Dysentery(negative)
                {
                    AfflictionType = AfflictionType.Dysentery,
                    Location = 7,
                    AntibioticsTaken = proxy.m_AntibioticsTaken,
                    CleanWaterConsumed = proxy.m_CleanWaterConsumedLiters,
                    DurationHours = proxy.m_DurationHours,
                    ElapsedHours = proxy.m_ElapsedHours,
                    ElapsedRest = proxy.m_ElapsedRest,
                });
            }
        }

        private void ConvertSprainedAnkle(SprainedAnkleSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_ElapsedHoursList.Count; i++)
            {
                negative.Add(new SprainAffliction(negative)
                {
                    AfflictionType = AfflictionType.SprainedAnkle,
                    Location = proxy.m_Locations[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    Duration = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                    ElapsedRest = proxy.m_ElapsedRestList[i],
                });
            }
        }

        private void ConvertSprainedWrist(SprainedWristSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_ElapsedHoursList.Count; i++)
            {
                negative.Add(new SprainAffliction(negative)
                {
                    AfflictionType = AfflictionType.SprainedWrist,
                    Location = proxy.m_Locations[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    Duration = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                    ElapsedRest = proxy.m_ElapsedRestList[i],
                });
            }
        }

        private void ConvertBurns(BurnsSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new Burns(negative)
                {
                    AfflictionType = AfflictionType.Burns,
                    Location = 5,
                    BandageApplied = proxy.m_BandageApplied,
                    CauseLocID = proxy.m_CauseLocID,
                    DurationHours = proxy.m_DurationHours,
                    ElapsedHours = proxy.m_ElapsedHours,
                    PainKillersTaken = proxy.m_PainKillersTaken,
                });
            }
        }

        private void ConvertBurnsElectric(BurnsElectricSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new BurnsElectric(negative)
                {
                    AfflictionType = AfflictionType.Burns,
                    Location = 5,
                    BandageApplied = proxy.m_BandageApplied,
                    DurationHours = proxy.m_DurationHours,
                    ElapsedHours = proxy.m_ElapsedHours,
                    PainKillersTaken = proxy.m_PainKillersTaken,
                });
            }
        }

        private void ConvertBloodLoss(BloodLossSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                negative.Add(new BloodLoss(negative)
                {
                    AfflictionType = AfflictionType.BloodLoss,
                    Location = proxy.m_Locations[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    DurationHours = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                });
            }
        }

        private void ConvertInfection(InfectionSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                negative.Add(new Infection(negative)
                {
                    AfflictionType = AfflictionType.Infection,
                    Location = proxy.m_Locations[i],
                    AntibioticsTaken = proxy.m_AntibioticsTakenList[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    DurationHours = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                    ElapsedRest = proxy.m_ElapsedRestList[i],
                });
            }
        }

        private void ConvertInfectionRisk(InfectionRiskSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                negative.Add(new InfectionRisk(negative)
                {
                    AfflictionType = AfflictionType.InfectionRisk,
                    Location = proxy.m_Locations[i],
                    AntisepticTaken = proxy.m_AntisepticTakenList[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    CurrentInfectionChance = proxy.m_CurrentInfectionChanceList[i],
                    DurationHours = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                });
            }
        }

        private void ConvertCabinFever(CabinFeverSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_Active)
            {
                negative.Add(new CabinFever(negative)
                {
                    AfflictionType = AfflictionType.CabinFever,
                    Location = 0,
                    ElapsedHours = proxy.m_ElapsedHours,
                });
            }
            else if (proxy.m_RiskActive)
            {
                negative.Add(new CabinFever(negative)
                {
                    AfflictionType = AfflictionType.CabinFeverRisk,
                    Location = 0,
                    ElapsedHours = proxy.m_ElapsedHours,
                });
            }
        }

        private void ConvertIntestinalParasites(IntestinalParasitesSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            if (proxy.m_HasParasites || proxy.m_HasParasiteRisk)
            {
                var affliction = proxy.m_HasParasites ? AfflictionType.IntestinalParasites : AfflictionType.IntestinalParasitesRisk;
                negative.Add(new IntestinalParasites(negative)
                {
                    AfflictionType = affliction,
                    Location = 7,
                    CurrentInfectionChance = proxy.m_CurrentInfectionChance,
                    DayToAllowNextDose = proxy.m_DayToAllowNextDose,
                    DosesTaken = proxy.m_NumDosesTaken,
                    HasTakenDoseToday = proxy.m_HasTakenDoseToday,
                    ParasitesElapsedHours = proxy.m_ParasitesElapsedHours,
                    PiecesEatenThisRiskCycle = proxy.m_NumPiecesEatenThisRiskCycle,
                    RiskDurationHours = proxy.m_RiskDurationHours,
                    RiskElapsedHours = proxy.m_RiskElapsedHours,
                });
            }
        }

        private void ConvertBrokenRib(BrokenRibSaveDataProxy proxy, ObservableCollection<Affliction> negative)
        {
            for (int i = 0; i < proxy.m_Locations.Count; i++)
            {
                negative.Add(new BrokenRib(negative)
                {
                    AfflictionType = AfflictionType.BrokenRib,
                    Location = proxy.m_Locations[i],
                    BandagesApplied = proxy.m_BandagesApplied[i],
                    ElapsedRest = proxy.m_ElapsedRestList[i],
                    NumHoursRestForCure = proxy.m_NumHoursRestForCureList[i],
                    PainKillersTaken = proxy.m_PainKillersTaken[i],
                });
            }
        }

        private void ConvertWellFed(WellFedSaveDataProxy proxy, ObservableCollection<Affliction> positive)
        {
            if (proxy.m_Active)
            {
                positive.Add(new WellFed(positive)
                {
                    AfflictionType = AfflictionType.WellFed,
                    Location = 6,
                    ElapsedHoursNotStarving = proxy.m_ElapsedHoursNotStarving,
                });
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var result = new object[targetTypes.Length];
            var afflictions = (Afflictions)value;
            var afflictionDict = new Dictionary<AfflictionType, List<Affliction>>();
            foreach (var affliction in afflictions.Negative.Concat(afflictions.Positive))
            {
                if (!afflictionDict.ContainsKey(affliction.AfflictionType))
                    afflictionDict.Add(affliction.AfflictionType, new List<Affliction>());
                afflictionDict[affliction.AfflictionType].Add(affliction);
            }

            result[Array.IndexOf(targetTypes, typeof(HypothermiaSaveDataProxy))] = ConvertBackHypothermia(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(FrostbiteSaveDataProxy))] = ConvertBackHypothermia(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(FoodPoisoningSaveDataProxy))] = ConvertBackFoodPoisoning(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(DysenterySaveDataProxy))] = ConvertBackDysentery(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(SprainedAnkleSaveDataProxy))] = ConvertBackSprainedAnkle(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(SprainedWristSaveDataProxy))] = ConvertBackSprainedWrist(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(BurnsSaveDataProxy))] = ConvertBackBurns(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(BurnsElectricSaveDataProxy))] = ConvertBackBurnsElectric(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(BloodLossSaveDataProxy))] = ConvertBackBloodLoss(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(InfectionSaveDataProxy))] = ConvertBackInfection(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(InfectionRiskSaveDataProxy))] = ConvertBackInfectionRisk(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(CabinFeverSaveDataProxy))] = ConvertBackCabinFever(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(IntestinalParasitesSaveDataProxy))] = ConvertBackIntestinalParasites(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(BrokenRibSaveDataProxy))] = ConvertBackBrokenRib(afflictions, afflictionDict);
            result[Array.IndexOf(targetTypes, typeof(WellFedSaveDataProxy))] = ConvertBackWellFed(afflictions, afflictionDict);
            return result;
        }

        private string FillCauseLocId(string s)
        {
            if (s == null || s == "")
                return "Save Editor";
            return s;
        }

        private HypothermiaSaveDataProxy ConvertBackHypothermia(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (HypothermiaSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(HypothermiaSaveDataProxy), new HypothermiaSaveDataProxy());
            if (!afflictionDict.ContainsKey(AfflictionType.Hypothermia) && !afflictionDict.ContainsKey(AfflictionType.HypothermiaRisk))
            {
                return (proxy.m_Active || proxy.m_ElapsedHours > 0) ? new HypothermiaSaveDataProxy() : proxy;
            }
            proxy.m_Active = afflictionDict.ContainsKey(AfflictionType.Hypothermia);
            var hypothermia = (Hypothermia)(proxy.m_Active ? afflictionDict[AfflictionType.Hypothermia][0] : afflictionDict[AfflictionType.HypothermiaRisk][0]);
            proxy.m_ElapsedHours = hypothermia.ElapsedHours;
            proxy.m_ElapsedWarmTime = hypothermia.ElapsedWarmHours;
            proxy.m_CauseLocID = hypothermia.Cause;
            return proxy;
        }

        private FrostbiteSaveDataProxy ConvertBackFrostBite(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (FrostbiteSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(FrostbiteSaveDataProxy), new FrostbiteSaveDataProxy());
            var frostbites = afflictionDict.GetOrDefault(AfflictionType.Frostbite, new List<Affliction>()).Cast<Frostbite>().ToList();
            var frostbiteRisks = afflictionDict.GetOrDefault(AfflictionType.FrostbiteRisk, new List<Affliction>()).Cast<Frostbite>().ToList();
            proxy.m_LocationsCurrentFrostbiteDamage = new List<float>();
            proxy.m_LocationsWithActiveFrostbite = new List<int>();
            foreach (var frostbite in frostbites)
            {
                proxy.m_LocationsWithActiveFrostbite.Add(frostbite.Location);
                proxy.m_LocationsCurrentFrostbiteDamage[frostbite.Location] = frostbite.Damage;
            }
            foreach (var frostbite in frostbiteRisks)
            {
                proxy.m_LocationsWithFrostbiteRisk.Add(frostbite.Location);
                proxy.m_LocationsCurrentFrostbiteDamage[frostbite.Location] = frostbite.Damage;
            }
            return proxy;
        }

        private FoodPoisoningSaveDataProxy ConvertBackFoodPoisoning(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (FoodPoisoningSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(FoodPoisoningSaveDataProxy), new FoodPoisoningSaveDataProxy());
            var foodpoisoning = (FoodPoisoning)afflictionDict.Get(AfflictionType.FoodPoisioning)?[0];
            if (foodpoisoning == null)
            {
                return proxy.m_Active ? new FoodPoisoningSaveDataProxy() : proxy;
            }
            proxy.m_Active = true;
            proxy.m_AntibioticsTaken = foodpoisoning.AntibioticsTaken;
            proxy.m_CauseLocID = foodpoisoning.Cause;
            proxy.m_DurationHours = foodpoisoning.DurationHours;
            proxy.m_ElapsedHours = foodpoisoning.ElapsedHours;
            proxy.m_ElapsedRest = foodpoisoning.ElapsedRest;
            return proxy;
        }

        private DysenterySaveDataProxy ConvertBackDysentery(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (DysenterySaveDataProxy)afflictions.proxies.GetOrDefault(typeof(DysenterySaveDataProxy), new DysenterySaveDataProxy());
            var dysentery = (Dysentery)afflictionDict.Get(AfflictionType.Dysentery)?[0];
            if (dysentery == null)
            {
                return proxy.m_Active ? new DysenterySaveDataProxy() : proxy;
            }

            proxy.m_Active = true;
            proxy.m_AntibioticsTaken = dysentery.AntibioticsTaken;
            proxy.m_CleanWaterConsumedLiters = dysentery.CleanWaterConsumed;
            proxy.m_DurationHours = dysentery.DurationHours;
            proxy.m_ElapsedHours = dysentery.ElapsedHours;
            proxy.m_ElapsedRest = dysentery.ElapsedRest;
            return proxy;
        }

        private SprainedAnkleSaveDataProxy ConvertBackSprainedAnkle(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (SprainedAnkleSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(SprainedAnkleSaveDataProxy), new SprainedAnkleSaveDataProxy());
            var sprainedAnkles = afflictionDict.Get(AfflictionType.SprainedAnkle)?.Cast<SprainAffliction>().ToList();
            if (sprainedAnkles == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new SprainedAnkleSaveDataProxy() : proxy;
            }
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_DurationHoursList = new List<float>();
            proxy.m_ElapsedHoursList = new List<float>();
            proxy.m_ElapsedRestList = new List<float>();
            proxy.m_Locations = new List<int>();
            foreach (var sprain in sprainedAnkles)
            {
                proxy.m_CausesLocIDs.Add(sprain.CauseLocID);
                proxy.m_DurationHoursList.Add(sprain.Duration);
                proxy.m_ElapsedHoursList.Add(sprain.ElapsedHours);
                proxy.m_ElapsedRestList.Add(sprain.ElapsedRest);
                proxy.m_Locations.Add(sprain.Location);
            }
            return proxy;
        }

        private SprainedWristSaveDataProxy ConvertBackSprainedWrist(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (SprainedWristSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(SprainedWristSaveDataProxy), new SprainedWristSaveDataProxy());
            var sprainedWrists = afflictionDict.Get(AfflictionType.SprainedWrist)?.Cast<SprainAffliction>().ToList();
            if (sprainedWrists == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new SprainedWristSaveDataProxy() : proxy;
            }
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_DurationHoursList = new List<float>();
            proxy.m_ElapsedHoursList = new List<float>();
            proxy.m_ElapsedRestList = new List<float>();
            proxy.m_Locations = new List<int>();
            foreach (var sprain in sprainedWrists)
            {
                proxy.m_CausesLocIDs.Add(sprain.CauseLocID);
                proxy.m_DurationHoursList.Add(sprain.Duration);
                proxy.m_ElapsedHoursList.Add(sprain.ElapsedHours);
                proxy.m_ElapsedRestList.Add(sprain.ElapsedRest);
                proxy.m_Locations.Add(sprain.Location);
            }
            return proxy;
        }

        private BurnsSaveDataProxy ConvertBackBurns(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (BurnsSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(BurnsSaveDataProxy), new BurnsSaveDataProxy());
            var burns = afflictionDict.Get(AfflictionType.Burns)?.Cast<Burns>().ToList()[0];
            if (burns == null)
            {
                return proxy.m_Active ? new BurnsSaveDataProxy() : proxy;
            }
            proxy.m_Active = true;
            proxy.m_BandageApplied = burns.BandageApplied;
            proxy.m_DurationHours = burns.DurationHours;
            proxy.m_ElapsedHours = burns.ElapsedHours;
            proxy.m_PainKillersTaken = burns.PainKillersTaken;
            proxy.m_CauseLocID = burns.CauseLocID;
            return proxy;
        }

        private BurnsElectricSaveDataProxy ConvertBackBurnsElectric(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (BurnsElectricSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(BurnsElectricSaveDataProxy), new BurnsElectricSaveDataProxy());
            var burns = afflictionDict.Get(AfflictionType.BurnsElectric)?.Cast<BurnsElectric>().ToList()[0];
            if (burns == null)
            {
                return proxy.m_Active ? new BurnsElectricSaveDataProxy() : proxy;
            }
            proxy.m_Active = true;
            proxy.m_BandageApplied = burns.BandageApplied;
            proxy.m_DurationHours = burns.DurationHours;
            proxy.m_ElapsedHours = burns.ElapsedHours;
            proxy.m_PainKillersTaken = burns.PainKillersTaken;
            return proxy;
        }

        private BloodLossSaveDataProxy ConvertBackBloodLoss(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (BloodLossSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(BloodLossSaveDataProxy), new BloodLossSaveDataProxy());
            var bloodLosses = afflictionDict.Get(AfflictionType.BloodLoss)?.Cast<BloodLoss>().ToList();
            if (bloodLosses == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new BloodLossSaveDataProxy() : proxy;
            }
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_DurationHoursList = new List<float>();
            proxy.m_ElapsedHoursList = new List<float>();
            proxy.m_Locations = new List<int>();
            foreach (var bloodLoss in bloodLosses)
            {
                proxy.m_CausesLocIDs.Add(bloodLoss.CauseLocID);
                proxy.m_DurationHoursList.Add(bloodLoss.DurationHours);
                proxy.m_ElapsedHoursList.Add(bloodLoss.ElapsedHours);
                proxy.m_Locations.Add(bloodLoss.Location);
            }
            return proxy;
        }

        private InfectionSaveDataProxy ConvertBackInfection(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (InfectionSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(InfectionSaveDataProxy), new InfectionSaveDataProxy());
            var infections = afflictionDict.Get(AfflictionType.Infection)?.Cast<Infection>().ToList();
            if (infections == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new InfectionSaveDataProxy() : proxy;
            }
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_DurationHoursList = new List<float>();
            proxy.m_ElapsedHoursList = new List<float>();
            proxy.m_Locations = new List<int>();
            proxy.m_AntibioticsTakenList = new List<bool>();
            proxy.m_ElapsedRestList = new List<float>();
            foreach (var infection in infections)
            {
                proxy.m_CausesLocIDs.Add(infection.CauseLocID);
                proxy.m_DurationHoursList.Add(infection.DurationHours);
                proxy.m_ElapsedHoursList.Add(infection.ElapsedHours);
                proxy.m_Locations.Add(infection.Location);
                proxy.m_AntibioticsTakenList.Add(infection.AntibioticsTaken);
                proxy.m_ElapsedRestList.Add(infection.ElapsedRest);
            }
            return proxy;
        }

        private InfectionRiskSaveDataProxy ConvertBackInfectionRisk(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (InfectionRiskSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(InfectionRiskSaveDataProxy), new InfectionRiskSaveDataProxy());
            var infectionRisks = afflictionDict.Get(AfflictionType.InfectionRisk)?.Cast<InfectionRisk>().ToList();
            if (infectionRisks == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new InfectionRiskSaveDataProxy() : proxy;
            }
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_DurationHoursList = new List<float>();
            proxy.m_ElapsedHoursList = new List<float>();
            proxy.m_Locations = new List<int>();
            proxy.m_AntisepticTakenList = new List<bool>();
            proxy.m_ConstantAfflictionIndices = new List<int>();
            proxy.m_CurrentInfectionChanceList = new List<float>();
            foreach (var infectionRisk in infectionRisks)
            {
                proxy.m_CausesLocIDs.Add(infectionRisk.CauseLocID);
                proxy.m_DurationHoursList.Add(infectionRisk.DurationHours);
                proxy.m_ElapsedHoursList.Add(infectionRisk.ElapsedHours);
                proxy.m_Locations.Add(infectionRisk.Location);
                proxy.m_AntisepticTakenList.Add(infectionRisk.AntisepticTaken);
                if (infectionRisk.Constant)
                {
                    proxy.m_ConstantAfflictionIndices.Add(infectionRisk.Location);
                }
                proxy.m_CurrentInfectionChanceList.Add(infectionRisk.CurrentInfectionChance);
            }
            return proxy;
        }

        private CabinFeverSaveDataProxy ConvertBackCabinFever(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (CabinFeverSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(CabinFeverSaveDataProxy), new CabinFeverSaveDataProxy());
            var cabinFever = (CabinFever)afflictionDict.Get(AfflictionType.CabinFever)?[0];
            var cabinFeverRisk = (CabinFever)afflictionDict.Get(AfflictionType.CabinFeverRisk)?[0];
            if (cabinFever == null && cabinFeverRisk == null)
            {
                return (proxy.m_Active || proxy.m_RiskActive) ? new CabinFeverSaveDataProxy() : proxy;
            }
            proxy.m_Active = cabinFever != null;
            proxy.m_RiskActive = cabinFeverRisk != null;
            proxy.m_ElapsedHours = cabinFever != null ? cabinFever.ElapsedHours : cabinFeverRisk.ElapsedHours;
            return proxy;
        }

        private IntestinalParasitesSaveDataProxy ConvertBackIntestinalParasites(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (IntestinalParasitesSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(IntestinalParasitesSaveDataProxy), new IntestinalParasitesSaveDataProxy());
            var parasites = (IntestinalParasites)afflictionDict.Get(AfflictionType.IntestinalParasites)?[0];
            var parasitesRisk = (IntestinalParasites)afflictionDict.Get(AfflictionType.IntestinalParasitesRisk)?[0];
            if (parasites == null && parasitesRisk == null)
            {
                return (proxy.m_HasParasites || proxy.m_HasParasiteRisk) ? new IntestinalParasitesSaveDataProxy() : proxy;
            }
            if (parasites != null)
            {
                proxy.m_CurrentInfectionChance = 80;
                proxy.m_DayToAllowNextDose = 0;
                proxy.m_HasParasiteRisk = false;
                proxy.m_HasParasites = true;
                proxy.m_HasTakenDoseToday = false;
                proxy.m_NumDosesTaken = 0;
                proxy.m_NumPiecesEatenThisRiskCycle = 0;
                proxy.m_ParasitesElapsedHours = 0;
                proxy.m_RiskDurationHours = 0;
                proxy.m_RiskElapsedHours = 0;
            }
            else
            {
                proxy.m_CurrentInfectionChance = 40;
                proxy.m_DayToAllowNextDose = 0;
                proxy.m_HasParasiteRisk = true;
                proxy.m_HasParasites = false;
                proxy.m_HasTakenDoseToday = false;
                proxy.m_NumDosesTaken = 0;
                proxy.m_NumPiecesEatenThisRiskCycle = 0;
                proxy.m_ParasitesElapsedHours = 0;
                proxy.m_RiskDurationHours = 0;
                proxy.m_RiskElapsedHours = 0;
            }
            return proxy;
        }

        private BrokenRibSaveDataProxy ConvertBackBrokenRib(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (BrokenRibSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(BrokenRibSaveDataProxy), new BrokenRibSaveDataProxy());
            var brokenRibs = afflictionDict.Get(AfflictionType.BrokenRib)?.Cast<BrokenRib>().ToList();
            if (brokenRibs == null)
            {
                return proxy.m_CausesLocIDs.Count > 0 ? new BrokenRibSaveDataProxy() : proxy;
            }
            proxy.m_BandagesApplied = new List<int>();
            proxy.m_CausesLocIDs = new List<string>();
            proxy.m_ElapsedRestList = new List<float>();
            proxy.m_Locations = new List<int>();
            proxy.m_NumHoursRestForCureList = new List<float>();
            proxy.m_PainKillersTaken = new List<int>();
            foreach (var brokenRib in brokenRibs)
            {
                proxy.m_BandagesApplied.Add(brokenRib.BandagesApplied);
                proxy.m_CausesLocIDs.Add(brokenRib.CauseLocID);
                proxy.m_ElapsedRestList.Add(brokenRib.ElapsedRest);
                proxy.m_Locations.Add(brokenRib.Location);
                proxy.m_NumHoursRestForCureList.Add(brokenRib.NumHoursRestForCure);
                proxy.m_PainKillersTaken.Add(brokenRib.PainKillersTaken);
            }
            return proxy;
        }

        private WellFedSaveDataProxy ConvertBackWellFed(Afflictions afflictions, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            var proxy = (WellFedSaveDataProxy)afflictions.proxies.GetOrDefault(typeof(WellFedSaveDataProxy), new WellFedSaveDataProxy());
            var wellFed = (WellFed)afflictionDict.Get(AfflictionType.WellFed)?[0];
            if (wellFed == null)
            {
                return proxy.m_Active ? new WellFedSaveDataProxy() : proxy;
            }
            proxy.m_Active = true;
            proxy.m_ElapsedHoursNotStarving = wellFed.ElapsedHoursNotStarving;
            return proxy;
        }
    }
}
