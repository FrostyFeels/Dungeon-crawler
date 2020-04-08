using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace Centipede
{
    class Turret : RotatingSpriteGameObject
    {

        bool death = false;
        public int framecounter = 0;
       
        float NewCounter;
        public int whichBullet;
        public int tutorialBullet = 1;
        public float hp = 3;
        public bool hit = false;
        public Turret(String assetName, Vector2 startposition ) : base(assetName)
        {
            position = startposition;
            origin = Center;
            NewCounter = GameEnvironment.Random.Next(120,240);
            
            

        }

        public override void Reset()
        {
            position = new Vector2(-1000, -1000);
            death = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            framecounter++;
            if(hp <= 0)
            {
                Reset();
            }

            if(this.hit)
            {
                this.hp--;
                this.hit = false;
            }

        }

        public bool Fire(float timer)
        {
            if (!death)
            {
                if (framecounter >= NewCounter)
                {

                    NewCounter = timer;
                    framecounter = 0;
                    return true;
                }
            }
            return false;
        }

        








    }
}
