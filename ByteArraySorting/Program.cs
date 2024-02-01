
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
                if(inputNumber >= '0' && inputNumber <= '9')
                {
                    numberOfElements = numberOfElements * 10 + (inputNumber - '0');
                }
                else
                {
                    break;
                }
            }
            Console.Read();
            byte[][] bytes = new byte[numberOfElements][];
            char[][] chars = new char[numberOfElements][];

            //colection data and converting to byte
            for (int i = 0; i < numberOfElements; i++)
            {
                char[] element = new char[0];
                Console.Write($"Please enter element {i + 1}: ");
                while (true)
                {
                    char inputChar = (char)Console.Read();

                    if(
                        (inputChar >= '0' && inputChar <= '9') ||
                        (inputChar >= 'a' && inputChar <= 'z') ||
                        (inputChar >= 'A' && inputChar <= 'Z'))
                    {
                        element = AddCharToArray(element, inputChar);
                    }
                    else if(inputChar == '\n' ||  inputChar == '\0')
                    {
                        continue;
                    }
                    else
                    {
                        chars[i] = element;
                        break;
                    }
                }

            }
            
            //Converting: char -> byte

            for (int i = 0;i < chars.Length;i++)
            {
                byte[] list = new byte[chars[i].Length];
                for (int j = 0; j < chars[i].Length; j++)
                {
                    list[j] = (byte)chars[i][j];
                }
                bytes[i] = list;
            }

            bytes = SortByteArray(bytes);

            //Converting: byte -> char

            for (int i = 0; i < bytes.Length; i++)
            {
                char[] list = new char[bytes[i].Length];
                for (int j = 0; j < bytes[i].Length; j++)
                {
                    list[j] = (char)bytes[i][j];
                }
                chars[i] = list;
            }
            Console.WriteLine();
            Console.Write("The sorted array is: ");
            for (int i = 0; i < chars.Length-1; i++)
            {
                for (int j = 0; j < chars[i].Length; j++)
                {
                    Console.Write($"{chars[i][j]}");
                }
                Console.Write(", ");
            }
            for (int i = 0; i < chars[chars.Length-1].Length; i++)
            {
                Console.Write($"{chars[chars.Length-1][i]}");
            }

            
            Console.WriteLine("\n\nPress any key for closing");
            Console.ReadKey();
        }

        private static byte[][] SortByteArray(byte[][] bytes)
        {
            byte[][] arr = bytes;

            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i].Length > arr[j].Length)
                    {
                        byte[] temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                    else if (arr[i].Length == arr[j].Length)
                    {
                        for (int k = 0; k < arr[i].Length; k++)
                        {
                            if (arr[i][k] > arr[j][k])
                            {
                                byte[] temp = arr[i];
                                arr[i] = arr[j];
                                arr[j] = temp;
                                break;
                            }
                            else if (arr[i][k] < arr[j][k])
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return arr;
        }

        private static char[] AddCharToArray(char[] arr, char c)
        {
            char[] list = new char[arr.Length+1];

            for (int i = 0; i < arr.Length; i++)
            {
                list[i] = arr[i];
            }
            list[arr.Length] = c;

            return list;
        }
        
    }
}
