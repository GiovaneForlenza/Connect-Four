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
    public enum PlayerActive
    {
        Active = 0,
        Inactive = 1
    }

    // public class Player : GameComponent

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

        public abstract void CreateNewToken();

       public void DropToken(Vector2 tokenRestingPositon)
        {
            lastCreated.MoveTokenToRestingPosition(tokenRestingPositon);
            lastCreated = null;
        }






    }
}
