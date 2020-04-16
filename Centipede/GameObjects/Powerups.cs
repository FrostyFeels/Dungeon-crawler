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

    class Powerups : GameObjectList
    {
        int chance = 0;
        int whatPowerup = 0;
        public GameObjectList shields = new GameObjectList();
        public GameObjectList dmg = new GameObjectList();
        public GameObjectList hp = new GameObjectList();
        public GameObjectList firerate = new GameObjectList();
        public GameObjectList dashes = new GameObjectList();

        Player player;
        
        public Powerups()
        {
            player = new Player("Sprites/Player");
            this.Add(shields);
            this.Add(dmg);
            this.Add(dashes);
            this.Add(firerate);
            this.Add(hp);

        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
      
           
            base.Update(gameTime);
        }



        public void Chance(Vector2 position)
        {
            chance = GameEnvironment.Random.Next(3, 4);

            if(chance == 3)
            {
                whatPowerup = GameEnvironment.Random.Next(0, 3);

                switch(whatPowerup)
                {
                    case 0:
                        {
                            shields.Add(new Shield("spr_shield", position));
                            break;
                        }
                    case 1:
                        {
                            dashes.Add(new Dash(position));
                            break;
                        }
             
                  

                }
            }
            
        }
    }
}
