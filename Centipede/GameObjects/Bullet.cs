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
    class Bullet : RotatingSpriteGameObject
    {
        public int lifeTime;
        public bool pastWall = false;

        public Bullet(String assetName, Vector2 AngularDirections, Vector2 startposition, float offsetAngle,  int velocity) : base(assetName)
        {
            this.origin = Center;
            this.AngularDirection = AngularDirections;
            this.offsetDegrees = 90;
            this.position = startposition;
            this.velocity.X = velocity;       
            this.Angle += offsetAngle;

        }

        public override void Update(GameTime gameTime)
        {
            lifeTime++;
            base.Update(gameTime);
            position += AngularDirection * velocity.X;

            if (position.X > 250 && position.X + sprite.Width < 1728 && position.Y > 250 && position.Y + sprite.Width < 888)
            {
                pastWall = true;
            }


        }



    }
}
