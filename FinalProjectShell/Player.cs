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

    public class Player : GameComponent
    {
        public Player(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }
    }
}
