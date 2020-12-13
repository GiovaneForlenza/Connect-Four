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
    class PlayerTwo : Player
    {
        public PlayerTwo(Microsoft.Xna.Framework.Game game, GameScene parent) : base(game, parent)
        {
        }

        /// <summary>
        /// Creates a new token with the property "useRedTexture" false, so that the token will use the yellow texture
        /// </summary>
        public override void CreateNewToken()
        {
            if (PlayerEnabled)
            {
                lastCreated = new Token(Game, false);
                this.parent.AddComponent(lastCreated);
            }
        }
    }
}
