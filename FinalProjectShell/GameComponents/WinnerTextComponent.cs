using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FinalProject
{
    internal class WinnerTextComponent : DrawableGameComponent
    {
        SpriteFont regularFont;
        private Color hilightColor = Color.Red;
        private Vector2 startingPosition;
        private string winnerMessage;

        Texture2D kermitTextures;
        List<Rectangle> sourceRectangles;
        Vector2 kermitPosition; 
        int frameCount = 52;

        int currentFrame;
        double frameTimer;
        private int kermitWidth = 200;
        
        private int kermitHeight = 184;
        private SpriteEffects spriteEffects;
        const double FRAME_DURATION = 0.05;


        public WinnerTextComponent(Game game) : base(game)
        {
            sourceRectangles = new List<Rectangle>();
            spriteEffects = SpriteEffects.None;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            regularFont = Game.Content.Load<SpriteFont>(@"Fonts\hilightFont");
            kermitTextures = Game.Content.Load<Texture2D>(@"Images\kermitSprite");
            for(int i = 0; i < frameCount; i++)
            {
                Rectangle rect = new Rectangle(i * kermitWidth, 0, kermitWidth, kermitHeight);
                sourceRectangles.Add(rect);

            }
            kermitPosition = new Vector2(250, 350);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService<SpriteBatch>();

            winnerMessage = "Congratulations " + Board.winner + ", you won the game! \n\n\n\n Press \"Esc\" to go back to the main menu";
            startingPosition = new Vector2(Game.GraphicsDevice.Viewport.Width / 2 - regularFont.MeasureString(winnerMessage).X / 2,
                                      100 - regularFont.MeasureString(winnerMessage).Y / 2);
            sb.Begin();
            sb.Draw(kermitTextures, kermitPosition, sourceRectangles[currentFrame], Color.White,
                    0f, Vector2.Zero, 1f, spriteEffects, 0f);            
            sb.DrawString(regularFont, winnerMessage, startingPosition, hilightColor);
            sb.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            frameTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTimer >= FRAME_DURATION)
            {
                frameTimer = 0;
                currentFrame++;
            }
            if (currentFrame >= sourceRectangles.Count)
            {
                currentFrame = 0;
            }
            base.Update(gameTime);
        }
    }
}