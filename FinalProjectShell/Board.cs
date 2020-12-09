using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    class Board : DrawableGameComponent
    {
        Texture2D boardTexture;

        public Board(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        Vector2 BoardPosition { get; }



        protected override void LoadContent()
        {
            boardTexture = Game.Content.Load<Texture2D>(@"Images\Assets\Board_Full");

            base.LoadContent();
        }
    }
}
