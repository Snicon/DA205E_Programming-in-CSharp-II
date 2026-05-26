using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    internal class IEEEStrategy : ICitationStrategy
    {
        // https://libguides-en.ub.uu.se/ieee
        public string Format(Literature literature) // TODO: Refactor into smaller methods and just call them based on the object type if this method grows to big?
        {
            string baseString = $"[N] {literature.Author}, ";

            if (literature is Book book)
            {
                string editionFormatted = book.Edition > 1 ? $", {book.FormattedEdition} ed." : string.Empty;
                return $"{baseString}{literature.Title}{editionFormatted}. {book.City}, COUNTRY: {book.Publisher}, {book.YearPublished}"; // TODO: Make author formatted correctly (Right now it just writes the name as it was saved in the Literature object; Add country field to fully support this citation strategy
            }
            else if (literature is JournalArticle journalArticle)
            {
                return $"{baseString}\"{literature.Title}\" {journalArticle.JournalName}, vol. {journalArticle.Volume}, no. {journalArticle.Issue}, pp. {journalArticle.Pages}, MONTH. {journalArticle.YearPublished}"; // TODO: Add month field to fully support this citation strategy
            }

            return string.Empty; // This literature type is not supported.
        }
    }
}
