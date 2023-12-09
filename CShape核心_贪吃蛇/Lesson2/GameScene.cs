using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson1;
using 贪吃蛇.Lesson4;
using 贪吃蛇.Lesson5;

namespace 贪吃蛇.Lesson2
{
    class GameScene : ISceneUpdate
    {
        Map map;
        Snack snack;
        Food food;
        //土办法，降低循环速度 用
        int updateIndex = 0;

        public GameScene()
        {
            map = new Map();
            snack = new Snack(40, 10);
            food = new Food(snack);
        }

        public void Update()
        {
            if (updateIndex % 4444 == 0)
            {
                map.Draw();
                food.Draw();

                //先移动，再绘制
                snack.Move();
                snack.Draw();

                //检测到是否撞墙
                if (snack.CheckEnd(map))
                {
                    //执行结束界面逻辑
                    Game.ChangeScene(E_SceneType.End);
                }
                //检测是否吃到食物
                snack.CheckEatFood(food);

                updateIndex = 0;
            }
            updateIndex++;

            //在控制台中 检测玩家输入 让程序不被检测卡住
            if (Console.KeyAvailable)
            {
                //检测输入输出 不能在间隔帧里面处理 应该每次检测，这样才准确
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snack.ChangeDir(E_MoveDir.Up);
                        break;
                    case ConsoleKey.S:
                        snack.ChangeDir(E_MoveDir.Down);
                        break;
                    case ConsoleKey.A:
                        snack.ChangeDir(E_MoveDir.Left);
                        break;
                    case ConsoleKey.D:
                        snack.ChangeDir(E_MoveDir.Right);
                        break;
                }
            }
        }
    }
}
