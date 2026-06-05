// Sixten Peterson (AQ9300) 2026-05-26

namespace DA205E_Assignment6.Models
{
    public class Course
    {
        #region Fields
        private int id;
        private string name;
        private string code;
        private List<Literature> literature;
        #endregion

        #region Constructor
        public Course(string name, string code)
        {
            // Validation is made outside of constructor for better or for worse.
            Name = name;
            Code = code;
        }
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

        public List<Literature> Literature
        {
            get => literature;
            set => literature = value;
        }
        #endregion
    }
}
