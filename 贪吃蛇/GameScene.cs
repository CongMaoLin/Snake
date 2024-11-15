using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace 贪吃蛇
{
    internal class GameScene : ISceneStart
    {
        Map map;
        Snake snake;
        Food food;
        bool checkEndGame = false;
        
        //初始化游戏场景
        public GameScene() 
        {
            
            map = new Map();
            snake  = new Snake(30,20);
            food = new Food(snake);
            
        }


        //游戏场景执行方法
        public void SceneStart()
        {


            snake.Move();
            checkEndGame = snake.CheckCrush(map);
            
            //如果撞墙，则切换结束场景
            if (checkEndGame) 
            { 
                Game.SceneChange(E_SceneType.Over);  
            }
            else //否则将墙体、食物、蛇画出
            {
                
                snake.Draw();
                map.Draw();
                snake.EatFood(food);
                food.Draw();
            }

            Thread.Sleep(200);

            //输入并改变蛇运动方向
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        snake.ChangeSnakeDirection(ESnakeMoveDirection.Up);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        snake.ChangeSnakeDirection(ESnakeMoveDirection.Down);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        snake.ChangeSnakeDirection(ESnakeMoveDirection.Left);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        snake.ChangeSnakeDirection(ESnakeMoveDirection.Right);
                        break;

                }
            }

            


        }
    }
}
