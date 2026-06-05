// Sixten Peterson (AQ9300) 2026-05-04
using DA205E_Assignment6.Models;
using DA205E_Assignment6.Utils;
using System.ComponentModel;
using System.Windows;

namespace DA205E_Assignment6.UI.Windows
{
    /// <summary>
    /// Interaction logic for CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window, INotifyPropertyChanged
    {
        #region Constants
        private const string editCourse = "Edit course";
        #endregion

        #region Fields
        private string courseName;
        private string courseCode;

        private Course? course;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Constructors
        public CourseWindow()
        {
            DataContext = this;
            InitFields(); // Initializing fields

            InitializeComponent();
        }

        public CourseWindow(Course course) : this()
        {
            this.course = course; // Setting course field to the instance of course provided since this object will be edited.

            PrefillForm(); // Pre-filling the form below based on the provided course object
            SetGUIToEditMode(); // Setting GUI to "edit mode"
        }
        #endregion

        #region Properties
        public string CourseName
        {
            get { return courseName; }
            set
            {
                courseName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseName"));
            }
        }

        public string CourseCode
        {
            get { return courseCode; }
            set
            {
                courseCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseCode"));
            }
        }

        public Course? Course
        {
            get { return course; }
        }
        #endregion

        #region Small helper methods
        /// <summary>
        /// Initializes some fields
        /// </summary>
        private void InitFields()
        {
            courseName = string.Empty;
            courseCode = string.Empty;
            course = null;
        }

        /// <summary>
        /// Sets the GUI to edit mode, whihc changes the window title and submit button text.
        /// </summary>
        private void SetGUIToEditMode()
        {
            btnSubmit.Content = editCourse;
            Title = editCourse; // Changing window title to match with action
        }

        /// <summary>
        /// Pre-fills the form for the user (used when in edit mode for improved UX)
        /// </summary>
        private void PrefillForm()
        {
            CourseName = course.Name;
            CourseCode = course.Code;
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// Event handler for when the submit button is pressed, it either adds a new course or edits an existing one based on the mode of the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool validInput = ValidationUtil.ValidateCouse(CourseName, CourseCode); // Validating input, also shows any validaiton errors to the user

            if (validInput)
            {
                if (Title != editCourse) // If title is not edit course that means we are adding
                {
                    course = new Course(CourseName.Trim(), CourseCode.Trim());
                    DialogResult = true;
                }
                else // We are editing
                {
                    if (course != null)
                    {
                        course.Name = courseName.Trim();
                        course.Code = courseCode.Trim();
                        DialogResult = true;
                    }
                } 
            }
        }

        /// <summary>
        /// Event handler for when the cancel button is pressed, essentialy closes the window with a dialog result of false indicating no data should be added/updated in the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            course = null; // Making sure course is null, shouldn't really matter but better safe than sorry
            DialogResult = false;
        }
        #endregion
    }
}
