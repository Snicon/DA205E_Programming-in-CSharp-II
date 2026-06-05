// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    /// <summary>
    /// Implements the Harvard citation style.
    /// This strategy fromats literature according to the umu library standards.
    /// https://www.umu.se/en/library/search-write-study/writing-references/harvard-writing-reference-list/
    /// </summary>
    public class HarvardStrategy : ICitationStrategy
    {
        /// <summary>
        /// Formats a literature object into an Harvard-style citation string.
        /// </summary>
        /// <param name="literature">The literature object to format.</param>
        /// <returns>A formatted citation string, or an empty string if the type is unsupported.</returns> TODO: Update if I change to exception.
        public string Format(Literature literature)
        {
            return literature switch
            {
                Book book => FormatBook(book),
                JournalArticle journalArticle => FormatJournalArticle(journalArticle),
                _ => string.Empty // This literature type is not supported. TODO: Refactor to NotImplemented exception and add try catch when formatting instead?
            };
        }

        /// <summary>
        /// Handles the specific task of formatting the citation for a Book.
        /// </summary>
        /// <param name="book">The book to format the citation for.</param>
        /// <returns>A nicely formatted citation string.</returns>
        private string FormatBook(Book book)
        {
            string baseString = BaseCitationString(book);
            string editionFormatted = book.Edition > 1 ? $" {book.FormattedEdition} ed." : string.Empty;

            return $"{baseString}{editionFormatted} {book.Publisher}";
        }

        /// <summary>
        /// Handles the specific task of formatting the citation for a Journal Articel.
        /// </summary>
        /// <param name="journalArticle">The journal article to format the citation for.</param>
        /// <returns>A nicely formatted citation string.</returns>
        private string FormatJournalArticle(JournalArticle journalArticle)
        {
            string baseString = BaseCitationString(journalArticle);
            string url = journalArticle.URL != null ? $" {journalArticle.URL}" : string.Empty;
            string datePattern = "yyyy-MM-dd"; // TODO: Refactor in order to make this reusable over all citations for less code duplication? (Will be done after hand in due to time constraints:/)

            return $"{baseString} {journalArticle.JournalName} {journalArticle.Volume}({journalArticle.Issue}): pp. {journalArticle.Pages}. {url} (Accessed {DateTime.Now.ToString(datePattern)})";
        }

        /// <summary>
        /// Helper method for that formats the name (with initials) according to the Hardvard style.
        /// </summary>
        /// <param name="author">The author names in an Author struct</param>
        /// <returns>A string representation of the name according to the Harvard style.</returns>
        private string FormatAuthorName(Author author)
        {
            // Initials
            string initials = string.Empty;

            // First initial
            if (!string.IsNullOrEmpty(author.FirstName))
                initials += $"{author.FirstName}.";

            // Middle initial(s)
            if (!string.IsNullOrEmpty(author.MiddleName))
            {
                // Splitting in case of multiple middle names
                string[] middleNames = author.MiddleName.Split(' ');
                foreach (string name in middleNames)
                {
                    initials += $"{name}.";
                }
            }

            return $"{author.LastName}, {initials}";
        }

        /// <summary>
        /// Small helper method that returns the shared base string (Author, YearPublished and Title) used in all Harvard citations.
        /// </summary>
        /// <returns>The base string</returns>
        private string BaseCitationString(Literature literature)
        {
            return $"{FormatAuthorName(literature.AuthorRecord)} ({literature.YearPublished}). {literature.Title}.";
        }
    }
}
