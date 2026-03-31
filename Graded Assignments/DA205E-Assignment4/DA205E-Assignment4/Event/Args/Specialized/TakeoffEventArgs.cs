// Sixten Peterson (AQ9300) 2026-03-31
namespace DA205E_Assignment4.EventArgsClasses
{
    /// <summary>
    /// This class extends the AirplaneEventArgs class, introducing a custom message based on the screen shot from the assignment document.
    /// </summary>
    public class TakeoffEventArgs : AirplaneEventArgs
    {
        #region Constructor
        /// <summary>
        /// Simple constuctor that calls the base constructor.
        /// </summary>
        /// <param name="name">The name of the airplane</param>
        /// <param name="destination">The destination of the airplane</param>
        public TakeoffEventArgs(string name, string destination) : base (name, destination) { }
        #endregion

        #region Properties
        /// <summary>
        /// Overriding the Message property in order to customize the message.
        /// </summary>
        public override string Message
        {
            get { return $"{Name} is taking off, destination {Destination}, {Timestamp:HH:mm:ss}!";  }
        }
        #endregion
    }
}
