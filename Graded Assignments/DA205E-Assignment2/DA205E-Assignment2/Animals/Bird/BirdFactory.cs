// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment1.Animals.Bird.Species;
using DA205E_Assignment1.Animals.Bird.Species.Raven;

namespace DA205E_Assignment1.Animals.Bird
{
    /// <summary>
    /// Factory class used for creating bird objects.
    /// </summary>
    public class BirdFactory
    {
        /// <summary>
        /// Attempts to create a bird object of the specified species with the wingspan and beak type from the parameters. If the species couldn't be found in the factory switch statment null is returned.
        /// </summary>
        /// <param name="species">The species of bird to create as BirdSpecies.</param>
        /// <param name="wingspan">The wingspan of the bird as a double</param>
        /// <param name="beakType">The type of beak of the bird as BeakType</param>
        /// <returns>Either null if the creation attempt failed or the actual species of bird as its object type.</returns>
        public static Bird CreateBird(BirdSpecies species, double wingspan, BeakType beakType)
        {
            Bird bird = null;

            switch (species)
            {
                case BirdSpecies.Dove:
                    bird = new Dove(wingspan, beakType);
                    break;
                case BirdSpecies.Raven:
                    bird = new Raven(wingspan, beakType);
                    break;
            }

            return bird;
        }
    }
}
