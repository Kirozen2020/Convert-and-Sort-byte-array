
using System;

namespace ByteArraySorting
{
    internal class ByteSorting
    {
        int numberOfElements;
        byte[] data;

        public ByteSorting(int numberOfElements)
        {
            this.numberOfElements = numberOfElements;
            this.data = new byte[numberOfElements];
        }
        public byte[] GetSortedArray()
        {
            FillArray();
            SortdArray();
            return this.data;
        }

        private void SortdArray()
        {
            for (int i = 0; i < this.data.Length-1; i++)
            {
                for (int j = 0; j < this.data.Length-i-1; j++)
                {
                    if (this.data[j] > this.data[j + 1])
                    {
                        byte temp = this.data[j];
                        this.data[j] = this.data[j + 1];
                        this.data[j + 1] = temp;
                    }
                }
            }
        }

        private void FillArray()
        {
            int input = 0;
            for (int i = 0; i < this.numberOfElements; i++)
            {
                Console.Write($"Plese enter element {i+1}: ");
                while (true)
                {
                    char inputChar = (char)Console.Read();
                    if(inputChar >= '0' &&  inputChar <= '9')
                    {
                        input = input * 10 + (inputChar - '0');
                    }
                    else if (inputChar == '\n' || inputChar == '\0')
                    {
                        continue;
                    }
                    else
                    {
                        if(input > 255)
                        {
                            Console.Write("Invalid input, try again. ");
                            i--;
                        }
                        else
                        {
                            this.data[i] = (byte)input;
                        }
                        
                        input = 0;
                        break;
                    }
                }
            }
        }
    }
}
