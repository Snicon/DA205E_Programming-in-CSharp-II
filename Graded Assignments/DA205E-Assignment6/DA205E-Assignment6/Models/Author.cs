namespace DA205E_Assignment6.Models
{
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
        #endregion
    }
}
