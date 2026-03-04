// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment3.Animals.Insect.Species;
using DA205E_Assignment3.Animals.Insect.Species.Beetle;
using DA205E_Assignment3.Animals.Insect.Species.Butterfly;
using DA205E_Assignment3.Utils;

namespace DA205E_Assignment3.Animals.Insect
{
    /// <summary>
    /// The form used for creating a specified insect species. The form inherits the AnimalForm which contains an Animal property
    /// that it has in common with the rest of the animal form derived class.
    /// 
    /// If an insect object is passed into the form the form is pre-filled (handy when editing an animal inside the application).
    /// </summary>
    public partial class InsectForm : AnimalForm
    {
        #region Fields
        private InsectSpecies species = 0; // Storing the species index
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor initializes the GUI. Depending on the provided InsectSpecies the GUI is initialized differently.
        /// If an insect object is passed in the form will get pre-filled for easier editing.
        /// </summary>
        /// <param name="species">The species of insect used for creating/editing the animal.</param>
        /// <param name="insect">An optional insect object used for prefilling. Can be null if no pre-filling is required.</param>
        public InsectForm(int species, Insect? insect)
        {
            InitializeComponent();
            this.species = (InsectSpecies)species; // Setting the species based on the provided sepcies int that represents an Enum value
            InitializeGUI(insect); // Initializing the GUI, see the method below
        }
        #endregion

        #region GUI initialization
        /// <summary>
        /// Initializes the GUI by:
        /// A) making sure that the relevant controls are shown to the user 
        /// B) Populating the cmbBeakType control 
        /// C) Pre-filling the relevant form controls if the insect parameter is not null.
        /// </summary>
        /// <param name="insect">An optional Insect object used for pre-filling, can be null.</param>
        private void InitializeGUI(Insect? insect)
        {
            ShowInsectSpecies(insect);
            ComponentPopulationUtility.populate(cmbLifecycleStage, Enum.GetNames(typeof(LifecycleStage)), (int)LifecycleStage.Egg); // Populating the combo box and preselecting the Egg lifecycle stage
            if (insect != null) // Pre-filling form if an insect object was provided
            {
                chkHasWings.Checked = insect.HasWings;
                cmbLifecycleStage.SelectedIndex = (int)insect.LifecycleStage;
            }
            Icon = Properties.Resources.EAMS; // Setting the icon for the form
        }

        /// <summary>
        /// Makes the GUI reflect the specified species. The group box text is updated to showcase the species and any fields/properties specific to the different species get set correctly.
        /// </summary>
        /// <param name="insect">An optional Insect object used for pre-filling, can be null.</param>
        private void ShowInsectSpecies(Insect? insect)
        {
            grpSpecificToAnimal.Text = $"Specific data to {species.ToString()}"; // Setting the group box text to reflect the animal species

            switch (species)
            {
                case InsectSpecies.Beetle:
                    lblSpecificToAnimal1.Text = "Body type";
                    ComponentPopulationUtility.populate(cmbSpecificToAnimal1, Enum.GetNames(typeof(BodyType)), (int)BodyType.Flat); // Populating the combo box and preselecting the flat body type
                    if (insect is Beetle beetle) // Pre-filling if the insect object is of beetle dove
                        cmbSpecificToAnimal1.SelectedIndex = (int) beetle.BodyType;
                    break;
                case InsectSpecies.Butterfly:
                    lblSpecificToAnimal1.Text = "Wing pattern";
                    ComponentPopulationUtility.populate(cmbSpecificToAnimal1, Enum.GetNames(typeof(WingPattern)), (int)WingPattern.Spotted); // Populating the combo box and preselecting the spotted wing pattern
                    if (insect is Butterfly butterfly) // Pre-filling if the insect object is of type butterfly
                        cmbSpecificToAnimal1.SelectedIndex = (int)butterfly.WingPattern;
                    break;
            }
        }
        #endregion

        #region Object creation
        /// <summary>
        /// Creates the specified species using the InsectFactory and sets any species specific properties.
        /// </summary>
        private void CreateInsectSpecies()
        {
            bool hasWings = chkHasWings.Checked;
            LifecycleStage lifecycleStage = LifecycleStage.Egg;

            if (cmbLifecycleStage.SelectedIndex >= 0)
                lifecycleStage = (LifecycleStage)cmbLifecycleStage.SelectedIndex;

            Animal = InsectFactory.CreateInsect(species, hasWings, lifecycleStage);

            switch (species)
            {
                case InsectSpecies.Beetle:
                    if (cmbSpecificToAnimal1.SelectedIndex >= 0)
                        ((Beetle)Animal).BodyType = (BodyType)cmbSpecificToAnimal1.SelectedIndex;

                    break;
                case InsectSpecies.Butterfly:
                    if (cmbSpecificToAnimal1.SelectedIndex >= 0)
                        ((Butterfly)Animal).WingPattern = (WingPattern)cmbSpecificToAnimal1.SelectedIndex;
                    break;
            }
        }
        #endregion

        #region Win forms designer provided. All of these just calls custom made methods.
        /// <summary>
        /// Calls the CreateInsectSpecies method whenever the OK button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            CreateInsectSpecies();
        }
        #endregion
    }
}
