// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    /// <summary>
    /// Implements the APA7 citation style.
    /// This strategy fromats literature according to the KI library standards.
    /// https://kib.ki.se/en/write-cite/referencing-declaring-your-sources/reference-guides/reference-guide-apa-7
    /// </summary>
    public class APA7Strategy : ICitationStrategy
    {
        /// <summary>
        /// Formats a literature object into an APA7-style citation string.
        /// </summary>
        /// <param name="literature">The literature object to format.</param>
        /// <returns>A formatted citation string, or an empty string if the type is unsupported.</returns> TODO: Update if I change to exception
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

            string editionFormatted = book.Edition > 1 ? $" ({book.FormattedEdition} ed.)" : string.Empty;
            return $"{baseString}{editionFormatted}. {book.Publisher}";
        }

        /// <summary>
        /// Handles the specific task of formatting the citation for a Journal Articel.
        /// </summary>
        /// <param name="journalArticle">The journal article to format the citation for.</param>
        /// <returns>A nicely formatted citation string.</returns>
        private string FormatJournalArticle(JournalArticle journalArticle)
        {
            string baseString = BaseCitationString(journalArticle);

            return $"{baseString}. {journalArticle.JournalName}, {journalArticle.Volume}({journalArticle.Issue}), pp. {journalArticle.Pages}. {journalArticle.URL}";
        }

        /// <summary>
        /// Helper method for that formats the name (with initials) according to the APA style.
        /// </summary>
        /// <param name="author">The author names in an Author struct</param>
        /// <returns>A string representation of the name according to the APA style.</returns>
        private string FormatAuthorName(Author author)
        {
            // First initial
            string firstInitial = !string.IsNullOrEmpty(author.FirstName) 
                ? $"{author.FirstName}. "
                : string.Empty;

            // Middle initial
            string middleInitials = string.Empty;
            if (!string.IsNullOrEmpty(author.MiddleName)) 
            {
                // Splitting in case of multiple middle names
                string[] middleNames = author.MiddleName.Split(' ');
                foreach (string name in middleNames)
                {
                    middleInitials += $" {name}. ";
                }
            }

            return $"{author.LastName}, {firstInitial}{middleInitials}".Trim();
        }

        /// <summary>
        /// Small helper method that returns the shared base string (Author, YearPublished and Title) used in all APA7 citations.
        /// </summary>
        /// <returns>The base string</returns>
        private string BaseCitationString(Literature literature)
        {
            return $"{FormatAuthorName(literature.AuthorRecord)} ({literature.YearPublished}). {literature.Title}";
        }
    }
}
