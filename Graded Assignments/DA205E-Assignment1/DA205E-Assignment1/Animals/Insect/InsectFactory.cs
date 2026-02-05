// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment1.Animals.Insect.Species;
using DA205E_Assignment1.Animals.Insect.Species.Beetle;
using DA205E_Assignment1.Animals.Insect.Species.Butterfly;

namespace DA205E_Assignment1.Animals.Insect
{
    /// <summary>
    /// Factory class used for creating insect objects.
    /// </summary>
    public class InsectFactory
    {
        /// <summary>
        /// Attempts to create a insect object of the specified species with the hasWings and lifecycleStage from the parameters. If the species couldn't be found in the factory switch statment null is returned.
        /// </summary>
        /// <param name="species">The species of bird to create as BirdSpecies.</param>
        /// <param name="hasWings">The has wings of the insect as a bool</param>
        /// <param name="lifecycleStage">The lifecycle stage of the insect as LifecycleStage</param>
        /// <returns>Either null if the creation attempt failed or the actual species of insect as its object type.</returns>
        public static Insect CreateInsect(InsectSpecies species, bool hasWings, LifecycleStage lifecycleStage)
        {
            Insect insect = null;

            switch (species)
            {
                case InsectSpecies.Beetle:
                    insect = new Beetle(hasWings, lifecycleStage);
                    break;
                case InsectSpecies.Butterfly:
                    insect = new Butterfly(hasWings, lifecycleStage);
                    break;
            }

            return insect;
        }
    }
}
