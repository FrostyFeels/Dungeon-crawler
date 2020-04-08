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
    class Bombs : RotatingSpriteGameObject

    {
       
        int framecounter = 0;
        int spritecounter = 0;
        int i = 0;
        
        SpriteSheet[] sprites;
        public Bombs(Vector2 AngularDirections, Vector2 startposition, float offsetAngle) : base("Explosion/Spr_Explosion_01")
        {
            sprites = new SpriteSheet[5];
            sprites[0] = new SpriteSheet("Explosion/Spr_Explosion_01");
            sprites[1] = new SpriteSheet("Explosion/Spr_Explosion_02");
            sprites[2] = new SpriteSheet("Explosion/Spr_Explosion_03");
            sprites[3] = new SpriteSheet("Explosion/Spr_Explosion_04");
            sprites[4] = new SpriteSheet("Explosion/Spr_Explosion_05");

            origin = Center;
            AngularDirection = AngularDirections;
            offsetDegrees = 90;
            position = startposition;
            velocity.X = 5f;
            Angle += offsetAngle;
                    
        }

        public override void Reset()
        {
            base.Reset();
            velocity.X = 0;
            position.X = -1000;
            position.Y = -1000;
        }


        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
            this.spritecounter++;
            this.framecounter++;
            Console.WriteLine(framecounter);


            position += AngularDirection * velocity.X;

            if (spritecounter == 12)
            {
                i++;
                spritecounter = 0;
            }
        }

            public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
            base.Draw(gameTime, spriteBatch);
            if (i < 5)
            {
                sprite = sprites[i];
            }
            
            }



    

        public  bool Explode()
        {
            if (this.framecounter >= 60)
            {
                this.framecounter = 0;
                return true;
              
            }
            return false;
        }


    
    }
}
