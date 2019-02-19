using System;
using System.Linq;

namespace Permutations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter in array of numbers seperated with ',': ");
                Console.WriteLine(classifyPermutation(Console.ReadLine().Split(',').Select(x => Convert.ToInt32(x)).ToArray()));
            }

        }

        static string classifyPermutation(int[] arrayToSort)
        {
            int[] sortedArray = arrayToSort.OrderBy(x => x).ToArray();
            int count = 0;
            //classification is either 0 or 1, 0 means the permutation is even; and 1 meaning the permutation is odd
            string classification = "Odd";
            bool isDone = false;
            while (!isDone)
            {
                int[] tmpArray = arrayToSort;
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    if (arrayToSort[i] != sortedArray[i])
                    {
                        int correctIndex = Array.IndexOf(sortedArray, tmpArray[i]);
                        int tmp = tmpArray[correctIndex];
                        tmpArray[correctIndex] = tmpArray[i];
                        tmpArray[i] = tmp;
                        count++;
                        arrayToSort = tmpArray;
                    }
                }
                for (int i = 0; i < arrayToSort.Length; i++)
                {
                    if (arrayToSort[i] != sortedArray[i])
                    {
                        break;
                    }
                    if (i == arrayToSort.Length - 1)
                    {
                        isDone = true;
                    }
                }
            }
            if (count % 2 == 0) { classification = "Even"; }
            return classification;
        }
    }
}
