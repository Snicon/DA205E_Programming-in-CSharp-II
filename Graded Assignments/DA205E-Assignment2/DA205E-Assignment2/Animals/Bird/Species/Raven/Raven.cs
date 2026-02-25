// Sixten Peterson (AQ9300) 2026-02-24

namespace DA205E_Assignment2.Animals.Bird.Species.Raven
{
    /// <summary>
    /// Sub class of the base/super class Bird. It adds the beakSize field along with a property along with an overriden ToString()-method.
    /// </summary>
    public class Raven : Bird
    {
        #region Constants
        private const string LatinName = "Corvas Corvax";
        #endregion

        #region Fields
        private double beakSize;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="wingspan">The wingspan of the Raven, used in the base constructor</param>
        /// <param name="beakType">The type of beak of the Raven, used in the base constructor</param>
        public Raven(double wingspan, BeakType beakType) : base(wingspan, beakType)
        {
        }
        #endregion

        #region Properties
        public double BeakSize
        {
            get { return beakSize; }
            set { 
                if (value > 0) // I would expect that a beak has to be bigger than zero (of whatever unit the uses wants to use).
                    beakSize = value;
            }
        }
        #endregion

        #region ToString() and simliar methods
        /// <summary>
        /// Overriden ToString method. Adds the beak size to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string beakSizeString = $"{Environment.NewLine}{"Beak size",-18} {BeakSize,-10}{Environment.NewLine}";
            return base.ToString() + beakSizeString;
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Raven).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Raven),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        /// <summary>
        /// Sets the sleep time field to 10.
        /// </summary>
        public override void SetSleepTime()
        {
            base.sleepTime = 10;
        }

        /// <summary>
        /// Gets the average lifespan of the Raven in years. Which is overriden to 15.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Raven.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "100g seeds");
            foodDictionary.Add("Lunch", "50g meat");
            foodDictionary.Add("Evening", "100g meat");
            
            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 09:30");
            eventQueue.Enqueue("Training session at 13:20");
            eventQueue.Enqueue("Enrichment session at 18:00");

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
