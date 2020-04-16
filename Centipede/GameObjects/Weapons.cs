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
        public float setfireRate = 10;
        public  float fireRate = 15;
        public  float offsetAngle = 0;
        public float dmg = 1;
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
            fireRate = setfireRate * 3;
            offsetAngle = GameEnvironment.Random.Next(-12, 12);
            dmg = 0.3f;
        }

        public void Sniper()
        {   
            shotgun = false;
            fireRate = setfireRate * 6;
            offsetAngle = 0;
            dmg = 3f;
        }

        public void Pistol()
        {
            shotgun = false;
            fireRate = setfireRate * 1.5f;
            offsetAngle = 0;
            dmg = 1;
        }

        public void SemiAuto()
        {
            shotgun = false;
            fireRate = setfireRate;
            offsetAngle = 0;
            dmg = 0.5f;
        }

    }
}
