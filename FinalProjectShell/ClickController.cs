using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class ClickController : GameComponent
    {
        MouseState ms;

        public ClickController(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }
        internal static void Clicked(MouseState ms)
        {
            Console.WriteLine(ms.X);

        }
    }
}
