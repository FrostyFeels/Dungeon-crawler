using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede
{
    class Score : TextGameObject
    {
        protected int score;
        public Score(int layer = 0, string id = "") : base("GameFont", layer, id)
        {
            position.X = 250;
            position.Y = 100;
        }


        public override void Reset()
        {
            base.Reset();
            score = 0;
        }

        public override void Update(GameTime gameTime)
        {
            this.Text = score.ToString();
           
        }

        public int getScore
        {
            get { return score; }
            set { score = value; }
        }

}

    
}
