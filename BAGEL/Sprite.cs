namespace BAGEL
{
    class Sprite
    {
        private Vector position = null!;
        private Border brdr = null!;
        private Texture img = null!;
        private Physics phys = null!;
        // Parent Group Goes Here
        // Animation Object Goes Here

        // store rectangles to define boundary/wrapping/destroy areas.
        // if a rectangle exists, corresponding function called during update.
        private Border boundBorder = null!;
        private Border wrapBorder = null!;
        private Border destroyBorder = null!;

        private float angle;
        private float opacity;
        private Boolean mirrored;
        private Boolean flipped;

        public Sprite()
        {
            this.brdr.SetPosition(position.GetXCoord(), position.GetYCoord());
            this.angle = 0;
            this.opacity = 0;
            this.mirrored = false;
            this.flipped = false;
        }

        private void SetPosition(float x, float y)
        {
            this.brdr.SetValues(x, y);
        }

        private void MoveBy(float dx, float dy)
        {
            this.position.AddValues(dx, dy);
        }

        private void SetTexture(Texture t)
        {
            this.img = t;
            this.brdr.SetWidth(t.GetWidth());
            this.brdr.SetHeight(t.GetHeight());
        }

        private void SetSize(float s_width, float s_height)
        {
            this.brdr.SetWidth(s_width);
            this.brdr.SetHeight(s_height);
        }
    }
}
