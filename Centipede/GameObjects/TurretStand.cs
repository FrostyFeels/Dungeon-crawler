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
    class TurretStand : RotatingSpriteGameObject
    {
        public TurretStand(Vector2 position, int rotation) : base("Sprites/spr_turret_stand")
        {
            this.position = position;

            this.offsetDegrees = rotation;
            origin = Center;

        }
    }
}
