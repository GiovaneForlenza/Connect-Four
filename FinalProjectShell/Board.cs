using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class Board : DrawableGameComponent
    {
        Texture2D lightBoardTexture;
        int gridSizeX, gridSizeY;
        int windowSizeX, windowSizeY;
        int tileSizeX, tileSizeY;
        const int ROWS = 7, COLS = 6;
        Texture2D tileTexture;
        bool print = true;

        bool playerWon = false;
        public static string winner;
        List<Token> winnersTokens;

        Player activePlayer;
        int counter;

        bool playing = true;

        MouseState pvMouseS;

        int[,] boardArray = new int[ROWS, COLS];
        Vector2[,] boardPositionArray = new Vector2[ROWS, COLS];

        Vector2 boardPosition;

        public Board(Game game) : base(game)
        {
            tileSizeX = 70;
            tileSizeY = 70;
            windowSizeX = Game.GraphicsDevice.Viewport.Width;
            windowSizeY = Game.GraphicsDevice.Viewport.Height;
            gridSizeX = windowSizeX / tileSizeX;
            gridSizeY = windowSizeY / tileSizeY;
            activePlayer = Game.Services.GetService<PlayerOne>();
            activePlayer.PlayerEnabled = true;
            counter++;
        }


        public override void Initialize()
        {
            SetBoardArrayEmpty();
            activePlayer.CreateNewToken();
            //DisplayBoard();
            FillPositionArray();
            DrawOrder = int.MaxValue - 1;
            winnersTokens = new List<Token>();
            base.Initialize();
        }

        public void SetBoardArrayEmpty()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLS; column++)
                {
                    boardArray[row, column] = 0;
                }
            }
        }

        protected override void LoadContent()
        {
            lightBoardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\light-board");
            tileTexture = Game.Content.Load<Texture2D>(@"Images\Assets\grid");
            //Game.Services.GetService<PlayerOne>();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (playing)
            {
                boardPosition = new Vector2(0, 100);

                MouseState ms = Mouse.GetState();
                if (!playerWon)
                {

                    if (ms.LeftButton == ButtonState.Pressed && pvMouseS.LeftButton == ButtonState.Released
                        && ms.X >= 0 && ms.X <= Game.GraphicsDevice.Viewport.Width
                        && ms.Y >= 0 && ms.Y <= Game.GraphicsDevice.Viewport.Height)
                    {
                        PlayPosition(ms.X);
                    }
                }
                pvMouseS = Mouse.GetState();
                base.Update(gameTime);
            }
        }
            private void PlayPosition(int position)
            {
                int playedPosition = position;
                if (playedPosition >= 40 && playedPosition <= 110) playedPosition = 0;
                else if (playedPosition >= 136 && playedPosition <= 206) playedPosition = 1;
                else if (playedPosition >= 226 && playedPosition <= 296) playedPosition = 2;
                else if (playedPosition >= 316 && playedPosition <= 386) playedPosition = 3;
                else if (playedPosition >= 406 && playedPosition <= 476) playedPosition = 4;
                else if (playedPosition >= 496 && playedPosition <= 566) playedPosition = 5;
                else if (playedPosition >= 586 && playedPosition <= 656) playedPosition = 6;

                int placePosition = -1;
                if (playedPosition == 0 || playedPosition == 1 || playedPosition == 2 ||
                    playedPosition == 3 || playedPosition == 4 || playedPosition == 5 || playedPosition == 6)
                {

                    for (int i = 0; i < COLS; i++)
                    {
                        if (i != COLS - 1)
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
                    boardArray[playedPosition, placePosition] = activePlayer is PlayerOne ? 1 : 2;


                    activePlayer.DropToken(boardPositionArray[playedPosition, placePosition]);
                    SwitchActivePlayer();

                }

                //Check Win
                counter++;
                if (counter >= 7)
                {
                    CheckForWin(activePlayer);
                } else if (counter == 45)
                {
                    Console.WriteLine("NO WINNER");
                }
                //Console.WriteLine(boardArray[0, 0] + ", " + counter);
                DisplayBoard();
            }

            public void SwitchActivePlayer()
            {
                if (activePlayer != null)
                {
                    activePlayer.PlayerEnabled = false;
                }

                if (activePlayer is PlayerOne)
                {
                    activePlayer = Game.Services.GetService<PlayerTwo>();
                } else
                {
                    activePlayer = Game.Services.GetService<PlayerOne>();
                }
                activePlayer.PlayerEnabled = true;
                activePlayer.CreateNewToken();
            }

            void PlacePiece(int playedPosition, int placePosition)
            {

            }

            public void DisplayBoard()
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
            sb.Draw(lightBoardTexture, boardPosition, Microsoft.Xna.Framework.Color.White);
            print = false;
            sb.End();
            base.Draw(gameTime);
        }

        private void FillPositionArray()
        {
            int xOffset = 20;
            int yOffset = 10;
            int countSquares = 0;
            int boardOffsetX = 100;
            int boarfOffsetY = 50;
            int xStartPos = 45;
            int yStartPos = 135;
            int row = 0, col = 0;
            for (int i = xStartPos; i < windowSizeX - boardOffsetX; i += tileSizeX)
            {
                for (int j = yStartPos; j < windowSizeY - boarfOffsetY; j += tileSizeY)
                {
                    if (countSquares == 42) break;
                    countSquares++;
                    boardPositionArray[row, col] = new Vector2(i, j);
                    col++;
                    j += yOffset;
                }
                col = 0;
                row++;
                i += xOffset;
            }
        }

        private void CheckForWin(Player player)
        {
            int check = 0;
            switch (player)
            {
                case PlayerOne: check = 2; break;
                case PlayerTwo: check = 1; break;
            }
            for (int i = 0; i < 6; i++)
            {
                CheckRows(i, check);
            }
            for (int i = 0; i < 7; i++)
            {
                CheckCols(i, check);
            }
            CheckDiagonals(2, 0, check);
            CheckDiagonals(1, 0, check);
            CheckDiagonals(0, 0, check);
            if (playerWon)
            {
                if (check == 1) winner = "player one";
                else winner = "player two";
                ResetStart();
                ShowWinScreen();

            }
        }

        private void ShowWinScreen()
        {
            ((ConnectFourGame)Game).HideAllScenes();
            Game.Services.GetService<WinScene>().Show();
        }

        private void ResetStart()
        {
            activePlayer = Game.Services.GetService<PlayerTwo>();
            SwitchActivePlayer();
            RemoveTokens();
            SetBoardArrayEmpty();
            playerWon = false;
            playing = true;
        }

        private void RemoveTokens()
        {
            for (int i = Game.Components.ToList().Count() - 2; i > 1; i--)
            {
                if (Game.Components.ElementAt(i) is Token)
                {
                    Game.Components.RemoveAt(i);

                }
            }
            playerWon = false;
        }

        private void GetWinnerTokens()
        {
            foreach (GameComponent item in Game.Components)
            {
                if (item is Token)
                {
                    Token dummy = item as Token;
                    //Console.WriteLine(dummy.position);
                }
                Console.WriteLine(item.ToString());
            }
        }

        private void CheckCols(int col, int check)
        {
            for (int i = 0; i < 3; i++)
            {
                if (boardArray[col, i] == check && boardArray[col, i + 1] == check &&
                   boardArray[col, i + 2] == check && boardArray[col, i + 3] == check)
                {
                    playerWon = true;
                    Console.WriteLine("WINNER FUCK COLIA");
                    playing = false;
                    return;
                }
            }
        }

        private void CheckDiagonals(int row, int col, int check)
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardArray[col + 0 + i, row + 0] == check &&
                   boardArray[col + 1 + i, row + 1] == check &&
                   boardArray[col + 2 + i, row + 2] == check &&
                   boardArray[col + 3 + i, row + 3] == check)
                {
                    playerWon = true;
                    Console.WriteLine("WINNER FUCK DIE");

                    playing = false;
                    return;
                }
            }
        }

        private void CheckForwardDiagonals(int row, int col, int check)
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardArray[col + 0 + i, row - 0] == check &&
                   boardArray[col + 1 + i, row - 1] == check &&
                   boardArray[col + 2 + i, row - 2] == check &&
                   boardArray[col + 3 + i, row - 3] == check)
                {
                    Console.WriteLine("WINNER FUCK DIE BACK");
                    playing = false;
                    return;
                }
            }
        }

        private void CheckRows(int row, int check)
        {
            for (int i = 0; i < 4; i++)
            {
                if (boardArray[i, row] == check && boardArray[i + 1, row] == check &&
                   boardArray[i + 2, row] == check && boardArray[i + 3, row] == check)
                {
                    playerWon = true;
                    Console.WriteLine("WINNER FUCK YEA");
                    playing = false;
                    return;
                }
            }

        }

        private void ShowTotals()
        {
            int zero = 0, one = 0, two = 0;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    switch (boardArray[i, j])
                    {
                        case 0: zero++; break;
                        case 1: one++; break;
                        case 2: two++; break;
                    }
                }
            }

            Console.WriteLine("zero: " + zero);
            Console.WriteLine("one: " + one);
            Console.WriteLine("two: " + two);
        }
    }
}
