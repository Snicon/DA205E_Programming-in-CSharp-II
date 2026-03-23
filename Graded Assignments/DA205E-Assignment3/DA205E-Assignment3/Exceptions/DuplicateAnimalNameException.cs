namespace DA205E_Assignment3.Exceptions
{
    public class DuplicateAnimalNameException : ApplicationException
    {
        private string name;

        public DuplicateAnimalNameException() : base("This list contains duplicate animal names.")
        {

        }

        public DuplicateAnimalNameException(string reason) : base(reason) { 

        }

        public DuplicateAnimalNameException(string reason, Exception innerException, string name) : base(reason, innerException)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}
