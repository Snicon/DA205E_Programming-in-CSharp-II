// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment2.Animals.Bird.Species
{
    /// <summary>
    /// Sub class of the base/super class Bird. It adds the mildProduction field along with a property along with an overriden ToString()-method.
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
        
        #region ToString() and similar method
        /// <summary>
        /// Overriden ToString method. Adds the milk production property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string milkProductionString = $"{Environment.NewLine}{"Milk production",-18} {MilkProduction,-10}{Environment.NewLine}";
            return base.ToString() + milkProductionString;
        }

        public override string ToStringSummary()
        {
            return $"{nameof(Dove),-8} {base.ToStringSummary()}";
        }

        #endregion

        #region Other methods
        public override void SetSleepTime()
        {
            SleepTime = 12;
        }

        public override int GetAverageLifeSpan()
        {
            return 5;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "100g seeds");
            foodDictionary.Add("Lunch", "A pack of McDonalds French Fries");
            foodDictionary.Add("Evening", "50g mixed seeds");

            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Foraging session 12:05");
            eventQueue.Enqueue("Training session 12:00");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
