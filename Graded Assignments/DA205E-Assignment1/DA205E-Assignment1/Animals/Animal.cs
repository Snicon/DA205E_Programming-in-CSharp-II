// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals
{
    public class Animal
    {
        private static int lastAssignedId = 0;

        #region Fields
        private readonly int id;
        private string? name;
        private GenderType gender = GenderType.Unknown;
        private double age = 0.0;
        private double weight = 0.0;
        private Bitmap? image;
        #endregion

        #region Constructor(s)
        public Animal()
        {
            lastAssignedId++; // Adding one to make a new id
            id = lastAssignedId; // Setting the unique id for the animal
        }
        #endregion

        #region Properties
        // Properties below
        public int Id
        {
            get { return id; } // No set because we don't want to allow the ID to change
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value)) // A name can't be blank
                {
                    name = value;
                }
            }
        }

        public GenderType Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public double Age
        {
            get { return age; }
            set
            {
                if (value >= 0.0) // Only allowing positive numbers, 0 is allowed since an animal may not be 1 year old yet.
                {
                    age = value;
                }
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0.0) // Weight can't be negative or 0.
                {
                    weight = value; 
                }
            }
        }

        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handling image loading via an OpenFileDialog, filters and default extensions are applied. The file path is then used to create a new instance of a bitmap which is then set for the animal.
        /// </summary>
        public void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Opens a File Dialog for picking what file to load
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog.DefaultExt = "jpg"; // Defaulting to the jpg file extenision

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filePath = openFileDialog.FileName; // Getting full file path (called FileName in C#, which I first learned about during assignment 6 for the previous course)
                Bitmap bitmap = new Bitmap(filePath); // "Making" a bitmap out of the image file
                Image = bitmap; // Setting the bitmap
            }

            openFileDialog.Dispose();
        }

        /// <summary>
        /// Overriding the ToString to better represent the object data/fields in a string. Showcasing ID, Name, Gender, Age and Weight in a nicley formatted string.
        /// </summary>
        /// <returns>The string representing the object with nice formatting.</returns>
        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nGender: {Gender.ToString()}\nAge: {Age}\nWeight: {Weight}";
        }
        #endregion
    }
}
