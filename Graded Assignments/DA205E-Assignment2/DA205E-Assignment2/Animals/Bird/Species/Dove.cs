// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Bird.Species
{
    /// <summary>
    /// Sub class of the base/super class Bird. It adds the mildProduction field along with a property along with an overriden ToString()-method.
    /// </summary>
    public class Dove : Bird
    {
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

        #region ToString()-method
        /// <summary>
        /// Overriden ToString method. Adds the milk production property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nMilk production: {MilkProduction}";
        }
        #endregion
    }
}
