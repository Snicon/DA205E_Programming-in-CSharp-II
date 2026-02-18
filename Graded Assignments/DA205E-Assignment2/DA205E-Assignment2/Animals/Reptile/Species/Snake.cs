// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Reptile.Species
{
    /// <summary>
    /// Sub class/derived class of the base/super class Reptile. It adds fields and properties for venomous along with an overriden ToString()-method.
    /// </summary>
    public class Snake : Reptile
    {
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

        #region Overriden ToString method
        /// <summary>
        /// Overriden ToString method. Adds the venomous property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nVenomous: {Venomous}";
        }
        #endregion
    }
}
