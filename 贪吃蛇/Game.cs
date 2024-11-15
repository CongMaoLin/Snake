using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 场景类型
    /// </summary>
    enum E_SceneType
    {
        /// <summary>
        /// 开始场景
        /// </summary>
        Begin,
        /// <summary>
        /// 游戏场景
        /// </summary>
        Game,
        /// <summary>
        /// 结束场景
        /// </summary>
        Over
    }

    internal class Game
    {

        public static ISceneStart scene;
        
        //控制台宽高
        public const int width = 50;
        public const int height = 30;

        //控制台初始化
         static Game()
        {
            
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            //初始化场景为开始场景
            SceneChange(E_SceneType.Begin);
        }

        public static void Start()
        {
            //游戏主循环
            while (true)
            {
                if (scene != null)
                {
                    //不同场景的执行方法，scene符合里氏替换
                    scene.SceneStart();
                }
            }

        }
        
        //场景切换
        public static void SceneChange(E_SceneType type)
        {
            Console.Clear();
            Console.CursorVisible = false;
            switch (type)
            {   
                case E_SceneType.Begin:
                    scene = new StartScene();
                    break;
                case E_SceneType.Game:
                    scene = new GameScene();
                    break;
                case E_SceneType.Over:
                    scene = new OverScene();
                    break;
                
            }
        }
    }
}
