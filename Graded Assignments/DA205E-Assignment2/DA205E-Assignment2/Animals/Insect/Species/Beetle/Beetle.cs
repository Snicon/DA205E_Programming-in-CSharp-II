// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Insect.Species.Beetle
{
    /// <summary>
    /// Sub class/derived class of the base/super class Insect. It adds the bodyType field and property along with an overriden ToString()-method.
    /// </summary>
    public class Beetle : Insect
    {
        #region Fields
        private BodyType bodyType;
        #endregion

        #region Constructor(s)
        public Beetle(bool hasWings, LifecycleStage lifecycleStage) : base(hasWings, lifecycleStage) 
        { 
        }
        #endregion

        #region Properties
        public BodyType BodyType
        {
            get { return bodyType; }
            set { bodyType = value; }
        }
        #endregion

        #region ToString() Override
        /// <summary>
        /// Overriden ToString method. Adds the body type to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nBody type: {BodyType}";
        }
        #endregion
    }
}
