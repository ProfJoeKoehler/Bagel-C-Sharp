namespace BAGEL
{
    /// <summary>
    /// A Rectangle has a size (width & height) and a position (x, y)
    /// The position is stored as a Vector so it can be easily synchronized
    /// with the position of a Sprite
    /// </summary>
    class Rectangle
    {
        // Note: position must be non-null in order to utilize SetValues
        // in the Constructor to avoid repitive code; might be overcomplicating
        // Rectangle, but it's worth experimenting
        private Vector position = null!;
        private float width;
        private float height;

        /// <summary>
        /// Set initial center position (x, y) and size (width and height).
        /// </summary>
        /// <param name="rx">x coordinate of the top-left corner</param>
        /// <param name="ry">y coordinate of the top-left corner</param>
        /// <param name="r_width">the length in the x-direction</param>
        /// <param name="r_height">the length in the y-direction</param>
        public Rectangle(float rx = 0, float ry = 0, float r_width = 0, float r_height = 0)
        {
            this.SetValues(rx, ry, r_width, r_height);
        }

        /// <summary>
        /// Set new center position (x, y) and new size (width and height).
        /// </summary>
        /// <param name="rx">x coordinate of the top-left corner</param>
        /// <param name="ry">y coordinate of the top-left corner</param>
        /// <param name="r_width">width: the length in the x-direction</param>
        /// <param name="r_height">height: the length in the y-direction</param>
        public void SetValues(float rx = 0, float ry = 0, float r_width = 0, float r_height = 0)
        {
            this.position.SetValues(rx, ry);
            this.width = r_width;
            this.height = r_height;
        }

        /// <summary>
        /// Set new center position (x, y).
        /// </summary>
        /// <param name="rx">x coordinate of the top-left corner</param>
        /// <param name="ry">y coordinate of the top-left corner</param>
        public void SetPosition(float rx, float ry)
        {
            this.position.SetValues(rx, ry);
        }

        /// <summary>
        /// Set new size (width and height).
        /// </summary>
        /// <param name="r_width">width: the length in the x-direction</param>
        /// <param name="r_height">height: the length in the y-direction</param>
        public void SetSize(float r_width, float r_height)
        {
            this.width = r_width;
            this.height = r_height;
        }

        /// <summary>
        /// Determine if this rectangle overlaps another rectangle (includes overlapping edges).
        /// </summary>
        /// <param name="other">rectangle to check for overlap with</param>
        /// <returns>true if this rectangle overlaps other rectangle, false otherwise</returns>
        public Boolean Overlaps(Rectangle other)
        {
            if ((other.position.GetXCoord() + other.width/2 <= this.position.GetXCoord() - this.width / 2) || (this.position.GetXCoord() + this.width/2 <= other.position.GetXCoord() - other.width/2)|| (other.position.GetYCoord() + other.height/2 <= this.position.GetYCoord() - this.height/2)|| (this.position.GetYCoord() + this.height/2 <= other.position.GetYCoord() - other.height/2))
                { return true; }
            else
                { return false; }

        }
    }
}
