// Sixten Peterson (AQ9300) 2026-03-31
using DA205E_Assignment4.EventArgsClasses;

namespace DA205E_Assignment4.Event.Args.Specialized
{
    /// <summary>
    /// This class extends the AirplaneEventArgs class, introducing the flightHeight and a custom message based on the screen shot from the assignment document.
    /// </summary>
    public class FlightHeightEventArgs : AirplaneEventArgs
    {
        #region Fields
        private int flightHeight;
        #endregion

        #region Constructor
        /// <summary>
        /// Very simple constructor that calls the base constructor with the relevant parameters. It also sets the flightHeight field.
        /// I was dumb enough to write flightHeight = this.flightHeight earlier, costing me 1 hour of debugging. 0/10, do not recommend - such a dumb and embarrasing mistake.
        /// </summary>
        /// <param name="name">The name of the flight</param>
        /// <param name="destination">The destination of the flight</param>
        /// <param name="flightHeight">The hegiht of the flight</param>
        public FlightHeightEventArgs(string name, string destination, int flightHeight) : base(name, destination)
        {
            this.flightHeight = flightHeight;
        }
        #endregion

        #region Properties
        public int FlightHeight
        {
            get { return flightHeight; }
        }
        #endregion

        /// <summary>
        /// Overriding the Message property in order to customize the message.
        /// </summary>
        public override string Message
        {
            // Note to self: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
            get { return $"{Name} heading to {Destination}, changed its altitude to {FlightHeight}, {Timestamp:HH:mm:ss}"; }
        }
    }
}
