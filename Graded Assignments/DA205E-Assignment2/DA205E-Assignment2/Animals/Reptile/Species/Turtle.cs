// Sixten Peterson (AQ9300) 2026-02-04
using System.Runtime.CompilerServices;

namespace DA205E_Assignment2.Animals.Reptile.Species
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

        public override string ToStringSummary()
        {
            return $"{nameof(Turtle),-8} {base.ToStringSummary()}";
        }
        #endregion

        #region Other methods
        public override void SetSleepTime()
        {
            SleepTime = 10;
        }

        public override int GetAverageLifeSpan()
        {
            return 100;
        }

        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> foodDictionary = new Dictionary<string, string>();

            foodDictionary.Add("Morning", "A couple of frutis");
            foodDictionary.Add("Lunch", "50g seaweed");
            foodDictionary.Add("Evening", "Leafy greens");

            return foodDictionary;
        }

        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> eventQueue = new Queue<string>();

            eventQueue.Enqueue("Vet. appointment at 10:50");
            eventQueue.Enqueue("Enrichment session at 16:00");

            return eventQueue;
        }

        public override string GetLatinName()
        {
            return LatinName;
        }
        #endregion
    }
}
