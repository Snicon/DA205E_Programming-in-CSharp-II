// Sixten Peterson (AQ9300) 2026-05-18
using DA205E_Assignment5.GenericList;
using DA205E_Assignment5.Model.AppData;
using DA205E_Assignment5.Model.CashFlow;
using DA205E_Assignment5.Model.Category;
using DA205E_Assignment5.Model.Transaction;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DA205E_Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region fields
        // Collections
        private AppData appData;
        private ObservableCollectionManager<MonthlyCashFlowSummary> monthlyCashflowManager; // Responsible for keeping track of the monthly cash flow in the data grid

        // Input/textbox
        private string categoryName;
        private string transactionDescription;
        private DateTime? transactionDate;
        private decimal transactionAmount;
        private Category? transactionCategory;

        // Filtering & search
        private string searchDescription;
        private Category? filterSelectedCategory;
        private CategoryType? filterCategoryType;
        private DateTime? filterMonth;
        private DateTime? filterDate;

        // file name/path
        private string fileName;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged; // Eventhandler used for property changes/bindings

        #region Constructor
        public MainWindow()
        {
            DataContext = this;

            appData = new AppData();
            monthlyCashflowManager = new ObservableCollectionManager<MonthlyCashFlowSummary>();

            searchDescription = string.Empty;
            FilterSelectedCategory = null;
            FilterCategoryType = null;
            FilterMonth = null;
            FilterDate = null;

            InitializeComponent();
            InitGUI();
        }
        #endregion

        #region Collection properties
        public ObservableCollection<Category> Categories
        {
            get { return appData.Categories.Collection; }
        }

        public ObservableCollection<Transaction> Transactions
        {
            get { return appData.Transactions.Collection; }
        }

        public ObservableCollection<Transaction> FilteredTransactions
        {
            get { return appData.Transactions.FilteredTransactions; }
        }

        public ObservableCollection<DateTime> Months // Specifically refers to the normalized months available within the monthlyTransactionManager.
        {
            get { return appData.Transactions.Months.Collection; }
        }

        public ObservableCollection<MonthlyCashFlowSummary> MonthlyCashflow
        {
            get { return monthlyCashflowManager.Collection; }
        }
        #endregion

        #region Properties (for textbox and similar controls)
        public string SearchDescription
        {
            get { return searchDescription; }
            set
            {
                searchDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchDescription"));
                ApplyFilters();
            }
        }

        public Category? FilterSelectedCategory
        {
            get { return filterSelectedCategory; }
            set
            {
                filterSelectedCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilterSelectedCategory"));
                ApplyFilters();
            }
        }

        public CategoryType? FilterCategoryType
        {
            get { return filterCategoryType; }
            set
            {
                filterCategoryType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilterCategoryType"));
                ApplyFilters();
            }
        }

        public DateTime? FilterMonth
        {
            get { return filterMonth; }
            set
            {
                filterMonth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilterMonth"));
                ApplyFilters();
            }
        }

        public DateTime? FilterDate
        {
            get { return filterDate; }
            set
            {
                filterDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilterDate"));
                ApplyFilters();
            }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CategoryName"));
            }
        }

        public string TransactionDescription
        {
            get { return transactionDescription; }
            set
            {
                transactionDescription = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionDescription"));
            }
        }

        public DateTime? TransactionDate
        {
            get { return transactionDate; }
            set
            {
                transactionDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionDate"));
            }
        }

        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set
            {
                transactionAmount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionAmount"));
            }
        }

        public Category? TransactionCategory
        {
            get { return transactionCategory; }
            set
            {
                transactionCategory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TransactionCategory"));
            }
        }
        #endregion

        #region GUI init
        /// <summary>
        /// Initializes the GUI
        /// </summary>
        private void InitGUI()
        {
            PopulateCategoryTypeCMB();
        }

        /// <summary>
        /// Populates the combo box with enum values for the type. Also selects the index 0 to pre-fill the control.
        /// </summary>
        private void PopulateCategoryTypeCMB()
        {
            cmbCategoryType.ItemsSource = Enum.GetValues(typeof(CategoryType));
            cmbCategoryType.SelectedIndex = 0; // Selecting the first available category type.
        }
        #endregion

        #region GUI repopulation
        /// <summary>
        /// Calculates the cash flow for all months and repopulates the collection
        /// </summary>
        private void CalculateCashflow()
        {
            List<MonthlyCashFlowSummary> data = appData.Transactions.CalculateCashFlowForAllMonths();
            monthlyCashflowManager.DeleteAll();

            foreach (MonthlyCashFlowSummary summary in data)
            {
                monthlyCashflowManager.Add(summary);
            }
        }
        #endregion

        #region GUI clearing/refreshing methods
        /// <summary>
        /// Clears the category creation related form controls
        /// </summary>
        private void ClearCategoryForm()
        {
            CategoryName = string.Empty;
            cmbCategoryType.SelectedIndex = 0; // Setting to default value
        }

        /// <summary>
        /// Clears the transaction creation related form controls
        /// </summary>
        private void ClearTransactionForm()
        {
            TransactionDescription = string.Empty;
            TransactionAmount = 0m;
            TransactionDate = DateTime.Now;
            TransactionCategory = null;

        }

        /// <summary>
        /// The secret sauce to getting the data grid of transactions to work with filtering and searching.
        /// In essence it makes the filtered transactions collection get re-filtered. Thus showcasing only
        /// the desired transactions.
        /// </summary>
        private void ApplyFilters()
        {
            appData.Transactions.RefreshFilteredTransactions(
                SearchDescription,
                FilterCategoryType,
                FilterSelectedCategory?.Name,
                FilterDate,
                FilterMonth
            );
        }

        /// <summary>
        /// Clears the selection in the provided list box
        /// </summary>
        /// <param name="listBox"></param>
        private void ClearLstSelection(ListBox listBox)
        {
            listBox.SelectedIndex = -1; // Clearing selection of the specified listbox
        }
        #endregion

        #region Clearing state
        /// <summary>
        /// Clears the application state by deleting the contents in the managers
        /// </summary>
        private void ClearApplicationState()
        {
            appData.Categories.DeleteAll();
            appData.Transactions.DeleteAll();
            monthlyCashflowManager.DeleteAll();
        }
        #endregion

        #region Category management methods
        /// <summary>
        /// Adding a new category to the application if the "fields" (controls) of the form is valid.
        /// The category name must be at least 3 characters, otherwise a messagebox appears informing
        /// of validation error. May fail if name is already taken.
        /// </summary>
        private void AddCategory()
        {
            string name = CategoryName.Trim(); // Removing any extra unwanted white space
            CategoryType type = (CategoryType) cmbCategoryType.SelectedIndex;

            if (ValidationUtil.ValidateCategory(name)) // Validating length
            {
                Category category = new Category(name, type); // Creating record instance

                if (appData.Categories.Add(category)) // Attempting to add the category to the collection keeping state
                    ClearCategoryForm(); // Clearing the form for a better ux if the category was successfully added
            }
        }

        /// <summary>
        /// Deletes the selected category if a valid category was selected, warns the user if
        /// no valid selection was made.
        /// </summary>
        private void DeleteCategory()
        {
            int selectedIndex = lstCategories.SelectedIndex;

            if (!appData.Categories.CheckIndex(selectedIndex))
            {
                MessageBox.Show("Weird... This index selection is invalid. Please retry.");
                return;
            }

            string categoryName = appData.Categories.GetAt(selectedIndex).Name;

            if (!appData.Transactions.CategoryInUse(categoryName)) // Idealy this would be handled in the delete but this was the simplest implementation without "breaking" interfaces
            {
                bool isSuccessfullyDeleted = appData.Categories.DeleteAt(selectedIndex);

                if (!isSuccessfullyDeleted)
                {
                    MessageBox.Show("Failed to delete the category, are you sure you made a valid selection before pressing the delete button?", "Deletion failed");
                }
            } 
            else
            {
                MessageBox.Show("The category is already in use, in order to be able to delete this category you must first delete or edit any transactions using it.", "Deletion failed");
            }
        }
        #endregion

        #region Transaction management methods
        /// <summary>
        /// Adds a new transaction to the state if valid input was provided to the transaction creation form controls.
        /// Also re-applies the filters for the transaction data grid, re-calculates cashflow and clears the form.
        /// </summary>
        private void AddTransaction()
        {
            string description = TransactionDescription.Trim();
            DateTime? date = TransactionDate;
            decimal amount = TransactionAmount;
            Category? category = TransactionCategory;

            if (ValidationUtil.ValidateTransaction(description, date, amount, category))
            {
                Transaction transaction = new Transaction()
                {
                    Date = date ?? DateTime.Now,
                    Amount = amount,
                    Category = category,
                    Description = description
                };

                if (appData.Transactions.Add(transaction))
                {
                    ClearTransactionForm();
                    CalculateCashflow();
                    ApplyFilters();
                }
            }
        }

        /// <summary>
        /// Deletes the selected transaction (if there is one) from the application state.
        /// </summary>
        private void DeleteTransaction()
        {
            if (dgTransactions.SelectedItem is Transaction selectedTransaction)
            {
                int index = appData.Transactions.Collection.IndexOf(selectedTransaction); // Hacky way of getting the index of the selected transaction even if the observable collection (which may be a filtered version of the original list) missmatches the original list which could otherwise lead to the wrong index being chosen.

                bool isSuccessfullyDeleted = appData.Transactions.DeleteAt(index);

                if (!isSuccessfullyDeleted)
                {
                    MessageBox.Show("Failed to delete the transaction, are you sure you made a valid selection before pressing the delete button?", "Deletion failed");
                }

                ApplyFilters();
            }

            CalculateCashflow();
        }
        #endregion

        #region Button event handlers
        /// <summary>
        /// Button event handler for adding categories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategory();
        }

        /// <summary>
        /// Button event handler for deleting categories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            DeleteCategory();
        }

        /// <summary>
        /// Button event handler for clearing selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCategorySelection_Click(object sender, RoutedEventArgs e)
        {
            ClearLstSelection(lstCategories);
        }

        /// <summary>
        /// Button event for adding transactions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            AddTransaction();
        }

        /// <summary>
        /// Button event handler for deleting transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTransaction_Click(object sender, RoutedEventArgs e)
        {
            DeleteTransaction();
        }

        /// <summary>
        /// Button event handler for clearing selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTransactionSelection_Click(object sender, RoutedEventArgs e)
        {
            dgTransactions.SelectedIndex = -1; // Clearing selection by setting it to -1
        }

        /// <summary>
        /// Button event handler that clears the relevant filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearThisFilter_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                switch (clickedButton.Name)
                {
                    case "btnClearSearch":
                        SearchDescription = string.Empty;
                        break;
                    case "btnClearCategory":
                        FilterSelectedCategory = null;
                        break;
                    case "btnClearMonth":
                        FilterMonth = null;
                        break;
                    case "btnClearDate":
                        FilterDate = null;
                        break;
                }
            }
        }

        /// <summary>
        /// Button event handler for editing a transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (dgTransactions.SelectedItem is Transaction selectedTransaction)
            {
                int index = appData.Transactions.Collection.IndexOf(selectedTransaction); // Hacky way of getting the index of the selected transaction even if the observable collection (which may be a filtered version of the original list) missmatches the original list which could otherwise lead to the wrong index being chosen.
                List<Category> categoriesList = appData.Categories.Collection.ToList();

                EditTransactionWindow editTransactionWindow = new EditTransactionWindow(selectedTransaction, categoriesList);
                editTransactionWindow.Owner = this;

                if (editTransactionWindow.ShowDialog() == true)
                {
                    Transaction updatedTransaction = editTransactionWindow.Transaction;

                    bool isEditSuccessful = appData.Transactions.ChangeAt(updatedTransaction, index);

                    if (!isEditSuccessful)
                    {
                        MessageBox.Show("Failed to edit the transaction. Developer note: The index might be invalid.", "Edit failed");
                    }
                }

                ApplyFilters();
                CalculateCashflow();
            }
        }

        /// <summary>
        /// Button event handler for reseting all filters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterReset_Click(object sender, RoutedEventArgs e)
        {
            searchDescription = string.Empty;
            FilterSelectedCategory = null;
            FilterCategoryType = null;
            FilterMonth = null;
            FilterDate = null;
        }
        #endregion

        #region Menu button event handlers
        /// <summary>
        /// Menu button event handler for clearing state in the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Click(object sender, RoutedEventArgs e)
        {
            ClearApplicationState();
        }

        /// <summary>
        /// Menu button event handler for saving as json file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileAs();
        }

        /// <summary>
        /// Menu button for saving as last selected json file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Menu button event handler for opening a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.DefaultExt = "json";

            if (openFileDialog.ShowDialog() == true)
                fileName = openFileDialog.FileName;

            if (fileName != null)
            {
                ClearApplicationState();
                PersistenceManager.Deserialize(appData, fileName);
                ApplyFilters(); // Making sure the filtered list is updated on "import"/open.
                CalculateCashflow();
            }
        }

        /// <summary>
        /// Menu button event handler for generating report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            string txtFileName = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                txtFileName = saveFileDialog.FileName;
                if (txtFileName != string.Empty)
                {
                    appData.Transactions.GenerateReport(txtFileName);
                }
            }
        }

        /// <summary>
        /// Menu button event handler that shuts down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region File saving logic
        /// <summary>
        /// Saving file as, also setting the filename field. Code is mostly taken from
        /// assignment 3 and modified to suit this application.
        /// </summary>
        private void SaveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.DefaultExt = "json";

            if (saveFileDialog.ShowDialog() == true)
            {
                fileName = saveFileDialog.FileName;
                if (fileName != string.Empty)
                {
                    SaveFile();
                }
            }
        }

        /// <summary>
        /// Saving file (requires a filename to be set). Code is mostly taken from
        /// assignment 3 and modified to suit this application.
        /// </summary>
        private void SaveFile()
        {
            if (fileName == string.Empty)
            {
                SaveFileAs();
                return;
            }

            PersistenceManager.Serialize(appData, fileName);
        }
        #endregion
    }
}