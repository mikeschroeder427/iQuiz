using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseUno
{
    public class Node<T>
    {
        public Node<T> Next;
        public T value;

        public Node(T value) 
        {
            this.value = value;
            Next = null;
        }
    }
}
