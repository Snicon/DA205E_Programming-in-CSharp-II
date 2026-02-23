// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment2.Animals.Reptile.Species
{
    /// <summary>
    /// Sub class/derived class of the base/super class Reptile. It adds fields and properties for venomous along with an overriden ToString()-method.
    /// </summary>
    public class Snake : Reptile
    {
        #region Constants
        private const string LatinName = "Serpentes";
        #endregion

        #region Fields
        private bool venomous;
        #endregion

        #region Constructor(s)
        public Snake(bool livesInWater, bool canRegrowTail) : base(livesInWater, canRegrowTail)
        {
        }
        #endregion

        #region Properties
        public bool Venomous
        {
            get { return venomous; }
            set { venomous = value; }
        }
        #endregion

        #region ToString() and similar methods
        /// <summary>
        /// Overriden ToString method. Adds the venomous property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string venomousString = $"{Environment.NewLine}{"Venomous",-18} {Venomous,-10}{Environment.NewLine}";
            return base.ToString() + venomousString;
        }

        public override string ToStringSummary()
        {
            return $"{nameof(Snake),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        public override void SetSleepTime()
        {
            SleepTime = 16;
        }

        public override int GetAverageLifeSpan()
        {
            return 8;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "2 mice");
            foodDictionary.Add("Evening", "1 egg");

            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 16:20");
            eventQueue.Enqueue("Enrichment session at 14:00");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
