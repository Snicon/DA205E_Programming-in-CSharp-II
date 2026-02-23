// Sixten Peterson (AQ9300) 2026-02-04

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
        /// Overriden ToString method. Adds the milk production to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string beakSizeString = $"{Environment.NewLine}{"Beak size",-18} {BeakSize,-10}{Environment.NewLine}";
            return base.ToString() + beakSizeString;
        }
        

        public override string ToStringSummary()
        {
            return $"{nameof(Raven),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        public override void SetSleepTime()
        {
            SleepTime = 10;
        }

        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "100g seeds");
            foodDictionary.Add("Lunch", "50g meat");
            foodDictionary.Add("Evening", "100g meat");
            
            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 09:30");
            eventQueue.Enqueue("Training session at 13:20");
            eventQueue.Enqueue("Enrichment session at 18:00");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
