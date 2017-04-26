using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Week3
{
    class Enemy : GameObject
    {
        static Random rnd = new Random();
        ContentManager content;
        int speed = 3;
        public Enemy(ContentManager content) : base(content)
        {
            this.content = content;
            texture = content.Load<Texture2D>("enemy");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (rnd.Next(1500) == 27)
            {
                Missile missile = new Missile(content, false);
                missile.position = position;
                GameScene.missiles.Add(missile);
            }

            position.X += speed;
            if (position.X > 800)
            {
                speed *= -1;
            }
            if (position.X < 0)
            {
                speed *= -1;
            }
            position.Y += speed;
            if (position.Y > 800)
            {
                speed--;
                position.Y++; 
            }
        }
    }
}
