namespace DA205E_Assignment3.Utils
{
    /// <summary>
    /// This static class houses any logic required for handling files, as of assignment 2 specifically image files.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Handling image loading via an OpenFileDialog, filters and default extensions are applied. The file path is then used to create a new instance of a bitmap which is returned.
        /// </summary>
        /// <returns>The bitmap of the image</returns>
        public static Bitmap LoadImage()
        {
            Bitmap image = null;

            OpenFileDialog openFileDialog = new OpenFileDialog(); // Opens a File Dialog for picking what file to load
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            openFileDialog.DefaultExt = "jpg"; // Defaulting to the jpg file extenision

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filePath = openFileDialog.FileName; // Getting full file path (called FileName in C#, which I first learned about during assignment 6 for the previous course)
                image = new Bitmap(filePath); // "Making" a bitmap out of the image file and setting the image variable to the object reference
            }

            openFileDialog.Dispose();

            return image;
        }
    }
}
