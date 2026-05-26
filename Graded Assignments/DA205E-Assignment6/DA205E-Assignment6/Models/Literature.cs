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
        private int yearPublished;
        private LiteratureFormat format;
        private LiteratureStatus status;
        private List<Course> courses;
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
            return $"Id: {Id}{System.Environment.NewLine}Title: {Title}{System.Environment.NewLine}Year Published: {YearPublished}{System.Environment.NewLine}Format: {Format.ToString()}{System.Environment.NewLine}Status: {Status}{System.Environment.NewLine}"; // TODO: Courses not included for now.
        }
        #endregion
    }
}
