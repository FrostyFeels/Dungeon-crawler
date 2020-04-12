using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centipede
{
    class MouseCursors : SpriteGameObject
    {
        public MouseCursors() : base("Sprites/spr_mouse")
        {
            
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            position = inputHelper.MousePosition;
            base.HandleInput(inputHelper);
        }


    }
}
