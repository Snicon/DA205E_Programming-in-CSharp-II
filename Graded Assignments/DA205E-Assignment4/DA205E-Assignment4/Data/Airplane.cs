// Sixten Peterson (AQ9300) 2026-03-31
using DA205E_Assignment4.EventArgsClasses;
using System.Configuration;
using System.Windows.Threading;

namespace DA205E_Assignment4.Data
{
    public delegate int FlightHeightChange(int newHeight); // Declaring a delegate within the namespace, much like the example in the lecture slides (see p. 7)

    /// <summary>
    /// This class essentially represents an airplane model, consisting of various fields such as id, name and time among others. It also includes event handlers for taking off and landing the plane.
    /// </summary>
    public class Airplane
    {
        #region Fields
        private string id;
        private string name;
        private double time; // flight duration in hours (which qre represented as seconds in the simulation)
        private bool inFlight; // if the airplane is currently in a flight or not
        private int flightHeight; // also reffered to as altitude in some places
        private DispatcherTimer dispatchTimer; // Timer used for the flight time

        private TimeOnly departureTime; // Event handler displayed as field here
        private string destination; // Event handler displayed as field here
        #endregion

        #region EventHandlers
        public event EventHandler<LandedEventArgs> Landed;
        public event EventHandler<TakeoffEventArgs> Takeoff;
        #endregion

        #region Constructor
        /// <summary>
        /// Normally I just comment these as simple but there is actually a few things happening here now.
        /// 
        /// Firstly the fields are initialized through the parameters of the constructor (simple enough).
        /// Secondly a DispatcherTimer is creater, the interval is set to a TimeSpan from 1 second and
        /// a lambda function is used for the time simulation of the application.
        /// 
        /// In short, if the time left is bigger than or equal to the flight time the inFlight field
        /// is set to false, an instance of the LandedEventArgs are created and the OnNewLanded() is
        /// invoked. Lastly the dispatch timer is stopped.
        /// </summary>
        /// <param name="name">The name of the airplane</param>
        /// <param name="id">The id of the airplane</param>
        /// <param name="destination">The destination of the airplane</param>
        /// <param name="time">The flight time of the airplane (how long it will fly for)</param>
        public Airplane(string name, string id, string destination, double time)
        {
            this.name = name;
            this.id = id;
            this.destination = destination;
            this.time = time;

            dispatchTimer = new DispatcherTimer(); // New timer
            dispatchTimer.Interval = TimeSpan.FromSeconds(1); // Setting the interval to 1 second
            dispatchTimer.Tick += (object? sender, EventArgs e) => // Lambda for what happens at each tick
            {
                // A big part of the code is inspired from the code provided in the assignment document by Farid.
                TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

                double timeLeft = (currentTime - departureTime).TotalSeconds;
                if (timeLeft >= time) // See the xml comment above
                {
                    inFlight = false;
                    LandedEventArgs eventArgs = new LandedEventArgs(name, Destination);
                    OnNewLanded(eventArgs);
                    dispatchTimer.Stop();
                }
            };
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public string FlightNumber
        {
            get { return id; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public double FlightTime
        {
            get { return time; }
        }

        public bool InFlight
        {
            get { return inFlight; }
        }

        public int FlightHeight
        {
            get { return flightHeight; }
        }
        #endregion

        #region Raising events
        /// <summary>
        /// Raises the Takeoff event.
        /// </summary>
        /// <param name="e">An instance of TakeoffEventArgs containing the relevant data</param>
        protected void OnNewTakeoff(TakeoffEventArgs e)
        {
            Takeoff?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the Landed event.
        /// </summary>
        /// <param name="e">An instance of LandedEventArgs containg the relevant data</param>
        protected void OnNewLanded(LandedEventArgs e)
        {
            Landed?.Invoke(this, e);
        }
        #endregion

        #region Methods
        /// <summary>
        /// If the airplane is not already in flight it starts a flight by invoking the takeoff event and
        /// starting the timer.
        /// </summary>
        public void StartFlight()
        {
            if (inFlight) return; // Plane is already in flight

            inFlight = true; // Setting inFlight to true to indicate that the plane is now in flight
            departureTime = TimeOnly.FromDateTime(DateTime.Now);

            TakeoffEventArgs takeoffInfo = new TakeoffEventArgs(this.name, Destination);
            OnNewTakeoff(takeoffInfo); // invoking the event
            dispatchTimer.Start(); // starting time
        }

        /// <summary>
        /// Method that the delegate points to. Returns -1 if the newHeight was invalid (or the plane is already in flight) and the height if it was valid (and not in flight).
        /// </summary>
        /// <returns></returns>
        public int AltitudeChange(int newHeight)
        {
            if (inFlight && newHeight > 0) // I assume a negative flight height isn't allowed.
            {
                this.flightHeight = newHeight; // Setting the flight height.
                return FlightHeight; // Returns the flight height that was set through the property for the field.
            }
            else
            {
                return -1; // Returning -1 since the plane was in flight and/or the height was invalid
            }
        }
        #endregion

        #region ToString()
        /// <summary>
        /// A basic string representation of the airplane consisting of the name, id and the destination. This is used for the airplane listbox in the MainWindow.xaml-file.
        /// </summary>
        /// <returns>The string representation of the object</returns>
        public override string ToString()
        {
            return $"{name}, {id}, heading for {Destination}";
        }
        #endregion
    }
}
