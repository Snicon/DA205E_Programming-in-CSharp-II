// Sixten Peterson (AQ9300) 2026-05-18

using System.Collections.ObjectModel;

namespace DA205E_Assignment5.GenericList
{
    /// <summary>
    /// An interface for a generic observable collection manager. (Copied from Assignment 3 and modified to use Observable MutableCollection for WPF)
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public interface IObservableCollectionManager<T>
    {
        int Count { get; }

        /// <summary>
        /// Method used for adding an object to the collection
        /// </summary>
        /// <param name="type">The object to add to the collection</param>
        /// <returns>True if successfully added, false if not.</returns>
        bool Add(T type);

        /// <summary>
        /// Method used to add all objects from one collection to the collection within the manager.
        /// </summary>
        /// <param name="collection">The collection of objects to copy over to the manager collection.</param>
        /// <returns>True if all items was added, false if it failed.</returns>
        bool AddAll(IList<T> collection);

        /// <summary>
        /// Replaces the item in the collection at the specified index.
        /// </summary>
        /// <param name="type">The object to replace with</param>
        /// <param name="index">The index of the item in the collection to replace</param>
        /// <returns>True if successfully changed, false if not.</returns>
        bool ChangeAt(T type, int index);

        /// <summary>
        /// Checks if the provided index is valid (within the bounds of the collection collection)
        /// </summary>
        /// <param name="index">The index to check/validate</param>
        /// <returns>True if valid, false if invalid</returns>
        bool CheckIndex(int index);

        /// <summary>
        /// Deletes the entire collection
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Deletes the object at the specified index that was provided.
        /// </summary>
        /// <param name="index">The index to delete at</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        bool DeleteAt(int index);

        /// <summary>
        /// Gets the element at the specified object.
        /// </summary>
        /// <param name="index">The index of the element/item in the collection.</param>
        /// <returns>The element/item as the stored object.</returns>
        T GetAt(int index);

        /// <summary>
        /// Creates an array consisting of the strings received by calling ToString() for each element/item in the collection.
        /// </summary>
        /// <returns>The array of ToString()s</returns>
        string[] ToStringArray();

        /// <summary>
        /// Creates a collection consisting of the strings received by calling ToString() for each element/item in the collection.
        /// </summary>
        /// <returns>The collection collection of ToString()s</returns>
        List<string> ToStringList();
    }
}