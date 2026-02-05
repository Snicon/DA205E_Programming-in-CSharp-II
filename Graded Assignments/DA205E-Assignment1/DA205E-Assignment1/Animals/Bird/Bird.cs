namespace DA205E_Assignment1.Animals.Bird
{
    /// <summary>
    /// Sub class/derived class of the base/super class Animal. It adds fields and properties for wingspan and beak type along with an overriden ToString()-method.
    /// </summary>
    public class Bird : Animal
    {
        #region Fields
        private double wingspan;
        private BeakType beakType;
        #endregion

        #region Constructor(s)
        public Bird(double wingspan, BeakType beakType) : base()
        {
            Wingspan = wingspan;
            BeakType = beakType;
        }
        #endregion

        #region Properties
        public double Wingspan
        {
            get { return wingspan; }
            set { 
                if (value >= 0)
                    wingspan = value; // Since there is at least one instance of a bird that does not have wings (Kiwi birds) I will allow 0 though most birds will have a wingspan.
            }
        }

        public BeakType BeakType
        {
            get { return beakType; }
            set { beakType = value; }
        }
        #endregion

        #region ToString()
        /// <summary>
        /// Overriden ToString method. Adds the wingspan and beak type to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\nWingspan: {Wingspan}\nBeak type: {BeakType.ToString()}";
        }
        #endregion
    }
}
