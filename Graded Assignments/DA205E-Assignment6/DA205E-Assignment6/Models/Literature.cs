// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DA205E_Assignment6.Models
{
    /// <summary>
    /// The Literature class is an abstract class representing a literature source.
    /// </summary>
    public abstract class Literature
    {
        #region Fields
        private int id;
        private string title;
        private string author;
        private int yearPublished;
        private LiteratureFormat format;
        private LiteratureStatus status;
        private List<Course> courses;
        #endregion

        #region Constructors
        protected Literature() { }

        protected Literature(string title, string author, int yearPublished, LiteratureFormat format, LiteratureStatus status, List<Course> courses)
        {
            this.title = title;
            this.author = author;
            this.yearPublished = yearPublished;
            this.format = format;
            this.status = status;
            this.courses = courses;
        }
        #endregion

        #region Properties
        [Key]
        public int Id
        {
            get => id;
            set { id = value; }
        }

        public string Title
        {
            get => title;
            set { title = value; }
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        /// <summary>
        /// Essentialy determines the names of the author and returns an Author record containing the names.
        /// This property is mainly here in order to simplify the citation strategy logic by having the names structured.
        /// Without this property this process would have to be reimplemented in all the citation strategies.
        /// </summary>
        public Author AuthorRecord
        {
            get
            {
                if (string.IsNullOrEmpty(Author))
                    return new Author(); // Just empty strings for all names. TODO: Improve, this is not ideal for production

                string[] parts = Author.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Splitting name into multiple parts and removed any empty empty strings

                // Identifying the string parts as different names.
                string last = parts[parts.Length - 1]; // The last occuring name in the parts of the name is obviously the last name
                string first = parts.Length > 1 ? parts[0] : string.Empty; // If more than one name occurs then the first name is the first part. If only one name occurs it is assumed that name is the last name.
                string middle = parts.Length > 2 ? string.Join(" ", parts.Skip(1).Take(parts.Length - 2)) : string.Empty; // Gets the middle name if there is any

                return new Author(first, middle, last);
            }
        }

        public int YearPublished
        {
            get => yearPublished;
            set { yearPublished = value; }
        }

        public LiteratureFormat Format
        {
            get => format;
            set { format = value; }
        }

        public LiteratureStatus Status
        {
            get => status;
            set { status = value; }
        }

        public List<Course> Courses
        {
            get => courses;
            set { courses = value; }
        }
        #endregion

        #region Methods
        public abstract string GetInfo();

        /// <summary>
        /// Gets the fields of the literature class (which acts a base class for Book and JournalArticle)
        /// </summary>
        /// <returns>A nicley formatted string of the fields.</returns>
        public string GetBaseDetails()
        {
            string courseString = $"Courses:{System.Environment.NewLine}";
            foreach (Course course in Courses)
            {
                courseString += $"- {course.Name} ({course.Code}){System.Environment.NewLine}";
            }
            return $"Id: {Id}{System.Environment.NewLine}Title: {Title}{System.Environment.NewLine}Year Published: {YearPublished}{System.Environment.NewLine}Format: {Format.ToString()}{System.Environment.NewLine}Status: {Status}{System.Environment.NewLine}{courseString}";
        }
        #endregion
    }
}
