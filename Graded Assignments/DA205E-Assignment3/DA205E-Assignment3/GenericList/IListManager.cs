// Sixten Peterson (AQ9300) 2026-02-24

namespace DA205E_Assignment3.GenericList
{
    /// <summary>
    /// An interface for a generic list manager.
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public interface IListManager<T>
    {
        int Count { get; }

        /// <summary>
        /// Method used for adding an object to the list
        /// </summary>
        /// <param name="type">The object to add to the list</param>
        /// <returns>True if successfully added, false if not.</returns>
        bool Add(T type);

        /// <summary>
        /// Replaces the item in the list at the specified index.
        /// </summary>
        /// <param name="type">The object to replace with</param>
        /// <param name="index">The index of the item in the list to replace</param>
        /// <returns>True if successfully changed, false if not.</returns>
        bool ChangeAt(T type, int index);

        /// <summary>
        /// Checks if the provided index is valid (within the bounds of the list collection)
        /// </summary>
        /// <param name="index">The index to check/validate</param>
        /// <returns>True if valid, false if invalid</returns>
        bool CheckIndex(int index);

        /// <summary>
        /// Deletes the entire list
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
        /// Creates an array consisting of the strings received by calling ToString() for each element/item in the list.
        /// </summary>
        /// <returns>The array of ToString()s</returns>
        string[] ToStringArray();

        /// <summary>
        /// Creates a list consisting of the strings received by calling ToString() for each element/item in the list.
        /// </summary>
        /// <returns>The list collection of ToString()s</returns>
        List<string> ToStringList();

        /// <summary>
        /// Serializes the list to Json and stores it in a .json file.
        /// </summary>
        /// <param name="fileName">The fileName/path to store the serialized data in.</param>
        void JsonSerialize(string fileName);

        /// <summary>
        /// Deseraializes the list from Json and applies it to the list.
        /// </summary>
        /// <param name="fileName">The fileName/path to the file that will be deserialized from</param>
        void JsonDeserialize(string fileName);

        /// <summary>
        /// Serializes the list to XML and stores it in a .xml file.
        /// </summary>
        /// <param name="fileName">The fileName/path to store the serialized data in.</param>
        void XMLSerialize(string fileName);
    }
}
