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
        Player player;
        int reloadtimer = 0;
        int reloadtime = 90;
        public float hp = 2;
        public bool hit = false;
       
        public Enemies(Vector2 position) : base("spr_enemy_01")
        {
            player = new Player("Sprites/Player");
            
            origin = Center;
            this.position = position;

        }

        public override void Reset()
        {
            base.Reset();
            position.X = -1000;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity == new Vector2(0, 0))
            {
                reloadtimer++;
            } 

            if(hit)
            {
                this.hp--;
                this.hit = false;
            }

          
            base.Update(gameTime);



            
            
        }

        public bool LoadShot()
        {
            

            
            if (reloadtime < reloadtimer)
            {
                reloadtimer = 0;
                return true;
            }

            return false;
        }
        
            

        public void MoveToPlayerX(Vector2 playerpos)
        {
            if (position.X > playerpos.X + 25)
            {
                velocity.X = -100;
            }
            else velocity.X = 100;
            

        }

        public void MoveToPlayerY(Vector2 playerpos)
        {
            if(position.Y  > playerpos.Y + 25)
            {
                velocity.Y = -100;
            } else  velocity.Y = 100;
            
        }


        public double pythogoras(float xDiff, float yDiff) 
        {
          
            float Xsqrd = xDiff * xDiff;
            float Ysqrd = yDiff * yDiff;
            float diff = Xsqrd + Ysqrd;
            
            double answer = Math.Sqrt(diff);
            return answer;

        }
    }
}
