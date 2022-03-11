namespace BAGEL
{
    /// <summary>
    /// The Clock keeps track of time-related values for a {Game}:
    /// elapsed time (total time since initialization)
    /// delta time (the change in time since last {@link Clock#update|update}).
    /// </summary>
    class Clock
    {
        private DateTime previousTime;
        private DateTime currentTime;
        private float deltaTime;
        private float elapsedTime;

        /// <summary>
        /// Initialize required variables and begin tracking time.
        /// </summary>
        public Clock()
        {
            this.previousTime = DateTime.Now;
            this.currentTime = DateTime.Now;
            this.deltaTime = 0;
            this.elapsedTime = 0;
        }

        /// <summary>
        /// Return the time (seconds) since the last time the {@link Clock#update|update} method was called.
        /// </summary>
        /// <returns>time (seconds) since last update</returns>
        public float GetDeltaTime()
        {
            return this.deltaTime;
        }

        /// <summary>
        /// Return the time (seconds) since the last time the {@link Clock#update|update} method was called.
        /// </summary>
        /// <returns>time (seconds) since clock was created</returns>
        public float GetElapsedTime()
        {
            return this.elapsedTime;
        }

        /// <summary>
        /// Update the values for delta time and elapsed time.
        /// This method should be called once per frame by the {@link Game} class. 
        /// </summary>
        public void Update()
        {
            this.currentTime = DateTime.Now;
            this.deltaTime = (this.currentTime.Ticks - this.previousTime.Ticks) / 1000;
            this.elapsedTime += this.deltaTime;
            this.previousTime = DateTime.Now;
        }
    }
}
