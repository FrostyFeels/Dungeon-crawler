using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Centipede
{
    class FirePatterns : GameObjectList
    {
        public GameObjectList bullets = new GameObjectList();
        public GameObjectList playerbullets = new GameObjectList();
        public GameObjectList bombs = new GameObjectList();




        public FirePatterns()
        {
            this.Add(bullets);
            this.Add(bombs);
            this.Add(playerbullets);
            SoundEffect.MasterVolume = 0.05f;
        }



        public void Pattern1(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, 0, true ));

        }

        public void Pattern2(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            for (int i = 0; i < 5; i++)
            {
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, -12 + (6 * i), true));

            }

        }

        public void Pattern3(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("sounds/BulletsSound");

            bombs.Add(new Bombs(AngularDirection, Position, 0));

        }

        public void Explosive(Vector2 AngularDirection, Vector2 Position)
        {
            this.Add(new Explosion(AngularDirection, Position, 0, true));
            Centipede.AssetManager.PlaySound("Sounds/ExplosionSound");
            for (int i = 0; i < 6; i++)
            {
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, i, true));
            }         
            
        }

        public void PlayerShot(Vector2 AngularDirection, Vector2 Position)
        {

            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            playerbullets.Add(new Bullet("Sprites/spr_player_bullets", AngularDirection, Position, 0, false));
        }
    }



}
