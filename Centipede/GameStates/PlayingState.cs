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
    class PlayingState : GameObjectList
    {

        Vector2[] turretLocations = new Vector2[8];
        
        Vector2 location1 = new Vector2(100, 50);
        Vector2 location2 = new Vector2(960, 50);
        Vector2 location3 = new Vector2(960,1025);
        Vector2 location4 = new Vector2(100, 1025);
        Vector2 location5 = new Vector2(1850, 50);
        Vector2 location6 = new Vector2(1850, 1025);
        Vector2 location7 = new Vector2(100, 540);
        Vector2 location8 = new Vector2(1850, 540);

        

        int framecounter = 0;

        Player player;
        Score score;
     
        FirePatterns firepattern;
        LevelDesign leveldesign;
       
        GameObjectList turrets = new GameObjectList();
        public GameObjectList KillList = new GameObjectList();


        bool death = false;
        
     
        int turretAmount = 0;

        public PlayingState()
        {
           
            turretLocations[0] = location1;
            turretLocations[1] = location2;
            turretLocations[2] = location3;
            turretLocations[3] = location4;
            turretLocations[4] = location5;
            turretLocations[5] = location6;
            turretLocations[6] = location7;
            turretLocations[7] = location8;



            score = new Score();
            player = new Player("Sprites/Player");
            leveldesign = new LevelDesign();
            firepattern = new FirePatterns();



            this.Add(new SpriteGameObject("Sprites/BackGround"));
            this.Add(leveldesign);
            this.Add(turrets);  
            this.Add(firepattern);
            this.Add(player);
            this.Add(score);

            for (int i = 0; i < 8; i++)
			{
                turrets.Add(new Turret("Sprites/turret", turretLocations[i]));
                turretAmount++;
			}
            
         


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            framecounter++;


   
            foreach (Turret aturret in turrets.Children)
            {
                aturret.LookAt(player, 90);

                if (aturret.Fire(GameEnvironment.Random.Next(120,240))) 
                {                   
                    aturret.whichBullet = GameEnvironment.Random.Next(1, 5);
                    if (aturret.whichBullet == 1) 
                    {
                        firepattern.Pattern1(aturret.AngularDirection, aturret.Position);
                    }
                    if (aturret.whichBullet == 2)
                    {
                        firepattern.Pattern2(aturret.AngularDirection, aturret.Position);
                    }
                    if (aturret.whichBullet == 3)
                    {
                        firepattern.Pattern3(aturret.AngularDirection, aturret.Position);

                    }
                    if (aturret.whichBullet == 4)
                    {
                        firepattern.Pattern1(aturret.AngularDirection, aturret.Position);
                    }                 
                }

                if(player.shoot)
                {
                    firepattern.PlayerShot(player.AngularDirection, player.Position);
                }
                  
            }

            foreach (Bombs abomb in firepattern.bombs.Children)
            {
                if (abomb.Explode())
                {
                    firepattern.Explosive(abomb.AngularDirection, abomb.Position);
                    KillList.Add(abomb);
                }

            }
            foreach (Bullet aPlayerBullet in firepattern.playerbullets.Children)
            {
                foreach (Turret aturret in turrets.Children)
                {
                    if (aPlayerBullet.CollidesWith(aturret))
                    {
                        aturret.hit = true ;
                        aPlayerBullet.Position = new Vector2(-1000, 1000);
                        KillList.Add(aPlayerBullet);
                    }
                }
            }

            foreach (Bullet abullet in firepattern.bullets.Children)
            {
                if(abullet.lifeTime >= 600)
                {
                    KillList.Add(abullet);
                }

                if(abullet.CollidesWith(player))
                {
                    death = true;
                }

            }

            foreach (var aobject in KillList.Children)
            {
                firepattern.bullets.Remove(aobject );
                firepattern.bombs.Remove(aobject);
                firepattern.playerbullets.Remove(aobject);

            }


            if (death)
            {
                firepattern.bullets.Children.Clear();
                firepattern.bombs.Children.Clear();
                player.Reset();
                GameEnvironment.GameStateManager.SwitchTo("GameOver");
                death = false;
            }
        }


    }
}
