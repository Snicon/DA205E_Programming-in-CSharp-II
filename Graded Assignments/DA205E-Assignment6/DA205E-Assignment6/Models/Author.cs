// Sixten Peterson (AQ9300) 2026-05-28
namespace DA205E_Assignment6.Models
{
    /// <summary>
    /// A lightweight author record used to pass structured author names to citation strategies.
    /// Not stored in the database in order to simplify the logic and get the project done within the time limit.
    /// </summary>
    public record Author
    {
        #region Fields
        private string firstName;
        private string middleName;
        private string lastName;
        #endregion

        #region Properties
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string MiddleName
        {
            get => middleName;
            set => middleName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }
        #endregion

        #region Constructor
        public Author(string firstName, string middleName, string lastName) 
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public Author()
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }
        #endregion
    }
}
