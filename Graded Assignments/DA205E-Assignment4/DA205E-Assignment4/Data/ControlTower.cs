// Sixten Peterson (AQ9300) 2026-03-31
using DA205E_Assignment4.Event.Args.Specialized;
using DA205E_Assignment4.EventArgsClasses;
using DA205E_Assignment4.GenericList;

namespace DA205E_Assignment4.Data
{
    /// <summary>
    /// The control tower implements the ListManager with the Airplane type.
    /// Additionally it adds a bulk of other features mainly consisting of
    /// airplane management. A big part of the logic is based on event.
    /// These are used to relay data to the GUI.
    /// </summary>
    public class ControlTower : ListManager<Airplane>
    {
        #region EventHandlers
        public event EventHandler<LandedEventArgs> Landed;
        public event EventHandler<TakeoffEventArgs> Takeoff;
        public event EventHandler<FlightHeightEventArgs> FlightHeightChange;
        #endregion

        #region Methods
        /// <summary>
        /// Orders a take off for the specified plane.
        /// </summary>
        /// <param name="index">The index of the plane in the control tower</param>
        public void OrderTakeoff(int index)
        {
            if (CheckIndex(index)) // Checking if the index is valid
            {
                Airplane airplane = GetAt(index); // Gets the airplane since the index was indeed valid.

                // Unsubscribing before subscibing below to ensure that the handler isn't already there. This is mostly nessecary due to the requirement in section 8 of the assignment description.
                airplane.Takeoff -= AirplaneStatusUpdate;
                airplane.Landed -= AirplaneStatusUpdate;

                // Resubscribing before the next departure takes place as per the assignment requirements (see point 18 under section 7)
                airplane.Takeoff += AirplaneStatusUpdate;
                airplane.Landed += AirplaneStatusUpdate;

                airplane.StartFlight(); // Starts the flight which causes the take off event to be invoked if the conditions detailed in the StartFlight()-method xml-comment are met.
            }
        }

        /// <summary>
        /// Event handler for the takeoff and landed events. The type of event is determined by the type of AirplaneEventArgs in the parameter.
        /// If it is a takeoff event the Takeoff inside of the control tower is invoked.
        /// If it is a landed event the airplane destination is set to Home per the assignment requirements. Additionally the landed event
        /// inside of the class is invoked, lastly the takeoff and landed events are unsubscribed from the airplane (these are resubscribed to upon taking off again)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AirplaneStatusUpdate(object sender, AirplaneEventArgs e)
        {
            if (sender is Airplane airplane)
            {
                // Determining the type of AirplaneEventsArgs as it can be one of multiple specialized types.
                if (e is TakeoffEventArgs takeoff)
                {
                    OnNewTakeoff(takeoff);
                }
                else if (e is LandedEventArgs landed)
                {
                    airplane.Destination = "Home";
                    OnNewLanded(landed);
                    // Unsubscribing when the plane has landed as per the assignment requirements (see point 18 under section 7)
                    airplane.Takeoff -= AirplaneStatusUpdate;
                    airplane.Landed -= AirplaneStatusUpdate;
                }
            }
        }

        /// <summary>
        /// Invokes the flightHeightChange event for the GUI if the delegate returns a valid height (0 or bigger).
        /// </summary>
        /// <param name="index">The index of the airplane</param>
        /// <param name="height">The desired new height of the airplane</param>
        public void FlightHeight(int index, string height)
        {
            bool validIndex = CheckIndex(index); // Making sure the index is valid
            
            if (!validIndex) // Guard clause
            {
                return; // Invalid index -> early return
            }

            Airplane airplane = GetAt(index);
            
            FlightHeightChange del = airplane.AltitudeChange;
            int newAltitude = del(int.Parse(height)); // Invoking/calling the delegate with the new height value. Since the delegate is a regular delegate and not an event the new altitude/flightHeight is returend (and set to the newAltitude variable)

            if (newAltitude > -1) // The altitude is not negative
            {
                FlightHeightEventArgs flightHeightInfo = new FlightHeightEventArgs(airplane.Name, airplane.Destination, newAltitude);
                OnNewFlightHeightChanged(flightHeightInfo); // Raising the event with the args created on the line above. ^
            }
        }
        #endregion

        #region Overwritten methods
        /// <summary>
        /// Overrides the add logic from the base class in order to include event subscription to the logic since it is mentioned in the assignment document.
        /// </summary>
        /// <param name="airplane">The airplane object to add into the list.</param>
        /// <returns>true if successfully added to the list, false if not.</returns>
        public override bool Add(Airplane airplane)
        {
            if (airplane == null) // Making sure the airplane is not null.
                return false; // early return since the airplane was null

            TheBaseList.Add(airplane);
            airplane.Takeoff += AirplaneStatusUpdate;
            airplane.Landed += AirplaneStatusUpdate;
            return true; // Returing true since the airplane was successfully added.
        }
        #endregion

        #region Raising events
        /// <summary>
        /// Raises the Takeoff event.
        /// </summary>
        /// <param name="e">Event args</param>
        protected void OnNewTakeoff(TakeoffEventArgs e)
        {
            Takeoff?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the landed event.
        /// </summary>
        /// <param name="e">Event args</param>
        protected void OnNewLanded(LandedEventArgs e)
        {
            Landed?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the flight height changed event.
        /// </summary>
        /// <param name="e">Event args</param>
        protected void OnNewFlightHeightChanged(FlightHeightEventArgs e)
        {
            FlightHeightChange?.Invoke(this, e);
        }
        #endregion
    }
}
