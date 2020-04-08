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
    class Player : RotatingSpriteGameObject
    {
        FirePatterns firePatterns;
        

        int pressed = 0;
        int framecounter = 0;
        bool starttimer = false;
        bool movement = false;
        public bool shoot = false;
        public Player(String assetName) : base(assetName)
        {
            firePatterns = new FirePatterns();
            Reset();
          
            //origin = new Vector2(sprite.Width / 2, sprite.Height);
            origin = Center;
            

           
            
        }

        public override void Reset()
        {
            position.X = GameEnvironment.Screen.X / 2;
            position.Y = GameEnvironment.Screen.Y / 2;
        }



        public override void HandleInput(InputHelper inputHelper)
        {
            if(inputHelper.KeyPressed(Keys.Q))
            {
                movement = true;
            }

            if (!movement)
            {
                if (inputHelper.IsKeyDown(Keys.D) || inputHelper.IsKeyDown(Keys.Right))
                {
                    Angle += 0.1f;
                }
                if (inputHelper.IsKeyDown(Keys.A) || inputHelper.IsKeyDown(Keys.Left))
                {
                    Angle -= 0.1f;
                }
                if (inputHelper.IsKeyDown(Keys.W) || inputHelper.IsKeyDown(Keys.Up))
                {
                    velocity.X = 7.5f;                 
                }
                else
                {
                    velocity.X = 4;
                }
                

                if (inputHelper.IsKeyDown(Keys.S) || inputHelper.IsKeyDown(Keys.Down))
                {
                    velocity.X = 7.5f;


                }



                position += AngularDirection * velocity.X;


                if (inputHelper.KeyPressed(Keys.Space))
                {
                    
                    shoot = true;
                }
                else { shoot = false; }
            }

                if(movement)
                {
                    if(inputHelper.IsKeyDown(Keys.W))
                    {
                        position.Y -= 7.5f;
                        
                    }
                    if (inputHelper.IsKeyDown(Keys.S))
                    {
                        position.Y += 7.5f;
                    }
                    if (inputHelper.IsKeyDown(Keys.D))
                    {
                        position.X += 7.5f;

                    }
                    if (inputHelper.IsKeyDown(Keys.A))
                    {
                        position.X -= 7.5f;

                    }
                  
                }
            

            if(inputHelper.KeyPressed(Keys.LeftShift))
            {
                pressed++;
                starttimer = true;
            }



 
            base.HandleInput(inputHelper);

            
            
        }

        public override void Update(GameTime gameTime)
        {
            if(starttimer)
            {
                framecounter++;
            }
            base.Update(gameTime);
            position.X = MathHelper.Clamp(position.X, 175, GameEnvironment.Screen.X - sprite.Width - 125);
            position.Y = MathHelper.Clamp(position.Y, 100, GameEnvironment.Screen.Y - sprite.Height - 70);
            if (framecounter <= 30)
            {
                if (pressed >= 2)
                {
                    Dash();
                    pressed = 0;
                    starttimer = false;
                    framecounter = 0;

                }
            }

            if(framecounter >= 30 )
            {
                starttimer = false;
                pressed = 0;
                framecounter = 0;
            }
        }



        public void Dash()
        {
            velocity.X *= 25;
            position += AngularDirection * velocity.X;
            
        }


 
    }
}
