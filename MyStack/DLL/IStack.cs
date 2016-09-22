using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.DLL
{
    public interface IStack<T>
    {
        /// <summary>
        /// Inserts an object to the top of the stack
        /// </summary>
        /// <param name="item">The object to insert</param>
        void Push(T item);

        /// <summary>
        /// Removes and returnes the top object from the stack
        /// </summary>
        /// <returns>The object removed from the stack</returns>
        T Pop();

        /// <summary>
        /// The object from the top of the stack
        /// </summary>
        T Peek { get; }

        /// <summary>
        /// Removes all objects from the Stack
        /// </summary>
        void Clear();

        /// <summary>
        /// The number of elements contained in the Stack
        /// </summary>
        int Count { get; }

        /// <summary>
        /// The maximum size of the stack
        /// </summary>
        int MaxSize { get; set; }
    }
}
