
using System;

namespace ByteArraySorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter number of elements: ");
            int numberOfElements = 0;

            while (true)
            {
                int inputNumber = Console.Read();
                //check if the entered character is a digit
                if (inputNumber >= '0' && inputNumber <= '9')
                {
                    numberOfElements = numberOfElements * 10 + (inputNumber - '0');
                }
                else
                {
                    break;
                }
            }

            PrintByteArray(new ByteSorting(numberOfElements).GetSortedArray());

            Console.ReadKey();
            
        }
        
        private static void PrintByteArray(byte[] bytes)
        {
            Console.Write("\nSorted array: ");
            for (int i = 0; i < bytes.Length-1; i++)
            {
                Console.Write(bytes[i]+", ");
            }
            Console.Write(bytes[bytes.Length-1]);
        }

    }
}
