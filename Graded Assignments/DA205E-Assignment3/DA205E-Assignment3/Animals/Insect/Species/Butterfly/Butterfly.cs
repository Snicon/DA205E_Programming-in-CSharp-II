// Sixten Peterson (AQ9300) 2026-03-23
namespace DA205E_Assignment3.Animals.Insect.Species.Butterfly
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
        /// <summary>
        /// Basic constructor
        /// </summary>
        public Butterfly() : base() { }

        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="hasWings">A boolean representing if the Butterfly have any wings, used in the base constructor</param>
        /// <param name="lifecycleStage">The lifecycle stage of the Butterfly, used in the base constructor</param>
        public Butterfly(bool hasWings, LifecycleStage lifecycleStage) : base(hasWings, lifecycleStage) { }
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

        /// <summary>
        /// Prefixes the base ToStringTxt() with the name of the species (Butterfly) and suffixes it with the wing pattern.
        /// </summary>
        /// <returns>A string representation of the animal used when storing it in a .txt-file.</returns>
        public override string ToStringTxt()
        {
            return $"{nameof(Butterfly)}{Environment.NewLine}" + base.ToStringTxt() + $"Wing Pattern: {WingPattern}";
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Butterfly).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Butterfly),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        /// <summary>
        /// Gets the average lifespan of the Butterfly in years. Which is overriden to 4.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 4;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Butterfly.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "1ml nectar");
            foodDictionary.Add("Lunch", "water");
            foodDictionary.Add("Evening", "2ml nectar");

            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Enclousure cleaning at 07:25");

            return eventQueue;
        }

        /// <summary>
        /// Gets the latin name of the animal, this string is stored as a constant in this class.
        /// </summary>
        /// <returns>The latin name as a string</returns>
        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
