using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stack
    {
        private float[] items;
        private int count;
        const int n = 10;

        public float this[int index] // метод, чтобы взять элемент стека по индексу
        {
            get { return items[index]; }
        }
        public Stack()
        {
            items = new float[n];
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }
        public void Push(float item) //добавление элемента в стек
        {
            if (count == items.Length)
            {
                Console.WriteLine("Стек заполнен");
                return;
            }
            items[count++] = item;
        }
        public float Pop() // извлечение элемента из стека
        {
            if (IsEmpty)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            float item = items[--count];
            items[count] = 0;
            return item;
        }
        public float PeekTop() // вершины стека
        {
            if (IsEmpty)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            int countt = count;
            return items[--countt];
        }
        public float PeekStack() // вывод стека
        {
            if (IsEmpty)
            {
                Console.WriteLine("Стек пуст");
                return 0;
            }
            int countt = count;
            do
            {
                Console.WriteLine("\t" + items[--countt]);
            } while (countt > 0);
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество стеков (равное кол-ву эл-в в каждом стеке): ");
            sbyte counter = sbyte.Parse(Console.ReadLine());
            Stack[] stack = new Stack[counter]; // массив объектов

            // ввод элементов
            for (int i = 0; i < counter; i++)
            {
                stack[i] = new Stack();
                for (int j = 0; j < counter; j++) // кол-во элементов в каждом стеке = кол-ву стеков
                {
                    Console.WriteLine($"Введите элемент {j + 1} в стеке номер {i + 1}: ");
                    float x = float.Parse(Console.ReadLine());
                    stack[i].Push(x);
                }
            }

            // вывод элементов
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"\nВывод стека №{i + 1}: ");
                stack[i].PeekStack();
            }


            Console.WriteLine("\nCписок стеков, содержащих отрицательные элементы на данный момент:");
            bool flag1 = false;
            for (int i = 0; i < counter; i++) // перебираем стеки
            {
                for (int j = 0; j < counter; j++) // перебираем элементы стека
                {
                    if (stack[i][j] < 0) // проверка на отрицание
                    {
                        Console.WriteLine("Найден стек #{0}", i + 1);
                        Console.WriteLine("Элементы этого стека:");
                        stack[i].PeekStack();
                        flag1 = true;
                    }
                }
            }
            if (flag1 == false)
            {
                Console.WriteLine("Такого стека нет.");
            }

            Console.WriteLine("\nИзвлечение элемента из стека:");
            Console.Write("Введите номер стека[1-3]:");
            sbyte p = sbyte.Parse(Console.ReadLine());
            p = --p;
            stack[p].Pop();
            stack[p].PeekStack();

            Console.WriteLine("\nДобавление элемента в стек:");
            Console.Write("Введите номер стека[1-3]:");
            p = sbyte.Parse(Console.ReadLine());
            p = --p;
            Console.Write("Введите элемент, к-й хотите добавить:");
            int q = sbyte.Parse(Console.ReadLine());
            stack[p].Push(q);
            stack[p].PeekStack();


            float min = stack[0].PeekTop();
            int IndexMin = 0;
            float max = stack[0].PeekTop();
            int IndexMax = 0;
            for (int i = 1; i < counter; i++) // counter = кол-во стеков, но уже != кол-ву эл-в в стеке
            {
                if (stack[i].PeekTop() < min)
                {
                    min = stack[i].PeekTop();
                    IndexMin = i;
                }
            }

            Console.Clear();

            // вывод элементов
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"\nВывод стека №{i + 1}: ");
                stack[i].PeekStack();
            }

            Console.WriteLine("\nCтек #{0} с наименьшим верхним элементом: ", IndexMin + 1);
            stack[IndexMin].PeekStack();

            for (int i = 1; i < counter; i++) // counter = кол-во стеков, но уже != кол-ву эл-в в стеке
            {
                if (stack[i].PeekTop() > max)
                {
                    max = stack[i].PeekTop();
                    IndexMax = i;
                }
            }
            Console.WriteLine("\nCтек #{0} с наибольшим верхним элементом: ", IndexMax + 1);
            stack[IndexMax].PeekStack();
        }
    }
}
