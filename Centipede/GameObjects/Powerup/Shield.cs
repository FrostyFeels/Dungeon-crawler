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
   
    class Shield : RotatingSpriteGameObject
    {
        
        public SpriteSheet[] sprites;
        
        public Shield(String assetName, Vector2 position) : base(assetName)
        {
            
            sprites = new SpriteSheet[2];
            sprites[0] = new SpriteSheet("spr_shield");
            sprites[1] = new SpriteSheet("spr_barrier_collision");

            sprite = sprites[0];
            this.position = position;
            
            origin = Center;
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
          
            


           
        }

        public void ChangeDirection(Vector2 playerpos, Vector2 velocity )
        {
            
            if (sprite == sprites[1])
            {
                if (velocity.X > 0)
                {
                    position.X = playerpos.X + 50;
                    position.Y = playerpos.Y;
                    Degrees = 90;
                }
                else if (velocity.X < 0)
                {
                    position.X = playerpos.X - 50;
                    position.Y = playerpos.Y;
                    Degrees = -90;

                }
                else if (velocity.Y > 0)
                {
                    position.Y = playerpos.Y + 50;
                    position.X = playerpos.X;
                    Degrees = 180;

                }
                else if (velocity.Y < 0)
                {
                    position.Y = playerpos.Y - 50;
                    position.X = playerpos.X;
                    Degrees = 0;

                }
                





            }

        }

        public void Pickup()
        {
           
            sprite = sprites[1];
            
            
        }

 
    }
}
