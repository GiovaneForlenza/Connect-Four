using System;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class DarkBoard : DrawableGameComponent
    {
        public DarkBoard(Game game) : base(game)
        {
        }
        Texture2D darkBoardTexture;
        private Vector2 boardPosition;

        public override void Initialize()
        {
            DrawOrder = int.MaxValue - 3;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            darkBoardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\dark-board");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            boardPosition = new Vector2(0, 100);            
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();
            sb.Begin();
            sb.Draw(darkBoardTexture, boardPosition, Microsoft.Xna.Framework.Color.White);
            
            sb.End();
            base.Draw(gameTime);
        }
    }
}
