// Sixten Peterson (AQ9300) 2026-02-24
using DA205E_Assignment2.Animals.Reptile.Species;
using DA205E_Assignment2.Utils;

namespace DA205E_Assignment2.Animals.Reptile
{
    /// <summary>
    /// The form used for creating a specified reptile species. The form inherits the AnimalForm which contains an Animal property
    /// that it has in common with the rest of the animal form derived class.
    /// 
    /// If a reptile object is passed into the form the form is pre-filled (handy when editing an animal inside the application).
    /// </summary>
    public partial class ReptileForm : AnimalForm
    {
        #region Fields
        private ReptileSpecies species = 0; // Storing the species index
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor initializes the GUI. Depending on the provided ReptileSpecies the GUI is initialized differently.
        /// If a reptile object is passed in the form will get pre-filled for easier editing.
        /// </summary>
        /// <param name="species">The species of reptile used for creating/editing the animal.</param>
        /// <param name="reptile">An optional reptile object used for prefilling. Can be null if no pre-filling is required.</param>
        public ReptileForm(int species, Reptile? reptile)
        {
            InitializeComponent();
            this.species = (ReptileSpecies)species; // Setting the species based on the provided sepcies int that represents an Enum value
            InitializeGUI(reptile);
        }
        #endregion

        #region GUI initialization
        /// <summary>
        /// Initializes the GUI by making sure that the relevant controls are shown to the user. Also sets the form icon.
        /// </summary>
        private void InitializeGUI(Reptile? reptile)
        {
            ShowReptileSpecies(reptile);
            if (reptile != null) // Pre-filling form if a reptile object was provided
            {
                chkCanRegrowTail.Checked = reptile.CanRegrowTail;
                chkLivesInWater.Checked = reptile.LivesInWater;
            }
            Icon = Properties.Resources.EAMS; // Setting the icon for the form
        }

        /// <summary>
        /// Makes the GUI reflect the specified species. The group box text is updated to showcase the species and any fields/properties specific to the different species get set correctly.
        /// </summary>
        /// <param name="reptile">An optional Bird object used for pre-filling, can be null.</param>
        private void ShowReptileSpecies(Reptile? reptile)
        {
            grpSpecificToAnimal.Text = $"Specific data to {species.ToString()}"; // Setting the group box text to reflect the animal species

            switch (species)
            {
                case ReptileSpecies.Snake:
                    chkVenomous.Visible = true; // Setting the check box visible
                    chkVenomous.Top = lblSpecificToAnimal1.Top; // Moving the check box up
                    if (reptile is Snake snake) // Pre-filling if the bird object is of type Snake
                        chkVenomous.Checked = snake.Venomous;
                    break;
                case ReptileSpecies.Turtle:
                    txtSpecificToAnimal1.Visible = true;
                    lblSpecificToAnimal1.Visible = true;

                    lblSpecificToAnimal1.Text = "Shell width";

                    if (reptile is Turtle turtle) // Pre-filling if the bird object is of type Turtle
                        txtSpecificToAnimal1.Text = turtle.ShellWidth.ToString();
                    break;
            }
        }
        #endregion

        #region Object creation
        /// <summary>
        /// Creates the specified species using the ReptileFactory and sets any species specific properties along with some validation where it is needed.
        /// </summary>
        private void CreateReptileSpecies()
        {
            bool livesInWater = chkLivesInWater.Checked;
            bool canRegrowTail = chkCanRegrowTail.Checked;

            // Since these definitvley are either true or false per nature no validation is needed for these. If the values above would have originated from a texbox for instance, validation would be required.
            Animal = ReptileFactory.CreateReptile(species, livesInWater, canRegrowTail);

            switch (species)
            {
                case ReptileSpecies.Snake:
                    ((Snake)Animal).Venomous = chkVenomous.Checked;
                    break;
                case ReptileSpecies.Turtle:
                    (double shellWidth, bool isValidShellWidth) = NumericUtility.GetDouble(txtSpecificToAnimal1.Text);
                    
                    if (shellWidth > 0) // Validating shell width
                    {
                        ((Turtle)Animal).ShellWidth = shellWidth; // Valid width
                    } 
                    else
                    { // Invalid width
                        ValidationUtility.WarnUser("Seems like you inputted an invalid shell width. Please enter any positive number bigger than 0 (for example 20,4).");
                        DialogResult = DialogResult.None; // Stopping the dialog from giving an OK DialogResult, which in turn keeps the dialog open
                    }

                    break;
            }
        }
        #endregion

        #region Win forms designer provided. All of these just calls custom made methods.
        /// <summary>
        /// Calls the CreateReptileSpecies method whenever the OK button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            CreateReptileSpecies();
        }
        #endregion
    }
}
