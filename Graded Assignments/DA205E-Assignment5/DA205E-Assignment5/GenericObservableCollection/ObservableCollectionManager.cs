// Sixten Peterson (AQ9300) 2026-05-18

using System.Collections.ObjectModel;

namespace DA205E_Assignment5.GenericList
{
    /// <summary>
    /// An implementation of the IObservableCollectionManager interface. 
    /// </summary>
    /// <typeparam name="T">The type of the collection</typeparam>
    public class ObservableCollectionManager<T> : IObservableCollectionManager<T>
    {
        #region Fields
        private ObservableCollection<T> collection; // Field that stores the collection of items
        #endregion

        /// <summary>
        /// Returns the count/length of the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return collection.Count();
            }
        }

        /// <summary>
        /// Property for the collection field, read-only (no set)
        /// </summary>
        public ObservableCollection<T> Collection
        {
            get { return collection; }
        }

        /// <summary>
        /// Property for the collection field that is "writeable". This collection property is protected for restricted "write access" to the collection variable.
        /// </summary>
        protected ObservableCollection<T> MutableCollection
        {
            get { return collection; }
            set { collection = value; }
        }

        /// <summary>
        /// Simple constructor, just creates a new collection for the collection field.
        /// </summary>
        public ObservableCollectionManager()
        {
            collection = new ObservableCollection<T>();
        }

        /// <summary>
        /// Adds a new item based on the object provided in the parameters of the method.
        /// </summary>
        /// <param name="type">The object to add to the collection</param>
        /// <returns>True if the object was successfully added to the collection</returns>
        public virtual bool Add(T type)
        {
            if (type == null)
                return false;

            collection.Add(type);
            return true;
        }

        /// <summary>
        /// Copies the contents of another collection into this colleciton.
        /// </summary>
        /// <param name="collection">The collection to copy from</param>
        /// <returns>True if successfully copied, false if not.</returns>
        public bool AddAll(IList<T> collection)
        {
            foreach (T item in collection)
            {
                bool successfullyAdded = Add(item);

                if (!successfullyAdded)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Replaces the item in the collection at the specified index.
        /// </summary>
        /// <param name="type">The object to replace with</param>
        /// <param name="index">The index of the item in the collection to replace</param>
        /// <returns>True if successfully changed, false if not.</returns>
        public virtual bool ChangeAt(T type, int index)
        {
            if (!CheckIndex(index) || type == null)
                return false;

            collection[index] = type;
            return true;
        }

        /// <summary>
        /// Checks if the provided index is valid (within the bounds of the collection collection)
        /// </summary>
        /// <param name="index">The index to check/validate</param>
        /// <returns>True if valid, false if invalid</returns>
        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= collection.Count)
                return false;

            return true;
        }

        /// <summary>
        /// Deletes the entire contents of the collection. Note: I originally wanted to make a new
        /// intance of the collection instead, however this seemed to screw up the bindings.
        /// This was the best compromise for now as I'm still learning WPF and its quirks.
        /// </summary>
        public virtual void DeleteAll()
        {
            collection.Clear();
        }

        /// <summary>
        /// Deletes the object at the specified index that was provided.
        /// </summary>
        /// <param name="index">The index to delete at</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public virtual bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
                return false;

            collection.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Gets the element at the specified object.
        /// </summary>
        /// <param name="index">The index of the element/item in the collection.</param>
        /// <returns>The element/item as the stored object.</returns>
        public T GetAt(int index)
        {
            return collection.ElementAt(index);
        }

        /// <summary>
        /// Creates an array consisting of the strings received by calling ToString() for each element/item in the collection.
        /// </summary>
        /// <returns>The array of ToString()s</returns>
        public string[] ToStringArray()
        {
            if (Count == 0)
                return Array.Empty<string>();

            string[] info = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                info[i] = collection[i].ToString();
            }

            return info;
        }

        /// <summary>
        /// Creates a collection consisting of the strings received by calling ToString() for each element/item in the collection.
        /// </summary>
        /// <returns>The collection collection of ToString()s</returns>
        public List<string> ToStringList()
        {
            if (Count == 0)
                return new List<string>(); // Returning an empty collection of strings to avoid null checks

            List<string> info = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                info.Add(collection[i].ToString());
            }

            return info;
        }
    }
}