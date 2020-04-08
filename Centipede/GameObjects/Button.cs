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
    class Button : SpriteGameObject
    {
        public Button(String assetName, Vector2 startposition) : base(assetName)
        {
            position = startposition;
        }

        public override void Reset()
        {
            position.X = -1000;
            position.Y = -1000;
        }
    }
}
