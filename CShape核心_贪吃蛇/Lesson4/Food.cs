using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson1;
using 贪吃蛇.Lesson3;
using 贪吃蛇.Lesson5;

namespace 贪吃蛇.Lesson4
{
    class Food : GameObject
    {
        public Food(Snack snack)
        {
            RandomPos(snack);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[]");
        }

        //随机位置的行为
        //和蛇的位置有关系，有了蛇再考虑
        /// <summary>
        /// 随机生成食物的位置
        /// </summary>
        /// <param name="snack"></param>
        public void RandomPos(Snack snack)
        {
            //随机设置位置
            Random r = new Random();
            int x = r.Next(2, Game.w / 2 - 1) * 2;//* 2是为了让x轴为偶数
            int y = r.Next(1, Game.h - 4);
            pos = new Position(x, y);
            //得到蛇
            //如果重合 就会进if语句 进行递归
            //如果 蛇 和 食物 的位置没有重合，就不进递归
            if (snack.CheckSamePos(pos))
            {
                RandomPos(snack);
            }
        }
    }
}
