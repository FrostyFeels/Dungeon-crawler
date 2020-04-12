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
    class Weapons : GameObject
    {
        public  int fireRate = 15;
        public  float offsetAngle = 0;
        public bool shotgun = false;
        

       
        public Weapons()
        {
            Pistol();
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if(inputHelper.KeyPressed(Keys.P))
            {
                Pistol();
               
            }
            if (inputHelper.KeyPressed(Keys.O))
            {
                Shotgun();
                
            }
            if (inputHelper.KeyPressed(Keys.I))
            {
                Sniper();
                
            }
            if (inputHelper.KeyPressed(Keys.U))
            {
                SemiAuto();
               
            }
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }


        public void Shotgun()
        {
            shotgun = true;
            fireRate = 30;
            offsetAngle = GameEnvironment.Random.Next(-12, 12);
        }

        public void Sniper()
        {
            fireRate = 60;
            offsetAngle = 0;
        }

        public void Pistol()
        {
            fireRate = 15;
            offsetAngle = 0;
        }

        public void SemiAuto()
        {
            fireRate = 10;
            offsetAngle = 0;
        }

    }
}
