
using System;
using System.Text;

namespace ByteArraySorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("For parcing please enter empty line\n");
            string input = Console.ReadLine();
            string allStrings = "";

            //Get strings until the input is empty
            while(input.Length > 0)
            {
                allStrings += ";" + input;
                input = Console.ReadLine();
            }
            
            if (allStrings.Length > 0 && allStrings[0] == ';')
            {
                allStrings = allStrings.Substring(1);
            }
            //convert all the input to a array
            string[] array = allStrings.Split(';');

            string[] sortedArray = SortByteArray(ConvertToByteArray(array));

            //print sorted array
            
            foreach(var item in sortedArray)
            {
                Console.WriteLine(item.ToString());
            }
            
            Console.WriteLine("\n\nPress any key for closing");
            Console.ReadKey();
        }
        /// <summary>
        /// Converts to byte array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private static string[] ConvertToByteArray(string[] array)
        {
            string[] bytes = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                // from: https://stackoverflow.com/questions/5657169/convert-string-to-byte
                byte[] arr = Encoding.UTF8.GetBytes(array[i]);//UTF8 & ASCII giving the same result at the end
                
                for(int j = 0;j < arr.Length ; j++)
                {
                    bytes[i] += arr[j];
                }
            }

            return bytes;
        }
        /// <summary>
        /// Sorts the byte array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        private static string[] SortByteArray(string[] array) //Bubble sort
        {
            //from: https://www.geeksforgeeks.org/bubble-sort/
            string[] copy = array;
            for (int i = 0; i < copy.Length-1; i++)
            {
                for (int j = 0; j < copy.Length - i - 1; j++)
                {
                    if (copy[j].Length > copy[j + 1].Length)
                    {
                        string temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                    else if (copy[j].Length == copy[j + 1].Length)
                    {
                        //from: https://www.c-sharpcorner.com/UploadFile/mahesh/compare-strings-in-C-Sharp/#:~:text=Figure%201.-,Using%20String.Compare,-String.Compare%20method
                        if (string.Compare(copy[j], copy[j+1]) > 0)
                        {
                            string temp = copy[j];
                            copy[j] = copy[j + 1];
                            copy[j + 1] = temp;
                        }
                    }
                }
            }
            return copy;
        }
    }
}
