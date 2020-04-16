using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Centipede
{
    class FirePatterns : GameObjectList
    {
        public GameObjectList bullets = new GameObjectList();
        public GameObjectList playerbullets = new GameObjectList();
        public GameObjectList bombs = new GameObjectList();
        Weapons weapon;




        public FirePatterns()
        {
            weapon = new Weapons();
            this.Add(weapon);
            this.Add(bullets);
            this.Add(bombs);
            this.Add(playerbullets);
            SoundEffect.MasterVolume = 0.05f;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
          
        }


        public void Pattern1(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, 0, 5));

        }

        public void Pattern2(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            for (int i = 0; i < 5; i++)
            {
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, -24 + (12 * i), 5));

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
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, i, 5));
            }

        }

        public void PlayerShot(Vector2 AngularDirection, Vector2 Position)
        {

            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
            if (weapon.shotgun)
            {
                for (int i = 0; i < 6; i++)
                {                   
                    playerbullets.Add(new Bullet("Sprites/spr_player_bullets", AngularDirection, Position, -4 + (2 * i), 25));
                }
                
            }
            if (!weapon.shotgun)
            {
                playerbullets.Add(new Bullet("Sprites/spr_player_bullets", AngularDirection, Position, weapon.offsetAngle, 25));
            }
        }


        public void EnemyShot(Vector2 AngularDirection, Vector2 Position)
        {
            Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
           
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, 0, 5));

            
        }

        public void EnemyShotGun(Vector2 AngularDirection, Vector2 Position)
        {
            for (int i = 0; i < 5; i++)
            {
                bullets.Add(new Bullet("Sprites/Bullet", AngularDirection, Position, -24 + (12 * i), 5));

            }

        }
    }



}
