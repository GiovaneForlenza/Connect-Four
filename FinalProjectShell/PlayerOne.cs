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
    class PlayerOne : DrawableGameComponent
    {
        Texture2D Image { get; }
        Vector2 positionX;
        Vector2 positionY;
        
        public PlayerOne(Game game) : base(game)
        {
        }
    }
}
