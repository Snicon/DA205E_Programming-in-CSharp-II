// Sixten Peterson (AQ9300) 2026-03-23
using DA205E_Assignment3.Animals.Reptile.Species;
using System.Xml.Serialization;

namespace DA205E_Assignment3.Animals.Reptile
{
    /// <summary>
    /// An abstract sub class/derived class of the base/super class Animal. It adds fields and properties for lives in water and can regrow tail along with an overriden ToString()-method.
    /// </summary>
    [XmlInclude(typeof(Snake))]
    [XmlInclude(typeof(Turtle))]
    public abstract class Reptile : Animal
    {
        #region Fields
        private bool livesInWater;
        private bool canRegrowTail;
        #endregion

        #region Constructor
        /// <summary>
        /// Basic constructor
        /// </summary>
        public Reptile() : base() { }

        /// <summary>
        /// Basic constructor that sets the canRegrowTail and livesInWater fields.
        /// </summary>
        /// <param name="livesInWater"></param>
        /// <param name="canRegrowTail"></param>
        public Reptile(bool livesInWater, bool canRegrowTail) : base()
        {
            CanRegrowTail = canRegrowTail;
            LivesInWater = livesInWater;
        }
        #endregion

        #region Properties
        public bool LivesInWater
        {
            get { return livesInWater; } 
            set { livesInWater = value; }
        }

        public bool CanRegrowTail
        {
            get { return canRegrowTail; }
            set { canRegrowTail = value; }
        }

        public override Category Category
        {
            get
            {
                return Category.Reptile;
            }
        }
        #endregion

        #region ToString() method
        /// <summary>
        /// Overriden ToString method. Adds the LivesInWater and CanRegrowTail property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string livesInWaterString = $"{"Lives in water",-18} {LivesInWater,-10}{Environment.NewLine}";
            string canRegrowTailString = $"{"Can regrow tail",-18} {CanRegrowTail,-10}{Environment.NewLine}";
            return base.ToString() + livesInWaterString + canRegrowTailString;
        }

        /// <summary>
        /// Overriden ToStringTxtMethod(). It adds the lives in water and can regrow tail properties to the string.
        /// </summary>
        /// <returns>A nicley fromatted string used for storing an animal in a .txt-file.</returns>
        public override string ToStringTxt()
        {
            return base.ToStringTxt() + $"Lives in water: {LivesInWater}{Environment.NewLine}" +
                $"Can regrow tail: {CanRegrowTail}{Environment.NewLine}";
        }
        #endregion
    }
}
