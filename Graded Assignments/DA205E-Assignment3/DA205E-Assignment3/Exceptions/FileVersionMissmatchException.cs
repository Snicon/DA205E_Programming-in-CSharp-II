namespace DA205E_Assignment3.Exceptions
{
    public class FileVersionMissmatchException : ApplicationException
    {
        private double expectedToken;
        private double missmatchedToken;

        public FileVersionMissmatchException() : base("The file tokens are missmatched, making the file uncompatible with the program.") { }
    
        public FileVersionMissmatchException(string reason) : base(reason) { }

        public FileVersionMissmatchException(string reason, Exception innerException, double expectedToken, double missmatchedToken) : base(reason, innerException)
        {
            this.expectedToken = expectedToken;
            this.missmatchedToken = missmatchedToken;
        }

        public double ExpectedToken
        {
            get { return expectedToken; }
        }

        public double MissmatchedToken 
        { 
            get { return missmatchedToken; }
        }
    }
}
