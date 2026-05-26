// Sixten Peterson (AQ9300) 2026-05-26

namespace DA205E_Assignment6.Models.Enums
{
    /// <summary>
    /// Enum representing the status of a literature resoruce. Literature may be owned by the user, borrowed from a library or friend or lent out to a friend.
    /// </summary>
    public enum LiteratureStatus
    {
        Owned,
        Borrowed,
        Lent
    }
}
