// Sixten Peterson (AQ9300) 2026-02-24
namespace DA205E_Assignment2.Animals
{
    /// <summary>
    /// An interface containing the structure of the Animal class, which is implemented in the Animal class.
    /// </summary>
    public interface IAnimal
    {
        #region Properties
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get; 
            set;
        }

        public GenderType Gender
        {
            get;
            set;
        }

        public double Age
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }

        public Bitmap Image
        {
            get;
            set;
        }

        public Category Category
        {
            get; 
        }
        #endregion

        #region Methods
        /// <summary>
        /// An at a glance overview of the animal object as a summary string.
        /// </summary>
        /// <returns>The nicley formatted summary string</returns>
        public string ToStringSummary();

        /// <summary>
        /// An additional to string containing extra data displayed in a control in the ui.
        /// </summary>
        /// <returns>The additional data in a nicley formatted string</returns>
        public string ToStringAdditional();

        /// <summary>
        /// Overriding the ToString to better represent the object data/fields in a string. Showcasing ID, Name, Gender, Age and Weight in a nicley formatted string.
        /// </summary>
        /// <returns>The string representing the object with nice formatting.</returns>
        public abstract string ToString();
        #endregion
    }
}
