namespace BAGEL
{
    /// <summary>
    /// The Physics class performs position-velocity-acceleration (Vector) related calculations for more advanced (Sprite) movement. 
    /// For example, can set speed and motion angle of a sprite with constant velocity (no deceleration),
    /// or player character can accelerate at an angle and automatically decelerate at a fixed rate.
    /// Similar to the (Rectangle) class design, 
    /// the Physics position Vector can be set to reference the position of a (Sprite),
    /// which keeps them synchronized.
    /// A Physics object needs to be updated once per frame; for Sprites, this is handled by
    /// their (Sprite.Update) method.
    /// </summary>
    class Physics
    {
        private float accelerationValue;
        private float maximumSpeed;
        private float decelerationValue;
        private Vector positionVector = null!;
        private Vector velocityVector = null!;
        private Vector accelerationVector = null!;

        /// <summary>
        /// Initialize position, velocity, and acceleration vectors,
        /// and set acceleration, maximum speed, and deceleration values.
        /// </summary>
        /// <param name="accValue">default magnitude of acceleration when using (Physics.AccelerateAtAngle)</param>
        /// <param name="maxSpeed">maximum speed: if speed is ever above this amount, it will be reduced to this amount</param>
        /// <param name="decValue">when not accelerating, object will decelerate (decrease speed) by this amount</param>
        public Physics(float accValue, float maxSpeed, float decValue)
        {
            this.accelerationValue = accValue;
            this.maximumSpeed = maxSpeed;
            this.decelerationValue = decValue;
        }

        /// <summary>
        /// Get the current speed of this object (pixels/second).
        /// </summary>
        /// <returns>current speed</returns>
        public float GetSpeed()
        {
            return this.velocityVector.GetLength();
        }

        /// <summary>
        /// Set the speed (pixels/second) for this object (without changing the current angle of motion).
        /// </summary>
        /// <param name="spd">the new speed</param>
        public void SetSpeed(float spd)
        {
            this.velocityVector.SetLength(spd);
        }

        /// <summary>
        /// Get the current angle of motion (in degrees) of this object.
        /// (The angle is measured from the positive x-axis, 
        /// and angles increase in clockwise direction, since positive y-axis is down.)
        /// </summary>
        /// <returns>current angle of motion</returns>
        public float GetMotionAngle()
        {
            return this.velocityVector.GetAngle();
        }

        /// <summary>
        /// Set the angle of motion (in degrees) for this object (without changing the current speed).
        /// (The angle is measured from the positive x-axis, 
        /// and angles increase in clockwise direction, since positive y-axis is down.)
        /// </summary>
        /// <param name="angleDegrees">the new angle of motion</param>
        public void SetMotionAngle(float angleDegrees)
        {
            this.velocityVector.SetAngle(angleDegrees);
        }

        /// <summary>
        /// Accelerate this object in the given direction.
        /// (Uses the constant acceleration value specified in constructor.)
        /// </summary>
        /// <param name="angleDegrees">the direction of acceleration</param>
        public void AccelerateAtAngle(float angleDegrees)
        {
            // Creating an empty vector with default values and changing
            // them anyway feels weird
            Vector v = new Vector(0, 0);
            v.SetLength(this.accelerationValue);
            v.SetAngle(angleDegrees);
            this.accelerationVector.CombineVector(v);
        }

        /// <summary>
        /// Overrides the position vector with a new one
        /// </summary>
        /// <param name="other">the vector to replace the position vector</param>
        public void SetPositionVector(Vector other)
        {
            this.positionVector = other;
        }

        /// <summary>
        /// Sets new values for the Physics Object
        /// </summary>
        /// <param name="accValue">New acceleration value</param>
        /// <param name="maxSpeed">New maximum speed value</param>
        /// <param name="decValue">New deceleration value</param>
        public void SetValues(float accValue, float maxSpeed, float decValue)
        {
            this.accelerationValue = accValue;
            this.maximumSpeed = maxSpeed;
            this.decelerationValue = decValue;
        }

        /// <summary>
        /// Update the values for position, velocity, and acceleration vectors.
        /// This method should be called once per frame (automatically handled for (Sprite) objects). 
        /// </summary>
        /// <param name="deltaTime">the value of time passed</param>
        public void Update(float deltaTime)
        {
            // Apply Acceleration to Velocity
            this.velocityVector.AddValues(this.accelerationVector.GetXCoord() * deltaTime, 
                this.accelerationVector.GetYCoord() * deltaTime);

            float speed = this.GetSpeed();

            // Decrease speed (decelerate) when not accelerating
            if (this.accelerationVector.GetLength() < 0.001)
            {
                speed -= this.decelerationValue * deltaTime;
            }

            // Keep speed within set bounds
            if (speed < 0)
            {
                speed = 0;
            }
            if (speed > this.maximumSpeed)
            {
                speed = this.maximumSpeed;
            }

            // Update Velocity
            this.SetSpeed(speed);

            // Apply Velocity to Position
            this.positionVector.AddValues(this.velocityVector.GetXCoord() * deltaTime, 
                this.velocityVector.GetYCoord() * deltaTime);

            // Reset Acceleration
            this.accelerationVector.SetValues(0, 0);
        }
    }
}
