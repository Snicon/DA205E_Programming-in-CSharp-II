// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment2.Animals
{
    public interface IAnimal
    {
        // private static int lastAssignedId = 0;

        // TODO: Remove
        #region Fields
        /*private readonly int id;
        private string? name;
        private GenderType gender = GenderType.Unknown;
        private double age = 0.0;
        private double weight = 0.0;
        private Bitmap? image;*/
        #endregion

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
        public string ToStringSummary();

        public string ToStringAdditional();

        public void LoadImage();

        /// <summary>
        /// Overriding the ToString to better represent the object data/fields in a string. Showcasing ID, Name, Gender, Age and Weight in a nicley formatted string.
        /// </summary>
        /// <returns>The string representing the object with nice formatting.</returns>
        /*public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nGender: {Gender.ToString()}\nAge: {Age}\nWeight: {Weight}";
        }
        */

        public string ToString();
        #endregion
    }
}
