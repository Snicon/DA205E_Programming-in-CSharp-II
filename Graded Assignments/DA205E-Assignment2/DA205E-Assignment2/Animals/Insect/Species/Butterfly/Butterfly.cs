// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Insect.Species.Butterfly
{
    /// <summary>
    /// Sub class/derived class of the base/super class Insect. It adds the wingPattern field and property along with an overriden ToString()-method.
    /// </summary>
    public class Butterfly : Insect
    {
        #region Fields
        private WingPattern wingPattern;
        #endregion

        #region Constructor(s)
        public Butterfly(bool hasWings, LifecycleStage lifecycleStage) : base(hasWings, lifecycleStage)
        {
        }
        #endregion

        #region Properties
        public WingPattern WingPattern
        {
            get { return wingPattern; } 
            set { wingPattern = value; }
        }
        #endregion

        #region ToString() Override
        /// <summary>
        /// Overriden ToString method. Adds the wing pattern to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nWing pattern: {WingPattern.ToString()}";
        }
        #endregion
    }
}
