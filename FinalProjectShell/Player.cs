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
    public abstract class Player : GameComponent
    {

        protected GameScene parent;
        protected Token lastCreated;

        public bool PlayerEnabled { get; set; }
        public Player(Game game, GameScene parent) : base(game)
        {
            this.parent = parent;
            PlayerEnabled = false;
        }

        /// <summary>
        /// Sets the lastCreated to a token with the same color as the active player
        /// Add lastCreated to the game services
        /// </summary>
        public abstract void CreateNewToken();

        /// <summary>
        /// Sets the restingPosition of the token to be the needed for the animation to work
        /// </summary>
        /// <param name="tokenRestingPositon"></param>
        public void DropToken(Vector2 tokenRestingPositon)
        {
            lastCreated.MoveTokenToRestingPosition(tokenRestingPositon);
            lastCreated = null;
        }






    }
}
