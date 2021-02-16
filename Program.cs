using System;
using System.Numerics;


namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int m;
            int n;
            Console.WriteLine("Добрый день! ");
            Console.WriteLine("Данная программа рассчитывает для прямоугольного поля размера M на N клеток количество путей из верхней левой клетки в правую нижнюю.");
            // Только положительные числа
            do {
            Console.Write("Введите размер поля М: ");
             m= Convert.ToInt32(System.Console.ReadLine());
            } while (m<1);
            do {
            Console.Write("Введите размер поля N: ");
             n = Convert.ToInt32(System.Console.ReadLine());
            } while (n<1);
            // проверено тут https://www.wolframalpha.com
            Console.WriteLine("Количество путей вычисляется по формуле неупорядоченной выборки с повторениями из комбинаторики.");
            // проверяем по частям 
            if (n==1 || m==1) {    Console.Write("Будет только один путь.");  }
            else
            {
            BigInteger result1 = FactTree((m - 1) + n);
            BigInteger result2 = FactTree(m);
            BigInteger result3 = FactTree(n-1);
            // конечное значение
            BigInteger total = result1 / (result2 * result3);
            Console.Write("Путей будет ");
            Console.Write(total);
            }
            Console.WriteLine();
            System.Console.ReadLine();

        }
        // создаем древо для вычислений факториала
          static  BigInteger ProdTree(int l, int r)
            {
                if (l > r)
                    return 1;
                if (l == r)
                    return l;
                if (r - l == 1)
                // использую BigInteger из пространства  System.Numeric
                //возможно переполнение, лучше использовать значения до 20
                    return (BigInteger)l * r;
                //уполовиним значение
                int m = (l + r) / 2;
            // и раскидаем по веткам в рекурсии
                return ProdTree(l, m) * ProdTree(m + 1, r);
            }
        // Формула факториала
            static BigInteger FactTree(int n)
            {
                if (n < 0)
                    return 0;
                if (n == 0)
                    return 1;
                if (n == 1 || n == 2)
                    return n;
                return ProdTree(2, n);
            }
        }
    }

