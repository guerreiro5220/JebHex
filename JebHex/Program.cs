using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JebHex
{
    public class Program
    {
        private static string[] ValidHexValues = new string[]
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "a", "b", "c", "d", "e", "f", "1a"
        };
        

        static void Main(string[] args)
        {
            bool validInput = true;
            var sb = new StringBuilder();

            Console.WriteLine("Enter encrypted message(s) or enter 0 to end:");

            while (validInput)
            {
                string encryptedCodes = Console.ReadLine().Trim().ToLower();
                validInput = !string.Equals(encryptedCodes, "0") ? true : false;
                if (validInput)
                {
                    int totalpermutations = CalculatePermutations(encryptedCodes, 0);
                    sb.Append(string.Format("{0} has {1} permutation(s). {2}", encryptedCodes, totalpermutations.ToString(), Environment.NewLine));
                }
                else
                {
                    break;
                }
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("           Results           ");
                Console.WriteLine("-----------------------------");
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("\nPress Any Key to Exit");
            Console.ReadKey();
        }

        private static int CalculatePermutations(string stringToAnalyze, int currentIndex)
        {
            int permutationCount = 0;

            //Analyze single character string
            if (ValidHexValues.Contains(stringToAnalyze.Substring(currentIndex, 1)))
            {
                if (currentIndex + 1 < stringToAnalyze.Length)
                {
                    permutationCount += CalculatePermutations(stringToAnalyze, currentIndex + 1);
                }
                else
                {
                    permutationCount++;
                }
            }

            //Analyze 2 character string
            if (currentIndex + 1 < stringToAnalyze.Length)
            {
                if (ValidHexValues.Contains(stringToAnalyze.Substring(currentIndex, 2)))
                {
                   if (currentIndex + 2 < stringToAnalyze.Length)
                   {
                       permutationCount += CalculatePermutations(stringToAnalyze, currentIndex + 2);
                   }
                   else
                   {
                       permutationCount++;
                   }
                }
            }

            return permutationCount;
        }
    }
}
