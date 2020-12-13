using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.GameComponents
{
    class HelpTextComponent : DrawableGameComponent
    {
        SpriteFont regularFont;
        private Color hilightColor = Color.Black;
        private Vector2 startingPosition;
        private string creditMessage;
        public HelpTextComponent(Game game) : base(game)
        {
            creditMessage =    ($"           Connect Four game instructions:\n" +
                                $"          The goal of the game is to align\n" +
                                $"            4 chips of the same color\n" +
                                $"           It could be horizontally, vertically\n" +
                                $"              or diagonally align.\n" +
                                $"  The game ends when one of the players manage\n " +
                                $"           to align 4 of their chips color\n" +
                                $"\n\n" +
                                $"               How to control the game:\n" +
                                $"    Move the chip with your mouse and press the\n" +
                                $"                Left Mouse Click to drop it\n" +
                                $"   onto the desired position, but be carefull,\n" +
                                $"            there are no takesies backsies.\n" +
                                $"\n\n" +
                                $"Press \"Esc\" to go back to the main menu. Have fun!");
        }

        protected override void LoadContent()
        {
            regularFont = Game.Content.Load<SpriteFont>(@"Fonts\hilightFont");
            base.LoadContent();
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            startingPosition = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - regularFont.MeasureString(creditMessage).X / 2,
                                      Game.GraphicsDevice.Viewport.Height / 2 - regularFont.MeasureString(creditMessage).Y / 2);
            sb.Begin();
            sb.DrawString(regularFont, creditMessage, startingPosition, hilightColor);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
