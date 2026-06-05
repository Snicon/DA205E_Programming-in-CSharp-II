// Sixten Peterson (AQ9300) 2026-06-02
using DA205E_Assignment6.Data;
using DA205E_Assignment6.Models;
using DA205E_Assignment6.Strategies.CitationStrategey;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DA205E_Assignment6.Managers
{
    /// <summary>
    /// While named LiteratureManager this course handles basically all the bussiness logic for this
    /// literature-centered application, including courses. It includes logic for citation strategies
    /// (used for getting citations for literature), managing literature and courses (related to
    /// literature).
    /// </summary>
    public class LiteratureManager
    {
        #region Fields
        private ICitationStrategy citationStrategy;
        private LiteratureAppContext context;
        #endregion

        #region Properties
        public ICitationStrategy CitationStrategy
        {
            get => citationStrategy;
            set
            {
                if (value != null)
                    citationStrategy = value;
            }
        }
        #endregion

        #region Constructor
        public LiteratureManager()
        {
            citationStrategy = new HarvardStrategy(); // Setting Harvard as a default because its popular, though I guess that goes for all of these
            context = new LiteratureAppContext();
        }
        #endregion

        #region Course related methods
        /// <summary>
        /// Adds the provided course object to the database.
        /// </summary>
        /// <param name="course">The course object to add</param>
        /// <returns>True if successfully added, false if not.</returns>
        public bool Add(Course course)
        {
            try
            {
                context.Add(course);
                context.SaveChanges();

                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        /// <summary>
        /// Deleting the provided course from the database.
        /// </summary>
        /// <param name="course">The course to remove</param>
        /// <returns>True if successfully deleted, false if not.</returns>
        public bool Delete(Course course)
        {
            if (course == null) // Null check with early return ("guard clause")
                return false;

            try
            {
                bool existsInDB = context.Courses.Any(c => c.Id == course.Id); // Basically checking if the provided course actually exists in the database

                if (!existsInDB) // Another guard clause, deletion failed since there is no such object to delete.
                    return false;

                context.Courses.Remove(course);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        /// <summary>
        /// Stores any edits made to the provided course in the database.
        /// </summary>
        /// <param name="course">The course that was edited.</param>
        /// <returns>True if successfully edited, false if not.</returns>
        public bool Edit(Course course)
        {
            if (course == null) // Null check with early return ("guard clause")
                return false;

            try
            {
                bool existsInDB = context.Courses.Any(c => c.Id == course.Id); // Basically checking if the provided course actually exists in the database

                if (!existsInDB) // Another guard clause, deletion failed since there is no such object to delete.
                    return false;

                context.Entry(course).State = EntityState.Modified; // Basically informaing EF Core that the entity has been modified
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        public List<Course> GetAllCourses()
        {
            return context.Courses
                .Include(c => c.Literature) // Eager loading, p. 945-950 in Pro C# 10 with .NET 6 by Andrew Troelsen & Phil Japikse.
                .ToList(); // Turning into a list for the GUI
        }
        #endregion

        #region Literature related methods
        /// <summary>
        /// Adds the provided literature object to the database.
        /// </summary>
        /// <param name="literature">The literature object to add</param>
        /// <returns>True if successfully added, false if not.</returns>
        public bool Add(Literature literature)
        {
            try
            {
                context.Add(literature);
                context.SaveChanges();

                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        /// <summary>
        /// Deleting the provided literature from the database.
        /// </summary>
        /// <param name="literature">The literature to remove</param>
        /// <returns>True if successfully deleted, false if not.</returns>
        public bool Delete(Literature literature)
        {
            if (literature == null) // Null check with early return ("guard clause")
                return false;

            try
            {
                bool existsInDB = context.Literatures.Any(c => c.Id == literature.Id); // Basically checking if the provided course actually exists in the database

                if (!existsInDB) // Another guard clause, deletion failed since there is no such object to delete.
                    return false;

                context.Literatures.Remove(literature);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        /// <summary>
        /// Stores any edits made to the provided literature in the database.
        /// </summary>
        /// <param name="literature">The literature that was edited.</param>
        /// <returns>True if successfully edited, false if not.</returns>
        public bool Edit(Literature literature)
        {
            if (literature == null) // Null check with early return ("guard clause")
                return false;

            try
            {
                bool existsInDB = context.Literatures.Any(c => c.Id == literature.Id); // Basically checking if the provided literature actually exists in the database

                if (!existsInDB) // Another guard clause, deletion failed since there is no such object to delete.
                    return false;

                context.Entry(literature).State = EntityState.Modified; // Basically informaing EF Core that the entity has been modified
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                if (innerException != null)
                    MessageBox.Show(innerException?.Message, "Database error");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong.");
                return false;
            }
        }

        public List<Literature> GetAllLiterature()
        {
            return context.Literatures.ToList();
        }
        #endregion
    }
}
