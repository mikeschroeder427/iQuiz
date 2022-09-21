using System;

namespace ReverseUno
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ReverseUnoSingleLinkedList<string>();
            list.AddNode(new Node<string>("a"));
            list.AddNode(new Node<string>("b"));
            list.AddNode(new Node<string>("c"));
            Console.WriteLine(string.Format("Initial: {0}", list.first.value));
            list.Reverse();
            Console.WriteLine(string.Format("Reversed: {0}", list.first.value));
        }
    }
}