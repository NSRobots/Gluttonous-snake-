using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 贪吃蛇.Lesson2;

namespace 贪吃蛇.Lesson1
{
    /// <summary>
    /// 游戏场景枚举
    /// </summary>
    enum E_SceneType
    {
        /// <summary>
        /// 游戏开始
        /// </summary>
        Begin,
        /// <summary>
        /// 游戏中
        /// </summary>
        Game,
        /// <summary>
        /// 游戏结束
        /// </summary>
        End
    }

    /// <summary>
    /// 游戏类
    /// </summary>
    class Game
    {
        //定义窗口的宽高
        public const int w = 80;
        public const int h = 20;
        //定义当前场景
        public static ISceneUpdate nowScene;

        /// <summary>
        /// 初始化控制台
        /// </summary>
        public Game()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);

            //游戏初始化时 需要切换场景，默认是Begin场景
            ChangeScene(E_SceneType.Begin);
        }

        /// <summary>
        /// 游戏主体循环
        /// </summary>
        public void Start()
        {
            //游戏主体循环 主要负责 游戏场景逻辑的更新
            while (true)
            {
                //判断当前游戏场景不为空 就更新
                if (nowScene != null)
                {
                    nowScene.Update();
                }
            }
        }

        /// <summary>
        /// 切换场景-行为
        /// </summary>
        public static void ChangeScene(E_SceneType type)
        {
            //切换场景之前 应该把上一个场景的绘制内容删除
            Console.Clear();

            switch (type)
            {
                case E_SceneType.Begin:
                    nowScene = new BeginScene();
                    break;
                case E_SceneType.Game:
                    nowScene = new GameScene();
                    break;
                case E_SceneType.End:
                    nowScene = new EndScene();
                    break;
            }
        }
    }
}
