using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal class OverScene : StartOrOverBaseScene
    {
        //初始化结束场景
        public OverScene()
        {
            
            title = "游戏结束";
            choiceName = "返回主菜单";
        }

        //结束场景选项确定的方法
        public override void EnterJ()
        {
            if(choice == EChoice.Start)
            {
                Game.SceneChange(E_SceneType.Begin);
            }
            else if(choice == EChoice.Over)
            {
                Environment.Exit(0);
            }
        }
    }
}
