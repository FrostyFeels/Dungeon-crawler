using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Centipede
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Centipede : GameEnvironment
    {
        
        Song song;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1920, 1080);
            ApplyResolutionSettings();
            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.AddGameState("GameOver", new GameOver());
            GameStateManager.AddGameState("StartScherm", new StartScherm());
            GameStateManager.AddGameState("Tutorial", new Tutorial());
            GameStateManager.SwitchTo("StartScherm");





            this.song = Content.Load<Song>("Sounds/BackGroundMusic");
            MediaPlayer.Volume = 0.05f;
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            
            
       
            //effect = Content.Load<SoundEffect>("ExplosionSound");
            



            // TODO: use this.Content to load your game content here
        }

 

    }
}
