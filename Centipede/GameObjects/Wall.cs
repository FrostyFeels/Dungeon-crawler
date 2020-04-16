using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    class Wall : SpriteGameObject
    {
        public SpriteSheet[] sprites;
        public Wall(int i) : base("spr_fill_01")
        {
            sprites = new SpriteSheet[11];

            sprites[0] = new SpriteSheet("spr_fill_01");
            sprites[1] = new SpriteSheet("spr_fill_02");
            sprites[2] = new SpriteSheet("spr_fill_03");
            sprites[3] = new SpriteSheet("spr_fill_01");
            sprites[4] = new SpriteSheet("spr_fill_01");
            sprites[5] = new SpriteSheet("spr_fill_01");
            sprites[6] = new SpriteSheet("spr_fill_01");
            sprites[7] = new SpriteSheet("spr_fill_roof_collide");
            sprites[8] = new SpriteSheet("spr_wall_01");           
            sprites[9] = new SpriteSheet("spr_wall_02");
            sprites[10] = new SpriteSheet("spr_fill_roof_02");
            

            sprite = sprites[i];

        }
    }
}
