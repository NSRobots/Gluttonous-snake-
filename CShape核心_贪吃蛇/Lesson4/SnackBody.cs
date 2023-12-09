using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson3;

namespace 贪吃蛇.Lesson4
{
    /// <summary>
    /// 蛇头与身体 枚举
    /// </summary>
    enum E_SnackBody_Type
    {
        /// <summary>
        /// 蛇头
        /// </summary>
        Head,
        /// <summary>
        /// 蛇身
        /// </summary>
        Body
    }

    class SnackBody : GameObject
    {
        private E_SnackBody_Type type;

        public SnackBody(E_SnackBody_Type type, int x, int y)
        {
            this.type = type;
            pos = new Position(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = type == E_SnackBody_Type.Head ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.Write(type == E_SnackBody_Type.Head ? "<>" : "()");
        }
    }
}
