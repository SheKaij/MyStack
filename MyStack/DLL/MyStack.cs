using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.DLL
{
    public class MyStack : IStack<int>
    {
        private readonly Stack<int> Stack;

        public MyStack(int maxSize)
        {
            Stack = new Stack<int>();
            MaxSize = maxSize;
        }

        public int MaxSize { get; set; }
        public int Count { get; private set; }
        public int Peek { get; private set; }

        public void Push(int item)
        {
            if (Count < MaxSize)
            {
                Count++;
                Peek = item;
                Stack.Push(item);
            }
        }

        public int Pop()
        {
            Count--;
            return Stack.Pop();
        }
        
        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
