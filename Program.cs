using System;
using System.Diagnostics;
using System.Threading;

namespace Sorting_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
 
            stopwatch.Start();
            int[] array = GenerateUnsortedArray(10, 0, 10);
            PrintArray(array);
            array = BubbleSort(array);
            PrintArray(array);
            stopwatch.Stop();
    
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }



        static int[] GenerateUnsortedArray(int arrayLength, int minVal, int maxVal){
            Random rand = new Random();
            int[] array = new int[arrayLength];

            for(int i = 0; i < arrayLength; i++){
                array[i] = rand.Next(minVal, maxVal);
            }
            return array;
        }

        static void PrintArray(int[] array){
            Console.WriteLine("");
            for(int i = 0; i < array.Length - 1; i++){
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine(array[array.Length - 1]);
            Console.WriteLine("");
        }

        static void Swap(ref int a, ref int b){
            /*
            a = a+b;
            b = a-b;
            a = a-b;
            */
            int temo = a;
            a= b;
            b = temo;
        }

        static int[] BubbleSort(int[] array){
            for(int i = 0; i < array.Length; i++){
                for(int j = 0; j < array.Length - i - 1; i++){
                    if(array[i] > array[i+1]){
                        Swap(ref array[i], ref array[i+1]);
                    }
                }
            }
            return array;
        }
    }
}