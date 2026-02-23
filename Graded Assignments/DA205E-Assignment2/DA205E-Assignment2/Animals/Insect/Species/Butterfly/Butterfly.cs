// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment2.Animals.Insect.Species.Butterfly
{
    /// <summary>
    /// Sub class/derived class of the base/super class Insect. It adds the wingPattern field and property along with an overriden ToString()-method.
    /// </summary>
    public class Butterfly : Insect
    {
        #region Constants
        private const string LatinName = "Papilionoidea";
        #endregion

        #region Fields
        private WingPattern wingPattern;
        #endregion

        #region Constructor(s)
        public Butterfly(bool hasWings, LifecycleStage lifecycleStage) : base(hasWings, lifecycleStage)
        {
        }
        #endregion

        #region Properties
        public WingPattern WingPattern
        {
            get { return wingPattern; } 
            set { wingPattern = value; }
        }
        #endregion

        #region ToString() and similar methods
        /// <summary>
        /// Overriden ToString method. Adds the wing pattern to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string wingpatternString = $"{Environment.NewLine}{"Wing pattern",-18} {WingPattern,-10}{Environment.NewLine}";
            return base.ToString() + wingpatternString;
        }

        public override string ToStringSummary()
        {
            return $"{nameof(Butterfly),-8} {base.ToStringSummary()}";
        }
        #endregion


        #region Other methods
        public override int GetAverageLifeSpan()
        {
            return 4;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "1ml nectar");
            foodDictionary.Add("Lunch", "water");
            foodDictionary.Add("Evening", "2ml nectar");

            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Enclousure cleaning at 07:25");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
