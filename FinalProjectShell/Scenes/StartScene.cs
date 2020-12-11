using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{    

    public class StartScene : GameScene
    {
        public StartScene(Microsoft.Xna.Framework.Game game): base(game)
        {          
        }

        public override void Initialize()
        {
            // create and add any components that belong to this scene
            AddComponent(new MenuComponent(Game));

            base.Initialize();
        }
        
    }
}
