using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circular_prime
{
    class Program
    {
        static void Select_simple(int n)
        {
            bool IsSimple;
            for (int i = 2; i <= n; i++)
            {
                IsSimple = true;
                foreach (int num in simple_nums)
                {
                    if (Math.Sqrt(i) < num)
                        break;
                    if (((i % num) == 0))
                    {
                        IsSimple = false;
                        break;
                    }
                }
                if (IsSimple)
                    simple_nums.Add(i);
            }
        }

        static int Count_rank(int n)
        {
            int count = 1;
            while ((n / 10) > 0)
            {
                count++;
                n = n / 10;
            }
            return count;
        }
        static int Make_circular(int n)
        {
            int temp;
            temp = n % 10;
            return n/10+temp*(int)Math.Pow(10,Count_rank(n)-1);
        }
        static bool Check_circular_prime(int n)
        {
            int temp=n;
            bool IsSimple = true;
            do
            {
                temp = Make_circular(temp);
                if (!circular_prime_nums.Contains(temp))
                {
                    IsSimple = false;
                    break;
                }
            }
            while (temp != n);
            return IsSimple;
        }
        static void Count_circular()
        {
            int count = 0;
            while (circular_prime_nums.Count!=0)
            {
                int num = circular_prime_nums[0];
                if (Check_circular_prime(num))
                {
                    int temp = num;
                    do
                    {
                        temp = Make_circular(temp);
                        count++;
                        circular_prime_nums.Remove(num);
                    }
                    while (temp != num);
                }
                else
                    circular_prime_nums.Remove(num);
            }
            Console.WriteLine(count);
        }
        static List<int> simple_nums = new List<int>();
        static List<int> circular_prime_nums = new List<int>();
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Select_simple(n);
            circular_prime_nums = simple_nums.GetRange(0, simple_nums.Count);
            Count_circular();
        }
    }
}
