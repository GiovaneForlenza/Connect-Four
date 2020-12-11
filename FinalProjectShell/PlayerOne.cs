using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FinalProject
{
    class PlayerOne : Player
    {        
        public PlayerOne(Game game, GameScene parent) : base(game, parent)
        {
        }

        public override void CreateNewToken()
        {
           if(PlayerEnabled)
            {
                lastCreated = new Token(Game, true);
                this.parent.AddComponent(lastCreated);
            }
        }

        




    }
}
