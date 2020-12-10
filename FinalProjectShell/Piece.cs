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
    class Piece : DrawableGameComponent
    {
        Texture2D texture;
        Vector2 position;
        public Piece(Microsoft.Xna.Framework.Game game, Texture2D texture, Vector2 position) : base(game)
        {
            this.texture = texture;
            this.position = position;
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
