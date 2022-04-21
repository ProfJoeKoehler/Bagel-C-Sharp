using System.Drawing;

namespace BAGEL
{
    public class Sprite
    {
        private Vector position = null!;
        private Border brdr = null!;
        private Texture img = null!;
        private Physics phys = null!;
        private Group? parentGroup = null!;
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
        private Boolean visible;

        public Sprite()
        {
            this.brdr.SetPosition(position.GetXCoord(), position.GetYCoord());
            this.angle = 0;
            this.opacity = 0;
            this.mirrored = false;
            this.flipped = false;
            this.visible = true;
        }

        public void SetPosition(float x, float y)
        {
            this.brdr.SetValues(x, y);
        }

        public void MoveBy(float dx, float dy)
        {
            this.position.AddValues(dx, dy);
        }

        public void SetTexture(Texture t)
        {
            this.img = t;
            this.brdr.SetWidth(t.GetWidth());
            this.brdr.SetHeight(t.GetHeight());
        }

        public void SetSize(float s_width, float s_height)
        {
            this.brdr.SetWidth(s_width);
            this.brdr.SetHeight(s_height);
        }

        public void SetVisible(Boolean visible)
        {
            this.visible = visible;
        }

        public float GetAngle()
        {
            return this.angle;
        }

        public void SetAngle(float angleDegrees)
        {
            this.angle = angleDegrees;
        }

        public void RotateBy(float angleDegrees)
        {
            this.angle += angleDegrees;
        }

        public void MoveAtAngle(float distance, float angleDegrees)
        {
            float xAngle = (float)(distance * Math.Cos(angleDegrees * Math.PI / 180));
            float yAngle = (float)(distance * Math.Sin(angleDegrees * Math.PI / 180));
            this.position.SetValues(xAngle, yAngle);
        }

        public void MoveForward(float distance)
        {
            this.MoveAtAngle(distance, this.angle);
        }

        public Boolean Overlaps(Border other)
        {
            return this.brdr.Overlaps(other);
        }

        public void SetPhysics(float accValue, float maxSpeed, float decValue)
        {
            this.phys.SetValues(accValue, maxSpeed, decValue);
            this.phys.SetPositionVector(this.position);
        }

        public void SetBoundingBorder(float width, float height)
        {
            this.boundBorder = new Border(width / 2, height / 2, width, height);
        }

        public void SetWrapBorder(float width, float height)
        {
            this.wrapBorder = new Border(width / 2, height / 2, width, height);
        }

        public void SetDestroyBorder(float width, float height)
        {
            this.destroyBorder = new Border(width / 2, height / 2, width, height);
        }

        public void boundWithinBorder(float worldWidth, float worldHeight)
        {
            if (this.position.GetXCoord() - this.brdr.GetWidth() / 2 < 0)
                this.position.SetXCoord(this.brdr.GetWidth() / 2);

            if (this.position.GetXCoord() + this.brdr.GetWidth() / 2 > worldWidth)
                this.position.SetXCoord(worldWidth - this.brdr.GetWidth() / 2);

            if (this.position.GetYCoord() - this.brdr.GetHeight() / 2 < 0)
                this.position.SetYCoord(this.brdr.GetHeight() / 2);

            if (this.position.GetYCoord() + this.brdr.GetHeight() / 2 > worldHeight)
                this.position.SetYCoord(worldHeight - this.brdr.GetHeight() / 2);
        }

        public void wrapAroundBorder(float worldWidth, float worldHeight)
        {
            if (this.position.GetXCoord() + this.brdr.GetWidth() / 2 < 0)
                this.position.SetXCoord(worldWidth + this.brdr.GetWidth() / 2);

            if (this.position.GetXCoord() - this.brdr.GetWidth() / 2 > worldWidth)
                this.position.SetXCoord((this.brdr.GetWidth() / 2) * -1);

            if (this.position.GetYCoord() + this.brdr.GetHeight() / 2 < 0)
                this.position.SetYCoord(worldHeight + this.brdr.GetHeight() / 2);

            if (this.position.GetYCoord() - this.brdr.GetHeight() / 2 > worldHeight)
                this.position.SetYCoord((this.brdr.GetHeight() / 2) * -1);
        }

        public void destroyOutsideBorder(float worldWidth, float worldHeight)
        {
            if ((this.position.GetXCoord() + this.brdr.GetWidth() / 2 < 0) ||
                (this.position.GetXCoord() - this.brdr.GetWidth() / 2 > worldWidth) ||
                (this.position.GetYCoord() + this.brdr.GetHeight() / 2 < 0) ||
                (this.position.GetYCoord() - this.brdr.GetHeight() / 2 > worldHeight))
                this.SetGroupNull();


        }

        public void SetGroup(Group g)
        {
            this.parentGroup = g;
        }

        public void SetGroupNull()
        {
            this.parentGroup = null;
        }

        public Texture GetTexture()
        {
            return this.img;
        }

        public Vector GetPosition()
        {
            return this.position;
        }

        public void SetAnimation()
        {

        }

        public void Update(float deltaTime)
        {
            if(this.phys != null)
            {
                this.phys.Update(deltaTime);
            }

            if(this.boundBorder != null)
            {
                this.boundWithinBorder(this.boundBorder.GetWidth(), this.boundBorder.GetHeight());
            }

            if (this.wrapBorder != null)
            {
                this.boundWithinBorder(this.wrapBorder.GetWidth(), this.wrapBorder.GetHeight());
            }

            if (this.destroyBorder != null)
            {
                this.boundWithinBorder(this.destroyBorder.GetWidth(), this.destroyBorder.GetHeight());
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.GetTexture().GetImg(), this.GetPosition().GetXCoord(), this.GetPosition().GetYCoord());
        }

        public void Destroy()
        {
            this.parentGroup.RemoveSprite(this);
        }
    }
}
