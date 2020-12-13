using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace FinalProject
{
    internal class WinnerTextComponent : DrawableGameComponent
    {
        SpriteFont regularFont;
        private Color hilightColor = Color.Red;
        private Vector2 startingPosition;
        private string winnerMessage;

        public WinnerTextComponent(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            regularFont = Game.Content.Load<SpriteFont>(@"Fonts\hilightFont");
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            winnerMessage = "Congratulations " + Board.winner + ", you won the game! \n\n\n\n\n Press \"Esc\" to go back to the main menu";
            startingPosition = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - regularFont.MeasureString(winnerMessage).X / 2,
                                      Game.GraphicsDevice.Viewport.Height / 2 - regularFont.MeasureString(winnerMessage).Y / 2);
            

            sb.Begin();

            //for (int i = 0; i < menuItems.Count; i++)
            //{
            //    SpriteFont activeFont = regularFont;
            //    Color activeColor = regularColor;

            //    // if the selection is the item we are drawing
            //    // made it a the special font and colour
            //    if (selectedIndex == i)
            //    {
            //        activeFont = regularFont;
            //        activeColor = hilightColor;
            //    }


            //    // update the position of next string
            //    nextPosition.Y += regularFont.LineSpacing;
            //}
            sb.DrawString(regularFont, winnerMessage, startingPosition, hilightColor);

            sb.End();

            base.Draw(gameTime);
        }
    }
}