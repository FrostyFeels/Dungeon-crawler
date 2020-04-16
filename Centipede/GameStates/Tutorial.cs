using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede
{
    class Tutorial : GameObjectList
    {
        bool a, d, w = false;
        bool turret = false;
        bool dontSpawnAgain = false;
        bool spawned = false;
        bool startCounting = false;

        int framecounter = 0;
        Turret turrets;
        TurretStand turretstand;
        Player player;
        Button abutton;
        Button dbutton;
        Button wbutton;
     
       
        public GameObjectList bullets = new GameObjectList();
        GameObjectList KillList = new GameObjectList();
        GameObjectList bombs = new GameObjectList();
        


        public Tutorial()
        {
            player = new Player("Sprites/Player");
            abutton = new Button("Buttons/AButton", new Vector2(player.Position.X + 50, player.Position.Y));
            dbutton = new Button("Buttons/DButton", new Vector2(player.Position.X - 150, player.Position.Y));
            wbutton = new Button("Buttons/WBullot", new Vector2(player.Position.X - 50, player.Position.Y - 200));
           


            this.Add(new SpriteGameObject("Sprites/BackGround"));

            this.Add(abutton);
            this.Add(dbutton);
            this.Add(wbutton);
            this.Add(player);
            this.Add(bullets);
            this.Add(bombs);
           
          
       

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            
            base.HandleInput(inputHelper);
            if(startCounting)
            {
                framecounter++;
            }

            if(framecounter >= 300)
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
            if(inputHelper.KeyPressed(Keys.A))
            {
                a = true;
            }
            if (inputHelper.KeyPressed(Keys.D))
            {
                d = true;
            }
            if (inputHelper.KeyPressed(Keys.W))
            {
                w = true;
            }

            if (a && d && w)
            {
                dbutton.Reset();
                abutton.Reset();
                wbutton.Reset();
                turret = true;
            }
            if(inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(turret && !dontSpawnAgain)
            {
                this.Add(turrets = new Turret("Sprites/spr_turret", new Vector2(player.Position.X, player.Position.Y - 300)));
                this.Add(turretstand = new TurretStand(new Vector2(player.Position.X, player.Position.Y - 300), 90));
                dontSpawnAgain = true;
                spawned = true;
            }
            if (spawned)
            {
                turrets.LookAt(player, 90);

                if (turrets.Fire(GameEnvironment.Random.Next(120, 240)))
                {

                    

                    if (turrets.tutorialBullet == 1)
                    {
                        Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
                        bullets.Add(new Bullet("Sprites/Bullet", turrets.AngularDirection, turrets.Position, 0, 5));
                        
                    }
                

                    if (turrets.tutorialBullet == 2)
                    {
                        Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
                        for (int i = 0; i < 5; i++)
                        {
                            bullets.Add(new Bullet("Sprites/Bullet", turrets.AngularDirection, turrets.Position, -12 + (6 * i) , 5));
                            

                        }
                    }
          

                    if (turrets.tutorialBullet == 3)
                    {
                        Centipede.AssetManager.PlaySound("Sounds/BulletsSound");
                        bombs.Add(new Bombs( turrets.AngularDirection, turrets.Position, 0));
                        
                    }






                    turrets.tutorialBullet++;
                }

                foreach (Bombs abomb in bombs.Children)
                {
                    if (abomb.Explode())
                    {
                        this.Add(new Explosion(abomb.AngularDirection, abomb.Position, 0, true));
                        Centipede.AssetManager.PlaySound("Sounds/ExplosionSound");
                        
                        for (int i = 0; i < 6; i++)
                        {
                            bullets.Add(new Bullet("Sprites/Bullet", turrets.AngularDirection, abomb.Position, i, 5));
                        }
                        KillList.Add(abomb);
                        startCounting = true;
                        
                    }
                }




            }
            foreach (Bullet abullet in bullets.Children)
            {
                if (abullet.lifeTime >= 600)
                {
                    KillList.Add(abullet);
                }

 

            }

            foreach (var abullet in KillList.Children)
            {
                bullets.Remove(abullet);

            }

            foreach (var abomb in KillList.Children)
            {
                bombs.Remove(abomb);
            }

            


        
        }
    }
}
