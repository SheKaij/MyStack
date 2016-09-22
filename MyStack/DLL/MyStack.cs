using System;
using System.CodeDom;
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

        public int Count { get; private set; }

        private int _maxSize;

        public int MaxSize
        {
            get { return _maxSize; }
            set
            {
                if (value < Count)
                    Count = value;
                _maxSize = value;
            }
        }

        private int _peek;
        public int Peek
        {
            get
            {
                if (Count == 0)
                    throw new InvalidOperationException("The Stack is empty!");
                return _peek;
            }
            private set { _peek = value; }
        }

        public void Push(int item)
        {
            Stack.Push(item);
            if (Count < MaxSize)
                Count++;
            Peek = item;
        }

        public int Pop()
        {
            var result = Stack.Pop();
            Count--;
            if (Count > 0)
                Peek = Stack.Peek();
            return result;
        }
        
        public void Clear()
        {
            Count = 0;
            Stack.Clear();
        }

        public int AddTop()
        {
            int result;
            switch (Count)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    return Peek;
                default:
                    result = checked(Pop() + Pop());
                    break;
            }
            Push(result);
            return result;
        }

        public int MultiplyTop()
        {
            int result;
            switch (Count)
            {
                case 0:
                    result = 0;
                    break;
                case 1:
                    return Peek;
                default:
                    result = checked(Pop() * Pop());
                    break;
            }
            Push(result);
            return result;
        }

        public int AddAll()
        {
            if (Count == 0)
                return 0;

            int[] array = Stack.ToArray();
            int result = 0;
            
            for (int i = 0; i < Count; i++)
            {
                result = checked(result + array[i]);
            }
            return result;
        }

        public int MultiplyAll()
        {
            if (Count == 0)
                return 0;

            int[] array = Stack.ToArray();
            int result = array[0];

            for (int i = 1; i < Count; i++)
            {
                result = checked(result * array[i]);
            }
            return result;
        }
    }
}
