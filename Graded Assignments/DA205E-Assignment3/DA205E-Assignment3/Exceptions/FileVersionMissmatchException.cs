// Sixten Peterson (AQ9300) 2026-03-23
namespace DA205E_Assignment3.Exceptions
{
    /// <summary>
    /// Custom exception class for a missmatch of file version
    /// </summary>
    public class FileVersionMissmatchException : ApplicationException
    {
        #region Fields
        private double expectedVersion; // The file version that was expected for the program
        private double missmatchedVersion; // The actual file version of the file that was read/openend.
        #endregion

        /// <summary>
        /// Basic constructor, passes a pre-specified message/reason to base.
        /// </summary>
        public FileVersionMissmatchException() : base("The file versions are missmatched, making the file uncompatible with the program.") { }
    
        /// <summary>
        /// Basic constructor allowing a reason to be passed as a paramter.
        /// </summary>
        /// <param name="reason">The message that describes the error.</param>
        public FileVersionMissmatchException(string reason) : base(reason) { }

        /// <summary>
        /// Basic constructor. It allows a reason, inner exception and expectedVersion and missmatchedVersion to be passed via parameters.
        /// </summary>
        /// <param name="reason">The message that describes the error.</param>
        /// <param name="innerException">The exception that caused the current exception, or null if no inner exception is specified.</param>
        /// <param name="expectedVersion">The file version that was expected for the program.</param>
        /// <param name="missmatchedVersion">The actual file version of the file that was read/openend.</param>
        public FileVersionMissmatchException(string reason, Exception innerException, double expectedVersion, double missmatchedVersion) : base(reason, innerException)
        {
            this.expectedVersion = expectedVersion;
            this.missmatchedVersion = missmatchedVersion;
        }

        #region Properties
        public double ExpectedToken
        {
            get { return expectedVersion; }
        }

        public double MissmatchedToken 
        { 
            get { return missmatchedVersion; }
        }
        #endregion
    }
}
