// Sixten Peterson (AQ9300) 2026-05-18
namespace DA205E_Assignment5.Model.CashFlow
{
    /// <summary>
    /// Record that keeps track of the cash-flow summary for a month
    /// </summary>
    public record MonthlyCashFlowSummary
    {
        public DateTime Month { get; init; }
        public decimal Revenues { get; init; }
        public decimal Expenses { get; init; }
        public string TopExpenses { get; init; }
        public string TopRevenues { get; init; }
        public decimal Net { get; init; }

        /// <summary>
        /// Simple constructor
        /// </summary>
        /// <param name="month">The month as date time</param>
        /// <param name="revenues">The revenues</param>
        /// <param name="expenses">The expenses</param>
        /// <param name="topExpenses">The top 3 expenses</param>
        /// <param name="topRevenues">The top 3 revenues</param>
        /// <param name="net">The net cash-flow</param>
        public MonthlyCashFlowSummary(DateTime month, decimal revenues, decimal expenses, string topExpenses, string topRevenues, decimal net)
        {
            Month = month;
            Revenues = revenues;
            Expenses = expenses;
            TopExpenses = topExpenses;
            TopRevenues = topRevenues;
            Net = net;
        }
    }
}
