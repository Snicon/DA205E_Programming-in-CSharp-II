// Sixten Peterson (AQ9300) 2026-02-04
namespace DA205E_Assignment1.Animals.Reptile.Species
{
    /// <summary>
    /// Sub class/derived class of the base/super class Reptile. It adds fields and properties for shell width along with an overriden ToString()-method.
    /// </summary>
    public class Turtle : Reptile
    {
        #region Field(s)
        private double shellWidth;
        #endregion

        #region Constructor(s)
        public Turtle(bool livesInWater, bool canRegrowTail) : base(livesInWater, canRegrowTail)
        {
        }
        #endregion

        #region Properties
        public double ShellWidth
        {
            get { return shellWidth; }
            set
            {
                if (value > 0) // I'm no expert in turtle shells but I would imagine their shells are at least bigger than 0 of whichever unit you may want to use. Probably this limit could be set bigger but I'm not researching hte minimum shell width of a turtle shell for this assignment...
                {
                    shellWidth = value;
                }
            }
        }
        #endregion

        #region ToString()
        /// <summary>
        /// Overriden ToString method. Adds the shell width property to the base ToString().
        /// </summary>
        /// <returns>A representation of the object as a string containing all relevant fields.</returns>
        public override string ToString()
        {
            return base.ToString() + $"\n\nShell width: {ShellWidth}";
        }
        #endregion
    }
}
