using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 蛇的类型
    /// </summary>
    internal enum E_SnakeType
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
    internal class SnakeBody : GameObject
    {
        E_SnakeType type;

        //初始化蛇块位置
        public SnakeBody(E_SnakeType type,int x,int y)
        {
            this.type = type;
            position.x = x;
            position.y = y; 
        }


        //画蛇的方法
        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (type == E_SnakeType.Head)
            {
                Console.Write("●");
            }
            else if(type == E_SnakeType.Body)
            {
                Console.Write("◎");
            }
        }
    }
}
