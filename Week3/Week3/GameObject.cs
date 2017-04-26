
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class GameObject
    {
        protected Texture2D texture;
        public Vector2 position = Vector2.Zero;
        public Vector2 scale = new Vector2(1, 1);
        protected float rotation;
        public Vector2 origin
        {
            get
            {
                return new Vector2(scale.X * (texture.Width / 2), scale.Y * (texture.Height / 2));
            }
        }

        public GameObject(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, origin: origin, rotation: rotation, scale: scale);
        }
        
        public Rectangle GetBoundingBox()
        {
            Rectangle rect = new Rectangle();
            rect.X = (int)(position.X - scale.X * (texture.Width / 2));
            rect.Y = (int)(position.Y - scale.Y * (texture.Height / 2));
            rect.Height = texture.Height;
            rect.Width = texture.Width;

            return rect;
        } 
    }
}
