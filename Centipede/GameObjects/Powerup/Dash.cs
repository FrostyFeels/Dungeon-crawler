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
    class Dash : SpriteGameObject
    {
        int i;
        int framecounter = 0;
        SpriteSheet[] sprites;
        public Dash(Vector2 position) : base("spr_dash_02")
        {
            sprites = new SpriteSheet[7];
            sprites[0] = new SpriteSheet("spr_dash_01");
            sprites[1] = new SpriteSheet("spr_dash_02");
            sprites[2] = new SpriteSheet("spr_dash_03");
            sprites[3] = new SpriteSheet("spr_dash_04");
            sprites[4] = new SpriteSheet("spr_dash_05");
            sprites[5] = new SpriteSheet("spr_dash_06");
            sprites[6] = new SpriteSheet("spr_dash_07");

            sprite = sprites[0];
            this.position = position;

            
            
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            framecounter++;
            if(i < 6)
            {
                if(framecounter > 15)
                {

                    i++;
                    framecounter = 0;


                }
                if(i == 6)
                {
                    i = 0;
                }
                sprite = sprites[i];
            }
        }

      
    }
}
