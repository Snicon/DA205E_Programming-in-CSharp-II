// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.GenericList;
using DA205E_Assignment5.Model.CashFlow;
using DA205E_Assignment5.Model.Category;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace DA205E_Assignment5.Model.Transaction
{
    public class TransactionManager : ObservableCollectionManager<Transaction>
    {
        #region Fields
        private ObservableCollectionManager<Transaction> filteredTransactions; // Observable collection of filtered transactions, this collection is used in the GUI to display the relevant transactions after filters have been applied.
        private Dictionary<DateTime, List<Transaction>> monthlyGroupedTransactions; // Dictionary used for grouping transactions into groups of months, used for cash-flow
        private ObservableCollectionManager<DateTime> months; // Observable collection containing all the keys of the monthly grouped transactions (which is used for the filters)
        #endregion

        #region Constructor
        public TransactionManager() : base()
        {
            // Just making new instances below
            filteredTransactions = new ObservableCollectionManager<Transaction>();
            monthlyGroupedTransactions = new Dictionary<DateTime, List<Transaction>>();
            months = new ObservableCollectionManager<DateTime>();
        }
        #endregion

        #region Properties
        public ObservableCollection<Transaction> FilteredTransactions
        {
            get { return filteredTransactions.Collection; }
        }

        public ObservableCollectionManager<DateTime> Months
        {
            get { return months; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the transaction to the transaction collection and dictionary. Also refreshses the month list.
        /// </summary>
        /// <param name="transaction">The transaction to add</param>
        /// <returns>True if successfully added false if not.</returns>
        public override bool Add(Transaction transaction)
        {
            bool isSuccessfull = base.Add(transaction) && AddToDictionary(transaction); // Realistically if one fails the other also does as they only perform a simple null check on the same object reference that may return false.
            RefreshMonthList();
            return isSuccessfull;
        }

        /// <summary>
        /// Checks if the index is valid specifically for the dictionary of grouped transactions
        /// </summary>
        /// <param name="date">The date (key)</param>
        /// <param name="index">The index of the list (value) of the dictionary</param>
        /// <returns>True if valid, flase if invalid.</returns>
        public bool CheckGroupedIndex(DateTime date, int index)
        {
            bool containsKey = monthlyGroupedTransactions.ContainsKey(date);
            List<Transaction> transactions = monthlyGroupedTransactions[date];

            if (!containsKey) // Invalid key check
            {
                return false; // Failed check
            }

            if (index < 0 || index >= transactions.Count) // Invalid index check
            {
                return false; // Failed check
            }

            return true;
        }

        /// <summary>
        /// Deletes the transaction at the specified index in the base collection and dictionary
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool DeleteAt(int index)
        {
            bool isValidIndex = CheckIndex(index); // Checking if index is valid for the base collection

            if (!isValidIndex)
                return false; // Failed check

            Transaction transaction = GetAt(index); // Gets the transaction object, used to get the index for the dict
            DateTime key = NormalizeDateTime(transaction.Date); // Normalizing date to get the key for the dict
            int dictIndex = monthlyGroupedTransactions[key].IndexOf(transaction); // Getting the index of the specified transactions

            if (dictIndex == -1) // -1 means no match found for the transaction
                return false;

            bool isValidDictIndex = CheckGroupedIndex(key, dictIndex);
            if (!isValidDictIndex)
                return false;

            if (!DeleteAt(key, dictIndex)) 
                // Assuming that the collection of transactions and the grouped transactions in dict are synced.
                return false;
            base.DeleteAt(index);

            RefreshMonthList();
            return true;
        }

        /// <summary>
        /// Deletes (more like clears) all of the different collections
        /// </summary>
        public override void DeleteAll()
        {
            base.DeleteAll(); // Clears the transactions list
            monthlyGroupedTransactions.Clear(); // Clears the transactions from the grouped dictionary
            RefreshMonthList();
        }

        /// <summary>
        /// Generates a .txt file report
        /// </summary>
        /// <param name="fileName"></param>
        public void GenerateReport(string fileName)
        {
            List<MonthlyCashFlowSummary> summaries = CalculateCashFlowForAllMonths();

            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("Monthly report");
                    writer.WriteLine("Please note that the top 3 expenses/revenues may be empty if there are no expenses or revenues. There may also be less than 3 expenses or revenues if there are not enough revenues/expenses to cover all top 3.");

                    foreach (MonthlyCashFlowSummary summary in summaries)
                    {
                        writer.WriteLine(); // White-space to make the report look nicer
                        writer.WriteLine($"{summary.Month:MMMM yyyy}");
                        writer.WriteLine($"Top 3 expenses: {summary.TopExpenses}");
                        writer.WriteLine($"Top 3 revenues: {summary.TopRevenues}");
                        writer.WriteLine($"Net cash-flow: {summary.Net:C}");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong while trying to export a .txt-report!", "Error exporting file");
            }
        }

        /// <summary>
        /// Calculates the cash flow for all months and returns it in a list.
        /// </summary>
        /// <returns>The list of MonthlyCashFlowSummary</returns>
        public List<MonthlyCashFlowSummary> CalculateCashFlowForAllMonths()
        {
            List<MonthlyCashFlowSummary> results = new List<MonthlyCashFlowSummary>();

            foreach (KeyValuePair<DateTime, List<Transaction>> entry in monthlyGroupedTransactions)
            {
                DateTime month = entry.Key;
                List<Transaction> transactions = entry.Value;

                (decimal revenue, decimal expense, string topExpenses, string topRevenues, decimal net) = CalculateCashFlow(transactions); // Using tuple just to show case it in use as it is mentioned in assignment instructions, could have been a record (and would probably have been clearer that way)

                results.Add(new MonthlyCashFlowSummary(month, revenue, expense, topExpenses, topRevenues, net));
            }

            return results;
        }

        /// <summary>
        /// Adds transaction to dictionary
        /// </summary>
        /// <param name="transaction">The transaction to add</param>
        /// <returns>True if successfully added, flase if not</returns>
        private bool AddToDictionary(Transaction transaction)
        {
            if (transaction == null) // Null check
                return false;

            DateTime normalizedDateTime = NormalizeDateTime(transaction.Date);

            if (!monthlyGroupedTransactions.ContainsKey(normalizedDateTime))
            {
                List<Transaction> valueList = new List<Transaction>(); // Creating a new list for the dict
                monthlyGroupedTransactions.Add(normalizedDateTime, valueList); // Adding the list to the dict
            }

            monthlyGroupedTransactions[normalizedDateTime].Add(transaction); // Adding the transaction to the list in the dict

            return true;
        }

        public void RefreshFilteredTransactions(string descriptionSearch, CategoryType? categoryType, string categoryName, DateTime? specifiedDate, DateTime? monthYear)
        {
            List<Transaction> filteredTransactionsList = base.Collection.Where(t =>
                // Filter by the description (search control)
                (string.IsNullOrEmpty(descriptionSearch) || t.Description.Contains(descriptionSearch, StringComparison.OrdinalIgnoreCase)) &&

                // Filter by the type of category
                (!categoryType.HasValue || t.Category.Type == categoryType.Value) &&

                // Filter by the category name
                (string.IsNullOrEmpty(categoryName) || t.Category.Name == categoryName) &&

                // Filter by the specified date
                (!specifiedDate.HasValue || t.Date.Date == specifiedDate.Value.Date) &&

                // Filter by month + year (monthly)
                (!monthYear.HasValue || (t.Date.Month == monthYear.Value.Month && t.Date.Year == monthYear.Value.Year))
            ).ToList();

            filteredTransactions.DeleteAll();
            filteredTransactions.AddAll(filteredTransactionsList);
        }

        /// <summary>
        /// Checks if the category is used in any transaction
        /// </summary>
        /// <param name="categoryName">The name to look for</param>
        /// <returns>True if the category is used in any transaction, false if not used in any transaction</returns>
        public bool CategoryInUse(string categoryName)
        {
            if (categoryName == null)
                return false;

            foreach (Transaction transaction in base.Collection)
            {
                if (transaction.Category.Name.Equals(categoryName))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Changes the transaction to a new one.
        /// </summary>
        /// <param name="transaction">The transaction object to change to</param>
        /// <param name="index">The index of the transaction in the base collection</param>
        /// <returns>True if succesfully changed, false if it failed.</returns>
        public override bool ChangeAt(Transaction transaction, int index)
        {
            if (!CheckIndex(index) || transaction == null)
                return false;

            DateTime key = NormalizeDateTime(transaction.Date);
            Transaction oldTransaction = base.Collection[index];
            int dictListIndex = monthlyGroupedTransactions[key].IndexOf(oldTransaction);

            if (dictListIndex == -1)
                return false;

            monthlyGroupedTransactions[key][dictListIndex] = transaction;
            base.ChangeAt(transaction, index);

            return true;
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Calculates the revenue, expenses and net cash flow for the provided transaction list.
        /// </summary>
        /// <param name="transactionsOfTheMonth">The list contianing all the transactions to calculate based on.</param>
        /// <returns>A tuple containg the results as decimals in the following order: revenue, expenses, net cash flow.</returns>
        public static (decimal, decimal, string, string, decimal) CalculateCashFlow(List<Transaction> transactionsOfTheMonth)
        {
            decimal revenue = 0m;
            decimal expenses = 0m;
            string topExpensesString;
            string topRevenuesString;
            decimal net = 0m;

            // calculating revenue, expenses and net cash flow
            foreach (Transaction transaction in transactionsOfTheMonth)
            {
                switch (transaction.Category.Type)
                {
                    case CategoryType.Revenue:
                        revenue += transaction.Amount;
                        break;
                    case CategoryType.Expense:
                        expenses += transaction.Amount;
                        break;
                }
            }
            net = revenue - expenses;

            // Figuring out the top three expenses and revenues through LINQ
            topExpensesString = GetFormattedTopStat(CategoryType.Expense, transactionsOfTheMonth);
            topRevenuesString = GetFormattedTopStat(CategoryType.Revenue, transactionsOfTheMonth);

            return (revenue, expenses, topExpensesString, topRevenuesString, net);
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Normalizes the provided DateTime object into a version that is easier to handle as a key
        /// for the dictionary. In other words the day is set to 1 to make all transactions within the
        /// same month be grouped to the same key. For mor context see the Add method.
        /// </summary>
        /// <param name="dateTime">The datetime to normalize</param>
        /// <returns>The normalized date time with matching year and month, however day is alwasy 1.</returns>
        private DateTime NormalizeDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Date.Year, dateTime.Date.Month, 1);
        }

        /// <summary>
        /// Deletes the transaction from the specified place in the dictionary
        /// </summary>
        /// <param name="date">The key</param>
        /// <param name="index">The index for the list (value)</param>
        /// <returns>True if successful, false if unsuccessful</returns>
        private bool DeleteAt(DateTime date, int index)
        {
            bool isValidIndex = CheckGroupedIndex(date, index);

            if (!isValidIndex)
                return false;

            monthlyGroupedTransactions[date].RemoveAt(index);

            if (monthlyGroupedTransactions[date].Count == 0) // There are no transactions in the value of the dictionary, meaning the key value pair can be removed. If not removed the UI would display a month with no transactions for the cash flow.
            {
                monthlyGroupedTransactions.Remove(date); // removing the key value pair
            }
            RefreshMonthList();

            return true;
        }

        /// <summary>
        /// Repopulates the list with the keys from the dictionary
        /// </summary>
        private void RefreshMonthList()
        {
            Months.DeleteAll();
            var sortedMonths = monthlyGroupedTransactions.Keys.OrderBy(d => d).ToList();
            Months.AddAll(sortedMonths);
        }

        /// <summary>
        /// Gets the top 3 expenses or revenues depending on the provided category type and formats them in a nice string
        /// </summary>
        /// <param name="categoryType">The type of category to select form</param>
        /// <param name="transactionsOfTheMonth">The list of transactions to get the top 3 from.</param>
        /// <returns></returns>
        private static string GetFormattedTopStat(CategoryType categoryType, List<Transaction> transactionsOfTheMonth)
        {
            var topExpenses = transactionsOfTheMonth
                .Where(t => t.Category.Type == categoryType)
                .GroupBy(t => t.Category.Name)
                .Select(group => new {
                    CategoryName = group.Key,
                    Total = group.Sum(t => t.Amount)
                })
                .OrderByDescending(x => x.Total)
                .Take(3)
                .ToList();

            return string.Join(", ", topExpenses.Select(e => $"{e.CategoryName} ({string.Format("{0:C}", e.Total)})").ToList());
        }
        #endregion
    }
}
