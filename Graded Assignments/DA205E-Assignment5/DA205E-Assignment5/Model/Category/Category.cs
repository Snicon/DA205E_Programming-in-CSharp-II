// Sixten Peterson (AQ9300) 2026-05-18
namespace DA205E_Assignment5.Model.Category
{
    /// <summary>
    /// Very basic record consisting of a name and a type.
    /// </summary>
    public record Category
    {
        public string Name { get; init; }
        public CategoryType Type { get; init; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="name">The name of the category</param>
        /// <param name="type">The type of category</param>
        public Category(string name, CategoryType type)
        {
            Name = name;
            Type = type;
        }
    }
}