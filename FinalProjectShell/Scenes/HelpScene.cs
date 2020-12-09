﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class HelpScene : GameScene
    {
        public HelpScene(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            // create and add any components that belong to 
            // this scene to the Scene components list
            AddComponent(new HelpTextComponent(Game));
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            // handle the escape key for this scene
            if (ks.IsKeyDown(Keys.Escape))
            {
                ((Game1)Game).HideAllScenes();
                Game.Services.GetService<StartScene>().Show();
            }

            base.Update(gameTime);
        }


    }
}
