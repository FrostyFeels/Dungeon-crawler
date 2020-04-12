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
    class Enemies : RotatingSpriteGameObject
    {
        public Enemies(Vector2 position) : base("spr_enemy_01")
        {
            this.position = position + new Vector2(16,16);

        }
    }
}
