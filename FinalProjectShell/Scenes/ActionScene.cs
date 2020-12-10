
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class ActionScene : GameScene
    {
        public ActionScene(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            // create and add any components that belong to this scene
            // Add them by calling AddComponent(GameComponent component) 
            // method.  It will take care of adding the component to the 
            // game as well as keeping track of what belongs to it.


            this.AddComponent(new Board(Game));
            PlayerOne playerOne = new PlayerOne(Game);
            this.AddComponent(playerOne);
            Game.Services.AddService<PlayerOne>(playerOne);
            PlayerTwo playerTwo = new PlayerTwo(Game);
            this.AddComponent(playerTwo);
            Game.Services.AddService<PlayerTwo>(playerTwo);
            this.AddComponent(new ClickController(Game));

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            // handle the escape key for this scene
            if (ks.IsKeyDown(Keys.Escape))
            {
                ((Game)Game).HideAllScenes();
                Game.Services.GetService<StartScene>().Show();
            }

            base.Update(gameTime);
        }

    }
}
