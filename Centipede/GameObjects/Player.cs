﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Centipede
{
    class Player : RotatingSpriteGameObject
    {
        int framecounter = 0;
        public int dash;
        FirePatterns firePatterns;
        public Weapons weapons;
        public int hp;
        public bool hit = false;
        public int radius = 150;

   
        



        public Vector2 truePlayer;
        public Vector2 trueWall;
        public bool shoot = false;

        public bool right, left, up, down = false;
        


        public Player(String assetName) : base(assetName)
        {
            hp = 5;
            weapons = new Weapons();

            firePatterns = new FirePatterns();
            Reset();          
            origin = Center;
            radius = 250;
            




        }

        public override void Reset()
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = GameEnvironment.Screen.Y / 2;
            velocity.X = 7.5f;
        }



        public override void HandleInput(InputHelper inputHelper)
        {
            
            weapons.HandleInput(inputHelper);
            base.HandleInput(inputHelper);
            framecounter++;

            if (dash > 0)
            {

                if (inputHelper.KeyPressed(Keys.LeftShift))
                {
                    if (velocity.X > 0)
                    {
                        Dash("right");
                    }
                    else if (velocity.X < 0)
                    {
                        Dash("left");
                    }
                    else if (velocity.Y > 0)
                    {
                        Dash("down");

                    }
                    else if (velocity.Y < 0)
                    {
                        Dash("up");
                    }
                    dash--;
                }
            }
           
            
                if (inputHelper.MouseLeftButtonPressed())
                {
                    if (weapons.fireRate <= framecounter)
                    {
                        framecounter = 0;
                        shoot = true;
                    }
                }
                else { shoot = false; }


            





            if (inputHelper.IsKeyDown(Keys.W) && !down) { velocity.Y = -300; }
            else if (inputHelper.IsKeyDown(Keys.S) && !up) { velocity.Y = 300; }
            else velocity.Y = 0;

            if (inputHelper.IsKeyDown(Keys.D) && !left) { velocity.X = 300; }
            else if (inputHelper.IsKeyDown(Keys.A) && !right) { velocity.X = -300; }
            else { velocity.X = 0; }

            AngularDirection = new Vector2(inputHelper.MousePosition.X, 100);

          

        }

        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
            if(hit)
            {
                hp--;
                hit = false;
            }
        }

        public void Dash(String whatSide) 
        {
            switch(whatSide)
            {
                case "right":
                    {
                        position.X += 250;
                        break;
                    }
                case "left":
                    {
                        position.X += -250;
                        break;
                    }
                case "down":
                    {
                        position.Y += 250;
                        break;
                    }
                case "up":
                    {
                        position.Y += -250;
                        break;
                    }
            }
            
        }




        public void WallHit(Vector2 wallPos)
        {


            Vector2 walloffset = Vector2.One * (32);
            Vector2 playerOffset = Vector2.One * (25);

            Vector2 playerPos = new Vector2(position.X, position.Y);

            Console.WriteLine(playerPos);

            trueWall = (wallPos);
            truePlayer = (playerPos - origin);

            Vector2 simple = (truePlayer - trueWall);

            Vector2 truePos = (simple / (Vector2.One * 57f));

            if (Math.Abs(simple.X) < Math.Abs(simple.Y))
            {
                // above or below
                if (truePos.Y < 0)
                {
                    Console.WriteLine("above");
                    up = true;

                }
                else if (truePos.Y > 0)
                {
                    Console.WriteLine("bellow");
                    down = true;


                }




            }
            else
            {
                //it's left or right
                if (truePos.X > 0)
                {
                    Console.WriteLine("right");
                    right = true;

                }
                else if (truePos.X < 0)
                {
                    Console.WriteLine("left");
                    left = true;

                }

            }





        }








    }
}
