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
    class CreditTextComponent : DrawableGameComponent
    {
        SpriteFont regularFont;
        private Color hilightColor = Color.Black;
        private Vector2 startingPosition;
        private string creditMessage;
        public CreditTextComponent(Game game) : base(game)
        {
            creditMessage = ($"Connect Four game\n" +
                $"Designed and coded by: \n" +
                $"Daniel Moore, Student number: 8657587,\n" +
                $"Giovane Forlenza, Student number: 8651239\n" +
                $"Board and chips desing: Authoral\n" +
                $"Menu design: Professor Aneta Canhoto\n" +
                $"Win animation Sprite Sheet: \n" +
                $"\"https://tenor.com/view/kermit-dance- \n " +
                $"fresh-happy-dance-move-gif-15781456\"\n"  +
                $"Icon: \"https://loading.io/icon/1t0dg \"\n" +
                $"Sound Effect: \"https://www.zapsplat.com/music/ \n" +
                $"game-tone-short-digital-generic-could-be-collect-item-1/ \"");            
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
