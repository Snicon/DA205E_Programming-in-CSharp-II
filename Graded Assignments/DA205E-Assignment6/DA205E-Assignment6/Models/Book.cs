// Sixten Peterson (AQ9300) 2026-05-26

namespace DA205E_Assignment6.Models
{
    /// <summary>
    /// The Book class inherits the Literature class and represents a book.
    /// </summary>
    public class Book : Literature
    {
        #region Fields
        private string isbn;
        private string publisher;
        private string city;
        #endregion

        #region Properties
        public string ISBN
        {
            get => isbn;
            set => isbn = value;
        }

        public string Publisher
        {
            get => publisher;
            set => publisher = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }
        #endregion

        #region Methods
        public override string GetInfo()
        {
            return GetBaseDetails() + $"ISBN: {ISBN}{System.Environment.NewLine}Publisher: {Publisher}{System.Environment.NewLine}City: {City}{System.Environment.NewLine}";
        }
        #endregion
    }
}
