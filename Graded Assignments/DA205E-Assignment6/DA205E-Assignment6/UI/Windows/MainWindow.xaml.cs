// Sixten Peterson (AQ9300) 2026-06-02
using DA205E_Assignment6.Managers;
using DA205E_Assignment6.Models;
using DA205E_Assignment6.Models.Enums;
using DA205E_Assignment6.Strategies.CitationStrategey;
using DA205E_Assignment6.UI.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace DA205E_Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields
        // Manager related
        LiteratureManager manager;

        // Course related
        private Course? selectedCourse;
        private ObservableCollection<Course> courses;

        // Literature related
        private Literature? selectedLiterature;
        private ObservableCollection<Literature> literature;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructor
        public MainWindow()
        {
            manager = new LiteratureManager(); // Creating new instance of the manager class, this will be used for most of the logic.

            this.courses = new();
            this.literature = new();

            DataContext = this;

            UpdateCourses();
            UpdateLiterature();

            InitializeComponent();
        }
        #endregion

        #region Properties
        public ObservableCollection<Course> Courses
        {
            get { return courses; }
        }

        public Course? SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCourse"));
            }
        }

        public ObservableCollection<Literature> Literature
        {
            get { return literature; }
        }

        public Literature? SelectedLiterature
        {
            get { return selectedLiterature; }
            set
            {
                selectedLiterature = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedLiterature"));
            }
        }
        #endregion

        #region Database fetching methods
        /// <summary>
        /// Fetches all courses from the database and displays them in the UI via the observable collection.
        /// </summary>
        private void UpdateCourses()
        {
            List<Course> courses = manager.GetAllCourses(); // Fetching all courses from database.

            this.courses.Clear(); // Clearing courses observable collection.

            // Adding all courses from the database to the courses observable collection.
            foreach (Course course in courses)
            {
                this.courses.Add(course);
            }
        }

        /// <summary>
        /// Fetches all literature from the database and displays them in the UI via the observable collection.
        /// </summary>
        private void UpdateLiterature()
        {
            List<Literature> allLiterature = manager.GetAllLiterature();

            this.literature.Clear(); // Clearing literature observable collection.

            // Adding all literature from the database to the literature observable collection.
            foreach (Literature literature in allLiterature)
            {
                this.literature.Add(literature);
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Event handler for when the Add course button is pressed, it opens a new window for adding a new course and
        /// re-fetches data from the UI if a course is successfully added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCourseAdd_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow courseWindow = new CourseWindow();
            bool? dialogResult = courseWindow.ShowDialog();

            if (dialogResult == true) { // I.e. dialog was not canceled
                Course? newCourse = courseWindow.Course;

                if (newCourse == null)
                {
                    MessageBox.Show("Failed to get the newly added course from the dialog. Please re-try.", "Whoops!");
                } 
                else
                {
                    bool successfullyAdded = manager.Add(newCourse);
                    if (!successfullyAdded)
                    {
                        MessageBox.Show("Failed to add course to database, please re-try.", "Whoops!");
                    }
                    else
                    {
                        UpdateCourses(); // Making sure UI is in sync with DB
                        UpdateLiterature();
                    }
                }
            }
        }

        /// <summary>
        /// Clears the course selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCourseClear_Click(object sender, RoutedEventArgs e)
        {
            SelectedCourse = null;
        }

        /// <summary>
        /// Event handler that attempts to delete the specified course if the user confirms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCourseDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourse == null)
            {
                MessageBox.Show("No course selected.", "Invalid selection");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete the course {SelectedCourse.Name} ({SelectedCourse.Code})? This cannot be undone.", "Delete confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    manager.Delete(SelectedCourse);
                    UpdateCourses(); // Since a deletion was made we need to re-fetch the courses from the database.
                    UpdateLiterature();
                }

            }
        }
        /// <summary>
        /// Event handler that attempts to edit the selected course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCourseEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourse == null)
            {
                MessageBox.Show("No course selected.", "Invalid selection");
            }
            else
            {
                CourseWindow courseWindow = new CourseWindow(SelectedCourse);
                bool? dialogResult = courseWindow.ShowDialog();

                if (dialogResult == true)
                { // I.e. dialog was not canceled
                    Course? editedCourse = courseWindow.Course;

                    if (editedCourse == null)
                    {
                        MessageBox.Show("Failed to get the edited course from the dialog. Please re-try.", "Whoops!");
                    }
                    else
                    {
                        bool successfullyEdited = manager.Edit(editedCourse);
                        if (!successfullyEdited)
                        {
                            MessageBox.Show("Failed to communicate the edits with the database, please re-try.", "Whoops!");
                        }
                        else
                        {
                            UpdateCourses(); // Making sure UI is in sync with DB
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event handler that attempts to add a new literature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiteratureAdd_Click(object sender, RoutedEventArgs e)
        {
            LiteratureWindow literatureWindow = new LiteratureWindow(courses.ToList());
            bool? dialogResult = literatureWindow.ShowDialog();

            if (dialogResult == true)
            { // I.e. dialog was not canceled
                Literature? newLiterature = literatureWindow.Literature;

                if (newLiterature == null)
                {
                    MessageBox.Show("Failed to get the newly added literature from the dialog. Please re-try.", "Whoops!");
                }
                else
                {
                    bool successfullyAdded = manager.Add(newLiterature);
                    if (!successfullyAdded)
                    {
                        MessageBox.Show("Failed to add literature to database, please re-try.", "Whoops!");
                    }
                    else
                    {
                        UpdateLiterature(); // Making sure UI is in sync with DB
                        UpdateCourses(); // Courses also display literature
                    }
                }
            }
        }

        /// <summary>
        /// Event handler that clears the literature selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiteratureClear_Click(object sender, RoutedEventArgs e)
        {
            SelectedLiterature = null;
        }

        /// <summary>
        /// Event handler for when the literature selection is changed, showcases the relevant literature information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgLiterature_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string info = "No literature selected...";

            if (SelectedLiterature != null)
                info = SelectedLiterature.GetInfo();

            txtLiteratureInfo.Text = info;
        }

        /// <summary>
        /// Event handler that attempts to copy the citation of the selected literature.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiteratureCitation_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLiterature == null)
            {
                MessageBox.Show("No literature selected, select a literature to be able to get its citation.");
            }
            else
            {
                try
                {
                    Clipboard.SetText(manager.CitationStrategy.Format(SelectedLiterature));
                }
                catch (COMException ex) 
                {
                    MessageBox.Show("Failed to access clipboard: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Event handler that handles when radio buttons are checked, it changes the citation strategy based on the active readio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                RadioButton selectedRadioButton = sender as RadioButton;

                if (selectedRadioButton != null)
                {
                    if (Enum.TryParse<ReferenceStyle>(selectedRadioButton.Name, out ReferenceStyle selectedStyle))
                    {
                        switch (selectedStyle)
                        {
                            case ReferenceStyle.Oxford:
                                manager.CitationStrategy = new OxfordStrategy();
                                break;
                            case ReferenceStyle.APA7:
                                manager.CitationStrategy = new APA7Strategy();
                                break;
                            case ReferenceStyle.Harvard:
                                manager.CitationStrategy = new HarvardStrategy();
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Event handler that attempts to delete the selected literature
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiteratureDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLiterature == null)
            {
                MessageBox.Show("No literature selected.", "Invalid selection");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete the literature {SelectedLiterature.Title} by {SelectedLiterature.Author}? This cannot be undone.", "Delete confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    manager.Delete(SelectedLiterature);
                    UpdateLiterature(); // Since a deletion was made we need to re-fetch the literature from the database.
                    UpdateCourses(); // Courses also contain data about literature.
                }
            }
        }

        /// <summary>
        /// Event handler that attempts to edit the selected literature (via another window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLiteratureEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLiterature == null)
            {
                MessageBox.Show("No literature selected.", "Invalid selection");
            }
            else
            {
                LiteratureWindow literatureWindow = new LiteratureWindow(courses.ToList(), SelectedLiterature);
                bool? dialogResult = literatureWindow.ShowDialog();

                if (dialogResult == true)
                { // I.e. dialog was not canceled
                    Literature? editedLiterature = literatureWindow.Literature;

                    if (editedLiterature == null)
                    {
                        MessageBox.Show("Failed to get the edited literature from the dialog. Please re-try.", "Whoops!");
                    }
                    else
                    {
                        bool successfullyEdited = manager.Edit(editedLiterature);
                        if (!successfullyEdited)
                        {
                            MessageBox.Show("Failed to communicate the edits with the database, please re-try.", "Whoops!");
                        }
                        else
                        {
                            UpdateLiterature(); // Making sure UI is in sync with DB
                            UpdateCourses();
                        }
                    }
                }
            }
        }
        #endregion
    }
}