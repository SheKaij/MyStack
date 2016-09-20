using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack.DLL
{
    interface IStack<T>
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
        /// Returns an object from the top of the stack without removing it
        /// </summary>
        /// <returns>The object at the top of the stack</returns>
        T Peek();

        /// <summary>
        /// Removes all objects from the Stack
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the number of elements contained in the Stack
        /// </summary>
        /// <returns>The number of elements in the stock</returns>
        int Size();
    }
}
