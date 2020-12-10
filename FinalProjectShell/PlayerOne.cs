using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FinalProject
{
    class PlayerOne : DrawableGameComponent
    {
        Texture2D texture;
        Vector2 position;
        
        public PlayerOne(Game game) : base(game)
        {
        }

        public PlayerOne(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(@"Images\Assets\Red");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            position = new Vector2(ms.X - texture.Width/2, 10);
            position.X = MathHelper.Clamp(position.X, 40, GraphicsDevice.Viewport.Width - texture.Width - 40);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.Draw(texture, position, Microsoft.Xna.Framework.Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
