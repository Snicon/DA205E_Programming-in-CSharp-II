// Sixten Peterson (AQ9300) 2026-03-23
using DA205E_Assignment3.Animals.Insect.Species;
using DA205E_Assignment3.Animals.Insect.Species.Beetle;
using DA205E_Assignment3.Animals.Insect.Species.Butterfly;

namespace DA205E_Assignment3.Animals.Insect
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

        /// <summary>
        /// Attempts to create an insect of the specified species with the provided data from the dictionary. If the spcies couldn't be found in the factory switch statment, null is returned.
        /// </summary>
        /// <param name="species">The species of insect to create as InsectSpecies</param>
        /// <param name="data">A dictionary containing the relevant fields.</param>
        /// <returns>Either null if the creation attempt failed or the actual species of insect as its object type.</returns>
        public static Insect CreateInsect(InsectSpecies species, Dictionary<string, object> data)
        {
            Insect insect = null;

            switch (species)
            {
                case InsectSpecies.Beetle:
                    return new Beetle
                    {
                        Id = (string)data["Id"],
                        Name = (string)data["Name"],
                        Age = (double)data["Age"],
                        Gender = (GenderType)data["Gender"],
                        Weight = (double)data["Weight"],
                        // SleepTime = (double)data["SleepTime"]
                        HasWings = (bool)data["HasWings"],
                        LifecycleStage = (LifecycleStage)data["LifecycleStage"],
                        BodyType = (BodyType)data["BodyType"]
                    };
                    break;

                case InsectSpecies.Butterfly:
                    return new Butterfly
                    {
                        Id = (string)data["Id"],
                        Name = (string)data["Name"],
                        Age = (double)data["Age"],
                        Gender = (GenderType)data["Gender"],
                        Weight = (double)data["Weight"],
                        // SleepTime = (double)data["SleepTime"]
                        HasWings = (bool)data["HasWings"],
                        LifecycleStage = (LifecycleStage)data["LifecycleStage"],
                        WingPattern = (WingPattern)data["WingPattern"]
                    };
            }

            return insect;
        }
    }
}
