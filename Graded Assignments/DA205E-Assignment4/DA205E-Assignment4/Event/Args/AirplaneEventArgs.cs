// Sixten Peterson (AQ9300) 2026-03-31
namespace DA205E_Assignment4.EventArgsClasses
{
    /// <summary>
    /// This abstact class is the foundation for all the different types of event args related to the airplanes. It extends the EventArgs class and implements the IAirplaneEventArgs interface.
    /// </summary>
    public abstract class AirplaneEventArgs : EventArgs, IAirplaneEventArgs
    {
        #region Fields
        string name;
        string destination;
        DateTime timestamp;
        #endregion

        #region Constructor
        /// <summary>
        /// Simple constuctor, sets the fields.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="destination"></param>
        public AirplaneEventArgs(string name, string destination)
        {
            this.name = name;
            this.destination = destination;
            this.timestamp = DateTime.Now; // Setting the timestamp to now as the TakeoffEvent was created now. Hopefully that makes sense to whoever ends up reading this.
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
        }

        public string Destination
        {
            get { return this.destination; }

        }

        public DateTime Timestamp
        {
            get { return this.timestamp; }
        }

        public abstract string Message
        {
            get;
        }
        #endregion
    }
}
