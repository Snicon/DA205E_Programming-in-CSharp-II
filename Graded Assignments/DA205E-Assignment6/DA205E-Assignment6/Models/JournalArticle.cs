// Sixten Peterson (AQ9300) 2026-05-26

using System.Security.Policy;

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
        #endregion

        #region Methods
        public override string GetInfo()
        {
            return GetBaseDetails() + $"Journal Name: {JournalName}{System.Environment.NewLine}Volume: {Volume}{System.Environment.NewLine}Issue: {Issue}{System.Environment.NewLine}Pages: {Pages}{System.Environment.NewLine}";
        }
        #endregion
    }
}
