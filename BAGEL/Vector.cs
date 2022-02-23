namespace BAGEL
{
    /// <summary>
    /// A Vector is a pair of values (x,y), useful for representing position
    /// See [Rectangle] and [Sprite]
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// 
        /// </summary>
        private float x;
        private float y;

        /// <summary>
        /// Set initial values for (x, y); defaults to (0, 0).
        /// </summary>
        /// <param name="vectorX">the x coordinate</param>
        /// <param name="vectorY">the y coordinate</param>
        public Vector(float vectorX = 0, float vectorY = 0)
        {
            this.SetValues(vectorX, vectorY);
        }

        /// <summary>
        /// Set new values for the x and y coordinates.
        /// </summary>
        /// <param name="vectorX">new x coordinate</param>
        /// <param name="vectorY">new y coordinate</param>
        public void SetValues(float vectorX, float vectorY)
        {
            this.x = vectorX;
            this.y = vectorY;
        }

        /// <summary>
        /// Add values to the x and y coordinates.
        /// </summary>
        /// <param name="vectorDX">value to add to the x coordinate</param>
        /// <param name="vectorDY">value to add to the y coordinate</param>
        public void AddValues(float vectorDX, float vectorDY)
        {
            this.x += vectorDX;
            this.y += vectorDY;
        }

        /// <summary>
        /// Add x and y components of another vector to this vector.
        /// </summary>
        /// <param name="other">vector to be added to this vector</param>
        public void CombineVector(Vector other)
        {
            this.x += other.x;
            this.y += other.y;
        }

        /// <summary>
        /// Scale x and y components of this vector by a constant.
        /// </summary>
        /// <param name="scaleValue">value to scale by</param>
        public void ScaleVector(float scaleValue)
        {
            this.x *= scaleValue;
            this.y += scaleValue;
        }

        /// <summary>
        /// Get the length of this vector.
        /// </summary>
        /// <returns>the length of this vector</returns>
        public float GetLength()
        {
            return (float)(Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2)));
        }

        /// <summary>
        /// Get the angle (in degrees) between this vector and the positive x-axis.
        /// (Angles increase in clockwise direction, since positive y-axis is down.)
        /// Angle returns 0 in length range -180 to 180
        /// </summary>
        /// <returns>angle between this vector and positive x-axis</returns>
        public float GetAngle()
        {
            if (this.GetLength() == 0)
                return 0;
            else
                return (float)(Math.Atan2(this.y, this.x) * (180 / Math.PI));
        }

        /// <summary>
        /// Gets the x coordinate of this vector
        /// </summary>
        /// <returns>x coordinate of this vector</returns>
        public float GetXCoord()
        {
            return this.x;
        }

        /// <summary>
        /// Gets the y coordinate of this vector
        /// </summary>
        /// <returns>y coordinate of this vector</returns>
        public float GetYCoord()
        {
            return this.y;
        }

        /// <summary>
        /// Set the length of this vector (without changing the current direction).
        /// </summary>
        /// <param name="length">new length of this vector</param>
        public void SetLength(float length)
        {
            float angleDegrees = this.GetAngle();
            this.x = (float)(length * Math.Cos(angleDegrees * (Math.PI / 180)));
            this.y = (float)(length * Math.Sin(angleDegrees * (Math.PI / 180)));
        }

        /// <summary>
        /// Set the angle (in degrees) between this vector and the positive x-axis (without changing the current length).
        /// (Angles increase in clockwise direction, since positive y-axis is down.)
        /// </summary>
        /// <param name="angleDegrees">the new direction angle of this vector</param>
        public void SetAngle(float angleDegrees)
        {
            float length = this.GetLength();
            this.x = (float)(length * Math.Cos(angleDegrees * (Math.PI / 180)));
            this.y = (float)(length * Math.Sin(angleDegrees * (Math.PI / 180)));
        }
    }
}