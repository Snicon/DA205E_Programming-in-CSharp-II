// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment3.Animals.Reptile.Species;

namespace DA205E_Assignment3.Animals.Reptile
{
    /// <summary>
    /// Factory class used for creating bird objects.
    /// </summary>
    public class ReptileFactory
    {
        /// <summary>
        /// Attempts to create a reptile object of the specified species with the wingspan and beak type from the parameters. If the species couldn't be found in the factory switch statment null is returned.
        /// </summary>
        /// <param name="species">The species of bird to create as BirdSpecies.</param>
        /// <param name="livesInWater">If the reptile lives in water as a bool</param>
        /// <param name="canRegrowTail">If the reptile can regrow its tail as a bool</param>
        /// <returns>Either null if the creation attempt failed or the actual species of reptile as its object type.</returns>
        public static Reptile CreateReptile(ReptileSpecies species, bool livesInWater, bool canRegrowTail)
        {
            Reptile reptile = null;

            switch (species)
            {
                case ReptileSpecies.Snake:
                    reptile = new Snake(livesInWater, canRegrowTail);
                    break;
                case ReptileSpecies.Turtle:
                    reptile = new Turtle(livesInWater, canRegrowTail);
                    break;
            }

            return reptile;
        }

        public static Reptile CreateReptile(ReptileSpecies species, Dictionary<string, object> data)
        {
            Reptile reptile = null;

            switch (species)
            {
                case ReptileSpecies.Snake:
                    return new Snake
                    {
                        Id = (string)data["Id"],
                        Name = (string)data["Name"],
                        Age = (double)data["Age"],
                        Gender = (GenderType)data["Gender"],
                        Weight = (double)data["Weight"],
                        // SleepTime = (double)data["SleepTime"],
                        LivesInWater = (bool)data["LivesInWater"],
                        CanRegrowTail = (bool)data["CanRegrowTail"],
                        Venomous = (bool)data["Venomous"]
                    };
                case ReptileSpecies.Turtle:
                    return new Turtle
                    {
                        Id = (string)data["Id"],
                        Name = (string)data["Name"],
                        Age = (double)data["Age"],
                        Gender = (GenderType)data["Gender"],
                        Weight = (double)data["Weight"],
                        // SleepTime = (double)data["SleepTime"],
                        LivesInWater = (bool)data["LivesInWater"],
                        CanRegrowTail = (bool)data["CanRegrowTail"],
                        ShellWidth = (double)data["ShellWidth"]
                    };
            }

            return reptile;
        }
    }
}
