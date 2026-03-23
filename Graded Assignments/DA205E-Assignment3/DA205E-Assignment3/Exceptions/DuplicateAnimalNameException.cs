// Sixten Peterson (AQ9300) 2026-03-23
namespace DA205E_Assignment3.Exceptions
{
    /// <summary>
    /// Custom exception class for duplicate animal names.
    /// </summary>
    public class DuplicateAnimalNameException : ApplicationException
    {
        private string name;

        /// <summary>
        /// Basic constructor, passes a pre-specified message/reason to base.
        /// </summary>
        public DuplicateAnimalNameException() : base("This list contains duplicate animal names.") { }

        /// <summary>
        /// Basic constructor allowing a reason to be passed as a parameter.
        /// </summary>
        /// <param name="reason">The message that describes the error.</param>
        public DuplicateAnimalNameException(string reason) : base(reason) { }

        /// <summary>
        /// Basic constructor. It allows a reason, inner exception and name to be passed via parameters.
        /// </summary>
        /// <param name="reason">The message that describes the error.</param>
        /// <param name="innerException">The exception that caused the current exception, or null if no inner exception is specified.</param>
        /// <param name="name">The name that is duplicate among the animals (causing the exception).</param>
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
