// Sixten Peterson (AQ9300) 2026-05-05
using DA205E_Assignment6.Models;
using DA205E_Assignment6.Models.Enums;
using DA205E_Assignment6.Utils;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DA205E_Assignment6.UI.Windows
{
    /// <summary>
    /// Interaction logic for LiteratureWindow.xaml
    /// </summary>
    public partial class LiteratureWindow : Window, INotifyPropertyChanged
    {
        #region Constants
        private const string editLiterature = "Edit literature";
        #endregion

        #region Fields
        // General
        private string literatureTitle;
        private string author;
        private int yearPublished;
        private LiteratureFormat format;
        private LiteratureStatus status;

        private List<Course> allCourses;

        // Book
        private string isbn;
        private int edition;
        private string publisher;
        private string city;

        // Journal Article
        private string journalName;
        private int volume;
        private int issue;
        private string pages;
        private string url;

        // Literature object, used to pass to MainWindow
        private Literature literature;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public LiteratureWindow(List<Course> allCourses)
        {
            DataContext = this;
            InitFields(allCourses); // Initializing fields

            InitializeComponent();

            // Combobox population
            PopulateComboBoxes();
        }

        public LiteratureWindow(List<Course> allCourses, Literature literature) : this(allCourses)
        {
            this.literature = literature;

            // Pre-filling general data
            PreFillGeneralLiteratureData();

            // Combobox population (These must be after InitializeComponent)
            PopulateComboBoxes();

            // Pre-filling specialized literature data
            PreFillSpecializedData();
            
            SetGUIToEditMode();
        }
        #endregion

        #region Properties (General literature)
        public string LiteratureTitle
        {
            get { return literatureTitle; }
            set 
            {
                literatureTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LiteratureTitle"));
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Author"));
            }
        }

        public int YearPublished
        {
            get { return yearPublished; }
            set
            {
                yearPublished = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("YearPublished"));
            }
        }

        public LiteratureFormat Format
        {
            get { return format; }
            set
            {
                format = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Format"));
            }
        }

        public LiteratureStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }

        public List<Course> AllCourses
        {
            get { return allCourses; }
        }
        #endregion

        #region Properties (Book literature)
        public string ISBN
        {
            get { return isbn; }
            set
            {
                isbn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ISBN"));
            }
        }

        public int Edition
        {
            get { return edition; }
            set
            {
                edition = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Edition"));
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Publisher"));
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
            }
        }
        #endregion

        #region Properties (JournalArticle literature)
        public string JournalName
        {
            get { return journalName; }
            set
            {
                journalName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JournalName"));
            }
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Volume"));
            }
        }

        public int Issue
        {
            get { return issue; }
            set
            {
                issue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Issue"));
            }
        }

        public string Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pages"));
            }
        }

        public string URL
        {
            get { return url; }
            set
            {
                url = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("URL"));
            }
        }
        #endregion

        #region Properties (others)
        public Literature Literature
        {
            get { return literature; }
        }

        public List<Course> SelectedCourses
        {
            get { return lstCourses.SelectedItems.Cast<Course>().ToList(); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes fields via properties wherever possible
        /// </summary>
        /// <param name="allCourses"></param>
        private void InitFields(List<Course> allCourses)
        {
            // General
            Title = string.Empty;
            Author = string.Empty;
            YearPublished = 0;
            Format = LiteratureFormat.Physical; // Setting default for convenience
            Status = LiteratureStatus.Owned; // Setting default for convenience
            this.allCourses = allCourses;

            // Book
            ISBN = string.Empty;
            Edition = 1; // Setting default for convenience
            Publisher = string.Empty;
            City = string.Empty;

            // JournalArticle
            JournalName = string.Empty;
            Volume = 0;
            Issue = 0;
            Pages = string.Empty;
            URL = string.Empty;
        }

        /// <summary>
        /// Generic method for populating any combobox with enum values (as well as pre-selecting a value based on index)
        /// </summary>
        /// <param name="comboBox">The combobox to populate with enum values</param>
        /// <param name="enumType">The type of enum for the values</param>
        /// <param name="selectedIndex">The pre-selected index</param>
        /// <exception cref="ArgumentException">Occurs if enumType is not of type Enum.</exception>
        private void PopulateComboBox(ComboBox comboBox, Type enumType, int selectedIndex)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Provided type must be an enum.");
            }

            comboBox.ItemsSource = Enum.GetValues(enumType);
            comboBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Attempts to create a book instance, book is only created if validation is passed.
        /// </summary>
        private void CreateBook()
        {
            bool validInput = ValidationUtil.ValidateBook(ISBN, Edition, Publisher, City);

            if (validInput)
            {
                literature = new Book(LiteratureTitle.Trim(), Author.Trim(), YearPublished, Format, Status, SelectedCourses, ISBN.Trim(), Edition, Publisher.Trim(), City.Trim());
                DialogResult = true;
            }
        }

        /// <summary>
        /// Attempts to edit the literature if validation passes and literature object is of type Book.
        /// </summary>
        private void EditBook()
        {
            bool validInput = ValidationUtil.ValidateBook(ISBN, Edition, Publisher, City);

            if (validInput && literature is Book book)
            {
                book.Title = LiteratureTitle.Trim();
                book.Author = Author.Trim();
                book.YearPublished = YearPublished;
                book.Format = Format;
                book.Status = Status;
                book.Courses = SelectedCourses;
                book.ISBN = ISBN.Trim();
                book.Edition = Edition;
                book.Publisher = Publisher.Trim();
                book.City = City.Trim();

                DialogResult = true;
            }
        }

        /// <summary>
        /// Attempts to create a journal article instance, journal article is only created if validation is passed.
        /// </summary>
        private void CreateJournalArticle()
        {
            bool validInput = ValidationUtil.ValidateJournalArticle(JournalName, Volume, Issue, Pages); // lenient on urls, these may be empty.

            if (validInput)
            {
                literature = new JournalArticle(LiteratureTitle.Trim(), Author.Trim(), YearPublished, Format, Status, SelectedCourses, JournalName, Volume, Issue, Pages, URL);
                DialogResult = true;
            }
        }

        /// <summary>
        /// Attempts to edit the literature if validation passes and literature object is of type JournalArticle.
        /// </summary>
        private void EditJournalArticle()
        {
            bool validInput = ValidationUtil.ValidateJournalArticle(JournalName, Volume, Issue, Pages); // lenient on urls, these may be empty.

            if (validInput && literature is JournalArticle journalArticle)
            {
                journalArticle.Title = LiteratureTitle.Trim();
                journalArticle.Author = Author.Trim();
                journalArticle.YearPublished = YearPublished;
                journalArticle.Format = Format;
                journalArticle.Status = Status;
                journalArticle.Courses = SelectedCourses;
                journalArticle.JournalName = JournalName.Trim();
                journalArticle.Volume = Volume;
                journalArticle.Issue = Issue;
                journalArticle.Pages = Pages.Trim();
                journalArticle.URL = URL.Trim();

                DialogResult = true;
            }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Updates the UI based on the literature type in order to make sure only the relevant parts of the GUI
        /// is shown to the user.
        /// </summary>
        private void UpdateLiteratureTypeUIMode()
        {
            switch (cmbType.SelectedIndex)
            {
                case (int)LiteratureType.Book:
                    grpBook.Visibility = Visibility.Visible;
                    grpJournalArticle.Visibility = Visibility.Collapsed;
                    break;
                case (int)LiteratureType.JournalArticle:
                    grpBook.Visibility = Visibility.Collapsed;
                    grpJournalArticle.Visibility = Visibility.Visible;
                    break;
            }
        }

        /// <summary>
        /// Pre-fills the selected courses in the GUI for the user
        /// </summary>
        private void PreFillSelectedCourses()
        {
            lstCourses.SelectedItems.Clear();

            foreach (Course course in lstCourses.Items)
            {
                if (literature.Courses.Any(c => c.Id == course.Id))
                    lstCourses.SelectedItems.Add(course);
            }
        }

        /// <summary>
        /// Pre-fills the general literature data in the GUI for the user
        /// </summary>
        private void PreFillGeneralLiteratureData()
        {
            LiteratureTitle = this.literature.Title;
            Author = this.literature.Author;
            YearPublished = this.literature.YearPublished;
            Format = this.literature.Format;
            Status = this.literature.Status;

            PreFillSelectedCourses();
        }

        /// <summary>
        /// Populates all the comboboxes with enum values.
        /// </summary>
        private void PopulateComboBoxes()
        {
            PopulateComboBox(cmbType, typeof(LiteratureType), (int)LiteratureType.Book);
            PopulateComboBox(cmbFormat, typeof(LiteratureFormat), (int)LiteratureFormat.Physical);
            PopulateComboBox(cmbStatus, typeof(LiteratureStatus), (int)LiteratureStatus.Owned);
        }

        /// <summary>
        /// Pre-fills the specialized literature data ín the GUI for the user based on the type of literature object
        /// </summary>
        private void PreFillSpecializedData()
        {
            if (literature is Book book)
            {
                ISBN = book.ISBN;
                Edition = book.Edition;
                Publisher = book.Publisher;
                City = book.City;
                cmbType.SelectedIndex = (int)LiteratureType.Book; // Making sure UI is in correct mode
            }
            else if (literature is JournalArticle journalArticle)
            {
                JournalName = journalArticle.JournalName;
                Volume = journalArticle.Volume;
                Issue = journalArticle.Issue;
                Pages = journalArticle.Pages;
                URL = journalArticle.URL;
                cmbType.SelectedIndex = (int)LiteratureType.JournalArticle; // Again, making sure UI is in correct mode
            }
        }

        /// <summary>
        /// Sets the GUI to "edit mode" (I.e. collpasing the literature type group box and changing some text to better convey the actions of the button and window)
        /// </summary>
        private void SetGUIToEditMode()
        {
            grpLiteratureType.Visibility = Visibility.Collapsed; // Users may not change the literature type after creation.
            btnSubmit.Content = editLiterature;
            Title = editLiterature;
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// As a web developer I think of this method as the onSubmit method for an html form.
        /// Essentially it either adds a new literature or edits an existing one on submission
        /// based on the mode of the ui.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool validGeneralInput = ValidationUtil.ValidateLiterature(LiteratureTitle, YearPublished);

            if (validGeneralInput)
            {
                if (Title != editLiterature) // If title is not edit literature, that means we are adding literature
                {
                    if (cmbType.SelectedIndex == (int)LiteratureType.Book)
                    {
                        CreateBook();
                    }
                    else if (cmbType.SelectedIndex == (int)LiteratureType.JournalArticle)
                    {
                        CreateJournalArticle();
                    }
                }
                else
                {
                    if (literature != null)
                    {
                        if (literature is Book)
                        {
                            EditBook();
                        }
                        else if (literature is JournalArticle)
                        {
                            EditJournalArticle();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Event handler for when the cancel button is pressed, closes the window with a dialog result of false conveying that no data is supposed to be updated/stored in the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        
        /// <summary>
        /// Event handler for when the Literature type selection is changed in the combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLiteratureTypeUIMode();
        }
        #endregion
    }
}
