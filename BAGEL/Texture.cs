using System.Drawing;

namespace BAGEL
{
    /// <summary>
    /// A Texture stores an Image and a Border
    /// that indicates which region of the Image will be drawn.
    /// </summary>
    public class Texture
    {
        private Border brdr = null!;
        private Image img = null!;

        /// <summary>
        /// Creates a new Texture with a given image
        /// </summary>
        /// <param name="pathToImage">Pathway to the Image File to load</param>
        public Texture(String pathToImage)
        {
            // Currently only usable on Windows
            img = Image.FromFile(pathToImage);
        }

        public float GetWidth()
        {
            return img.Height;
        }

        public float GetHeight()
        {
            return img.Width;
        }

        public Image GetImg()
        {
            return this.img;
        }
    }
}
