// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment1.Animals;
using DA205E_Assignment1.Animals.Bird;
using DA205E_Assignment1.Animals.Bird.Species;
using DA205E_Assignment1.Animals.Insect;
using DA205E_Assignment1.Animals.Insect.Species;
using DA205E_Assignment1.Animals.Reptile;
using DA205E_Assignment1.Animals.Reptile.Species;
using DA205E_Assignment1.Utils;

namespace DA205E_Assignment1
{
    /// <summary>
    /// The main form of the application. From here the user is able to choose an animal category and species, create an animal and adding it which for now only stores the latest added animal.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        private Animal animal = new Animal(); // Since the application is supposed to only support one animal I'm keeping the animal object here, it will be overwritten when a new animal is created.
        private int speciesIndex = -1; // The int representing the animal speices in its species enum. This was introduced to support the "list all animal species" feature for grade B in assignment 1. Only use this value if the GUI is in the list all species mode (can be determined by checking if the chkListAllSpecies is checked.
        #endregion

        #region Constructor
        /// <summary>
        /// The form constructor. When the form is created the GUI is initialized through the InitializeGUI()-method.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI(); // Initializing the GUI, populating relevant list, and combo boxes.
        }
        #endregion

        #region UI initilization
        /// <summary>
        /// Initializes the GUI, specifically populating and pre-selecting categories as well as genders.
        /// </summary>
        private void InitializeGUI()
        {
            ComponentPopulationUtility.populate(lstCategory, Enum.GetNames(typeof(Category)), (int)Category.Bird); // Populating the lstCategory list box and preselecting the Bird category
            ComponentPopulationUtility.populate(cmbGender, Enum.GetNames(typeof(GenderType)), (int)GenderType.Unknown); // Populating the cmbGender combo box and preselecting the Unknown gender
            Icon = Properties.Resources.EAMS;
        }
        #endregion

        #region UI population logic (adding items to combo boxes, listboxes..)
        /// <summary>
        /// Populates the lstSpecies list box based on the provided animal category in the parameter. You may fill the list box with all animal species if you pass null as the category.
        /// </summary>
        /// <param name="category">The animal CategoryType to fill the list with</param>
        private void populateSpecies(Category? category, bool clearList = false)
        {
            if (clearList) // Only clearing the list if "asked" to in the parameter
            {
                lstSpecies.Items.Clear(); // Removing all old items from the list as they may have become inaccurate after selection
            }

            switch (category)
            {
                case Category.Bird:
                    string[] birdSpecies = Enum.GetNames(typeof(BirdSpecies)); // Getting all enum names and storing them in an array of strings
                    lstSpecies.Items.AddRange(birdSpecies); // Adding the species to the lstSpecies component
                    lstSpecies.SelectedIndex = (int)BirdSpecies.Dove; // Setting a default selection, may be changed by the user later
                    break;
                case Category.Insect:
                    string[] insectSpecies = Enum.GetNames(typeof(InsectSpecies)); // Getting all enum names and storing them in an array of strings
                    lstSpecies.Items.AddRange(insectSpecies); // Adding the species to the lstSpecies component
                    lstSpecies.SelectedIndex = (int)InsectSpecies.Beetle; // Setting a default selection, may be changed by the user later
                    break;
                case Category.Reptile:
                    string[] reptileSpecies = Enum.GetNames(typeof(ReptileSpecies)); // Getting all enum names and storing them in an array of strings
                    lstSpecies.Items.AddRange(reptileSpecies); // Adding the species to the lstSpecies component
                    lstSpecies.SelectedIndex = (int)ReptileSpecies.Snake; // Setting a default selection, may be changed by the user later
                    break;
                default:
                    lstSpecies.Items.Clear(); // Always clearing before populating with all species. See this as a sftey meeasure against my own stupidity in case I forget to pass true for the clearList parameter.
                    populateSpecies(Category.Bird);
                    populateSpecies(Category.Insect);
                    populateSpecies(Category.Reptile);// Defaulting to a clear list just in case something weird happens, I have written bad code before...
                    break;
            }
        }

        /// <summary>
        /// Re-populates the categories with the appropriate species. Currently this method is ran whenever the selected category index is changed.
        /// </summary>
        private void RePopulateCategories()
        {
            if (!chkListAllSpecies.Checked && lstCategory.SelectedIndex >= 0) // Only populating the species list if all animal species isn't selected as the list box should still display all animal species until it is uncheked. The list box will be updated accordingly as soon as the check box is unchecked.
            {
                populateSpecies((Category)lstCategory.SelectedIndex, true); // Populating the species list box with the appropriate species
            }
        }
        #endregion

        #region Data reading
        /// <summary>
        /// Reads general data about the animal form the user interface and sets the relevant properties of the animal objects. Validation is also present to avoid invalid data. 
        /// </summary>
        /// <returns>true if the read data was valid, false if the data was invalid.</returns>
        private bool ReadGeneralData()
        {
            string name = txtName.Text;
            (double age, bool isValidAge) = NumericUtility.GetDouble(txtAge.Text);
            (double weight, bool isValidWeight) = NumericUtility.GetDouble(txtWeight.Text);
            GenderType gender = GenderType.Unknown;

            if (cmbGender.SelectedIndex >= 0)
                gender = (GenderType)cmbGender.SelectedIndex;

            if (ValidationUtility.ValidateGeneral(name, age, weight) && isValidAge && isValidWeight) // Validating the input and setting it for the animal object if it is valid
            {
                animal.Name = name;
                animal.Age = age;
                animal.Weight = weight;
                animal.Gender = gender;

                return true; // data was valid and has been set for the animal object
            } 

            ValidationUtility.WarnUser("It seems like some of your input was invalid. Make sure you have inputted a name, age (0.0 or older) and weight (0.0 or heavier).");
            return false; // data was invalid and nothing has been saved to the animal object
        }
        #endregion

        #region Component event handlers
        /// <summary>
        /// Creates the appropriate animal object through the use of the relevant AnimalForm (BirdForm, InsectForm or ReptileForm) based on the selected species.
        /// </summary>
        private void CreateAnimal()
        {
            int relevantSpeciesIndex = -1; // Setting -1 indicating that no relevant species has been selected

            if (chkListAllSpecies.Checked) // Setting the relevant species index based on if the user is in list all species mode or not
            {
                relevantSpeciesIndex = speciesIndex; // Setting the species index based on what has been stored during species selection in all species mode
            } else
            {
                if (lstSpecies.SelectedIndex >= 0)
                    relevantSpeciesIndex = lstSpecies.SelectedIndex; // Setting the species based on the selected index as it matches up with the relevant enum when all species are not listed.
            }

            if (relevantSpeciesIndex != -1) // Only execute the code within this if statement if a valid species index has been provided.
            {
                AnimalForm form = null;

                if (lstSpecies.SelectedIndex >= 0) {
                    switch ((Category)lstCategory.SelectedIndex) // Determining which kind of form to create
                    {
                        case Category.Bird:
                            form = new BirdForm(relevantSpeciesIndex);
                            break;
                        case Category.Insect:
                            form = new InsectForm(relevantSpeciesIndex);
                            break;
                        case Category.Reptile:
                            form = new ReptileForm(relevantSpeciesIndex);
                            break;
                        default: // NO matching form could be found
                            ValidationUtility.WarnUser("Animal category not properly implemented. Please let the developer know how to reproduce this. Developer hint: CreateAnimal()-method."); // Just a notice if I manage to forget to add the code for an animal category or in other ways break the application.
                            break;
                    }
                }

                if (form != null) // If a form was created we show it as a dialog with this form as the owner. If the Dialog closes with OK DialogResult we add the animal.
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Animal formAnimal = form.Animal; // I'd rather write this in a variable once than writing this casting each time I want to access the animal property from the form

                        if (formAnimal != null)
                        {
                            animal = formAnimal;
                            // Can be used for debugging: MessageBox.Show(this.animal.ToString());
                            formAnimal = null; // Clearing the animal object inside the form
                        }
                    }
                }

            } else
            {
                ValidationUtility.WarnUser("Invlaid species index, please provide the developer with steps to repoduce."); // As long as the rest of the code is sound this won't ever execute. Though I guess coding has given me some trust issues so see this as a way for me to make the testing stage of the application easier in order to catch any bugs that may or may not occur. 
            }
        }

        /// <summary>
        /// Adds the animal (more like reads the general data and sets it for the animal object if valid along with setting the text for the rtxtAnimalData component).
        /// </summary>
        private void AddAnimal()
        {
            if (ReadGeneralData()) { // Only setting the rtxtAnimalData text if the general data was valid
                rtxtAnimalData.Text = animal.ToString();
                picImage.Image = animal.Image; // The picture box should not show any old animal images, this way we make sure the correct image is shown for the animal
            }
        }

        /// <summary>
        /// Opens the AboutBox form with this form as the owner.
        /// </summary>
        private void OpenAboutBox()
        {
            AboutBox aboutBox = new AboutBox(); // New instance of AboutBox
            aboutBox.ShowDialog(this); // Showing the AboutBox as a dialog, passing this window (MainForm) as the owner
        }

        /// <summary>
        /// Toggles between listing all species and only showing the species of the selected category based on if the chkListAllSpecies control is checked or not.
        /// </summary>
        private void ToggleAllSpecies()
        {
            if (chkListAllSpecies.Checked)
            {
                lstCategory.Enabled = false; // Disabling the list category
                populateSpecies(null, true); // Populating the list box with all species
            }
            else
            {
                lstCategory.Enabled = true;
                if (lstCategory.SelectedIndex >= 0)
                    populateSpecies((Category)lstCategory.SelectedIndex, true); // Populate species based on selected category
            }
        }

        /// <summary>
        /// This method is used to keep track of which species is selected if the chkListAllSpecies control is checked in order to make it work with the GUI.
        /// </summary>
        private void SpeciesSelectionChanged()
        {
            if (chkListAllSpecies.Checked) // Irrelevant unless the checkbox for listing all species is checked
            {
                string selectedSpecies = "";

                // Updating the category selction in the listbox control based on the selected species
                if (lstSpecies.SelectedItem != null)
                {
                    selectedSpecies = lstSpecies.SelectedItem.ToString();

                    // Determining the category based on the selected species. TODO: Improve code
                    switch (selectedSpecies)
                    {
                        case nameof(BirdSpecies.Dove):
                            lstCategory.SelectedIndex = (int)Category.Bird;
                            speciesIndex = (int)BirdSpecies.Dove;
                            break;
                        case nameof(BirdSpecies.Raven):
                            lstCategory.SelectedIndex = (int)Category.Bird; // Setting the corresponding category index
                            speciesIndex = (int)BirdSpecies.Raven;
                            break;
                        case nameof(InsectSpecies.Beetle):
                            lstCategory.SelectedIndex = (int)Category.Insect;
                            speciesIndex = (int)InsectSpecies.Beetle;
                            break;
                        case nameof(InsectSpecies.Butterfly):
                            lstCategory.SelectedIndex = (int)Category.Insect; // Setting the corresponding category index
                            speciesIndex = (int)InsectSpecies.Butterfly;
                            break;
                        case nameof(ReptileSpecies.Snake):
                            lstCategory.SelectedIndex = (int)Category.Reptile;
                            speciesIndex = (int)ReptileSpecies.Snake;
                            break;
                        case nameof(ReptileSpecies.Turtle):
                            lstCategory.SelectedIndex = (int)Category.Reptile; // Setting the corresponding category index
                            speciesIndex = (int)ReptileSpecies.Turtle;
                            break;
                        default:
                            lstCategory.SelectedIndex = (int)Category.Bird; // Just defaulting to something
                            speciesIndex = -1; // No valid sepcies index could be interpreted
                            MessageBox.Show("Whoops! Seems like this species is missing in the lstSpecies_SelectedIndexChanged() MainForm GUI method. Defaulted to Bird, please report this to the developer of the application.", "Whoops!");
                            break;
                    }
                }
            }
            else
            {
                speciesIndex = -1; // Species index is irrelevant. Shouldn't really matter to update this but hey at least I can programmatically check the state if I ever wish to in the future.
            }
        }

        /// <summary>
        /// Loads/sets an image for the animal object.
        /// </summary>
        private void LoadImage()
        {
            animal.LoadImage();
            if (animal.Image != null)
                picImage.Image = animal.Image;
        }
        #endregion

        #region menu strip items
        /// <summary>
        /// Opens the AboutBox viathe OpenAboutBox()-method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAboutBox();
        }

        /// <summary>
        /// Loads the image via the LoadImage()-method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        #endregion

        #region Win forms designer provided. All of these just calls custom made methods.
        /// <summary>
        /// Calls the CreateAnimal method when the create animal button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAnimal_Click(object sender, EventArgs e)
        {
            CreateAnimal();
        }

        /// <summary>
        /// Calls the LoadImage method whenever the Load Image button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        /// <summary>
        /// Calls the RePopulateCategories()-method whenever the selected index of list category is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RePopulateCategories();
        }

        /// <summary>
        /// Calls ToggleAllSpecies method whenever the list all species checkbox control is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkListAllSpecies_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAllSpecies();
        }

        /// <summary>
        /// Calls the SpeciesSelectionChanged method whenever the selected index of the species list box is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpeciesSelectionChanged();
        }

        /// <summary>
        /// Calls the AddAnimal method whenever the add button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAnimal();
        }
        #endregion
    }
}
