// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Utils
{
    /// <summary>
    /// Static utility class containing validation logic and a helper function for showing a Message box to the user.
    /// </summary>
    public static class ValidationUtility
    {
        /// <summary>
        /// Warns the user based on the provided message, used in the program when validation fails
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        public static void WarnUser(string message)
        {
            MessageBox.Show(message, "Whoops!");
        }

        /// <summary>
        /// Validates all the general animal data (except for the GenderType) thorugh the help of some helper methods.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="weight"></param>
        /// <returns>true if valid, false if invalid</returns>
        public static bool ValidateGeneral(string name, double age, double weight)
        {
            return IsValidName(name) && IsValidAge(age) && IsValidWeight(weight);
        }

        /// <summary>
        /// Validates the provided name (not null or empty)
        /// </summary>
        /// <param name="name">the value to validate</param>
        /// <returns>true if valid, false if invalid</returns>
        private static bool IsValidName(string name) 
        {
            return !string.IsNullOrEmpty(name);
        }

        // DO NOTE: The two methods below (IsValidAge, IsValidWeight) are currently just duplicate code with new method signatures. I've decided to implement it this way to make the code more maintainable for any future validation rule changes as they may have seperate validation rules in the future.
        /// <summary>
        /// Validates the provided age (0.0 or older, age can't be negative)
        /// </summary>
        /// <param name="age">the value to validate</param>
        /// <returns>true if valid, false if invalid</returns>
        private static bool IsValidAge(double age)
        {
            return age >= 0.0;
        }

        /// <summary>
        /// Valides the provided weight (0.0 or heavier, weight can't be negative)
        /// </summary>
        /// <param name="weight">the value to validate</param>
        /// <returns>true if valid, false if invalid</returns>
        private static bool IsValidWeight(double weight)
        { 
            return weight >= 0.0;
        }
    }
}
