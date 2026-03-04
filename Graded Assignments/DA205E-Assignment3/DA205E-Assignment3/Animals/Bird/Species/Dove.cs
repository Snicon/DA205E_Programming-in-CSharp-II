// Sixten Peterson (AQ9300) 2026-02-24
namespace DA205E_Assignment3.Animals.Bird.Species
{
    /// <summary>
    /// Sub class of the base/super class Bird. It adds the mildProduction field along with a property along with overriden ToString() and ToStringSummary() methods. Additionally any abstract methods are implemented here as this class is not abstract.
    /// </summary>
    public class Dove : Bird
    {
        #region Constants
        private const string LatinName = "Zenaida";
        #endregion

        #region Fields
        private double milkProduction; // I was very suprised to hear that pigeons sweat milk for their babies, but hey, apparently thats a thing so here we are
        #endregion

        #region Constructor
        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="wingspan">The wingspan of the Dove, used in the base constructor</param>
        /// <param name="beakType">The type of beak of the Dove, used in the base constructor</param>
        public Dove(double wingspan, BeakType beakType) : base(wingspan, beakType)
        {
        }
        #endregion

        #region Properties
        public double MilkProduction
        {
            get 
            { 
                return milkProduction;
            } 
            set 
            {
                if (milkProduction >= 0) // Milk production can't be negative.
                {
                    milkProduction = value;
                }
            }
        }
        #endregion
        
        #region ToString() and similar methods
        /// <summary>
        /// Overriden ToString method. Adds the milk production property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string milkProductionString = $"{Environment.NewLine}{"Milk production",-18} {MilkProduction,-10}{Environment.NewLine}";
            return base.ToString() + milkProductionString;
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Dove).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Dove),-8} {base.ToStringSummary()}"; // Prefixes the base ToStringSummary()-method with the name of the class (the name of the animal species)
        }

        #endregion

        #region Other methods
        /// <summary>
        /// Sets the sleep time field to 12.
        /// </summary>
        public override void SetSleepTime()
        {
            base.sleepTime = 12;
        }

        /// <summary>
        /// Gets the average lifespan of the Dove in years. Which is overriden to 5.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 5;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Dove.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "100g seeds");
            foodDictionary.Add("Lunch", "A pack of McDonalds French Fries");
            foodDictionary.Add("Evening", "50g mixed seeds");

            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Foraging session 12:05");
            eventQueue.Enqueue("Training session 12:00");

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
