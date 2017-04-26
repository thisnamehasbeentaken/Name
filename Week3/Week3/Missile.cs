using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class Missile : GameObject
    {
        public bool IsPlayerMissile;

        public Missile(ContentManager content, bool isPlayerMissile) : base(content)
        {
            IsPlayerMissile = isPlayerMissile;
            texture = content.Load<Texture2D>("clash2");

            scale = new Vector2(.25f, .25f);
            rotation = MathHelper.ToRadians(270);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (IsPlayerMissile)
            {
                position.Y -= 10;
            }
            else
            {
                position.Y += 10;
            }
        }
    }
}
