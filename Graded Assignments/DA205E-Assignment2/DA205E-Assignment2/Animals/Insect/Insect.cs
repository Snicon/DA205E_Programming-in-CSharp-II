// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Insect
{
    /// <summary>
    /// Sub class/derived class of the base/super class Animal. It adds fields and properties for hasWings andlifeCycleStage along with an overriden ToString()-method.
    /// </summary>
    public class Insect : Animal
    {
        #region Fields
        private bool hasWings;
        private LifecycleStage lifecycleStage;
        #endregion

        #region Constructor(s)
        public Insect(bool hasWings, LifecycleStage lifecycleStage) : base()
        { 
            HasWings = hasWings;
            LifecycleStage = lifecycleStage;
        }
        #endregion

        #region Properties
        public bool HasWings
        {
            get { return hasWings; }
            set { hasWings = value; }
        }

        public LifecycleStage LifecycleStage
        {
            get { return lifecycleStage; } 
            set { lifecycleStage = value; }
        }
        #endregion

        #region ToString() override
        /// <summary>
        /// Overriden ToString method. Adds the has wings and lifecycle stage to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nHas wings: {HasWings}\nLifecycle stage: {LifecycleStage}";
        }
        #endregion
    }
}
