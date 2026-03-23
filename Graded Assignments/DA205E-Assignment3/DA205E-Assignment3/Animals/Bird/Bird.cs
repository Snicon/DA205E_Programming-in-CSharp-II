// Sixten Peterson (AQ9300) 2026-03-23
using DA205E_Assignment3.Animals.Bird.Species;
using DA205E_Assignment3.Animals.Bird.Species.Raven;
using System.Xml.Serialization;

namespace DA205E_Assignment3.Animals.Bird
{
    /// <summary>
    /// An abstract sub class/derived class of the base/super class Animal. It adds fields and properties for wingspan and beak type along with an overriden ToString()-method. It also implements the Category property.
    /// </summary>
    [XmlInclude(typeof(Dove))]
    [XmlInclude(typeof(Raven))]
    public abstract class Bird : Animal
    {
        #region Fields
        private double wingspan;
        private BeakType beakType;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Simple consturctor
        /// </summary>
        public Bird() : base() { }

        /// <summary>
        /// Sets the wingspan and beaktype via thir properties based on the provided parameters. Also calls the base constructor.
        /// </summary>
        /// <param name="wingspan">The wingspan value for the bird</param>
        /// <param name="beakType">The type of beak the bird has</param>
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

        public override Category Category
        {
            get
            {
                return Category.Bird;
            }
        }
        #endregion

        #region ToString()
        /// <summary>
        /// Overriden ToString method. Adds the wingspan and beak type to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a nicley formatted string containing all relevant fields.</returns>
        public override string ToString()
        {
            string wingspanString = $"{"Wingspan",-18} {Wingspan,-10}{Environment.NewLine}";
            string beakTypeString = $"{"BeakType",-18} {BeakType.ToString(),-10}{Environment.NewLine}";
            return base.ToString() + wingspanString + beakTypeString;
        }

        /// <summary>
        /// Overriden ToStringTxtMethod(). It adds the wingspan and beak type properties to the string.
        /// </summary>
        /// <returns>A nicley fromatted string used for storing an animal in a .txt-file.</returns>
        public override string ToStringTxt()
        {
            return base.ToStringTxt() + $"Wingspan: {Wingspan}{Environment.NewLine}" +
                $"Beak type: {BeakType}{Environment.NewLine}";
        }
        #endregion
    }
}
