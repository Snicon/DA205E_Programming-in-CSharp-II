using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    public class OxfordStrategy : ICitationStrategy
    {
        // https://www.umu.se/en/library/search-write-study/writing-references/oxford-writing-reference-list/
        public string Format(Literature literature) // TODO: Refactor into smaller methods and just call them based on the object type if this method grows to big?
        {
            string baseString = $"{literature.Author}. {literature.Title}.";

            if (literature is Book book)
            {
                string editionFormatted = book.Edition > 1 ? $" {book.FormattedEdition} ed." : string.Empty;
                return $"{baseString}{editionFormatted} ({book.Publisher}, {book.YearPublished})"; // TODO: Make author formatted correctly (Right now it just writes the name as it was saved in the Literature object
            }
            else if (literature is JournalArticle journalArticle)
            {
                return $"{baseString} {journalArticle.JournalName} {journalArticle.Volume}: {journalArticle.Issue} ({journalArticle.YearPublished}): pp. {journalArticle.Pages}."; // TODO: Make author formatted correctly (Right now it just writes the name as it was saved in the Literature object; Add DOI/URL or eqivelent?
            }

            return string.Empty; // This literature type is not supported.
        }
    }
}
