// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    public class APA7Strategy : ICitationStrategy
    {
        // https://kib.ki.se/en/write-cite/referencing-declaring-your-sources/reference-guides/reference-guide-apa-7
        public string Format(Literature literature) // TODO: Refactor into smaller methods and just call them based on the object type if this method grows to big?
        {
            string baseString = $"{literature.Author}. ({literature.YearPublished}). {literature.Title}";

            if (literature is Book book)
            {
                string editionFormatted = book.Edition > 1 ? $" ({book.FormattedEdition} ed.)" : string.Empty;
                return $"{baseString}{editionFormatted}. {book.Publisher}"; // TODO: Make author formatted correctly (Right now it just writes the name as it was saved in the Literature object
            }
            else if (literature is JournalArticle journalArticle)
            {
                return $"{baseString}. {journalArticle.JournalName}, {journalArticle.Volume}({journalArticle.Issue}), pp. {journalArticle.Pages}."; // TODO: Make author formatted correctly (Right now it just writes the name as it was saved in the Literature object; Add DOI/URL or eqivelent?
            }

            return string.Empty; // This literature type is not supported.
        }
    }
}
