// Sixten Peterson (AQ9300) 2026-02-24
namespace DA205E_Assignment3.Animals.Reptile.Species
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
        public Snake() : base() { }

        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="livesInWater">A boolean representing if the snake lives in water, used in the base constructor</param>
        /// <param name="canRegrowTail">A boolean representing if the snake regrow its tail, used in the base constructor</param>
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

        public override string ToStringTxt()
        {
            return $"{nameof(Snake)}{Environment.NewLine}" + base.ToStringTxt() + $"Venomous: {venomous}";
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Snake).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Snake),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        /// <summary>
        /// Sets the sleep time field to 16.
        /// </summary>
        public override void SetSleepTime()
        {
            base.sleepTime = 16;
        }

        /// <summary>
        /// Gets the average lifespan of the Snake in years. Which is overriden to 8.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 8;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Snake.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "2 mice");
            foodDictionary.Add("Evening", "1 egg");

            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 16:20");
            eventQueue.Enqueue("Enrichment session at 14:00");

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
