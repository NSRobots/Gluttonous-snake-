using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson3;
using 贪吃蛇.Lesson4;

namespace 贪吃蛇.Lesson5
{
    class Snack : IDraw
    {
        private SnackBody[] bodys;
        //存储蛇的身体，需要一个动态数组
        private int capacity = 5;
        private int length = 0;
        private E_MoveDir dir;

        //初始化蛇数组大小--构造函数
        public Snack(int x, int y)
        {
            bodys = new SnackBody[capacity];
            bodys[0] = new SnackBody(E_SnackBody_Type.Head, x, y);
            length = 1;

            //初始化向右移动
            dir = E_MoveDir.Right;
        }

        /// <summary>
        /// 重写 绘制 行为
        /// </summary>
        public void Draw()
        {
            //画一节一节的身体
            for (int i = 0; i < length; i++)
            {
                bodys[i].Draw();
            }
        }

        #region Lesson7 蛇的移动
        public void Move()
        {
            //动态增长数组
            if (length == capacity)
            {
                capacity *= 2;
                SnackBody[] newBodys = new SnackBody[capacity];
                //搬家
                for (int i = 0; i < bodys.Length; i++)
                {
                    newBodys[i] = bodys[i];
                }
                bodys = newBodys;
            }

            //蛇头 移动前，先擦除最后位置的蛇身体
            SnackBody lastBody = bodys[length - 1];
            Console.SetCursorPosition(lastBody.pos.x, lastBody.pos.y);
            Console.Write("  ");

            //在蛇头移动之前，从蛇尾开始，不停地让后一个位置等于前一个的位置
            //以实现 身体移动 的效果
            for (int i = length - 1; i > 0; i--)
            {
                bodys[i].pos = bodys[i - 1].pos;
            }

            //蛇头 再移动
            switch (dir)
            {
                case E_MoveDir.Up:
                    bodys[0].pos.y--;
                    break;
                case E_MoveDir.Down:
                    bodys[0].pos.y++;
                    break;
                case E_MoveDir.Left:
                    bodys[0].pos.x -= 2;
                    break;
                case E_MoveDir.Right:
                    bodys[0].pos.x += 2;
                    break;
            }
        }
        #endregion

        #region Lesson8 改变方向
        public void ChangeDir(E_MoveDir dir)
        {
            //有以下情况，不能移动
            //只有头部的时候 可以直接左转右 右转左 上转下 下转上
            //有身体时 不能直接朝身体方向转
            if (dir == this.dir ||
                length > 1 &&
                (this.dir == E_MoveDir.Left && dir == E_MoveDir.Right ||
                 this.dir == E_MoveDir.Right && dir == E_MoveDir.Left ||
                 this.dir == E_MoveDir.Up && dir == E_MoveDir.Down ||
                 this.dir == E_MoveDir.Down && dir == E_MoveDir.Up))
            {
                return;
            }

            //只要没有return，就记录外面传入的方向，之后就会按这个方向移动
            this.dir = dir;
        }
        #endregion

        #region Lesson9 撞墙 撞身体 结束逻辑
        public bool CheckEnd(Map map)
        {
            //是否和墙体位置重合
            for (int i = 0; i < map.walls.Length; i++)
            {
                if (map.walls[i].pos == bodys[0].pos)
                    return true;
            }
            //是否和身体位置重合
            for (int i = 1; i < length; i++)
            {
                if (bodys[0].pos == bodys[i].pos)
                    return true;
            }

            return false;
        }
        #endregion

        #region Lesson10 吃食物相关
        /// <summary>
        /// 判断蛇与食物的位置是否重合
        /// </summary>
        /// <param name="p">食物位置</param>
        /// <returns></returns>
        public bool CheckSamePos(Position p)
        {
            for (int i = 0; i < length; i++)
            {
                if (bodys[i].pos == p)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断是否吃到了食物
        /// 吃到了 就让食物位置再随机 并增加身体的长度
        /// </summary>
        /// <param name="food"></param>
        public void CheckEatFood(Food food)
        {
            if (bodys[0].pos == food.pos)
            {
                //吃到了 就让食物位置再随机 并增加身体的长度
                food.RandomPos(this);
                //长身体
                AddBody();
            }
        }
        #endregion

        #region Lesson11_长身体
        private void AddBody()
        {
            //先获得上一个身体
            SnackBody forntBody = bodys[length - 1];
            //先长
            bodys[length] = new SnackBody(E_SnackBody_Type.Body, forntBody.pos.x, forntBody.pos.y);

            //再加长度
            length++;
        }
        #endregion
    }
    /// <summary>
    /// 移动方向的枚举
    /// </summary>
    enum E_MoveDir
    {
        /// <summary>
        /// 上移动
        /// </summary>
        Up,
        /// <summary>
        /// 下移动
        /// </summary>
        Down,
        /// <summary>
        /// 左移动
        /// </summary>
        Left,
        /// <summary>
        /// 右移动
        /// </summary>
        Right
    }
}
