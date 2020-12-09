﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class HelpTextComponent : DrawableGameComponent
    {
        Texture2D texture;

        public HelpTextComponent(Game game) : base(game)
        {
            
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = Game.Services.GetService<SpriteBatch>();

            spriteBatch.Begin();
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        

        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>("Images/helpImage");
            base.LoadContent();
        }
    }
}
