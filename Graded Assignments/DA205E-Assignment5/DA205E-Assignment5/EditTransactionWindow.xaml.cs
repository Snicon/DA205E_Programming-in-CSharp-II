// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.Model.Category;
using DA205E_Assignment5.Model.Transaction;
using System.ComponentModel;
using System.Windows;

namespace DA205E_Assignment5
{
    /// <summary>
    /// Interaction logic for EditTransactionWindow.xaml
    /// </summary>
    public partial class EditTransactionWindow : Window
    {
        #region Fields
        Transaction transaction;
        List<Category> categories;
        Category? categorySelection;
        DateTime date;
        string description;
        decimal amount;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged; // Eventhandler used for property changes/bindings

        #region Properties
        public Transaction Transaction
        {
            get { return transaction; }
        }

        public List<Category> Categories
        {
            get { return categories; } // No set required
        }

        public Category? CategorySelection
        {
            get { return categorySelection; }
            set { categorySelection = value; }
        }

        public string Description
        {
            get { return description; }
            set 
            { 
                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public decimal Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Amount"));
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="transaction">The transaction that will be edited</param>
        /// <param name="categories">The available categories, used to choose a category in the GUI</param>
        public EditTransactionWindow(Transaction transaction, List<Category> categories)
        {
            DataContext = this;

            this.transaction = transaction;
            Date = Transaction.Date;
            Description = Transaction.Description;
            Amount = Transaction.Amount;
            this.categories = categories;
            CategorySelection = categories[categories.IndexOf(transaction.Category)];

            InitializeComponent();
        }
        #endregion

        #region Button event handlers
        /// <summary>
        /// Closes the window and cancels the edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Saves the edit in the transaction property which can then be accessed from the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = Description.Trim();


            if (ValidationUtil.ValidateTransaction(Description, Date, Amount, CategorySelection))
            {
                Transaction newTransaction = new Transaction() {
                    Date = this.Date,
                    Amount = this.Amount,
                    Category = this.CategorySelection,
                    Description = this.Description
                };

                transaction = newTransaction; // Setting the transaction field to a new transaction that contains all the up to date data
            }

            this.DialogResult = true;
            this.Close();
        }
        #endregion
    }
}
