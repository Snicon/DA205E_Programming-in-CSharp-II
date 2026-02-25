// Sixten Peterson (AQ9300) 2026-02-24
namespace DA205E_Assignment2.Animals.Insect.Species.Beetle
{
    /// <summary>
    /// Sub class/derived class of the base/super class Insect. It adds the bodyType field and property along with an overriden ToString()-method.
    /// </summary>
    public class Beetle : Insect
    {
        #region Constants
        private const string LatinName = "Coleoptera";
        #endregion

        #region Fields
        private BodyType bodyType;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="hasWings">A boolean representing if the beetle has wings, used in the base constructor</param>
        /// <param name="lifecycleStage">The lifecycle stage of the Beetle, used in the base constructor</param>
        public Beetle(bool hasWings, LifecycleStage lifecycleStage) : base(hasWings, lifecycleStage) 
        { 
        }
        #endregion

        #region Properties
        public BodyType BodyType
        {
            get { return bodyType; }
            set { bodyType = value; }
        }
        #endregion

        #region ToString() and similar methods
        /// <summary>
        /// Overriden ToString method. Adds the body type to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string bodyTypeString = $"{Environment.NewLine}{"Body type",-18} {BodyType.ToString(),-10}{Environment.NewLine}";
            return base.ToString() + bodyTypeString;
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Beetle).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Beetle),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        /// <summary>
        /// Gets the average lifespan of the Beetle in years. Which is overriden to 1.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 1;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Beetle.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "1/4 of banana");

            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Enclosure cleaning at 07:00");

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
