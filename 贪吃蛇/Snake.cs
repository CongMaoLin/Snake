using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    /// <summary>
    /// 蛇头的方向
    /// </summary>
    internal enum ESnakeMoveDirection 
    { 
        Up,
        Down,
        Left,
        Right
    }

    internal class Snake : IDraw
    {
        public SnakeBody[] snakeBodys;
        ESnakeMoveDirection direction;
        public  int snakeLen = 0;

        //初始化蛇头、蛇身
        public Snake(int x, int y)
        {
            snakeBodys = new SnakeBody[200];
            snakeBodys[0] = new SnakeBody(E_SnakeType.Head,x,y);
            snakeBodys[1] = new SnakeBody(E_SnakeType.Body, x-2, y);
            snakeBodys[2] = new SnakeBody(E_SnakeType.Body, x - 4, y);
            direction = ESnakeMoveDirection.Right;
            snakeLen = 3;
        }


        //画蛇
        public void Draw()
        {
            for (int i = 0; i < snakeLen; i++)
            {
                snakeBodys[i].Draw();
            }
        }


        //蛇移动
        public void Move()
        {
            //将前一个身体擦除
            Console.SetCursorPosition(snakeBodys[snakeLen-1].position.x, snakeBodys[snakeLen-1].position.y);
            Console.Write("  ");

            //蛇身追踪，最后一个蛇身块的位置等于前一个蛇身块的位置
            for (int i = snakeLen-1 ; i > 0; i--)
            {
                snakeBodys[i].position = snakeBodys[i - 1].position;
            }

            //判断蛇头此时的方向并改变位置
            switch (direction)
            {
                case ESnakeMoveDirection.Up:
                    snakeBodys[0].position.y--;
                    break;
                case ESnakeMoveDirection.Down:
                    snakeBodys[0].position.y++;
                    break;
                case ESnakeMoveDirection.Left:
                    snakeBodys[0].position.x -=2;
                    break;
                case ESnakeMoveDirection.Right:
                    snakeBodys[0].position.x += 2;
                    break;
            }
        }

        //改变蛇头方向
        public void ChangeSnakeDirection(ESnakeMoveDirection direction)
        {
            //如果有蛇身，不能让蛇头沿着蛇身反向移动，不然蛇身就被蛇头顶没了
            if(this.direction == direction ||
               snakeLen>1 &&
               (this.direction == ESnakeMoveDirection.Left && direction == ESnakeMoveDirection.Right ||
                 this.direction == ESnakeMoveDirection.Up && direction == ESnakeMoveDirection.Down ||
                 this.direction == ESnakeMoveDirection.Down && direction == ESnakeMoveDirection.Up ||
                this.direction == ESnakeMoveDirection.Right && direction == ESnakeMoveDirection.Left))
            {
                return;
            }
            this.direction = direction;
        }


        //判断蛇头是否撞了墙或者蛇身
        public bool CheckCrush(Map map)
        {
            foreach (var item in map.walls)
            {
                if (snakeBodys[0].position == item.position)
                {
                    return true;
                }
            }
            for (int i = 1; i < snakeLen; i++)
            {
                if (snakeBodys[0].position == snakeBodys[i].position)
                {
                    return true ;
                }
            }

            return false;
        }

        //吃食物
        public void EatFood(Food food)
        {
            if (snakeBodys[0].position == food.position)
            {

                //应该先确定食物下一次出现的位置
                food.SetFoodPositon(this);
                //然后再长身体
                GrowUp();
            }
        }

        //长身体
        public void GrowUp()
        {
            //让新长的蛇身位置等于上一个蛇身块或蛇头的位置
            snakeBodys[snakeLen] = new SnakeBody(E_SnakeType.Body, 
                snakeBodys[snakeLen-1].position.x, snakeBodys[snakeLen - 1].position.y);
            snakeLen++;
        }
    }
}
