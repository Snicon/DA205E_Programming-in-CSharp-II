// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.Model.Category;
using System.Windows;

namespace DA205E_Assignment5
{
    /// <summary>
    /// Static validation class, used to make the validation logic more reusable.
    /// </summary>
    public static class ValidationUtil
    {
        private const int MinStringLength = 3; // Got to set the limit somewhere, right?

        /// <summary>
        /// Validates the name of the category (minimum of 3 chars long)
        /// </summary>
        /// <param name="name">The name of the category</param>
        /// <returns></returns>
        public static bool ValidateCategory(string name)
        {
            name = name.Trim();

            if (name.Length < MinStringLength) // Validating length
            {
                MessageBox.Show("Invalid category name, make sure it is at least three characters.", "Validation error"); // Informing of validation problem
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the transaction data (description must be 3 chars long, date and category must not be null and amount must be bigger than zero.
        /// </summary>
        /// <param name="description">The description of the transaction</param>
        /// <param name="date">The date the transaction occured on</param>
        /// <param name="amount">The amount for the transaction</param>
        /// <param name="category">The category of the transaction</param>
        /// <returns></returns>
        public static bool ValidateTransaction(string description, DateTime? date, decimal amount, Category? category)
        {
            description = description.Trim();

            if (description.Length < MinStringLength) // Validating length
            {
                MessageBox.Show("Invalid description, make sure it is at least three characters.", "Validation error");
                return false;
            }

            if (date == null)
            {
                MessageBox.Show("Invalid date selection, make sure you have selected a date.", "Validation error");
                return false;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Invalid amount, make sure it is a positive number bigger than 0.", "Validation error");
                return false;
            }

            if (category == null)
            {
                MessageBox.Show("Invalid category selection, are you sure you selected a category?", "Validation error");
                return false;
            }

            return true;
        }
    }
}
