// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models.Enums;

namespace DA205E_Assignment6.Models
{
    /// <summary>
    /// The JournalArticle class inherits the Literature class and represents an article in a Journal.
    /// </summary>
    public class JournalArticle : Literature
    {
        #region Fields
        private string journalName;
        private int volume;
        private int issue;
        private string pages;
        private string url;
        #endregion

        #region Constructors
        public JournalArticle() { } // Needed for DB

        public JournalArticle(string title, string author, int yearPublished, LiteratureFormat format, LiteratureStatus status, List<Course> courses, string journalName, int volume, int issue, string pages, string url) : base(title, author, yearPublished, format, status, courses)
        {
            JournalName = journalName;
            Volume = volume;
            Issue = issue;
            Pages = pages;
            URL = url;
        }
        #endregion

        #region Properties
        public string JournalName
        {
            get => journalName;
            set => journalName = value;
        }

        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        public int Issue
        {
            get => issue;
            set => issue = value;
        }

        public string Pages
        {
            get => pages;
            set => pages = value;
        }

        public string URL
        {
            get => url;
            set => url = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets info about the journal article, including general literature data along with specialized journal article data in a nicley formatted string.
        /// </summary>
        /// <returns>A formatted string of data</returns>
        public override string GetInfo()
        {
            return GetBaseDetails() + $"Journal Name: {JournalName}{System.Environment.NewLine}Volume: {Volume}{System.Environment.NewLine}Issue: {Issue}{System.Environment.NewLine}Pages: {Pages}{System.Environment.NewLine}";
        }
        #endregion
    }
}
