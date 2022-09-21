using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseUno
{
    public class ReverseUnoSingleLinkedList<T>
    {
        public Node<T> first;
        public ReverseUnoSingleLinkedList() {}
        
        //Get to the last Node, append to the end
        public void AddNode(Node<T> newNode) 
        {
            if (first == null)
            {
                first = newNode;
            }
            else 
            {
                Node<T> current = first;
                while (current.Next != null) 
                {
                    current = current.Next;
                }
                current.Next = newNode;

            }
        }
        /*
         * Reversing a linked list means, swapping the pointer from a nodes "next" node, to the "previous" node. We can accomplish this in a loop
         * Standard (a) -> (b) -> (c), where A is "first" in the LinkedList
         * Reversed (a) <- (b) <- (c), where C is now "first" in the list 
         * 
         * 1) set nextNode to the current node's next node. nextNode is the currentNode of subsequent loops.
         * 2) Set the current Node next node to be the previous Node. 
         * 3) previousNode is now set to the currentNode
         * 4) currentNode is set to nextNode from step 1.
         * 5) When complete, set first as the previousNode and the list is now reversed
         */
        public Node<T> Reverse() 
        {
            Node<T> previousNode = null, currentNode = first, nextNode = null;
            while (currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            first = previousNode;
            return first;
        }
    }
}
