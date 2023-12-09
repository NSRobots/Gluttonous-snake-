using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇.Lesson3
{
    abstract class GameObject : IDraw
    {
        //游戏对象位置
        public Position pos;

        //可以继承接口后，把接口中的行为 编成 抽象行为
        //供子类去实现 因为是抽象行为 所以子类中是必须去实现
        abstract public void Draw();
    }
}
