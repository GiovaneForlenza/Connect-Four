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
    class Board : DrawableGameComponent
    {
        Texture2D boardTexture;
        int gridSizeX, gridSizeY;
        int tileSizeX, tileSizeY;
        const int ROWS = 7, COLS = 6;
        Texture2D tileTexture;
        bool print = true;

        MouseState pvMouseS;

        int[,] boardArray = new int[ROWS, COLS];

        Vector2 boardPosition;

        public Board(Microsoft.Xna.Framework.Game game) : base(game)
        {
            tileSizeX = 90;
            tileSizeY = 80;
            gridSizeX = Game.GraphicsDevice.Viewport.Width / tileSizeX;
            gridSizeY = Game.GraphicsDevice.Viewport.Height / tileSizeY;

        }


        public override void Initialize()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLS; column++)
                {
                    boardArray[row, column] = 0;
                }
            }
            DisplayBoard();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            boardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Board_Full");
            tileTexture = Game.Content.Load<Texture2D>(@"Images\Assets\grid");
            //Game.Services.GetService<PlayerOne>();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            boardPosition = new Vector2(0, 100);

            MouseState ms = Mouse.GetState();
            //Console.WriteLine(ms.LeftButton == ButtonState.Released);
            if (ms.LeftButton == ButtonState.Pressed && pvMouseS.LeftButton == ButtonState.Released
                && ms.X >= 0 && ms.X <= Game.GraphicsDevice.Viewport.Width
                && ms.Y >= 0 && ms.Y <= Game.GraphicsDevice.Viewport.Height)
            {
                //ClickController.Clicked(ms);
                PlayPosition(ms.X);
            }
            pvMouseS = Mouse.GetState();
            base.Update(gameTime);
        }

        private void PlayPosition(int position)
        {
            //Console.WriteLine(x / tileSizeX);            
            //Console.WriteLine(position);
            int playedPosition = position;
            if (playedPosition >= 40 && playedPosition <= 110) playedPosition = 0;
            else if (playedPosition >= 136 && playedPosition <= 206) playedPosition = 1;
            else if (playedPosition >= 226 && playedPosition <= 296) playedPosition = 2;
            else if (playedPosition >= 316 && playedPosition <= 386) playedPosition = 3;
            else if (playedPosition >= 406 && playedPosition <= 476) playedPosition = 4;
            else if (playedPosition >= 496 && playedPosition <= 566) playedPosition = 5;
            else if (playedPosition >= 586 && playedPosition <= 656) playedPosition = 6;
            //Console.WriteLine(playedPosition);
            int placePosition = -1;
            if (playedPosition == 0 || playedPosition == 1 || playedPosition == 2 ||
                playedPosition == 3 || playedPosition == 4 || playedPosition == 5 || playedPosition == 6)
            {

                for (int i = 0; i < COLS; i++)
                {
                    if (i != COLS-1)
                    {
                        if (boardArray[playedPosition, i + 1] == 0)
                        {
                            placePosition = i + 1;
                        } else if (boardArray[playedPosition, i] == 0)
                        {
                            placePosition = i;
                        }
                    } else
                    {
                        if (boardArray[playedPosition, i] == 0)
                        {
                            placePosition = i;
                        }
                    }
                }
            }
            if (placePosition != -1)
            {
                boardArray[playedPosition, placePosition] = 1;
            }
            DisplayBoard();
            //Game.Components.Add
        }

        private void DisplayBoard()
        {
            for (int col = 0; col < COLS; col++)
            {
                for (int row = 0; row < ROWS; row++)
                {
                    Console.Write(boardArray[row, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
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

                        //System.Console.WriteLine(i * tileSizeX + ", " + j * tileSizeY);
                    }
                }
            }
            print = false;
            sb.End();
            base.Draw(gameTime);
        }
    }
}
