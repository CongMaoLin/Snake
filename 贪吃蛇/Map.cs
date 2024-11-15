using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal class Map : IDraw
    {
        //用于存储每个墙方格
        public Wall[] walls;

        //墙块初始化，用于存储每个墙块的位置
        public Map()
        {
            //确定墙方块的个数
            //宽度一个字符占两个字节，所以不用乘2
            walls = new Wall[Game.width + (Game.height - 3) * 2];
            
            //记，墙列表里已经到第几块墙块
            int arrPos = 0;

            //横向墙块
            for (int i = 0; i < Game.width; i+=2)
            {
                walls[arrPos] = new Wall(i, 0);
                arrPos++;
            }
            for (int i = 0; i < Game.width; i += 2)
            {
                walls[arrPos] = new Wall(i, Game.height -2);//貌似画到倒数第一行会出现问题，不知道是不是控制台问题会，将下方Game.height-1后会少格子
                arrPos++;
            }

            //纵向墙块
            for (int i = 1; i < Game.height -2; i++) {
                walls[arrPos] = new Wall(0, i);
                arrPos++;
            }
            for (int i = 1; i < Game.height -2; i++)
            {
                walls[arrPos] = new Wall(Game.width - 2, i);
                arrPos++;
            }
        }


        //把全部墙块画出来，墙体就有了
        public void Draw()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
