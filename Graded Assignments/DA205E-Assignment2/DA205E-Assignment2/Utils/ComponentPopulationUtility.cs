// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Utils
{
    /// <summary>
    /// After noticing code duplication for populating combo boxes I decided to make a static class with generic implementations for populating combo and list boxes.
    /// This way I didn't have to re-invent the wheel in each form.
    /// </summary>
    public static class ComponentPopulationUtility
    {
        /// <summary>
        /// Populates any specified combo box with any provided values (as an array of strings). A default index may be provided in order to pre-select an item in the combobox. If none or a negative is provided as default index no item will be pre-selected.
        /// </summary>
        /// <param name="comboBox">the target combo box</param>
        /// <param name="values">the values to populate the combobox with</param>
        /// <param name="defaultIndex">any positive number within the range of the combobox. Or any negative number to avoid pre-selection.</param>
        public static void populate(ComboBox comboBox, string[] values, int defaultIndex = -1)
        {
            comboBox.Items.AddRange(values); // adding the values

            if (defaultIndex >= 0 && defaultIndex < values.Length)
            {
                comboBox.SelectedIndex = defaultIndex; // Pre-selecting the default index
            }
        }

        /// <summary>
        /// Populates any specified list box with any provided values (as an array of strings). A default index may be provided in order to pre-select an item in the combobox. If none or a negative is provided as default index no item will be pre-selected.
        /// </summary>
        /// <param name="listBox">the target list box</param>
        /// <param name="values">the values to populate the listbox with</param>
        /// <param name="defaultIndex">any positive number within the range of the listbox. Or any negative number to avoid pre-selection.</param>
        public static void populate(ListBox listBox, string[] values, int defaultIndex)
        {
            listBox.Items.AddRange(values); // Adding the values

            if (defaultIndex >= 0 && defaultIndex < values.Length)
            {
                listBox.SelectedIndex = defaultIndex; // Pre-selecting the default index
            }
        }
    }
}
