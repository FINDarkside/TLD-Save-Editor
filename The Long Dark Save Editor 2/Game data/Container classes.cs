using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers;
using The_Long_Dark_Save_Editor_2.Helpers.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{
    #region Injuries

    public class Afflictions : INotifyPropertyChanged
    {
        private ObservableCollection<Affliction> negative;
        public ObservableCollection<Affliction> Negative { get { return negative; } set { SetPropertyField(ref negative, value); } }
        private ObservableCollection<Affliction> positive;
        public ObservableCollection<Affliction> Positive { get { return positive; } set { SetPropertyField(ref positive, value); } }

        public Afflictions(GlobalSaveGameFormat global)
        {
            /*Negative = new ObservableCollection<Affliction>();
            negative.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Negative")); };
            Positive = new ObservableCollection<Affliction>();
            positive.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => { if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Positive")); };

            var hypothermia = Util.DeserializeObject<HypothermiaSaveDataProxy>(global.m_HypothermiaSerialized);
            if (hypothermia != null && hypothermia.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.Hypothermia,
                    proxy = global.m_HypothermiaSerialized,
                    Location = 6
                });
            }
            else if (hypothermia != null && hypothermia.m_ElapsedHours > 0)
            {
                Negative.Add(new HypothermiaRisk()
                {
                    AfflictionType = AfflictionType.HypothermiaRisk,
                    proxy = global.m_HypothermiaSerialized,
                    ElapsedHours = hypothermia.m_ElapsedHours,
                    Location = 6,
                });
            }


            var frostBite = Util.DeserializeObject<FrostBiteSaveDataProxy>(global.m_FrostbiteSerialized);
            if (frostBite != null)
            {
                foreach (int bodyArea in frostBite.m_LocationsWithActiveFrostbite)
                {
                    Negative.Add(new Affliction()
                    {
                        AfflictionType = AfflictionType.Frostbite,
                        Location = bodyArea
                    });
                }
                for (int i = 0; i < frostBite.m_LocationsWithFrostbiteRisk.Length; i++)
                {
                    Negative.Add(new FrostBiteRisk()
                    {
                        AfflictionType = AfflictionType.FrostbiteRisk,
                        Location = frostBite.m_LocationsWithFrostbiteRisk[i],
                        Damage = frostBite.m_LocationsCurrentFrostbiteDamage[i]
                    });
                }
            }

            // Duration > 0
            var foodPoisoning = Util.DeserializeObject<FoodPoisoningSaveDataProxy>(global.m_FoodPoisoningSerialized);
            if (foodPoisoning != null && foodPoisoning.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.FoodPoisioning,
                    proxy = global.m_FoodPoisoningSerialized,
                    Location = 6
                });
            }

            // Duration > 0
            var dysentery = Util.DeserializeObject<DysenterySaveDataProxy>(global.m_DysenterySerialized);
            if (foodPoisoning != null && foodPoisoning.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.Dysentery,
                    proxy = global.m_DysenterySerialized,
                    Location = 7
                });
            }

            var sprainedAnkle = Util.DeserializeObject<SprainedAnkleSaveDataProxy>(global.m_SprainedAnkleSerialized);
            if (sprainedAnkle != null)
            {
                for (int i = 0; i < sprainedAnkle.m_ElapsedHoursList.Length; i++)
                {
                    Negative.Add(new SprainAffliction()
                    {
                        AfflictionType = AfflictionType.SprainedAnkle,
                        Location = sprainedAnkle.m_Locations[i],
                        CauseLocID = sprainedAnkle.m_CausesLocIDs[i],
                        Duration = sprainedAnkle.m_DurationHoursList[i],
                        ElapsedHours = sprainedAnkle.m_ElapsedHoursList[i],
                        ElapsedRest = sprainedAnkle.m_ElapsedRestList[i]
                    });
                }
            }

            var sprainedWrist = Util.DeserializeObject<SprainedWristSaveDataProxy>(global.m_SprainedWristSerialized);
            if (sprainedWrist != null)
            {
                for (int i = 0; i < sprainedWrist.m_ElapsedHoursList.Length; i++)
                {
                    Negative.Add(new SprainAffliction()
                    {
                        AfflictionType = AfflictionType.SprainedWrist,
                        Location = sprainedWrist.m_Locations[i],
                        CauseLocID = sprainedWrist.m_CausesLocIDs[i],
                        Duration = sprainedWrist.m_DurationHoursList[i],
                        ElapsedHours = sprainedWrist.m_ElapsedHoursList[i],
                        ElapsedRest = sprainedWrist.m_ElapsedRestList[i]
                    });
                }
            }

            var sprainedWristMajor = Util.DeserializeObject<SprainedWristMajorSaveDataProxy>(global.m_SprainedWristMajorSerialized);
            if (sprainedWristMajor != null)
            {
                for (int i = 0; i < sprainedWristMajor.m_ElapsedRestList.Length; i++)
                {
                    Negative.Add(new SprainedWristMajor()
                    {
                        AfflictionType = AfflictionType.SprainedWristMajor,
                        Location = sprainedWristMajor.m_Locations[i],
                        CauseLocID = sprainedWristMajor.m_CausesLocIDs[i],
                        ElapsedRest = sprainedWristMajor.m_ElapsedRestList[i]
                    });
                }
            }

            var burns = Util.DeserializeObject<BurnsSaveDataProxy>(global.m_BurnsSerialized);
            if (burns != null && burns.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.Burns,
                    Location = 5,
                    proxy = global.m_BurnsSerialized
                });
            }

            var burnsElectric = Util.DeserializeObject<BurnsElectricSaveDataProxy>(global.m_BurnsElectricSerialized);
            if (burnsElectric != null && burnsElectric.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.BurnsElectric,
                    Location = 5,
                    proxy = global.m_BurnsElectricSerialized
                });
            }

            var bloodLoss = Util.DeserializeObject<BloodLossSaveDataProxy>(global.m_BloodLossSerialized);
            if (bloodLoss != null)
            {
                for (int i = 0; i < bloodLoss.m_DurationHoursList.Length; i++)
                {
                    Negative.Add(new BloodLoss()
                    {
                        AfflictionType = AfflictionType.BloodLoss,
                        Location = bloodLoss.m_Locations[i],
                        CauseLocID = bloodLoss.m_CausesLocIDs[i],
                        DurationHours = bloodLoss.m_DurationHoursList[i],
                        ElapsedHours = bloodLoss.m_ElapsedHoursList[i]
                    });
                }
            }

            var infection = Util.DeserializeObject<InfectionSaveDataProxy>(global.m_InfectionSerialized);
            if (infection != null)
            {
                for (int i = 0; i < infection.m_DurationHoursList.Length; i++)
                {
                    Negative.Add(new Infection()
                    {
                        AfflictionType = AfflictionType.Infection,
                        Location = infection.m_Locations[i],
                        AntibioticsTaken = infection.m_AntibioticsTakenList[i],
                        CauseLocID = infection.m_CausesLocIDs[i],
                        DurationHours = infection.m_DurationHoursList[i],
                        ElapsedHours = infection.m_ElapsedHoursList[i],
                        ElapsedRest = infection.m_ElapsedRestList[i]
                    });
                }
            }

            var infectionRisk = Util.DeserializeObject<InfectionRiskSaveDataProxy>(global.m_InfectionRiskSerialized);
            if (infectionRisk != null)
            {
                for (int i = 0; i < infectionRisk.m_DurationHoursList.Length; i++)
                {
                    Negative.Add(new InfectionRisk()
                    {
                        AfflictionType = AfflictionType.InfectionRisk,
                        Location = infectionRisk.m_Locations[i],
                        AntisepticTaken = infectionRisk.m_AntisepticTakenList[i],
                        CauseLocID = infectionRisk.m_CausesLocIDs[i],
                        CurrentInfectionChance = infectionRisk.m_CurrentInfectionChanceList[i],
                        DurationHours = infectionRisk.m_DurationHoursList[i],
                        ElapsedHours = infectionRisk.m_ElapsedHoursList[i]
                    });
                }
            }

            var cabinFever = Util.DeserializeObject<CabinFeverSaveDataProxy>(global.m_CabinFeverSerialized);
            if (cabinFever != null && cabinFever.m_Active)
            {
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.CabinFever,
                    Location = 0,
                    proxy = global.m_CabinFeverSerialized
                });
            }

            var parasites = Util.DeserializeObject<IntestinalParasitesSaveDataProxy>(global.m_IntestinalParasitesSerialized);
            if (parasites != null && (parasites.m_HasParasites || parasites.m_HasParasiteRisk))
            {
                var affliction = parasites.m_HasParasites ? AfflictionType.IntestinalParasites : AfflictionType.IntestinalParasitesRisk;
                Negative.Add(new AfflictionWithProxy()
                {
                    AfflictionType = affliction,
                    Location = 7,
                    proxy = global.m_IntestinalParasitesSerialized
                });
            }

            var brokenRibs = Util.DeserializeObject<BrokenRibSaveDataProxy>(global.m_BrokenRibSerialized);
            if (brokenRibs != null)
            {
                for (int i = 0; i < brokenRibs.m_Locations.Length; i++)
                {
                    Negative.Add(new BrokenRib()
                    {
                        AfflictionType = AfflictionType.BrokenRib,
                        Location = brokenRibs.m_Locations[i],
                        BandagesApplied = brokenRibs.m_BandagesApplied[i],
                        ElapsedRest = brokenRibs.m_ElapsedRestList[i],
                        NumHoursRestForCure = brokenRibs.m_NumHoursRestForCureList[i],
                        PainKillersTaken = brokenRibs.m_PainKillersTaken[i],
                    });
                }
            }

            var wellFed = Util.DeserializeObject<WellFedSaveDataProxy>(global.m_WellFedSerialized);
            if (wellFed != null && wellFed.m_Active)
            {
                Positive.Add(new AfflictionWithProxy()
                {
                    AfflictionType = AfflictionType.WellFed,
                    Location = 6,
                    proxy = global.m_WellFedSerialized,
                });
            }*/
        }

        public GlobalSaveGameFormat SerializeTo(GlobalSaveGameFormat proxy)
        {
            /*var afflictions = new Dictionary<AfflictionType, List<Affliction>>();
            foreach (var affliction in Negative.Concat(Positive))
            {
                if (!afflictions.ContainsKey(affliction.AfflictionType))
                    afflictions.Add(affliction.AfflictionType, new List<Affliction>());
                afflictions[affliction.AfflictionType].Add(affliction);
            }

            if (afflictions.ContainsKey(AfflictionType.Hypothermia))
            {
                proxy.m_HypothermiaSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.Hypothermia][0]).proxy;
            }

            var frostBiteProxy = new FrostBiteSaveDataProxy();
            frostBiteProxy.m_LocationsCurrentFrostbiteDamage = new float[11];
            frostBiteProxy.m_LocationsWithActiveFrostbite = new int[0];
            frostBiteProxy.m_LocationsWithFrostbiteRisk = new int[0];
            if (afflictions.ContainsKey(AfflictionType.Frostbite))
            {
                frostBiteProxy.m_LocationsWithActiveFrostbite = afflictions[AfflictionType.Frostbite].Select(f => f.Location).ToArray();
            }
            if (afflictions.ContainsKey(AfflictionType.FrostbiteRisk))
            {
                var locations = new List<int>();
                foreach (var frostBiteRisk in afflictions[AfflictionType.FrostbiteRisk])
                {
                    locations.Add(frostBiteRisk.Location);
                    frostBiteProxy.m_LocationsCurrentFrostbiteDamage[frostBiteRisk.Location] = ((FrostBiteRisk)frostBiteRisk).Damage;
                }
            }
            proxy.m_FrostbiteSerialized = Util.SerializeObject(frostBiteProxy);

            if (afflictions.ContainsKey(AfflictionType.FoodPoisioning))
            {
                proxy.m_FoodPoisoningSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.FoodPoisioning][0]).proxy;
            }

            if (afflictions.ContainsKey(AfflictionType.Dysentery))
            {
                proxy.m_DysenterySerialized = ((AfflictionWithProxy)afflictions[AfflictionType.Dysentery][0]).proxy;
            }

            if (afflictions.ContainsKey(AfflictionType.SprainedAnkle))
            {
                var sprainedAnkleProxy = new SprainedAnkleSaveDataProxy();
                var sprains = afflictions[AfflictionType.SprainedAnkle];
                sprainedAnkleProxy.m_CausesLocIDs = new string[sprains.Count];
                sprainedAnkleProxy.m_DurationHoursList = new float[sprains.Count];
                sprainedAnkleProxy.m_ElapsedHoursList = new float[sprains.Count];
                sprainedAnkleProxy.m_ElapsedRestList = new float[sprains.Count];
                sprainedAnkleProxy.m_Locations = new int[sprains.Count];

                for (int i = 0; i < sprains.Count; i++)
                {
                    var sprain = (SprainAffliction)sprains[i];
                    sprainedAnkleProxy.m_CausesLocIDs[i] = sprain.CauseLocID;
                    sprainedAnkleProxy.m_DurationHoursList[i] = sprain.Duration;
                    sprainedAnkleProxy.m_ElapsedHoursList[i] = sprain.ElapsedHours;
                    sprainedAnkleProxy.m_ElapsedRestList[i] = sprain.ElapsedHours;
                    sprainedAnkleProxy.m_Locations[i] = sprain.Location;
                }
                proxy.m_SprainedAnkleSerialized = Util.SerializeObject(sprainedAnkleProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.SprainedWrist))
            {
                var sprainedWristProxy = new SprainedWristSaveDataProxy();
                var sprains = afflictions[AfflictionType.SprainedWrist];
                sprainedWristProxy.m_CausesLocIDs = new string[sprains.Count];
                sprainedWristProxy.m_DurationHoursList = new float[sprains.Count];
                sprainedWristProxy.m_ElapsedHoursList = new float[sprains.Count];
                sprainedWristProxy.m_ElapsedRestList = new float[sprains.Count];
                sprainedWristProxy.m_Locations = new int[sprains.Count];

                for (int i = 0; i < sprains.Count; i++)
                {
                    var sprain = (SprainAffliction)sprains[i];
                    sprainedWristProxy.m_CausesLocIDs[i] = sprain.CauseLocID;
                    sprainedWristProxy.m_DurationHoursList[i] = sprain.Duration;
                    sprainedWristProxy.m_ElapsedHoursList[i] = sprain.ElapsedHours;
                    sprainedWristProxy.m_ElapsedRestList[i] = sprain.ElapsedHours;
                    sprainedWristProxy.m_Locations[i] = sprain.Location;
                }
                proxy.m_SprainedWristSerialized = Util.SerializeObject(sprainedWristProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.SprainedWristMajor))
            {
                var sprainedWristMajorProxy = new SprainedWristMajorSaveDataProxy();
                var sprains = afflictions[AfflictionType.SprainedWristMajor];
                sprainedWristMajorProxy.m_CausesLocIDs = new string[sprains.Count];
                sprainedWristMajorProxy.m_ElapsedRestList = new float[sprains.Count];
                sprainedWristMajorProxy.m_Locations = new int[sprains.Count];

                for (int i = 0; i < sprains.Count; i++)
                {
                    var sprain = (SprainedWristMajor)sprains[i];
                    sprainedWristMajorProxy.m_Locations[i] = sprain.Location;
                    sprainedWristMajorProxy.m_ElapsedRestList[i] = sprain.ElapsedRest;
                    sprainedWristMajorProxy.m_CausesLocIDs[i] = sprain.CauseLocID;
                }
                proxy.m_SprainedWristMajorSerialized = Util.SerializeObject(sprainedWristMajorProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.Burns))
            {
                proxy.m_BurnsSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.Burns][0]).proxy;
            }

            if (afflictions.ContainsKey(AfflictionType.BurnsElectric))
            {
                proxy.m_BurnsSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.BurnsElectric][0]).proxy;
            }

            if (afflictions.ContainsKey(AfflictionType.BloodLoss))
            {
                var bloodLossProxy = new BloodLossSaveDataProxy();
                var bloodLosses = afflictions[AfflictionType.BloodLoss];
                bloodLossProxy.m_CausesLocIDs = new string[bloodLosses.Count];
                bloodLossProxy.m_DurationHoursList = new float[bloodLosses.Count];
                bloodLossProxy.m_ElapsedHoursList = new float[bloodLosses.Count];
                bloodLossProxy.m_Locations = new int[bloodLosses.Count];

                for (int i = 0; i < bloodLosses.Count; i++)
                {
                    var bloodLoss = (BloodLoss)bloodLosses[i];
                    bloodLossProxy.m_CausesLocIDs[i] = bloodLoss.CauseLocID;
                    bloodLossProxy.m_DurationHoursList[i] = bloodLoss.DurationHours;
                    bloodLossProxy.m_ElapsedHoursList[i] = bloodLoss.ElapsedHours;
                    bloodLossProxy.m_Locations[i] = bloodLoss.Location;
                }
                proxy.m_BloodLossSerialized = Util.SerializeObject(bloodLossProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.Infection))
            {
                var infectionProxy = new InfectionSaveDataProxy();
                var infections = afflictions[AfflictionType.Infection];
                infectionProxy.m_AntibioticsTakenList = new bool[infections.Count];
                infectionProxy.m_CausesLocIDs = new string[infections.Count];
                infectionProxy.m_DurationHoursList = new float[infections.Count];
                infectionProxy.m_ElapsedHoursList = new float[infections.Count];
                infectionProxy.m_ElapsedRestList = new float[infections.Count];
                infectionProxy.m_Locations = new int[infections.Count];

                for (int i = 0; i < infections.Count; i++)
                {
                    var infection = (Infection)infections[i];
                    infectionProxy.m_AntibioticsTakenList[i] = infection.AntibioticsTaken;
                    infectionProxy.m_CausesLocIDs[i] = infection.CauseLocID;
                    infectionProxy.m_DurationHoursList[i] = infection.DurationHours;
                    infectionProxy.m_ElapsedHoursList[i] = infection.ElapsedHours;
                    infectionProxy.m_ElapsedRestList[i] = infection.ElapsedRest;
                    infectionProxy.m_Locations[i] = infection.Location;
                }
                proxy.m_InfectionSerialized = Util.SerializeObject(infectionProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.InfectionRisk))
            {
                var infectionRisk = new InfectionRiskSaveDataProxy();
                var infectionRisks = afflictions[AfflictionType.InfectionRisk];
                infectionRisk.m_CausesLocIDs = new string[infectionRisks.Count];
                infectionRisk.m_DurationHoursList = new float[infectionRisks.Count];
                infectionRisk.m_ElapsedHoursList = new float[infectionRisks.Count];
                infectionRisk.m_Locations = new int[infectionRisks.Count];
                infectionRisk.m_AntisepticTakenList = new bool[infectionRisks.Count];
                infectionRisk.m_CurrentInfectionChanceList = new float[infectionRisks.Count];

                for (int i = 0; i < infectionRisks.Count; i++)
                {
                    var infection = (InfectionRisk)infectionRisks[i];
                    infectionRisk.m_CausesLocIDs[i] = infection.CauseLocID;
                    infectionRisk.m_DurationHoursList[i] = infection.DurationHours;
                    infectionRisk.m_ElapsedHoursList[i] = infection.ElapsedHours;
                    infectionRisk.m_Locations[i] = infection.Location;
                    infectionRisk.m_AntisepticTakenList[i] = infection.AntisepticTaken;
                    infectionRisk.m_CurrentInfectionChanceList[i] = infection.CurrentInfectionChance;
                }
                proxy.m_InfectionRiskSerialized = Util.SerializeObject(infectionRisk);
            }

            if (afflictions.ContainsKey(AfflictionType.BrokenRib))
            {
                var brokenRibProxy = new BrokenRibSaveDataProxy();
                var brokenRibs = afflictions[AfflictionType.BrokenRib];
                brokenRibProxy.m_BandagesApplied = new int[brokenRibs.Count];
                brokenRibProxy.m_CausesLocIDs = new string[brokenRibs.Count];
                brokenRibProxy.m_ElapsedRestList = new float[brokenRibs.Count];
                brokenRibProxy.m_Locations = new int[brokenRibs.Count];
                brokenRibProxy.m_NumHoursRestForCureList = new float[brokenRibs.Count];
                brokenRibProxy.m_PainKillersTaken = new int[brokenRibs.Count];

                for (int i = 0; i < brokenRibs.Count; i++)
                {
                    var brokenRib = (BrokenRib)brokenRibs[i];
                    brokenRibProxy.m_BandagesApplied[i] = brokenRib.BandagesApplied;
                    brokenRibProxy.m_CausesLocIDs[i] = brokenRib.CauseLocID;
                    brokenRibProxy.m_ElapsedRestList[i] = brokenRib.ElapsedRest;
                    brokenRibProxy.m_Locations[i] = brokenRib.Location;
                    brokenRibProxy.m_NumHoursRestForCureList[i] = brokenRib.NumHoursRestForCure;
                    brokenRibProxy.m_PainKillersTaken[i] = brokenRib.PainKillersTaken;
                }
                proxy.m_BrokenRibSerialized = Util.SerializeObject(brokenRibProxy);
            }

            if (afflictions.ContainsKey(AfflictionType.CabinFever))
            {
                proxy.m_CabinFeverSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.CabinFever][0]).proxy;
            }

            if (afflictions.ContainsKey(AfflictionType.IntestinalParasites))
            {
                proxy.m_IntestinalParasitesSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.IntestinalParasites][0]).proxy;
            }
            else if (afflictions.ContainsKey(AfflictionType.IntestinalParasitesRisk))
            {
                proxy.m_IntestinalParasitesSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.IntestinalParasitesRisk][0]).proxy;
            }
            else if (afflictions.ContainsKey(AfflictionType.WellFed))
            {
                proxy.m_WellFedSerialized = ((AfflictionWithProxy)afflictions[AfflictionType.WellFed][0]).proxy;
            }

            return proxy;*/
            return null;
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

    public class Affliction
    {

        public AfflictionType AfflictionType { get; set; }
        public int Location { get; set; }
        public ICommand RemoveCommand { get; set; }

        public Affliction()
        {
            RemoveCommand = new CommandHandler(() =>
            {
                //MainWindow.Instance.CurrentSave.Global.Afflictions.Negative.Remove(this);
            });
        }
    }

    public class AfflictionWithProxy : Affliction
    {
        public string proxy { get; set; }
    }

    public class HypothermiaRisk : AfflictionWithProxy
    {
        private static int hoursSpentFreezingRequired = 10;
        public float ElapsedHours { get; set; }
        public float RiskChance
        {
            get { return ElapsedHours / hoursSpentFreezingRequired; }
        }
    }

    public class FrostBiteRisk : Affliction
    {
        private static int[] bodyAreaHP = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

        public float DamagePercentage
        {
            get
            {
                return Damage / bodyAreaHP[Location];
            }
            set
            {
                Damage = bodyAreaHP[Location] * value;
            }
        }
        public float Damage { get; set; }
    }

    public class SprainAffliction : Affliction
    {
        public string CauseLocID { get; set; }
        public float Duration { get; set; }
        public float ElapsedHours { get; set; }
        public float ElapsedRest { get; set; }
    }

    public class SprainedWristMajor : Affliction
    {
        public string CauseLocID { get; set; }
        public float ElapsedRest { get; set; }
    }

    public class BloodLoss : Affliction
    {
        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
    }

    public class Infection : Affliction
    {
        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntibioticsTaken { get; set; }
        public float ElapsedRest { get; set; }
    }

    public class InfectionRisk : Affliction
    {
        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntisepticTaken { get; set; }
        public float CurrentInfectionChance { get; set; }
    }

    public class BrokenRib : Affliction
    {
        public string CauseLocID { get; set; }
        public int PainKillersTaken { get; set; }
        public int BandagesApplied { get; set; }
        public float ElapsedRest { get; set; }
        public float NumHoursRestForCure { get; set; }
    }
    #endregion
}
