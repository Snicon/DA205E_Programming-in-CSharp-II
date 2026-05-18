// Sixten Peterson (AQ9300) 2026-05-18
namespace DA205E_Assignment5.Model.Transaction
{
    /// <summary>
    /// Very simple transaction record, consists of a date, an amount, a category and a description.
    /// </summary>
    public record Transaction
    {
        #region Properties
        public DateTime Date { get; init; }
        public decimal Amount { get; init; }
        public Category.Category Category { get; init; }
        public string Description { get; init; }
        #endregion
    }
}
