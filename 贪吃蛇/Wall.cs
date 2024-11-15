using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal class Wall : GameObject
    {

        //初始化墙方块的位置
        public Wall(int x,int y)
        {
            position.x = x; position.y = y;
        }

        //画墙块
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write("■");
        }
    }
}
