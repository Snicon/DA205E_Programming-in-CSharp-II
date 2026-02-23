using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DA205E_Assignment2.Animals
{
    public abstract class Animal: IAnimal
    {
        #region Fields
        private string id = string.Empty;
        private string? name;
        private GenderType gender = GenderType.Unknown;
        private double age = 0.0;
        private double weight = 0.0;
        private Bitmap? image;

        private double sleepTime = 0.0;
        #endregion

        public string Id { 
            get { return id; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    id = value;
            }
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

        public Bitmap? Image
        {
            get { return image; }
            set { image = value; }
        }

        abstract public Category Category
        {
            get;
        }

        public double SleepTime
        {
            get;
            set;
            // TODO: Improve and remove auto properties
        }

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

        public virtual void SetSleepTime()
        {
            SleepTime = 0.0;
        }

        public abstract int GetAverageLifeSpan();

        public abstract Dictionary<string, string> DailyFoodRequirement();

        public abstract Queue<string> GetUpcomingEvents();

        public abstract string GetLatinName();

        public virtual string ToStringSummary()
        {
            string name = Name.Substring(0, Math.Min(12, Name.Length));
            string strOut = $"{Id,-8} {name,-12} {Age,6:f1} {Weight,6:f1} {Gender.ToString()}";
            return strOut;
        }

        public virtual string ToStringAdditional()
        {
            string latinString = $"Latin name: {GetLatinName()}{Environment.NewLine}";
            string dailyFoodRequirementsString = $"Daily food requirements:{Environment.NewLine}";

            foreach(KeyValuePair<string, string> keyValuePair in DailyFoodRequirement())
            {
                dailyFoodRequirementsString += $" - {keyValuePair.Key}: {keyValuePair.Value}{Environment.NewLine}";
            }

            string upcomingEventsString = $"Upcomming events:{Environment.NewLine}";

            foreach (string upcomingEvent in GetUpcomingEvents()) {
                upcomingEventsString += $" - {upcomingEvent}{Environment.NewLine}";
            }

            string lifespanString = $"Lifespan: {GetAverageLifeSpan()} years";

            return latinString + dailyFoodRequirementsString + upcomingEventsString + lifespanString;
        }

        public override string ToString()
        {
            string idString = $"{"ID",-18} {Id,-10}{Environment.NewLine}";
            string nameString = $"{"Name",-18} {Name,-10}{Environment.NewLine}";
            string ageString = $"{"Age",-18} {Age,-10}{Environment.NewLine}";
            string weightString = $"{"Weight",-18} {Weight,-10}{Environment.NewLine}";
            string genderString = $"{"Gender",-18} {Gender,-10}{Environment.NewLine}";
            return idString + nameString + ageString + weightString + genderString;
        }
    }
}
