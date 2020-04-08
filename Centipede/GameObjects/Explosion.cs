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
    class Explosion : RotatingSpriteGameObject
    {
        SpriteSheet[] sprites;

        int framecounter = 0;
        
        int i = 0;
        bool alive = false;
        
        public Explosion(Vector2 AngularDirections, Vector2 startposition, float offsetAngle, bool isAlive) : base("Explosion/spr_explosion_01")
        {

            sprites = new SpriteSheet[7];
      
            sprites[0] = new SpriteSheet("Explosion/Spr_Explosion_06");
            sprites[1] = new SpriteSheet("Explosion/Spr_Explosion_07");
            sprites[2] = new SpriteSheet("Explosion/Spr_Explosion_08");
            sprites[3] = new SpriteSheet("Explosion/Spr_Explosion_09");
            sprites[4] = new SpriteSheet("Explosion/Spr_Explosion_10");
            sprites[5] = new SpriteSheet("Explosion/Spr_Explosion_11");
            sprites[6] = new SpriteSheet("Explosion/Spr_Explosion_12");

            position.X = startposition.X;
            position.Y = startposition.Y;
            alive = isAlive;

            origin = Center;
            AngularDirection = AngularDirections;
            offsetDegrees = 90;
           
            velocity.X = 5f;
            Angle += offsetAngle;





        }


 


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (alive)
            {
                this.framecounter++;
            }
            


            if (framecounter == 5)
            {
                i++;
                this.framecounter = 0;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (i < 7)
            {
                sprite = sprites[i];
                if(i == 6)
                {
                    visible = false;
                }

            }

            base.Draw(gameTime, spriteBatch);
        }





    }
}
