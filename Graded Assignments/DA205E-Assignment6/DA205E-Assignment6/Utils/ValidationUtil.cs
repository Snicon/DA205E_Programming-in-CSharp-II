// Sixten Peterson (AQ9300) 2026-06-04
using System.Text.RegularExpressions;
using System.Windows;

namespace DA205E_Assignment6.Utils
{
    /// <summary>
    /// This static utility class handles validation of user input, typically called before creating a new object to make sure
    /// the data is valid before attempting to create a new instance.
    /// 
    /// While there is a lot of code repetition here I decided to structure this class the way I did in order to allow as much
    /// flexibility as possible in case the different inputs would require different validation steps in the future.
    /// All the string validation could theoretically be refactored to be based on the same methods instead and take
    /// string constants of the validation messages as parameters but hey, this works for now and is the most flexible.
    /// </summary>
    public static class ValidationUtil
    {
        #region Constants (Avoiding magic numbers)
        private const int MinStringLength = 3; // Constant for minimum string lenght, could have been anything but I choose 3 as it should be rather lenient towards the user while still enforcing a non-empty value
        #endregion

        #region Course related
        /// <summary>
        /// Validates the course data required to create a new course.
        /// </summary>
        /// <param name="name">The name of the course</param>
        /// <param name="code">The code of the course</param>
        /// <returns>True if all values were valid, false if at least one value failed validation.</returns>
        public static bool ValidateCouse(string name, string code)
        {
            return ValidateCourseName(name) && ValidateCourseCode(code);
        }

        /// <summary>
        /// Validates the name of the course, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="name">The name of the course</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateCourseName(string name)
        {
            name = name.Trim();

            if (string.IsNullOrEmpty(name) || name.Length < MinStringLength)
            {
                MessageBox.Show("The course name must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the code of the course, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="code">The code of the course</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateCourseCode(string code)
        {
            code = code.Trim();

            if (string.IsNullOrEmpty(code) || code.Length < MinStringLength)
            {
                MessageBox.Show("The course code must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }
        #endregion

        #region Literature related
        /// <summary>
        /// Validates the provided literature data
        /// </summary>
        /// <param name="title">The title of the literature</param>
        /// <param name="yearPublished">The publishing year of the literature</param>
        /// <returns>True if valid, false if invalid</returns>
        public static bool ValidateLiterature(string title, int yearPublished)
        {
            return ValidateLiteratureTitle(title) && ValidateLiteraturePublishedYear(yearPublished);
        }

        /// <summary>
        /// Validates the title of the literature, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="title">The title of the literature</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateLiteratureTitle(string title)
        {
            title = title.Trim();

            if (string.IsNullOrEmpty(title) || title.Length < MinStringLength)
            {
                MessageBox.Show("The literature title must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the publishing year of the literature, and shows a messagebox detailing what failed if the validation fails.
        /// Must be at least four digits, no negative numbers allowed
        /// </summary>
        /// <param name="yearPublished">The publishing year of the literature</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateLiteraturePublishedYear(int yearPublished)
        {
            if (yearPublished < 0 || yearPublished.ToString().Length < 4) // Hacky? Sure, but at least it does make sure it is a reasonable year as in a year consisitng of four digits. Also disallows any negative input
            {
                MessageBox.Show("The provided year does not seem to be a valid year. It has to contian four digits, no positive numbers allowed.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }
        #endregion

        #region Book related
        /// <summary>
        /// Validates the provided book data
        /// </summary>
        /// <param name="isbn">ISBN of the book</param>
        /// <param name="edition">Edition of the book</param>
        /// <param name="publisher">Publisher of the book</param>
        /// <param name="city">City of the publisher of the book</param>
        /// <returns>True if valid, false if not</returns>
        public static bool ValidateBook(string isbn, int edition, string publisher, string city)
        {
            return ValidateISBN(isbn) && ValidateEdition(edition) && ValidatePublisher(publisher) && ValidateCity(city);
        }

        /// <summary>
        /// Validates the isbn of the book, and shows a messagebox detailing what failed if the validation fails.
        /// Must be a valid isbn.
        /// </summary>
        /// <param name="isbn">The isbn of the book</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateISBN(string isbn)
        {
            string regexString = @"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$"; // Regex "borrowed" from GeeksForGeeks: https://www.geeksforgeeks.org/dsa/regular-expressions-to-validate-isbn-code/

            if (!(new Regex(regexString).IsMatch(isbn)))
            {
                MessageBox.Show("This is an invalid ISBN. Please double check the value, and remove any charachters if there are any. Only digits and hyphens (optional) allowed.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the edition of the book, and shows a messagebox detailing what failed if the validation fails.
        /// Must be a positive number (excluding zero).
        /// </summary>
        /// <param name="edition">The edition of the book</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateEdition(int edition)
        {
            if (edition <= 0)
            {
                MessageBox.Show("Only positive numbers excluding zero are allowed for the edition.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the publisher of the book, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="publisher">The publisher of the course</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidatePublisher(string publisher)
        {
            publisher = publisher.Trim();

            if (string.IsNullOrEmpty(publisher) || publisher.Length < MinStringLength)
            {
                MessageBox.Show("The publisher must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the city of the (publisher of the) book, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="city">The city of the (publisher of the) book</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateCity(string city)
        {
            city = city.Trim();

            if (string.IsNullOrEmpty(city) || city.Length < MinStringLength)
            {
                MessageBox.Show("The city must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }
        #endregion

        #region JournalArticle related
        public static bool ValidateJournalArticle(string journalName, int volume, int issue, string pages)
        {
            return ValidateJournalName(journalName) && ValidateVolume(volume) && ValidateIssue(issue) && ValidatePages(pages);
        }

        /// <summary>
        /// Validates the name of the journal, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 3 characters long.
        /// </summary>
        /// <param name="journalName">The name of the journal</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateJournalName(string journalName)
        {
            journalName = journalName.Trim();

            if (string.IsNullOrEmpty(journalName) || journalName.Length < MinStringLength)
            {
                MessageBox.Show("The journal name must be at least 3 characters long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the volume of the journal article, and shows a messagebox detailing what failed if the validation fails.
        /// Must be a positive number (excluding zero).
        /// </summary>
        /// <param name="volume">The volume of the journal article</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateVolume(int volume)
        {
            if (volume <= 0)
            {
                MessageBox.Show("Only positive numbers excluding zero are allowed for the volume.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the issue of the journal article, and shows a messagebox detailing what failed if the validation fails.
        /// Must be a positive number (excluding zero).
        /// </summary>
        /// <param name="issue">The issue of the journal article</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidateIssue(int issue)
        {
            if (issue <= 0)
            {
                MessageBox.Show("Only positive numbers excluding zero are allowed for the issue.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the pages of the journal, and shows a messagebox detailing what failed if the validation fails.
        /// String must be at least 1 characters long.
        /// </summary>
        /// <param name="pages">The pages of the journal</param>
        /// <returns>True if valid, false if invalid</returns>
        private static bool ValidatePages(string pages)
        {
            pages = pages.Trim();

            if (string.IsNullOrEmpty(pages))
            {
                MessageBox.Show("The pages must be at least 1 character long.", "Whoops! Validation failed.");
                return false;
            }

            return true;
        }
        #endregion
    }
}
