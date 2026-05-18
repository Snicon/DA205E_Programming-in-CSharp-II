// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.Model.Category;
using DA205E_Assignment5.Model.Transaction;

namespace DA205E_Assignment5.Model.AppData
{
    /// <summary>
    /// This record is mainly constructed the way it is in order to make serialization and de-serialization easier.
    /// In essence it keeps the category and transaction managers.
    /// </summary>
    public record AppData
    {
        #region Properties
        public CategoryManager Categories { get; init; }
        public TransactionManager Transactions { get; init; }
        #endregion

        #region Constructor
        /// <summary>
        /// Basic constuctor, just creates new instances of the managers
        /// </summary>
        public AppData()
        {
            Categories = new CategoryManager();
            Transactions = new TransactionManager();
        }
        #endregion
    }
}
