// Sixten Peterson (AQ9300) 2026-03-27

namespace DA205E_Assignment4.GenericList
{
    /// <summary>
    /// An implementation of the IListManager interface. (Copied from Assignment 3)
    /// </summary>
    /// <typeparam airplaneName="T"></typeparam>
    public class ListManager<T> : IListManager<T>
    {
        #region Fields
        private List<T> list; // Field that stores the list of items
        #endregion

        /// <summary>
        /// Returns the count/length of the list.
        /// </summary>
        public int Count
        {
            get
            {
                return list.Count();
            }
        }

        /// <summary>
        /// Property for the list field, read-only (no set)
        /// </summary>
        public List<T> TheList
        {
            get { return list; }
        }

        /// <summary>
        /// Property for the list field that is "writeable". This list property is protected for restricted "write access" to the list variable.
        /// </summary>
        protected List<T> TheBaseList
        {
            get { return list; }
            set { list = value; }
        }

        /// <summary>
        /// Simple constructor, just creates a new list for the list field.
        /// </summary>
        public ListManager()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Adds a new item based on the object provided in the parameters of the method.
        /// </summary>
        /// <param airplaneName="type">The object to add to the list</param>
        /// <returns>True if the object was successfully added to the list</returns>
        public virtual bool Add(T type)
        {
            if (type == null)
                return false;
            
            list.Add(type);
            return true;
        }

        /// <summary>
        /// Replaces the item in the list at the specified index.
        /// </summary>
        /// <param airplaneName="type">The object to replace with</param>
        /// <param airplaneName="index">The index of the item in the list to replace</param>
        /// <returns>True if successfully changed, false if not.</returns>
        public bool ChangeAt(T type, int index)
        {
            if (!CheckIndex(index) && type != null)
                return false;

            list[index] = type;
            return true;
        }

        /// <summary>
        /// Checks if the provided index is valid (within the bounds of the list collection)
        /// </summary>
        /// <param airplaneName="index">The index to check/validate</param>
        /// <returns>True if valid, false if invalid</returns>
        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= list.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Deletes the entire list
        /// </summary>
        public void DeleteAll()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Deletes the object at the specified index that was provided.
        /// </summary>
        /// <param airplaneName="index">The index to delete at</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
                return false;

            list.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Gets the element at the specified object.
        /// </summary>
        /// <param airplaneName="index">The index of the element/item in the collection.</param>
        /// <returns>The element/item as the stored object.</returns>
        public T GetAt(int index)
        {
            return list.ElementAt(index);
        }

        /// <summary>
        /// Creates an array consisting of the strings received by calling ToString() for each element/item in the list.
        /// </summary>
        /// <returns>The array of ToString()s</returns>
        public string[] ToStringArray()
        {
            if (Count == 0)
                return Array.Empty<string>();

            string[] info = new string[Count];
            
            for (int i = 0; i < Count; i++)
            {
                info[i] = list[i].ToString();
            }

            return info;
        }

        /// <summary>
        /// Creates a list consisting of the strings received by calling ToString() for each element/item in the list.
        /// </summary>
        /// <returns>The list collection of ToString()s</returns>
        public List<string> ToStringList()
        {
            if (Count == 0)
                return new List<string>(); // Returning an empty list of strings to avoid null checks

            List<string> info = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                info.Add(list[i].ToString());
            }

            return info;
        }
    }
}
