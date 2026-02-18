// Sixten Peterson (AQ9300) 2026-02-04
using DA205E_Assignment1.Animals;
using System.ComponentModel;

namespace DA205E_Assignment1
{
    /// <summary>
    /// This class acts as the super class for all the different kinds of animal forms. I notices that all the forms used an animal property which caused me to opt to implement this class.
    /// There is a little bit less code repetition this way.
    /// </summary>
    public class AnimalForm : Form
    {
        #region Fields
        private Animal? animal = null;
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
        }
        #endregion
    }
}
