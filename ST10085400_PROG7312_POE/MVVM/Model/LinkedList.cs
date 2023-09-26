using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085400_PROG7312_POE.MVVM.Model
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddToEnd(double value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public bool Remove(double value)
        {
            if (Head == null)
                return false;

            if (Head.Value == value)
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            Node current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                        Tail = current;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public double[] ToArray()
        {
            double[] result = new double[Count];
            Node current = Head;
            int i = 0;
            while (current != null)
            {
                result[i] = current.Value;
                current = current.Next;
                i++;
            }
            return result;
        }

        public bool Contains(double value)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

    }
}
