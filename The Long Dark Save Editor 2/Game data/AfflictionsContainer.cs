using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    public class AfflictionsContainer
    {

        private ObservableCollection<Affliction> negative = new ObservableCollection<Affliction>();
        public ObservableCollection<Affliction> Negative { get { return negative; } set { SetPropertyField(ref negative, value); } }
        private ObservableCollection<Affliction> positive = new ObservableCollection<Affliction>();
        public ObservableCollection<Affliction> Positive { get { return positive; } set { SetPropertyField(ref positive, value); } }
        public Dictionary<Type, object> proxies = new Dictionary<Type, object>();

        public AfflictionsContainer(GlobalSaveGameFormat global)
        {
            negative.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Negative")); };
            positive.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Positive")); };

            ConvertHypothermia(global.Hypothermia);
            ConvertFrostbite(global.FrostBite);
            ConvertFoodPoisoning(global.FoodPoisoning);
            ConvertDysentery(global.Dysentery);
            ConvertSprainedAnkle(global.SprainedAnkle);
            ConvertSprainedWrist(global.SprainedWrist);
            ConvertBurns(global.Burns);
            ConvertBurnsElectric(global.BurnsElectric);
            ConvertBloodLoss(global.BloodLoss);
            ConvertInfection(global.Infection);
            ConvertInfectionRisk(global.InfectionRisk);
            ConvertCabinFever(global.CabinFever);
            ConvertIntestinalParasites(global.IntestinalParasites);
            ConvertBrokenRib(global.BrokenRibs);
            ConvertWellFed(global.WellFed);

        }

        private void ConvertHypothermia(HypothermiaSaveDataProxy proxy)
        {
            if (proxy == null)
                return;
            if (proxy.m_Active)
            {
                Negative.Add(new Hypothermia(negative)
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
                Negative.Add(new Hypothermia(negative)
                {
                    AfflictionType = AfflictionType.HypothermiaRisk,
                    Location = 6,
                    ElapsedHours = proxy.m_ElapsedHours,
                    ElapsedWarmHours = proxy.m_ElapsedHours,
                    Cause = proxy.m_CauseLocID,
                });
            }
        }

        private void ConvertFrostbite(FrostbiteSaveDataProxy proxy)
        {
            if (proxy == null)
                return;

            var frostbiteDamage = new List<float>(proxy.m_LocationsCurrentFrostbiteDamage);

            foreach (int bodyArea in proxy.m_LocationsWithActiveFrostbite)
            {
                Negative.Add(new Frostbite(negative)
                {
                    AfflictionType = AfflictionType.Frostbite,
                    Location = bodyArea,
                    Damage = proxy.m_LocationsCurrentFrostbiteDamage[bodyArea],
                });
                frostbiteDamage[bodyArea] = 0;
            }
            foreach (int bodyArea in proxy.m_LocationsWithFrostbiteRisk)
            {
                Negative.Add(new Frostbite(negative)
                {
                    AfflictionType = AfflictionType.FrostbiteRisk,
                    Location = bodyArea,
                    Damage = proxy.m_LocationsCurrentFrostbiteDamage[bodyArea],
                });
                frostbiteDamage[bodyArea] = 0;
            }
            for (int i = 0; i < frostbiteDamage.Count; i++)
            {
                if (frostbiteDamage[i] > 0)
                {
                    Negative.Add(new Frostbite(negative)
                    {
                        AfflictionType = AfflictionType.FrostbiteDamage,
                        Location = i,
                        Damage = frostbiteDamage[i],
                    });
                }
            }
        }

        private void ConvertFoodPoisoning(FoodPoisoningSaveDataProxy proxy)
        {
            if (proxy == null || !proxy.m_Active)
                return;
            Negative.Add(new FoodPoisoning(negative)
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

        private void ConvertDysentery(DysenterySaveDataProxy proxy)
        {
            if (proxy == null || !proxy.m_Active)
                return;
            Negative.Add(new Dysentery(negative)
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

        private void ConvertSprainedAnkle(SprainedAnkleSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_ElapsedHoursList == null)
                return;
            for (int i = 0; i < proxy.m_ElapsedHoursList.Count; i++)
            {
                Negative.Add(new SprainAffliction(negative)
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

        private void ConvertSprainedWrist(SprainedWristSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_CausesLocIDs == null)
                return;
            for (int i = 0; i < proxy.m_ElapsedHoursList.Count; i++)
            {
                Negative.Add(new SprainAffliction(negative)
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

        private void ConvertBurns(BurnsSaveDataProxy proxy)
        {
            if (proxy == null || !proxy.m_Active)
                return;
            Negative.Add(new Burns(negative)
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

        private void ConvertBurnsElectric(BurnsElectricSaveDataProxy proxy)
        {
            if (proxy == null || !proxy.m_Active)
                return;
            Negative.Add(new BurnsElectric(negative)
            {
                AfflictionType = AfflictionType.BurnsElectric,
                Location = 3,
                BandageApplied = proxy.m_BandageApplied,
                DurationHours = proxy.m_DurationHours,
                ElapsedHours = proxy.m_ElapsedHours,
                PainKillersTaken = proxy.m_PainKillersTaken,
            });
        }

        private void ConvertBloodLoss(BloodLossSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_CausesLocIDs == null)
                return;
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                Negative.Add(new BloodLoss(negative)
                {
                    AfflictionType = AfflictionType.BloodLoss,
                    Location = proxy.m_Locations[i],
                    CauseLocID = proxy.m_CausesLocIDs[i],
                    DurationHours = proxy.m_DurationHoursList[i],
                    ElapsedHours = proxy.m_ElapsedHoursList[i],
                });
            }
        }

        private void ConvertInfection(InfectionSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_DurationHoursList == null)
                return;
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                Negative.Add(new Infection(negative)
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

        private void ConvertInfectionRisk(InfectionRiskSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_CausesLocIDs == null)
                return;
            for (int i = 0; i < proxy.m_DurationHoursList.Count; i++)
            {
                Negative.Add(new InfectionRisk(negative)
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

        private void ConvertCabinFever(CabinFeverSaveDataProxy proxy)
        {
            if (proxy == null)
                return;
            if (proxy.m_Active)
            {
                Negative.Add(new CabinFever(negative)
                {
                    AfflictionType = AfflictionType.CabinFever,
                    Location = 0,
                    ElapsedHours = proxy.m_ElapsedHours,
                });
            }
            else if (proxy.m_RiskActive)
            {
                Negative.Add(new CabinFever(negative)
                {
                    AfflictionType = AfflictionType.CabinFeverRisk,
                    Location = 0,
                    ElapsedHours = proxy.m_ElapsedHours,
                });
            }
        }

        private void ConvertIntestinalParasites(IntestinalParasitesSaveDataProxy proxy)
        {
            if (proxy == null)
                return;
            if (proxy.m_HasParasites || proxy.m_HasParasiteRisk)
            {
                var affliction = proxy.m_HasParasites ? AfflictionType.IntestinalParasites : AfflictionType.IntestinalParasitesRisk;
                Negative.Add(new IntestinalParasites(negative)
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

        private void ConvertBrokenRib(BrokenRibSaveDataProxy proxy)
        {
            if (proxy == null || proxy.m_CausesLocIDs == null)
                return;
            for (int i = 0; i < proxy.m_Locations.Count; i++)
            {
                Negative.Add(new BrokenRib(negative)
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

        private void ConvertWellFed(WellFedSaveDataProxy proxy)
        {
            if (proxy == null || !proxy.m_Active)
                return;
            Positive.Add(new WellFed(positive)
            {
                AfflictionType = AfflictionType.WellFed,
                Location = 6,
                ElapsedHoursNotStarving = proxy.m_ElapsedHoursNotStarving,
            });
        }

        public void SerializeTo(GlobalSaveGameFormat global)
        {
            var afflictionDict = new Dictionary<AfflictionType, List<Affliction>>();
            foreach (var affliction in Negative.Concat(Positive))
            {
                if (!afflictionDict.ContainsKey(affliction.AfflictionType))
                    afflictionDict.Add(affliction.AfflictionType, new List<Affliction>());
                afflictionDict[affliction.AfflictionType].Add(affliction);
            }

            global.Hypothermia = ConvertBackHypothermia(global.Hypothermia, afflictionDict);
            global.FrostBite = ConvertBackFrostBite(global.FrostBite, afflictionDict);
            global.FoodPoisoning = ConvertBackFoodPoisoning(global.FoodPoisoning, afflictionDict);
            global.Dysentery = ConvertBackDysentery(global.Dysentery, afflictionDict);
            global.SprainedAnkle = ConvertBackSprainedAnkle(global.SprainedAnkle, afflictionDict);
            global.SprainedWrist = ConvertBackSprainedWrist(global.SprainedWrist, afflictionDict);
            global.Burns = ConvertBackBurns(global.Burns, afflictionDict);
            global.BurnsElectric = ConvertBackBurnsElectric(global.BurnsElectric, afflictionDict);
            global.BloodLoss = ConvertBackBloodLoss(global.BloodLoss, afflictionDict);
            global.Infection = ConvertBackInfection(global.Infection, afflictionDict);
            global.InfectionRisk = ConvertBackInfectionRisk(global.InfectionRisk, afflictionDict);
            global.CabinFever = ConvertBackCabinFever(global.CabinFever, afflictionDict);
            global.IntestinalParasites = ConvertBackIntestinalParasites(global.IntestinalParasites, afflictionDict);
            global.BrokenRibs = ConvertBackBrokenRib(global.BrokenRibs, afflictionDict);
            global.WellFed = ConvertBackWellFed(global.WellFed, afflictionDict);
        }

        private HypothermiaSaveDataProxy ConvertBackHypothermia(HypothermiaSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new HypothermiaSaveDataProxy();
            if (!afflictionDict.ContainsKey(AfflictionType.Hypothermia) && !afflictionDict.ContainsKey(AfflictionType.HypothermiaRisk))
            {
                return (proxy?.m_ElapsedHours > 0) ? new HypothermiaSaveDataProxy() : proxy;
            }
            proxy.m_Active = afflictionDict.ContainsKey(AfflictionType.Hypothermia);
            var hypothermia = (Hypothermia)(proxy.m_Active ? afflictionDict[AfflictionType.Hypothermia][0] : afflictionDict[AfflictionType.HypothermiaRisk][0]);
            proxy.m_ElapsedHours = hypothermia.ElapsedHours;
            proxy.m_ElapsedWarmTime = hypothermia.ElapsedWarmHours;
            proxy.m_CauseLocID = hypothermia.Cause;
            return proxy;
        }

        private FrostbiteSaveDataProxy ConvertBackFrostBite(FrostbiteSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new FrostbiteSaveDataProxy();
            var frostbites = afflictionDict.GetOrDefault(AfflictionType.Frostbite, new List<Affliction>()).Cast<Frostbite>().ToList();
            var frostbiteRisks = afflictionDict.GetOrDefault(AfflictionType.FrostbiteRisk, new List<Affliction>()).Cast<Frostbite>().ToList();
            var frostbiteDamage = afflictionDict.GetOrDefault(AfflictionType.FrostbiteDamage, new List<Affliction>()).Cast<Frostbite>().ToList();
            proxy.m_LocationsCurrentFrostbiteDamage = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
            foreach (var frostbite in frostbiteDamage)
            {
                proxy.m_LocationsCurrentFrostbiteDamage[frostbite.Location] = frostbite.Damage;
            }
            return proxy;
        }

        private FoodPoisoningSaveDataProxy ConvertBackFoodPoisoning(FoodPoisoningSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new FoodPoisoningSaveDataProxy();
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

        private DysenterySaveDataProxy ConvertBackDysentery(DysenterySaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new DysenterySaveDataProxy();
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

        private SprainedAnkleSaveDataProxy ConvertBackSprainedAnkle(SprainedAnkleSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new SprainedAnkleSaveDataProxy();
            var sprainedAnkles = afflictionDict.Get(AfflictionType.SprainedAnkle)?.Cast<SprainAffliction>().ToList();
            if (sprainedAnkles == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new SprainedAnkleSaveDataProxy() : proxy;
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

        private SprainedWristSaveDataProxy ConvertBackSprainedWrist(SprainedWristSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new SprainedWristSaveDataProxy();
            var sprainedWrists = afflictionDict.Get(AfflictionType.SprainedWrist)?.Cast<SprainAffliction>().ToList();
            if (sprainedWrists == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new SprainedWristSaveDataProxy() : proxy;
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

        private BurnsSaveDataProxy ConvertBackBurns(BurnsSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new BurnsSaveDataProxy();
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

        private BurnsElectricSaveDataProxy ConvertBackBurnsElectric(BurnsElectricSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new BurnsElectricSaveDataProxy();
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

        private BloodLossSaveDataProxy ConvertBackBloodLoss(BloodLossSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new BloodLossSaveDataProxy();
            var bloodLosses = afflictionDict.Get(AfflictionType.BloodLoss)?.Cast<BloodLoss>().ToList();
            if (bloodLosses == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new BloodLossSaveDataProxy() : proxy;
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

        private InfectionSaveDataProxy ConvertBackInfection(InfectionSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new InfectionSaveDataProxy();
            var infections = afflictionDict.Get(AfflictionType.Infection)?.Cast<Infection>().ToList();
            if (infections == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new InfectionSaveDataProxy() : proxy;
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

        private InfectionRiskSaveDataProxy ConvertBackInfectionRisk(InfectionRiskSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new InfectionRiskSaveDataProxy();
            var infectionRisks = afflictionDict.Get(AfflictionType.InfectionRisk)?.Cast<InfectionRisk>().ToList();
            if (infectionRisks == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new InfectionRiskSaveDataProxy() : proxy;
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

        private CabinFeverSaveDataProxy ConvertBackCabinFever(CabinFeverSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new CabinFeverSaveDataProxy();
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

        private IntestinalParasitesSaveDataProxy ConvertBackIntestinalParasites(IntestinalParasitesSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new IntestinalParasitesSaveDataProxy();
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

        private BrokenRibSaveDataProxy ConvertBackBrokenRib(BrokenRibSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new BrokenRibSaveDataProxy();
            var brokenRibs = afflictionDict.Get(AfflictionType.BrokenRib)?.Cast<BrokenRib>().ToList();
            if (brokenRibs == null)
            {
                return (proxy.m_CausesLocIDs?.Count > 0) ? new BrokenRibSaveDataProxy() : proxy;
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

        private WellFedSaveDataProxy ConvertBackWellFed(WellFedSaveDataProxy proxy, Dictionary<AfflictionType, List<Affliction>> afflictionDict)
        {
            proxy = proxy ?? new WellFedSaveDataProxy();
            var wellFed = (WellFed)afflictionDict.Get(AfflictionType.WellFed)?[0];
            if (wellFed == null)
            {
                return proxy.m_Active ? new WellFedSaveDataProxy() : proxy;
            }
            proxy.m_Active = true;
            proxy.m_ElapsedHoursNotStarving = wellFed.ElapsedHoursNotStarving;
            return proxy;
        }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
