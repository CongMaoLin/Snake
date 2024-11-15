using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal class StartScene : StartOrOverBaseScene
    {
        //初始化开始场景
        public StartScene()
        {
            
            title = "贪吃蛇";
            choiceName = "开始游戏";
        }


        //游戏场景选项确定的方法
        public override void EnterJ()
        {
            if(choice == EChoice.Start)
            {
                Game.SceneChange(E_SceneType.Game);
            }
            else if(choice == EChoice.Over)
            {
                Environment.Exit(0);
            }
        }
    }
}
