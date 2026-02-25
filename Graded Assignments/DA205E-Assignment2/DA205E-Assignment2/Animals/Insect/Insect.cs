// Sixten Peterson (AQ9300) 2026-02-24
namespace DA205E_Assignment2.Animals.Insect
{
    /// <summary>
    /// An abstract sub class/derived class of the base/super class Animal. It adds fields and properties for hasWings andlifeCycleStage along with an overriden ToString()-method.
    /// </summary>
    public abstract class Insect : Animal
    {
        #region Fields
        private bool hasWings;
        private LifecycleStage lifecycleStage;
        #endregion


        #region Constructor(s)
        /// <summary>
        /// Sets the hasWings and lifecycleStage via thir properties based on the provided parameters. Also calls the base constructor.
        /// </summary>
        /// <param name="hasWings">A boolean representing if the insect has wings or not</param>
        /// <param name="lifecycleStage">The lifxycle stage of the insect</param>
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

        public override Category Category
        {
            get
            {
                return Category.Insect;
            }
        }
        #endregion

        #region ToString() override
        /// <summary>
        /// Overriden ToString method. Adds the has wings and lifecycle stage to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            string hasWingsString = $"{"Has wings",-18} {HasWings,-10}{Environment.NewLine}";
            string lifecycleStageString = $"{"Lifecycle stage",-18} {LifecycleStage,-10}{Environment.NewLine}";
            return base.ToString() + hasWingsString + lifecycleStageString;
        }
        #endregion
    }
}
