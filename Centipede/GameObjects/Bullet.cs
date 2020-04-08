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

        public Bullet(String assetName, Vector2 AngularDirections, Vector2 startposition, float offsetAngle, bool Enemybullet) : base(assetName)
        {
            origin = Center;
            AngularDirection = AngularDirections;
            offsetDegrees = 90;
            position = startposition;
            if(Enemybullet)
            {
                this.velocity.X = 5f;
            } else { velocity.X = 10f; }
            
            Angle += offsetAngle;

        }

        public override void Update(GameTime gameTime)
        {
            lifeTime++;
            base.Update(gameTime);
            position += AngularDirection * velocity.X;

        
        }



    }
}
