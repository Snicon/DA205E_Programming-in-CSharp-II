// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.GenericList;
using System.Windows;

namespace DA205E_Assignment5.Model.Category
{
    public class CategoryManager : ObservableCollectionManager<Category>, IObservableCollectionManager<Category>
    {
        #region Fields
        private HashSet<string> categoryNames; // Field that stores all taken unique category names
        #endregion

        #region Constructor
        /// <summary>
        /// Simple constructor, just creates a new HashSet to assure that the category names are unique
        /// </summary>
        public CategoryManager() : base()
        {
            categoryNames = new HashSet<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the category to the observable collection if the name is not already taken.
        /// </summary>
        /// <param name="category">The category to add to the observable collection</param>
        /// <returns>True if successfully added, false if not.</returns>
        public override bool Add(Category category)
        {
            if (category == null)
                return false; // Null check failed

            bool isNameUnique = categoryNames.Add(category.Name);

            if (!isNameUnique)
            {
                MessageBox.Show("The category name provided is already in use, please choose another.", "Failed to add category");
                return false; // Name is already taken
            }

            base.MutableCollection.Add(category);

            return true;
        }

        /// <summary>
        /// Deletes the category at the specified index that was provided along with the unique
        /// name of the category.
        /// </summary>
        /// <param name="index">The index to delete at</param>
        /// <returns>True if deletion was successful, false otherwise (invalid index)</returns>
        public override bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
                return false;

            categoryNames.Remove(base.GetAt(index).Name); // Removing from the hashset data structure first since we need the string we want to remove
            base.MutableCollection.RemoveAt(index);
            return true;
        }

        public override void DeleteAll()
        {
            base.DeleteAll();
            categoryNames.Clear(); // clears the hashsets data since all the categories are deleted/cleared -> making all names available again.
        }
        #endregion
    }
}
