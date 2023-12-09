using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson1;

namespace 贪吃蛇.Lesson2
{
    class BeginScene : BeginOrEndbaseScene
    {
        public BeginScene()
        {
            strTitle = "贪吃蛇";
            strOne = "开始游戏";
        }

        public override void EnterJDoSomething()
        {
            //按J键做什么的逻辑
            if (nowSelIndex == 0)
            {
                Game.ChangeScene(E_SceneType.Game);
            }
            else
            {
                Game.ChangeScene(E_SceneType.End);
            }
        }
    }
}
