// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Bird.Species.Raven
{
    /// <summary>
    /// Sub class of the base/super class Bird. It adds the beakSize field along with a property along with an overriden ToString()-method.
    /// </summary>
    public class Raven : Bird
    {
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

        #region ToString()-method
        /// <summary>
        /// Overriden ToString method. Adds the milk production to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nBeak size: {BeakSize}";
        }
        #endregion
    }
}
