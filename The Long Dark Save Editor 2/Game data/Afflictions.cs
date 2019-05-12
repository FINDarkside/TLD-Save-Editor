using System.Collections.ObjectModel;
using System.Windows.Input;
using The_Long_Dark_Save_Editor_2.Helpers.Helpers;

namespace The_Long_Dark_Save_Editor_2.Game_data
{

    public class Affliction
    {

        public AfflictionType AfflictionType { get; set; }
        public int Location { get; set; }
        public ICommand RemoveCommand { get; set; }

        public Affliction(ObservableCollection<Affliction> collection)
        {
            RemoveCommand = new CommandHandler(() =>
            {
                collection.Remove(this);
            });
        }
    }

    public class Hypothermia : Affliction
    {
        public Hypothermia(ObservableCollection<Affliction> collection) : base(collection) { }

        private static int hoursSpentFreezingRequired = 10;
        public float ElapsedHours { get; set; }
        public float ElapsedWarmHours { get; set; }
        public float RiskChance
        {
            get { return ElapsedHours / hoursSpentFreezingRequired; }
        }
        public string Cause { get; set; }
    }

    public class Frostbite : Affliction
    {
        public Frostbite(ObservableCollection<Affliction> collection) : base(collection) { }

        private static int[] bodyAreaHP = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

        public float DamagePercentage
        {
            get { return Damage / bodyAreaHP[Location]; }
            set { Damage = bodyAreaHP[Location] * value; }
        }
        public float Damage { get; set; }
    }

    public class FoodPoisoning : Affliction
    {
        public FoodPoisoning(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntibioticsTaken { get; set; }
        public float ElapsedRest { get; set; }
        public string Cause { get; set; }
    }

    public class Dysentery : Affliction
    {
        public Dysentery(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntibioticsTaken { get; set; }
        public float ElapsedRest { get; set; }
        public float CleanWaterConsumed { get; set; }
    }

    public class SprainAffliction : Affliction
    {
        public SprainAffliction(ObservableCollection<Affliction> collection) : base(collection) { }

        public string CauseLocID { get; set; }
        public float Duration { get; set; }
        public float ElapsedHours { get; set; }
        public float ElapsedRest { get; set; }
    }

    public class Burns : Affliction
    {
        public Burns(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool PainKillersTaken { get; set; }
        public bool BandageApplied { get; set; }
        public string CauseLocID { get; set; }
    }

    public class BurnsElectric : Affliction
    {
        public BurnsElectric(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool PainKillersTaken { get; set; }
        public bool BandageApplied { get; set; }
    }

    public class BloodLoss : Affliction
    {
        public BloodLoss(ObservableCollection<Affliction> collection) : base(collection) { }

        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
    }

    public class Infection : Affliction
    {
        public Infection(ObservableCollection<Affliction> collection) : base(collection) { }

        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntibioticsTaken { get; set; }
        public float ElapsedRest { get; set; }
    }

    public class InfectionRisk : Affliction
    {
        public InfectionRisk(ObservableCollection<Affliction> collection) : base(collection) { }

        public string CauseLocID { get; set; }
        public float ElapsedHours { get; set; }
        public float DurationHours { get; set; }
        public bool AntisepticTaken { get; set; }
        public float CurrentInfectionChance { get; set; }
        public bool Constant { get; set; }
    }

    public class CabinFever : Affliction
    {
        public CabinFever(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHours { get; set; }
    }

    public class IntestinalParasites : Affliction
    {
        public IntestinalParasites(ObservableCollection<Affliction> collection) : base(collection) { }

        public float CurrentInfectionChance { get; set; }
        public float ParasitesElapsedHours { get; set; }
        public float RiskElapsedHours { get; set; }
        public float RiskDurationHours { get; set; }
        public int DosesTaken { get; set; }
        public bool HasTakenDoseToday { get; set; }
        public int DayToAllowNextDose { get; set; }
        public int PiecesEatenThisRiskCycle { get; set; }

    }

    public class BrokenRib : Affliction
    {
        public BrokenRib(ObservableCollection<Affliction> collection) : base(collection) { }

        public string CauseLocID { get; set; }
        public int PainKillersTaken { get; set; }
        public int BandagesApplied { get; set; }
        public float ElapsedRest { get; set; }
        public float NumHoursRestForCure { get; set; }
    }

    public class WellFed : Affliction
    {
        public WellFed(ObservableCollection<Affliction> collection) : base(collection) { }

        public float ElapsedHoursNotStarving { get; set; }
    }
}
