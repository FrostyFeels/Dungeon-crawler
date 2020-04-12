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
        Vector2 location3 = new Vector2(960, 1025);
        Vector2 location4 = new Vector2(100, 1025);
        Vector2 location5 = new Vector2(1850, 50);
        Vector2 location6 = new Vector2(1850, 1025);
        Vector2 location7 = new Vector2(100, 540);
        Vector2 location8 = new Vector2(1850, 540);

        

        int framecounter = 0;
        

        Player player;
        Score score;
        MouseCursors mouse;
        Weapons weapon;
        
        

        FirePatterns firepattern;
        public LevelDesign rightWall;

        public GameObjectList turrets = new GameObjectList();
        public GameObjectList KillList = new GameObjectList();
        public GameObjectList enemies = new GameObjectList();
       /* SpriteGameObject truewall = new SpriteGameObject("Sprites/spr_mouse");
        SpriteGameObject trueplayer = new SpriteGameObject("Sprites/spr_mouse");
*/

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
            mouse = new MouseCursors();
            weapon = new Weapons();
            player = new Player("Sprites/Player");
      

            // leftWall = new LevelDesign(6, 11);
            rightWall = new LevelDesign(30, 17);




            firepattern = new FirePatterns();


            this.Add(weapon);
            this.Add(new SpriteGameObject("Sprites/BackGround"));           
            this.Add(rightWall);        
            this.Add(turrets);
            this.Add(firepattern);
            this.Add(player);
            this.Add(score);
            this.Add(mouse);
            this.Add(enemies);
            /*this.Add(trueplayer);
            this.Add(truewall);*/
           

            for (int i = 0; i < 8; i++)
            {
                turrets.Add(new Turret("Sprites/turret", turretLocations[i]));
                turretAmount++;
            }

            for (int i = 0; i < 3; i++)
            {
                enemies.Add(new Enemies(rightWall.gridWall[GameEnvironment.Random.Next(5,10),GameEnvironment.Random.Next(5,10)].Position));
            }

            


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           
            framecounter++;
            player.LookAt(mouse);

            if (player.hp == 0)
            {
                death = true;
            }
            

            /*   trueplayer.Position = player.truePlayer;
               truewall.Position = player.trueWall;*/


            foreach (Turret aturret in turrets.Children)
            {
                aturret.LookAt(player, 90);

                if (aturret.Fire(GameEnvironment.Random.Next(120, 240)))
                {
                    aturret.whichBullet = GameEnvironment.Random.Next(1,                                   5);
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

                if (player.shoot)
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
                        aturret.hit = true;
                       
                      
                        
                        
                        
                     
                        KillList.Add(aPlayerBullet);
                    }
                }
            }

            foreach (Turret aturret in turrets.Children)
            {
                if(aturret.hit)
                {
                    score.getScore++;
                }
            }






            foreach (Wall awall in rightWall.gridWall)
            {

                if (awall.Sprite == awall.sprites[8] || awall.Sprite ==  awall.sprites[10])
                {
                    if (awall.CollidesWith(player))
                    {
                        player.WallHit(awall.Position);
                        break;
                    } else
                    { 
                        player.up = false;
                        player.down = false;
                        player.left = false;
                        player.right = false;
                    }

                    foreach (Bullet aPlayerBullet in firepattern.playerbullets.Children)
                    {
                        if (awall.Sprite == awall.sprites[10])
                        {
                            if (aPlayerBullet.CollidesWith(awall))
                            {
                                KillList.Add(aPlayerBullet);
                            }
                        }

                    }
                }
                
                    foreach (Bullet abullet in firepattern.bullets.Children)
                    {
                  
                        if (awall.Sprite == awall.sprites[10] || (abullet.pastWall && awall.Sprite == awall.sprites[8]))
                        {
                            if (abullet.CollidesWith(awall))
                            {
                                KillList.Add(abullet);
                            }
                        }
                    }

                    foreach (Bombs abomb in firepattern.bombs.Children)
                    {
                    if (awall.Sprite == awall.sprites[10] || (abomb.pastWall && awall.Sprite == awall.sprites[8]))
                        {
                            if (abomb.CollidesWith(awall))
                            {   
                                firepattern.Explosive(abomb.AngularDirection, abomb.Position);
                                KillList.Add(abomb);
                            }
                        }
                    }
                
                   


            }
            foreach (Bullet aplayerbullet in firepattern.playerbullets.Children)
            {
                if (aplayerbullet.lifeTime >= 60)
                {
                    KillList.Add(aplayerbullet);
                }
            }

            foreach (Bullet abullet in firepattern.bullets.Children)
            {
             
                
                if (abullet.lifeTime >= 600)
                {
                    KillList.Add(abullet);
                }

                if (abullet.CollidesWith(player))
                {
                    KillList.Add(abullet);
                    player.hit = true;
                    
                
                }

                

            }

            foreach (var aobject in KillList.Children)
            {
                firepattern.bullets.Remove(aobject);
                firepattern.bombs.Remove(aobject);
                firepattern.playerbullets.Remove(aobject);

            }


            if (death)
            {
                firepattern.bullets.Children.Clear();
                firepattern.bombs.Children.Clear();
                player.Reset();
                GameEnvironment.GameStateManager.SwitchTo("GameOver");
                player.hp = 3;
                death = false;

            }
        }


    }
}
