// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Reptile
{
    /// <summary>
    /// Sub class/derived class of the base/super class Animal. It adds fields and properties for lives in water and can regrow tail along with an overriden ToString()-method.
    /// </summary>
    public class Reptile : Animal
    {
        #region Fields
        private bool livesInWater;
        private bool canRegrowTail;
        #endregion

        #region Constructor
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
        #endregion

        #region ToString() method
        /// <summary>
        /// Overriden ToString method. Adds the LivesInWater and CanRegrowTail property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nLives in water: {LivesInWater}\nCan regrow tail: {CanRegrowTail}";
        }
        #endregion
    }
}
