using System.Collections;
using System.Drawing;

namespace BAGEL
{
    public class Group
    {
        private ArrayList spriteList;

        public Group()
        {
            this.spriteList = new ArrayList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void AddSprite(Sprite s)
        {
            s.SetGroup(this);
            this.spriteList.Add(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void RemoveSprite(Sprite s)
        {
            s.SetGroupNull();
            this.spriteList.Remove(s);
                
        }

        public ArrayList GetSpriteList()
        {
            return this.spriteList;
        }

        public int GetSpriteCount()
        {
            return this.spriteList.Count;
        }

        public void DrawSprites(Graphics g)
        {
            foreach (Sprite s in this.spriteList)
            {
                s.Draw(g);
            }
        }
    }
}
