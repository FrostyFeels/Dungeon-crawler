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
    class LevelDesign : GameObject
    {

        public Wall[,] gridWall;
        Vector2 cellSize;

        int collums;
        int rows;


        int i;
        int xPosition;
        int yPosition;
        int width;
        int height;




        public LevelDesign(int collums, int rows) : base()
        {

            this.rows = rows;
            this.collums = collums;
            this.xPosition = GameEnvironment.Random.Next(3, 27);
            this.yPosition = GameEnvironment.Random.Next(3, 13);
            this.width = GameEnvironment.Random.Next(1, 4);
            this.height = GameEnvironment.Random.Next(1, 4);
         
            cellSize = new Vector2(64, 64);
            Reset();

        }



        public override void Reset()
        {
            gridWall = new Wall[collums, rows];

            for (int x = 0; x < collums; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x <= xPosition + width && x >= xPosition && y <= yPosition + height && y >= yPosition)
                    {
                        AddWall(x, y, i = 10);
                    }
                    else if (x <= 1)
                    {

                        AddWall(x, y, i = 9);
                    }
                    else if (x == 2 && y >= 3 && y <= 14)
                    {
                        AddWall(x, y, i = 8);
                    }
                    else if (x >= 28)
                    {

                        AddWall(x, y, 9);
                    }
                    else if (x == 27 && y >= 3 && y <= 13)
                    {

                        AddWall(x, y, 8);
                    }
                    else if (y <= 1)
                    {

                        AddWall(x, y, 9);
                    }
                    else if (y == 2)
                    {

                        AddWall(x, y, 8);
                    }
                    else if (y == 14)
                    {

                        AddWall(x, y, 8);
                    }
                    else if (y >= 15)
                    {

                        AddWall(x, y, 9);
                    }
                    else
                    {
                        i = GameEnvironment.Random.Next(0, 8);
                        AddWall(x, y, i);
                    }






                }
            }

        }






        public void AddWall(int x, int y, int assetName)
        {
            gridWall[x, y] = new Wall(assetName);

            gridWall[x, y].Parent = this;
            gridWall[x, y].Position = GetCellPosition(x, y);
        }




        public override void Update(GameTime gameTime)
        {
            foreach (Wall wall in gridWall)
                wall.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Wall wall in gridWall)
                wall.Draw(gameTime, spriteBatch);
        }



        public Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * cellSize.X, y * cellSize.Y);

        }


    }
}
