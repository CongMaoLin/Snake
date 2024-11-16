using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal class Food : GameObject
    {
        Random random = new Random();

        //初始化食物，随机产生一个位置
        public Food(Snake snake)
        {
            SetFoodPositon(snake);
        }


        //画食物
        public override void Draw()
        {
            Console.SetCursorPosition(position.x,position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("●");
        }

        
        //给食物一个随机位置，且不能和墙、蛇重复
        public void SetFoodPositon(Snake snake)
        {
            
            int x = random.Next(2, Game.width / 2 - 1) * 2;//出现的位置如果是奇数，吃不到，因为横向一个字符占两个位置
            int y = random.Next(1, Game.height - 2);
            Position pos= new Position(x,y);

            bool samePosition = false;  
            for (int i = 0; i < snake.snakeLen; i++)
            {
                if(pos == snake.snakeBodys[i].position)
                {
                    SetFoodPositon(snake);
                    samePosition = true;
                    break;
                }
                 
            }
            if (!samePosition) { position = pos; }
           
            //position = pos;//递归被挂起后这里会无条件执行，且递归无返回值，最后还是第一次递归的重叠位置
        }
    }
}
