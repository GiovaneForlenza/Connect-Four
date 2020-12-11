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


        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            if (Enabled)
            {
                // create a new token
                // save it to a last toeken created placeholder before adding it as a component
                lastCreated = new Token(Game, true);
                //this.parent.AddComponent(lastCreated);

            } else
            {
                // tell that last token to lerp (which will move sideways to fit the row, and then down to posiotion
                // then the teoke will set its own enabled to false
                // then in the playaser set last token reference to null
                lastCreated = null;
            }

            base.OnEnabledChanged(sender, args);
        }

    }
}
