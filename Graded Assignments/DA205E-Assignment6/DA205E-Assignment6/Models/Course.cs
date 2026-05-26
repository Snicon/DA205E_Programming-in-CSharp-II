// Sixten Peterson (AQ9300) 2026-05-26

namespace DA205E_Assignment6.Models
{
    public class Course
    {
        #region Fields
        private int id;
        private string name;
        private string code;
        private List<Literature> readingList;
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Code
        {
            get => code;
            set => code = value;
        }

        public List<Literature> ReadingList
        {
            get => readingList;
            set => readingList = value;
        }
        #endregion

        #region Methods
        // TODO: Add methods
        #endregion
    }
}
