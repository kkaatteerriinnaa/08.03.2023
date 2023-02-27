using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        public static T Max<T>(T a, T b, T c) where T:IComparable<T>
        {
            if(a.CompareTo(b)>0 && a.CompareTo(c)>0)
            {
                return a;
            }
            if (b.CompareTo(a) > 0 && b.CompareTo(c) > 0)
            {
                return b;
            }
            return c;
        }
        public static T Min<T>(T a, T b, T c) where T : IComparable<T>
        {
            if (a.CompareTo(b) < 0 && a.CompareTo(c) < 0)
            {
                return a;
            }
            if (b.CompareTo(a) < 0 && b.CompareTo(c) < 0)
            {
                return b;
            }
            return c;
        }

        public class Queue
        {
            private string[] data;
            public int size;
            private int front = -1;
            private int back = 0;
            private int count = 0;

            public Queue()
            {
                size = 10;
                data = new string[size];
            }

            public Queue(int size)
            {
                this.size = size;
                data = new string[size];
            }

            public bool IsEmpty()
            {
                return count == 0;
            }

            public bool IsFull()
            {
                return count == size;
            }

            public void Add(int i)
            {
                if (IsFull())
                    throw new ApplicationException("Очередь заполнена");
                else
                {
                    count++;
                    data[back++ % size] = Convert.ToString(i);
                }
            }
            public string Remove()
            {
                if (IsEmpty())
                    throw new ApplicationException("Очередь пуста");
                else
                {
                    count--;
                    return data[++front % size];
                }
            }
            public string Head()
            {
                if (IsEmpty())
                {
                    throw new ApplicationException("Очередь пуста");
                }
                else
                    return data[(front + 1) % size];
            }
        }

        static void Main(string[] args)
        {
            int max = Max(1, 2, 3);
            int min = Min(1, 2, 3);

            Console.WriteLine(max);
            Console.WriteLine(min);

            var Stack = new Stack<char>();
            Stack.Push('1');
            Stack.Push('2');
            Stack.Push('3');

            Console.WriteLine("Исходный стек: ");
            foreach (char s in Stack)
            {
                Console.Write(s);
            }
            Console.WriteLine("\n");

            while (Stack.Count > 0)
            {
                Console.WriteLine("Pop -> {0}", Stack.Pop());
            }

            if (Stack.Count == 0)
            {
                Console.WriteLine("\nСтек пуст!");
            }

            Queue q1 = new Queue();
            q1.Add(4);
            q1.Add(5);
            Console.WriteLine("Head {0}", q1.Head());
            q1.Add(6);
            Console.WriteLine("Remove {0}", q1.Remove());
            Console.WriteLine("Size {0}", q1.size);
            Console.WriteLine("IsEmpty {0}", q1.IsEmpty());
            q1.Remove();
        }
    }
}
