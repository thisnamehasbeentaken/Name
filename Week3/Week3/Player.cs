using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class Player : GameObject
    {
        public Player(ContentManager content) : base(content)
        {
            texture = content.Load<Texture2D>("player");

            rotation = MathHelper.ToRadians(270);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 4;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 4;
            }
        }
    }
}
