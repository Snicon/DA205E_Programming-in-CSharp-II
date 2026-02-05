// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment1.Animals.Bird.Species;
using DA205E_Assignment1.Animals.Bird.Species.Raven;
using DA205E_Assignment1.Utils;

namespace DA205E_Assignment1.Animals.Bird
{
    /// <summary>
    /// The form used for creating a specified bird species. The form inherits the AnimalForm which contains an Animal property that it has in common with the rest of the animal form derived class
    /// </summary>
    public partial class BirdForm : AnimalForm
    {
        #region Fields
        private BirdSpecies species = 0; // Storing the species index
        #endregion

        #region Constructors
        public BirdForm(int species)
        {
            InitializeComponent();
            this.species = (BirdSpecies)species; // Setting the species based on the provided sepcies int that represents an Enum value
            InitializeGUI(); // Initializing the GUI, see the method below
        }
        #endregion

        #region GUI initialization
        /// <summary>
        /// Initializes the GUI by A) making sure that the relevant controls are shown to the user and B) Populating the cmbBeakType control
        /// </summary>
        private void InitializeGUI()
        {
            ShowBirdSpecies();
            ComponentPopulationUtility.populate(cmbBeakType, Enum.GetNames(typeof(BeakType)), (int)BeakType.Hooked);// Populating the combo box and preselecting the Hooked beak type 
            Icon = Properties.Resources.EAMS;
        }

        /// <summary>
        /// Makes the GUI reflect the specified species. The group box text is updated to showcase the species and any fields/properties specific to the different species get set correctly.
        /// </summary>
        private void ShowBirdSpecies()
        {
            grpSpecificToAnimal.Text = $"Specific data to {species.ToString()}"; // Setting the group box text to reflect the animal species

            switch (species)
            {
                case BirdSpecies.Dove:
                    lblSpecificToAnimal1.Text = "Milk production";
                    break;
                case BirdSpecies.Raven:
                    lblSpecificToAnimal1.Text = "Beak width";
                    break;
            }
        }
        #endregion


        #region Object creation
        /// <summary>
        /// Creates the specified species using the BirdFactory and sets any species specific properties along with some validation where it is needed.
        /// </summary>
        private void CreateBirdSpecies()
        {
            (double wingspan, bool isValidWingspan) = NumericUtility.GetDouble(txtWingspan.Text);
            BeakType beakType = BeakType.Hooked;

            if (cmbBeakType.SelectedIndex >= 0) // Validating as per the requirement of the code quality guidelines document
                beakType = (BeakType)cmbBeakType.SelectedIndex;

            if (!isValidWingspan || wingspan < 0)
            {
                ValidationUtility.WarnUser("Seems like you inputted an invalid wingspan. Make sure it is 0 or bigger.");
                DialogResult = DialogResult.None;
                return; // No point in running the rest of the code since we don't want to create a bird object with an invalid wingspan.
            }

            (double specificToAnimal1, bool isValidSpecificToAnimal1) = NumericUtility.GetDouble(txtSpecificToAnimal1.Text);

            if (species == BirdSpecies.Dove)
            {
                if (!isValidSpecificToAnimal1 || specificToAnimal1 < 0)
                {
                    ValidationUtility.WarnUser("Seems like your input for milk production was invalid. Make sure it is 0 or bigger.");
                    DialogResult = DialogResult.None;
                    return; // No point in running the rest.
                }
            }
            else if (species == BirdSpecies.Raven)
            {
                if (!isValidSpecificToAnimal1 || specificToAnimal1 <= 0)
                {
                    ValidationUtility.WarnUser("Seems like your input for beak width was invalid. Make sure it is bigger than 0.");
                    DialogResult = DialogResult.None;
                    return; // No point in running the rest.
                }
            }

            Animal = BirdFactory.CreateBird(species, wingspan, beakType);

            // Setting the rest of the properties that are specific to the species
            switch (species)
            {
                case BirdSpecies.Dove:
                    ((Dove)Animal).MilkProduction = specificToAnimal1;
                    break;
                case BirdSpecies.Raven:
                    ((Raven)Animal).BeakSize = specificToAnimal1;
                    break;
            }
        }
        #endregion

        #region Win forms designer provided. All of these just calls custom made methods.
        /// <summary>
        /// Calls the CreateBirdSpecies method whenever the OK button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            CreateBirdSpecies();
        }
        #endregion
    }
}
