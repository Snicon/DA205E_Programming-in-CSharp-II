// Sixten Peterson (AQ9300) 2026-02-23

using DA205E_Assignment3.Animals.Bird.Species;
using DA205E_Assignment3.Animals.Bird.Species.Raven;
using DA205E_Assignment3.Animals.Insect.Species;
using DA205E_Assignment3.Animals.Insect.Species.Beetle;
using DA205E_Assignment3.Animals.Insect.Species.Butterfly;
using DA205E_Assignment3.Animals.Reptile.Species;

namespace DA205E_Assignment3.Animals
{
    /// <summary>
    /// The root class for all animal derived classes (obviously). This class implements the IAnimal interface.
    /// </summary>
    public abstract class Animal: IAnimal
    {
        #region Fields
        private string id = string.Empty; // Introduced in assignment 2
        private string? name;
        private GenderType gender = GenderType.Unknown;
        private double age = 0.0;
        private double weight = 0.0;
        private Bitmap? image;

        protected double sleepTime = 0.0; // Introduced in assignment 2
        #endregion

        #region Properties
        public string Id 
        {
            get { return id; }
            set
            {
                if (!string.IsNullOrEmpty(value)) // Only setting new ids that are not an empty string or null
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

        public Bitmap? Image // Bitmap
        {
            get { return image; }
            set { image = value; }
        }

        abstract public Category Category // Will be implemented in a derived class
        {
            get;
        }

        public double SleepTime
        {
            get; // No set is required since there is a virtual setter method already in order to comply with the assignment requirements.
        }
        #endregion

        #region Other methods
        /// <summary>
        /// Virtual method for the sleep time of the animal. Some derived classes override this method. Others use the default of 0.0.
        /// </summary>
        public virtual void SetSleepTime()
        {
            sleepTime = 0.0;
        }

        /// <summary>
        /// Abstract method for getting the average life span. Since different species have different average life spans this is implemented in a derived class.
        /// </summary>
        /// <returns>An int representing the amount of years for an average life span of the animalspecies.</returns>
        public abstract int GetAverageLifeSpan();

        /// <summary>
        /// Abstract method for keeping track of daily food requirements through a dictionary.
        /// </summary>
        /// <returns>Dictionary containing all food requirements.</returns>
        public abstract Dictionary<string, string> DailyFoodRequirement();

        /// <summary>
        /// Abstract method for keeping track of upcoming events through a queue.
        /// </summary>
        /// <returns>Dictionary containing upcoming events.</returns>
        public abstract Queue<string> GetUpcomingEvents();

        /// <summary>
        /// This is my additional abstract mehtod of my own as per the requirement for grade A on the bottom of page 6 of the assignment document. In short it lets derived classes override the latin name of the species.
        /// </summary>
        /// <returns>The latin name of the animal as a string</returns>
        public abstract string GetLatinName();
        #endregion

        #region Methods for string representations of the object
        /// <summary>
        /// A string representation of some of the more important fields of the class (id, name, age, weight, gender). Note that the class is virtual and is therefor overridable in a derived class.
        /// </summary>
        /// <returns>The simplified representation of the class ass a string adapted for the lstAnimal listbox.</returns>
        public virtual string ToStringSummary()
        {
            string name = Name.Substring(0, Math.Min(12, Name.Length));
            string strOut = $"{Id,-8} {Name,-12} {Age,6:f1} {Weight,6:f1} {Gender.ToString()}";
            return strOut;
        }

        /// <summary>
        /// Virtual method for representing additional data of the class, specifically, the latin name, daily food requirement, upcoming events and life span.
        /// </summary>
        /// <returns>The additional data in a nicley formatted string for use in a rich text box.</returns>
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

        /// <summary>
        /// The string representation of the object. It displays the id, name, age, weight and gender nicley formatted.
        /// </summary>
        /// <returns>A nicley formatted string representing the object.</returns>
        public override string ToString()
        {
            string idString = $"{"ID",-18} {Id,-10}{Environment.NewLine}";
            string nameString = $"{"Name",-18} {Name,-10}{Environment.NewLine}";
            string ageString = $"{"Age",-18} {Age,-10}{Environment.NewLine}";
            string weightString = $"{"Weight",-18} {Weight,-10}{Environment.NewLine}";
            string genderString = $"{"Gender",-18} {Gender,-10}{Environment.NewLine}";
            return idString + nameString + ageString + weightString + genderString;
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Helper method used to determine the index of the specified animal by casting the XSpecies enum for said animal to an int
        /// </summary>
        /// <param name="animal">The animal to get the species index from</param>
        /// <returns>The species index of the animal</returns>
        public static int GetSpeciesIndexFromAnimal(Animal animal)
        {
            switch (animal)
            {
                case Dove:
                    return (int)BirdSpecies.Dove;
                case Raven:
                    return (int)BirdSpecies.Raven;
                case Beetle:
                    return (int)InsectSpecies.Beetle;
                case Butterfly:
                    return (int)InsectSpecies.Butterfly;
                case Snake:
                    return (int)ReptileSpecies.Snake;
                case Turtle:
                    return (int)ReptileSpecies.Turtle;
                default:
                    return -1;
            }
        }
        #endregion
    }
}
