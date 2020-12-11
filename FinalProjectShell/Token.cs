using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class Token : DrawableGameComponent
    {
        static Texture2D playerOneTexture;
        static Texture2D playerTwoTexture;
        Texture2D texture;
        bool playerOneActive;

        Vector2 position;
        public Token(Microsoft.Xna.Framework.Game game, bool playerOneActive) : base(game)
        {
            // this.texture = texture;
            this.playerOneActive = playerOneActive;
        }

        protected override void LoadContent()
        {
            // if null, load the textures
            if (playerOneTexture == null)
            {
                playerOneTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Red");
                playerTwoTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Yellow");
            }

            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            texture = playerOneActive ? playerOneTexture : playerTwoTexture;
            MouseState ms = Mouse.GetState();
            position = new Vector2(ms.X - texture.Width / 2, 10);

            position.X = MathHelper.Clamp(position.X, 40, Game.GraphicsDevice.Viewport.Width - texture.Width - 40);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            texture = playerOneActive ? playerOneTexture : playerTwoTexture;
            // based on which player you belong to, draw player1Texture or player2Texture

            sb.Draw(texture, position, Microsoft.Xna.Framework.Color.White);

            sb.End();

            base.Draw(gameTime);
        }
    }
}
