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
    class GameScene : Scene
    {
        ContentManager content;
        int numEnemies = 20;
        Player player;
        List<Enemy> enemies = new List<Enemy>();
        internal static List<Missile> missiles = new List<Missile>();

        public GameScene(ContentManager content)
        {
            this.content = content;
        }

        public override void LoadContent(GameWindow window)
        {
            player = new Player(content);
            player.position = new Vector2(window.ClientBounds.Width / 2, window.ClientBounds.Height - player.GetBoundingBox().Height * 2);
            for (int i = 0; i < numEnemies; i++)
            {
                Enemy enemy = new Enemy(content);
                enemy.position = new Vector2(20 + 40 * i, 20);
                enemies.Add(enemy);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                SpaceInvaders.LoseGame();
            }

            player.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Missile Missile = new Missile(content, true);
                Missile.position = player.position;
                missiles.Add(Missile);
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }

            foreach (Missile missile in missiles)
            {
                missile.Update(gameTime);
                List<Enemy> deadEnemies = new List<Enemy>();
                if (missile.IsPlayerMissile)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        if (missile.GetBoundingBox().Intersects(enemy.GetBoundingBox()))
                        {
                            deadEnemies.Add(enemy);
                        }
                    }
                }
                else
                {
                    if (missile.GetBoundingBox().Intersects(player.GetBoundingBox()))
                    {
                        SpaceInvaders.LoseGame();
                    }
                }
                foreach (Enemy deadEnemy in deadEnemies)
                {
                    enemies.Remove(deadEnemy);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (Missile missile in missiles)
            {
                missile.Draw(spriteBatch);
            }
        }
    }
}
