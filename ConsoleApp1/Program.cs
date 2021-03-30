using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static int[,] dp = new int[1001, 1001];

        static void Main(string[] args)
        {
            foreach (var item in FindDivisors(123))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


        public static List<int> FindDivisors(int num)
        {
            var divN1 = new List<int>();
            for (int i = 2; i <= (num+1)/2+1; i++)
            {
                if ((num+1)% i == 0)
                {
                    divN1.Add(i);
                }
            }

            var divN2 = new List<int>();
            for (int i = 2; i <= (num + 2)/2 + 1; i++)
            {
                if ((num + 2) % i == 0)
                {
                    divN2.Add(i);
                }
            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"div {num + 1}");
            foreach (var item in divN1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"div {num + 2}");
            foreach (var item in divN2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------");


            int mindiv1 = num;
            int mindiv2 = num;

            int ch1=num;
            int ch2=num;

            foreach (var item in divN1)
            {
                if (Math.Abs(item-(num+1)/item)<mindiv1)
                {
                    ch1 = item;
                    ch2 = (num + 1) / item;
                    mindiv1 = Math.Abs(item - (num + 1) / item);
                }
            }

            int ch11=num;
            int ch22=num;

            foreach (var item in divN2)
            {
                if (Math.Abs(item - (num + 2) / item) < mindiv2)
                {
                    ch11 = item;
                    ch22 = (num + 2) / item;
                    mindiv2 = Math.Abs(item - (num + 2) / item);
                }
            }

     

            if (mindiv1 < mindiv2)
            {
                return new List<int> { Math.Min(ch1,ch2), Math.Max(ch1,ch2) };
            } else
            {
                return new List<int> { Math.Min(ch11, ch22), Math.Max(ch11, ch22) };
            }


        }


        public static string ReverseWords(string s)
        {
            var items = s.Split().Reverse();
            return string.Join(' ', items);
            // Напишите ваш код здесь
        }


        public static int ClosestSum(List<int> nums, int target)
        {
            int div = target;
            int[] A = nums.ToArray();
            int res = A[0]+A[1]+A[2];

            for (int i = 0; i < A.Length - 2; i++)
            {
                for (int j = i + 1; j < A.Length - 1; j++)
                {

                    for (int k = j + 1; k < A.Length; k++)
                    {
                        if (Math.Abs(A[i] + A[j] + A[k] - target)< div)
                        {
                            res = A[i] + A[j] + A[k];
                            div = Math.Abs(A[i] + A[j] + A[k] - target);
                            Console.WriteLine($"{A[i]} {A[j]} {A[k]}");
                        }
                    }
                }
            }


            return res;
        }



    public static int PrimeProduct(int n)
        {
            int max = 0;
                for (int i = 1; i <= n; i++)
                {
                    int prod = 0;
                    if (isPrime(i) && isPrime(n - i))
                    {
                        prod = i * (n - i);
                    }
                    if (prod > max)
                    {
                        max = prod;
                    }
                }
            return max;
 
        }

        static bool isPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2;
                     i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static bool PerfectNumbers(int n)
        {
            if (n==1)
            {
                return false;
            }

            int sum = 1;
            for (int i = 2 ; i < n; i++)
            {
                if (n%i==0)
                {
                    sum += i;
                }
            }

            if (sum == n)
            {
                return true;
            }
            return false;
        }


        public static int MaxProduct(List<int> nums)
        {
            int[] arr = nums.ToArray();
            int result = arr[0];
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int mul = arr[i];

                for (int j = i + 1; j < n; j++)
                {
                    result = Math.Max(result, mul);
                    mul *= arr[j];
                }

                result = Math.Max(result, mul);
            }
            return result;
        }


        public static int SequenceMaxNumber(int n)
        {
            int max = n;
            while (true)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = n * 3 + 1;
                    if (n > max)
                    {
                        max = n;
                    }
                }
                if (n==4)
                {
                    return max;
                }
            }
        }


        public static int Moves(List<int> nums)
        {
            int changeEvenCnt = 0, changeOddCnt = 0;
            for (int idx = 0; idx < nums.Count; idx++)
            {
                int minOf2Sides = Math.Min((idx > 0 ? nums[idx - 1] : nums[idx] + 1), (idx + 1 < nums.Count ? nums[idx + 1] : nums[idx] + 1));
                if (idx % 2 == 0)
                {
                    changeEvenCnt += nums[idx] >= minOf2Sides ? nums[idx] - minOf2Sides + 1 : 0;
                }
                else
                {
                    changeOddCnt += nums[idx] >= minOf2Sides ? nums[idx] - minOf2Sides + 1 : 0;
                }
            }
            return Math.Min(changeEvenCnt, changeOddCnt);
        }


        public static int value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;
            return -1;
        }


        public static int GetDecimalNumber(string roman)
        {
            string str = roman;
            // Initialize result
            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {
                // Getting value of symbol s[i]
                int s1 = value(str[i]);

                // Getting value of symbol s[i+1]
                if (i + 1 < str.Length)
                {
                    int s2 = value(str[i + 1]);

                    // Comparing both values
                    if (s1 >= s2)
                    {
                        // Value of current symbol is greater
                        // or equalto the next symbol
                        res = res + s1;
                    }
                    else
                    {
                        res = res + s2 - s1;
                        i++; // Value of current symbol is
                             // less than the next symbol
                    }
                }
                else
                {
                    res = res + s1;
                    i++;
                }
            }

            return res;
        }


        public static int NumSubarrays(List<int> a, int s)
        {
            int[] arr = a.ToArray();
            int k = s;
            int n = arr.Length;
            int res = 0;

            // Calculate all subarrays
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {

                    // Calculate required sum
                    sum += arr[j];

                    // Check if sum is equal to
                    // required sum
                    if (sum == k)
                        res++;
                }
            }
            return res;
        }


        public static string GetLetter(string s, int k)
        {
            string res = "";
            if (s.Length == 0)
            {
                return "";
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    res = String.Concat(Enumerable.Repeat(res, int.Parse(s[i].ToString())));
                } else if (char.IsLetter(s[i]))
                {
                    res += s[i];
                }
            }
            return res[k+1].ToString();
        }


        public static string Expand(string s)
        {
            Console.WriteLine($"Раскрываем строку {s}");
            if (s.Contains("("))
            {
                Console.WriteLine("S contains (");
                int numberS = s.IndexOfAny("0123456789".ToCharArray());
                int numberF = numberS;
                while (char.IsDigit(s[numberF]))
                {
                    numberF++;
                }
                numberF--;
                Console.WriteLine($"number starts: {numberS}");
                Console.WriteLine($"number finishes: {numberF}");

                int length = numberF - numberS + 1;
                string extracted = s.Substring(numberS, length);
                int n = int.Parse(extracted);
                Console.WriteLine($"we got number: {n}");

                
                Stack<int> st = new Stack<int>();
                int idxS = s.IndexOf('(');
                Console.WriteLine($"( starts: {idxS}");

                int idxF = s.LastIndexOf(')');
                for (int i = idxS; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        st.Push((int)s[i]);
                    }
                    else if (s[i] == ')')
                    {
                        st.Pop();
                        if (st.Count==0)
                        {
                            idxF = i;
                            break;
                        }
                    }
                }
                Console.WriteLine($") is: {idxF}");

                length = idxF - idxS-1;
                string extractedW = s.Substring(idxS+1, length);
                Console.WriteLine($"Extract: {extractedW}");

                string resTemp = String.Concat(Enumerable.Repeat(extractedW, n));
                Console.WriteLine($"Extract multi: {resTemp}");



                string res = s[0..numberS]+resTemp+s.Substring(idxF+1);
                Console.WriteLine($"final res: {res}");
                Console.ReadLine();
                return Expand(res);
            }
            return s;
        }

        public static string ExpandedForm(int number)
        {
            int[] array = new int[10];
            int copyNumber = number;
            int j = 0;
            while (copyNumber != 0)
            {
                array[j] = copyNumber % 10;
                copyNumber = copyNumber / 10;
                j++;
            }
            for (int i = array.Length-1; i >= 0; i--)
            {
                array[i] = array[i] * (int)Math.Pow(10,i);
            }
            // Напишите ваш код здесь
            List<int> list = array.Where(s => s != 0).OrderByDescending(s=>s).ToList();
            return string.Join(" + ", list);
        }


        public static string HumanReadable(List<string> words)
        {
            var dtList = words.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            if (dtList.Count == 0)
            {
                return "";
            }

            if (dtList.Count == 1)
                return dtList.First();

            if (dtList.Count == 2)
            {
                return dtList.First() + " и " + dtList.Last();
            }
            return string.Join(", ", dtList.Take(dtList.Count - 1)) + " и " + dtList.Last();
        }


        static int find_max(int i, int sum, int[] v, int k)
        {

            if (i == v.Length)
                return 0;

            if (dp[i, sum] != -1)
                return dp[i, sum];

            int ans = 0;

            // check if sum of elements excluding the
            // current one is divisible by k
            if ((sum + find_max(i + 1, sum, v, k)) % k == 0)
                ans = find_max(i + 1, sum, v, k);

            // check if sum of elements including the
            // current one is divisible by k
            if ((sum + v[i] + find_max(i + 1, (sum + v[i]) % k,
                                           v, k)) % k == 0)
                // Store the maximum
                ans = Math.Max(ans, v[i] + find_max(i + 1,
                                    (sum + v[i]) % k, v, k));

            return dp[i, sum] = ans;
        }

        public static int MaxSum(List<int> nums)
        {
            int k = 3;
            for (int i = 0; i < 1001; i++)
                for (int j = 0; j < 1001; j++)
                    dp[i, j] = -1;
            return find_max(0, 0, nums.ToArray(), k);
        }



        public static List<string> AnagramFinder(string target, List<string> words)
        {
            var res = new List<string>();
            string pattern = string.Concat(target.OrderBy(c => c));
            foreach (var item in words)
            {
                if (pattern == string.Concat(item.OrderBy(c => c)))
                {
                    res.Add(item);
                }
            }
            return res;
        }

        public static string Encode(string text)
        {
            var tempList = text.Split(' ');
            for (int i = 0; i < tempList.Length; i++)
            {
                if (tempList[i].ToUpper() != tempList[i])
                {
                    tempList[i] = $"{tempList[i].Substring(1)}{tempList[i].Substring(0, 1)}оп";
                }
            }
            return string.Join(' ', tempList);
        }


        public static List<int> SearchRange(List<int> nums, int target)
        {
            int start = nums.IndexOf(target);
            int end = nums.LastIndexOf(target);
            return new List<int> { start, end };
            // Напишите ваш код здесь
        }

        public static string GetRomanNumber(int num)
        {
            string[] str_romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string result = "";

            for (int i = 0; i < 13; ++i)
            {
                while (num - values[i] >= 0)
                {
                    result += str_romans[i];
                    num -= values[i];
                }
            }
            return result;
        }


        static List<int> DivisibleBySix(string masked)
        {
            var res = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(masked.Replace('*', i.ToString().ToCharArray()[0]));
                if (number % 6 == 0)
                {
                    res.Add(number);
                }
            }
            return res;
        }
    }
}

