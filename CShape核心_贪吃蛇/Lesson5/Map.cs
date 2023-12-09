using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson1;
using 贪吃蛇.Lesson3;
using 贪吃蛇.Lesson4;

namespace 贪吃蛇.Lesson5
{
    class Map : IDraw
    {
        public Wall[] walls;

        public Map()
        {
            //初始化 墙格子的数量
            walls = new Wall[Game.w + (Game.h - 3) * 2];
            //遍历数组，传每个格子对应的坐标
            //i是坐标，index是格子数量
            int index = 0;
            for (int i = 0; i < Game.w; i += 2)
            {
                //横向的绘制
                walls[index] = new Wall(i, 0);
                ++index;
                walls[index] = new Wall(i, Game.h - 2);
                ++index;
            }
            for (int j = 1; j < Game.h - 2; j++)
            {
                //竖向绘制;Game.h - 2是因为上下都有墙了
                walls[index] = new Wall(0, j);
                index++;
                walls[index] = new Wall(Game.w - 2, j);
                index++;
            }
        }

        public void Draw()
        {
            //遍历数组，绘制Wall方格
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
