﻿using Microsoft.Xna.Framework;
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
    class TitleScene : Scene
    {
        ContentManager content;
        SpriteFont font;
        Vector2 titlePos;
        Vector2 buttonPos;
        String titleText = "Not a Space Invaders Clone";
        String buttonText = "Start the non-Clone";
        float titleScale = 2;
        Texture2D cursor;
        Vector2 cursorOffset;
        Rectangle buttonRect;

        public TitleScene(ContentManager content)
        {
            this.content = content;
        }

        public override void LoadContent(GameWindow window)
        {
            font = content.Load<SpriteFont>("spriteFont");
            cursor = content.Load<Texture2D>("player");

            titlePos = new Vector2(
                (window.ClientBounds.Size.X - titleScale * font.MeasureString(titleText).X) / 2,
                window.ClientBounds.Size.Y / 4
                );

            buttonPos = new Vector2(
                (window.ClientBounds.Size.X - font.MeasureString(buttonText).X) / 2,
                3 * window.ClientBounds.Size.Y / 4
                );

            buttonRect = new Rectangle(buttonPos.ToPoint(), font.MeasureString(buttonText).ToPoint());
            cursorOffset = new Vector2(16, 16);
        }

        public override void Update(GameTime gametime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && buttonRect.Contains(Mouse.GetState().Position))
            {
                SpaceInvaders.StartGame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, titleText, titlePos, Color.Yellow, 0, Vector2.Zero, titleScale, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, buttonText, buttonPos, Color.WhiteSmoke, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(cursor, Mouse.GetState().Position.ToVector2() - cursorOffset, Color.White);
        }
    }
}
