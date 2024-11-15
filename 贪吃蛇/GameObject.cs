using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪吃蛇
{
    internal abstract class GameObject : IDraw
    {
        //用于存储对象地址
        public Position position;


        //用于不同对象的绘画
        public abstract void Draw();
        
    }
}
