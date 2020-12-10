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
        int gridSizeX;
        int gridSizeY;
        int tileSizeX, tileSizeY;
        Texture2D tileTexture;
        bool print = true;
        public Board(Microsoft.Xna.Framework.Game game) : base(game)
        {
            tileSizeX = 90;
            tileSizeY = 80;
            gridSizeX = Game.GraphicsDevice.Viewport.Width / tileSizeX;
            gridSizeY = Game.GraphicsDevice.Viewport.Height / tileSizeY;
        }

        Vector2 boardPosition;



        protected override void LoadContent()
        {
            boardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Board_Full");
            tileTexture = Game.Content.Load<Texture2D>(@"Images\Assets\grid");
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
            for (float i = 0.9f; i < gridSizeX; ++i)
            {
                for (float j = 2.1f; j < gridSizeY; ++j)
                {
                    sb.Draw(tileTexture, new Microsoft.Xna.Framework.Rectangle(int.Parse((i * tileSizeX).ToString()), int.Parse((j * tileSizeY).ToString())
                        , tileSizeX, tileSizeY), Microsoft.Xna.Framework.Color.White);
                    if (print)
                    {

                    System.Console.WriteLine(i*tileSizeX + ", " + j*tileSizeY);
                    }
                }
            }
            print = false;
            sb.End();
            base.Draw(gameTime);
        }
    }
}
