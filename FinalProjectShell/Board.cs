using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class Board : DrawableGameComponent
    {
        Texture2D boardTexture;

        public Board(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        Vector2 boardPosition;



        protected override void LoadContent()
        {
            boardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Board_Full");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            boardPosition = new Vector2(0, 100);

            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                ClickController.Clicked(ms);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.Draw(boardTexture, boardPosition, Microsoft.Xna.Framework.Color.White);
            sb.End();
            base.Draw(gameTime);
        }
    }
}
