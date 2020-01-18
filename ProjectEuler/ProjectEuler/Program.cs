using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            //LychrelNumbers();
            Console.WriteLine(GoldBachsOtherConjecture());

            Console.Read();
        }

        static long GoldBachsOtherConjecture()
        {
            long i = 9;
            while (true)
            {
                bool isTrue = true;
                for (long p = 2; p < i; p++)
                {
                    if (!IsPrime(i) && IsPrime(p))
                    {
                        isTrue = Math.Sqrt((double)(i - p) / 2) % 1 < 1e-4;
                    }
                    if (isTrue)
                    {
                        Console.WriteLine("{0} = {1} + 2*{2}^2", i, p, Math.Floor(Math.Sqrt((double)(i - p) / 2)));
                        break;
                    }
                }
                if (!isTrue)
                {
                    break;  
                }
                i += 2;
            }

            return i;
        }

        static void LychrelNumbers()
        {
            int nLychrel = 0;
            HashSet<long> isNotLychrel = new HashSet<long>();
            for (int i = 1; i < 10000; i++)
            {
                int? iterations = IterationsForPalindrome(i, isNotLychrel);
                if (iterations is null)
                {
                    nLychrel++;
                }
                else
                {
                    isNotLychrel.Add(i);
                }
            }
            Console.WriteLine(nLychrel);
        }

        private static int? IterationsForPalindrome(long i, HashSet<long> isNotLychrel)
        {
            long j = ReverseInt(i);
            //if (isNotLychrel.Contains(j))
            //{
            //    return 0;
            //}
            int count = 1;
            HashSet<long> numbersReached = new HashSet<long>(); 
            while (i + j != ReverseInt(i + j))
            {
                count++;
                if (count >= 50)
                {
                    return null;
                }
                i = i + j;
                if (i < 10000)
                {
                    numbersReached.Add(i);
                }
                if (j < 10000)
                {
                    numbersReached.Add(j);
                }
                j = ReverseInt(i);
            }
            isNotLychrel.UnionWith(numbersReached);
            return count;
        }

        static long ReverseInt(long num)
        {
            long result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        private static double PythagoreanTriplet()
        {
            int a = 3;
            int b = 4;

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            while (true)
            {
                if (c % 1 < 1e-4)
                {
                    Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
                }
                b++;
                if (b > 499)
                {
                    a++;
                    b = a + 1;
                }
                c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                if (a + b + c == 1000)
                {
                    Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
                    break;
                }
            }
            return a*b*c;
        }

        private static int SpiralPrimes()
        {
            //int[] diags = new int[4 * sideLength / 2];
            int sideLength = 3;
            int maxSkip = sideLength - 1;
            int skip = 2;

            int number = 3;
            Console.WriteLine(number);
            int count = 2;
            int nPrimes = 1;
            double ratio = 1;

            while (ratio > 0.1)
            {
                while (skip <= maxSkip)
                {
                    while (number < Math.Pow(sideLength, 2))
                    {
                        number += skip;
                        Console.WriteLine(number);
                        count++;
                        if (IsPrime(number))
                        {
                            nPrimes++;
                        }
                    }
                    skip += 2;
                }
                ratio = (double)nPrimes / (count);
                sideLength += 2;
                maxSkip = sideLength - 1;
            }
            return sideLength - 2;
        }

        private static bool IsPalindrome(int number)
        {
            string numberString = number.ToString();
            char[] chars = numberString.ToCharArray();
            Array.Reverse(chars);
            StringBuilder builder = new StringBuilder();
            foreach (char value in chars)
            {
                builder.Append(value);
            }
            if (builder.ToString() == numberString)
            {
                return true;
            }
            return false;
        }

        static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
