// Sixten Peterson (AQ9300) 2026-02-24
using DA205E_Assignment2.GenericList;

namespace DA205E_Assignment2.Animals
{
    /// <summary>
    /// The animal manager is a specialized version of the ListManager which implements the IListManager interface. In short the additional logic consists of ID generation and getting an array of all string summaries.
    /// 
    /// It's purpose is to handle a list of animals.
    /// </summary>
    public class AnimalManager : ListManager<Animal>
    {
        private static int startID = 100; // The very first number for the ID generation. This number is added to by one for each ID generated.

        /// <summary>
        /// Generates a simple unique id for the animal object that is passed in the parameter based on the category of animal a letter is prefixed to the ID number. Example of an ID may be B101 for a bird.
        /// </summary>
        /// <param name="animal">The animal object to assign the new ID to</param>
        public void SetNewID(Animal animal)
        {
            Category category = animal.Category;
            string newID = string.Empty; // Will be replace by a new value via the switch statement

            switch (category)
            {
                case Category.Bird:
                    newID = "B"; // B as in bird
                    break;
                case Category.Insect:
                    newID = "I"; // I as in insect
                    break;
                case Category.Reptile:
                    newID = "R"; // R as in reptile
                    break;
                default:
                    newID = "U"; // U as in unknown
                    break;
            }

            animal.Id = newID + (startID++).ToString(); // the id of the animal object is set
        }

        /// <summary>
        /// Makes an array of all the ToStringSummary()-strings from the different animal classes in the AnimalManager by iterating over the TheList().
        /// </summary>
        /// <returns>The array containg all the strings from the ToStringSummary() for each animal</returns>
        public string[] ToStringSummaryAllAnimals()
        {
            string[] infoStrings = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                infoStrings[i] = TheList[i].ToStringSummary();
            }

            return infoStrings;
        }
    }
}
