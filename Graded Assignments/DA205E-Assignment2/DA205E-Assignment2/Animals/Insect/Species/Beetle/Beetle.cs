// Sixten Peterson (AQ9300) 2026-02-04
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

        public override string ToStringSummary()
        {
            return $"{nameof(Beetle),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        public override int GetAverageLifeSpan()
        {
            return 1;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Weekly", "1/4 of banana");

            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Enclosure cleaning at 07:00");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
