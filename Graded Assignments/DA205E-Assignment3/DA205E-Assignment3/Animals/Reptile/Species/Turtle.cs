// Sixten Peterson (AQ9300) 2026-02-24

namespace DA205E_Assignment3.Animals.Reptile.Species
{
    /// <summary>
    /// Sub class/derived class of the base/super class Reptile. It adds fields and properties for shell width along with an overriden ToString()-method.
    /// </summary>
    public class Turtle : Reptile
    {
        #region Constants
        private const string LatinName = "Testudines";
        #endregion

        #region Field(s)
        private double shellWidth;
        #endregion

        #region Constructor(s)
        public Turtle() : base() { }

        /// <summary>
        /// Simple constructor, just calls the base constructor.
        /// </summary>
        /// <param name="livesInWater">A boolean representing if the turtle lives in water, used in the base constructor</param>
        /// <param name="canRegrowTail">A boolean representing if the turtle regrow its tail, used in the base constructor</param>
        public Turtle(bool livesInWater, bool canRegrowTail) : base(livesInWater, canRegrowTail)
        {
        }
        #endregion

        #region Properties
        public double ShellWidth
        {
            get { return shellWidth; }
            set
            {
                if (value > 0) // I'm no expert in turtle shells but I would imagine their shells are at least bigger than 0 of whichever unit you may want to use. Probably this limit could be set bigger but I'm not researching hte minimum shell width of a turtle shell for this assignment...
                {
                    shellWidth = value;
                }
            }
        }
        #endregion

        #region ToString() and similar methods
        /// <summary>
        /// Overriden ToString method. Adds the shell width property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string shellWidthString = $"{Environment.NewLine}{"Shell width",-18} {ShellWidth,-10}{Environment.NewLine}";
            return base.ToString() + shellWidthString;
        }

        public override string ToStringTxt()
        {
            return $"{nameof(Turtle)}{Environment.NewLine}" + base.ToStringTxt() + $"Shell Width: {shellWidth}";
        }

        /// <summary>
        /// Prefixes the base ToStringSummary() with the name of the species (Turtle).
        /// </summary>
        /// <returns>The summary representation as a string</returns>
        public override string ToStringSummary()
        {
            return $"{nameof(Turtle),-8} {base.ToStringSummary()}";
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
        /// Gets the average lifespan of the Turtle in years. Which is overriden to 100.
        /// </summary>
        /// <returns>The average life span in years</returns>
        public override int GetAverageLifeSpan()
        {
            return 100;
        }

        /// <summary>
        /// Creates a dictionary and fills it with the food requirements of the Turtle.
        /// </summary>
        /// <returns>Returns the created dictionary.</returns>
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "A couple of frutis");
            foodDictionary.Add("Lunch", "50g seaweed");
            foodDictionary.Add("Evening", "Leafy greens");

            return foodDictionary;
        }

        /// <summary>
        /// Creates a queue collection and fills it with the upcoming events for the animal
        /// </summary>
        /// <returns>The newly created queue collection.</returns>
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 10:50");
            eventQueue.Enqueue("Enrichment session at 16:00");

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
