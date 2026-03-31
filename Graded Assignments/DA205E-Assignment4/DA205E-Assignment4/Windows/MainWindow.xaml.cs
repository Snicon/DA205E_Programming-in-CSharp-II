// Sixten Peterson (AQ9300) 2026-03-31
using DA205E_Assignment4.Data;
using DA205E_Assignment4.Event.Args.Specialized;
using DA205E_Assignment4.EventArgsClasses;
using DA205E_Assignment4.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DA205E_Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields
        private ControlTower controlTower; // Instance of control tower which essentially stores all airplanes

        private string airplaneName;
        private string id;
        private string destination;
        private string flightTime;

        private string newDestination; // Specifically refers to the "New destination" text box inside the Change airplane data groupbox. These are not to be mixed up as they have different purposes.
        private string newFlightHeight;

        private ObservableCollection<string> flightLog; // Used to keep all the flight log messages
        #endregion

        public event PropertyChangedEventHandler PropertyChanged; // Eventhandler used for property changes/bindings

        #region Constructor
        /// <summary>
        /// Somewhat simple constructor, initializes the fields and subscribes to the control tower events.
        /// </summary>
        public MainWindow()
        {
            DataContext = this;

            airplaneName = string.Empty;
            id = string.Empty;
            destination = string.Empty;
            flightTime = string.Empty;

            flightLog = new ObservableCollection<string>();

            controlTower = new ControlTower(); // Creating new instance of the ControlTower class
            Subscribe();

            InitializeComponent();
        }
        #endregion

        #region Properties
        public string AirplaneName
        {
            get { return airplaneName; }
            set 
            {
                airplaneName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AirplaneName"));
            }
        }

        public string ID {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));
            }
        }

        public string Destination
        {
            get { return destination; }
            set
            {
                destination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Destination"));
            }
        }

        public string FlightTime
        {
            get { return flightTime; }
            set
            {
                flightTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FlightTime"));
            }
        }

        public string NewDestination
        {
            get { return newDestination; }
            set
            {
                newDestination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewDestination"));
            }
        }

        public string NewFlightHeight
        {
            get { return newFlightHeight; }
            set
            {
                newFlightHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewFlightHeight"));
            }
        }

        public ObservableCollection<string> FlightLog
        {
            get { return flightLog; }
            set { flightLog = value; }
        }
        #endregion

        #region GUI Initilization
        /// <summary>
        /// Subscribes to the control tower events in order to let the GUI update accordingly.
        /// </summary>
        private void Subscribe()
        {
            controlTower.Takeoff += UpdateAirplaneStatus;
            controlTower.Landed += UpdateAirplaneStatus;
            controlTower.FlightHeightChange += UpdateAirplaneFlightHeight;
        }
        #endregion



        #region Data reading
        /// <summary>
        /// Reads the text box controls related to the airplane creation.
        /// </summary>
        /// <returns>An airplane instance (if successfully created) or null if the airplane instance creation failed due to invalid input.</returns>
        private Airplane? ReadAirplaneData()
        {
            (double time, bool validTime) = NumericUtility.GetDouble(FlightTime);

            if (!(AirplaneName.Length > 0) || !(ID.Length > 0) || !(Destination.Length > 0) || !validTime) 
                return null;

            return new Airplane(AirplaneName, ID, Destination, time);
        }

        /// <summary>
        /// Reads the new height control and returns height as string and a bool representing if the height was successfully parsed as a valid height (above -1)
        /// </summary>
        /// <returns>Typle consisting of a string and bool. See text above.</returns>
        private (string, bool) ReadHeight()
        {
            string height = NewFlightHeight;

            if (int.TryParse(height, out int heightInt))
            {
                bool valid = false;

                if (heightInt > -1)
                    valid = true;

                return (height, valid);
            } 
            else
            {
                return (height, false);
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Adds an airplane to the control tower list.
        /// </summary>
        private void AddAirplane()
        {
            Airplane airplane = ReadAirplaneData(); // Tries to create an airplane through the ReadAirplaneData()-method

            if (airplane == null) { // Informs the user that the application failed to create an airplane from the provided data in the control boxes
                MessageBox.Show("Failed to create an airplane based on the provided data, are you sure all fields was filled with valid data? (At least one character per field and any positive number for the flight time.)");
                return; // Early return
            }

            bool added = controlTower.Add(airplane); // Attempting to add an airplane to the controlTower list

            if (added) // Successfully added
            {
                FlightLog.Add(airplane.ToString() + " sent to runway!"); // Adds little log message to the flight log much like whats shown in the screen shot in the assignment document
                ClearPlaneCreationForm(); // Clears the form
            } 
            else
            {
                MessageBox.Show("Failed to add the new plane.");
            }
        }

        /// <summary>
        /// Basically enables/disables buttons based on if an airplane is selected or not. Also prefills the height and destination fields based onthe selected airplane (if the index of it is valid)
        /// </summary>
        private void HandleAirplanesLstChange()
        {
            if (lstAirplanes.SelectedIndex == -1) // I.e. no airplane selected
            {
                ButtonsEnabled(false); // Disabling all the buttons that can't be pressed while no airplane is selected
            } 
            else
            {
                ButtonsEnabled(true); // Enabling all the buttons that can only be pressed while an airplane is selected

                if (controlTower.CheckIndex(lstAirplanes.SelectedIndex))
                {
                    newFlightHeight = controlTower.GetAt(lstAirplanes.SelectedIndex).FlightHeight.ToString();
                    NewDestination = controlTower.GetAt(lstAirplanes.SelectedIndex).Destination.ToString();
                }
            }
        }

        /// <summary>
        /// Event handler for when the takeoff button is pressed. Ultimetley causes the control tower to order a take off of the specified airplane (if there is one selected).
        /// </summary>
        private void Takeoff()
        {
            if (lstAirplanes.SelectedIndex == -1) // No plane selected
            {
                MessageBox.Show("To takeoff a plane a plane must be selected.");
                return;
            }

            controlTower.OrderTakeoff(lstAirplanes.SelectedIndex); // Orders the take off
        }

        /// <summary>
        /// Removes the selected airplane from the list if there is a valid airplane selected that is not currently in the air.
        /// </summary>
        private void RemovePlane()
        {
            if (lstAirplanes.SelectedIndex == -1) // No airplane selected
            {
                MessageBox.Show("To remove a plane a plane must be selected.");
                return;
            }

            if (!controlTower.CheckIndex(lstAirplanes.SelectedIndex)) // Invalid index
            {
                MessageBox.Show("Invalid airplane index.");
            }

            if (!controlTower.GetAt(lstAirplanes.SelectedIndex).InFlight) // The airplane is not in flight -> removes it.
            {
                controlTower.DeleteAt(lstAirplanes.SelectedIndex);
                RepopulateAirplanesLst();
            } 
            else
            {
                MessageBox.Show("To remove a plane it must be landed."); // The airplane is still in the air.
            }
        }

        /// <summary>
        /// Handles a press of the change height button. 
        /// </summary>
        private void ChangeHeight()
        {
            if (lstAirplanes.SelectedIndex == -1) // No airplane selected
            {
                MessageBox.Show("To change the height/altitude a plane must be selected.");
            }

            (string height, bool validHeight) = ReadHeight(); // Reading height

            if (validHeight) // Height is valid, invoking the flight height change event
            {
                controlTower.FlightHeight(lstAirplanes.SelectedIndex, height);
            } 
            else // Invalid height inputted
            {
                MessageBox.Show("Failed to read the new height, are you sure you inputted a valid number? (0 or bigger.)");
            }
        }

        /// <summary>
        /// Event handler for a press of the change destination button.
        /// </summary>
        private void ChangeDestination()
        {
            if (lstAirplanes.SelectedIndex == -1) // No airplane selected.
            {
                MessageBox.Show("To change the destination a plane must be selected.");
                return;
            }

            if (controlTower.CheckIndex(lstAirplanes.SelectedIndex)) // The index is valid
            {
                Airplane airplane = controlTower.GetAt(lstAirplanes.SelectedIndex); // Getting the airplane
                if (!airplane.InFlight) // Airplane is not in flight
                {
                    airplane.Destination = NewDestination;
                    RepopulateAirplanesLst();
                } 
                else
                {
                    MessageBox.Show("The cannot be in a flight while changing he destination.");
                }
            }
        }
        #endregion

        #region GUI population
        /// <summary>
        /// Repopulates the airplane list box by clearing it and the going over each airplane in the control tower list.
        /// </summary>
        private void RepopulateAirplanesLst()
        {
            lstAirplanes.Items.Clear();
            
            foreach(Airplane airplane in controlTower.TheList)
            {
                lstAirplanes.Items.Add(airplane.ToString());
            }
        }

        /// <summary>
        /// Clears the airplane creation form to make it easier to create a new airplane
        /// </summary>
        private void ClearPlaneCreationForm()
        {
            AirplaneName = string.Empty;
            ID = string.Empty;
            Destination = string.Empty;
            FlightTime = string.Empty;
        }
        #endregion

        #region GUI enable/disable
        /// <summary>
        /// Sets the takeoff, remove plane, change height and destination buttons to be enabled/disabled depending on the provided bool.
        /// </summary>
        /// <param name="enabled">The desired state of the buttons, enabled if true, disabled if false.</param>
        private void ButtonsEnabled(bool enabled)
        {
            btnTakeOff.IsEnabled = enabled;
            btnRemovePlane.IsEnabled = enabled;
            btnChangeHeight.IsEnabled = enabled;
            btnNewDestination.IsEnabled = enabled;
        }
        #endregion

        #region Event related
        /// <summary>
        /// Adds a new mesage to the flight log since this event handler is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAirplaneStatus(object sender, AirplaneEventArgs e)
        {
            FlightLog.Add(e.Message);
            RepopulateAirplanesLst();
        }

        /// <summary>
        /// Adds a new mesage to the flight log since this event handler is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAirplaneFlightHeight(object sender, FlightHeightEventArgs e)
        {
            FlightLog.Add(e.Message);
        }
        #endregion

        #region WPF generated methods (not commented since they are all just simple event handlers that ultimatley just calls my "better" named methods that are all commented.
        private void btnAddPlane_Click(object sender, RoutedEventArgs e)
        {
            AddAirplane();
            RepopulateAirplanesLst();
        }

        private void lstAirplanes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            HandleAirplanesLstChange();
        }
        #endregion

        private void btnTakeOff_Click(object sender, RoutedEventArgs e)
        {
            Takeoff();
        }

        private void btnRemovePlane_Click(object sender, RoutedEventArgs e)
        {
            RemovePlane();
        }

        private void btnChangeHeight_Click(object sender, RoutedEventArgs e)
        {
            ChangeHeight();
        }

        private void btnNewDestination_Click(object sender, RoutedEventArgs e)
        {
            ChangeDestination();
        }
    }
}