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
        Vector2 location7 = new Vector2(20, 540);
        Vector2 location8 = new Vector2(1900, 540);

        

        int framecounter = 0;
        

        public Player player;
        Score score;
        MouseCursors mouse;
      
        Powerups powerups;
        
        

        FirePatterns firepattern;
        public LevelDesign rightWall;

        public GameObjectList turrets = new GameObjectList();
        public GameObjectList turretStands = new GameObjectList();
        public GameObjectList KillList = new GameObjectList();
        public GameObjectList enemies = new GameObjectList();
 


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
        
            powerups = new Powerups();
            player = new Player("Sprites/Player"); 
            rightWall = new LevelDesign(30, 17);
            firepattern = new FirePatterns();

            
            
            this.Add(new SpriteGameObject("Sprites/BackGround"));           
            this.Add(rightWall);        
            
            this.Add(turretStands);
            this.Add(turrets);
            this.Add(firepattern);
            this.Add(player);
            this.Add(score);
            this.Add(mouse);
            this.Add(enemies);
            this.Add(powerups);



            for (int i = 0; i < 8; i++)
            {
                turrets.Add(new Turret("Sprites/spr_turret", turretLocations[i]));              
                turretAmount++;
          
            
               
                if (i == 1)
                {
                    turretStands.Add(new TurretStand(turretLocations[0], 25));
                    turretStands.Add(new TurretStand(turretLocations[1], 0));
                    turretStands.Add(new TurretStand(turretLocations[2], 180));
                    turretStands.Add(new TurretStand(turretLocations[3], 140));
                    turretStands.Add(new TurretStand(turretLocations[4], -35));
                    turretStands.Add(new TurretStand(turretLocations[5], -135));
                    turretStands.Add(new TurretStand(turretLocations[6], 90));
                    turretStands.Add(new TurretStand(turretLocations[7], -90));
                    
                }

       }

       


            for (int i = 0; i < 3; i++)
            {
                foreach (Wall awall in rightWall.gridWall)
                {
                    if (awall.Sprite == awall.sprites[2]) 
                    {
                        enemies.Add(new Enemies(rightWall.gridWall[GameEnvironment.Random.Next(3, 26), GameEnvironment.Random.Next(3, 13)].Position));
                        break;
                    }
                }
                
            }

            


        }



    

        public override void Update(GameTime gameTime)
        {
       
            base.Update(gameTime);
            foreach (Shield ashield in powerups.shields.Children)
            {
                ashield.ChangeDirection(player.Position, player.Velocity);
            }
            



            framecounter++;
            player.LookAt(mouse);

            foreach (Enemies aEnemy in enemies.Children)
            {
                
                aEnemy.LookAt(player,90);
                float xdistance =   player.Position.X - aEnemy.Position.X;
                float ydistance = player.Position.Y - aEnemy.Position.Y;
                double distanceCenter = aEnemy.pythogoras(xdistance, ydistance);
                double SidetoSide = distanceCenter - player.radius;         
                if (SidetoSide > 0)
                {
                    aEnemy.MoveToPlayerX(player.Position);
                    aEnemy.MoveToPlayerY(player.Position);

                }
                else aEnemy.Velocity = new Vector2(0,0);

            }

            if (player.hp == 0)
            {
                death = true;
            }
            
 


            foreach (Turret aturret in turrets.Children)
            {
                aturret.LookAt(player, 90);

                if (aturret.Fire(GameEnvironment.Random.Next(120, 240)))
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



            }

            foreach (Enemies aEnemy in enemies.Children) 
            {
                int whichshot = GameEnvironment.Random.Next(0, 2);
                if(aEnemy.LoadShot())
                {
                    if (whichshot == 0)
                    {
                        firepattern.EnemyShot(aEnemy.AngularDirection, aEnemy.Position);
                    }
                      firepattern.EnemyShotGun(aEnemy.AngularDirection, aEnemy.Position);
                    
                }
            }
            if (player.shoot)
            {
                firepattern.PlayerShot(player.AngularDirection, player.Position);
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
                        score.getScore++;
                        aturret.hit = true;                                         
                        KillList.Add(aPlayerBullet);
                        
                    }
                }

                foreach (Enemies aEnemy in enemies.Children)
                {
                    if(aPlayerBullet.CollidesWith(aEnemy))
                    {
                        KillList.Add(aPlayerBullet);
                        aEnemy.hit = true;
                        
                    }
                    
                    if(aEnemy.hp <= 0)
                    {
                        KillList.Add(aEnemy);
                        powerups.Chance(aEnemy.Position);
                    }
                }
            }

  


            foreach (Shield aShield in powerups.shields.Children)
            {
                
                if (player.CollidesWith(aShield))
                {
                    Console.WriteLine("this works");
                    aShield.Pickup();
                    
                }

                foreach (Bullet abullet in firepattern.bullets.Children)
                {
                    if (aShield.Sprite == aShield.sprites[1])
                    {
                        if (abullet.CollidesWith(aShield))
                        {

                            KillList.Add(aShield);
                            KillList.Add(abullet);
                        }
                    }
                }           
            }

            foreach (Dash aDash in powerups.dashes.Children)
            {
                if(aDash.CollidesWith(player))
                {
                    player.dash++;
                    KillList.Add(aDash);
                }
            }

        






            foreach (Wall awall in rightWall.gridWall)
            {

                if (awall.Sprite == awall.sprites[7] || awall.Sprite == awall.sprites[8] || awall.Sprite == awall.sprites[9])
                {
                    if (awall.CollidesWith(player))
                    {
                        player.WallHit(awall.Position);
                        break;
                    }
                    else
                    {
                        player.up = false;
                        player.down = false;
                        player.left = false;
                        player.right = false;
                    }
                }

                    foreach (Bullet aPlayerBullet in firepattern.playerbullets.Children)
                    {
                        if (awall.Sprite == awall.sprites[7])
                        {                           
                            if (aPlayerBullet.CollidesWith(awall))
                            {
                                
                                KillList.Add(aPlayerBullet);
                            }
                        }

                    }
                
                
                    foreach (Bullet abullet in firepattern.bullets.Children)
                    {
                  
                        if (awall.Sprite == awall.sprites[7] || (abullet.pastWall && awall.Sprite == awall.sprites[8]) || (abullet.pastWall && awall.Sprite == awall.sprites[9]))
                        {
                            if (abullet.CollidesWith(awall))
                            {
                                KillList.Add(abullet);
                            }
                        }
                    }

                    foreach (Bombs abomb in firepattern.bombs.Children)
                    {
                    if (awall.Sprite == awall.sprites[7] || (abomb.pastWall && awall.Sprite == awall.sprites[8]) || (abomb.pastWall && awall.Sprite == awall.sprites[9]))
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
                enemies.Remove(aobject);
                powerups.shields.Remove(aobject);
                powerups.dashes.Remove(aobject);
                powerups.firerate.Remove(aobject);

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
