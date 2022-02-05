using System;
using System.Diagnostics;
using System.Threading;

namespace Sorting_algorithms
{
    class Program
    {
        const int globalArrayLength = 10;


        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
 
            int[] array = GenerateUnsorte§dArray(10, 0, 10);
            PrintArray(array);
            //array = BubbleSort(array);
            //array = SelectionSort(array);
            stopwatch.Start();
            array = InsertionSort(array);
            stopwatch.Stop();
            PrintArray(array);
    
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
            a = a+b;
            b = a-b;
            a = a-b;
        }

        static int[] BubbleSort(int[] array){
            for(int i = 0; i < array.Length; i++){
                for(int j = 0; j < array.Length - i - 1; j++){
                    if(array[j] > array[j+1]){
                        Swap(ref array[j], ref array[j+1]);
                    }
                }
            }
            return array;
        }
        //Delar upp arrayen i en sorterad och en osorterad del. 
        //Genom att jämföra array[j] mot varje element i arrayen efter j så kan man byta plats på array[j] och array[j + (x-steg)] om array[j + (x-steg)] är mindre än array[j]
        static int[] SelectionSort(int[] array){   
            for(int j = 0; j < array.Length - 1; j++){
                for(int i = 1 + j; i < array.Length; i++){
                    if(array[j] > array[i]){
                        Swap(ref array[j], ref array[i]);
                    }
                }
            }
            return array;
        }
        static int[] InsertionSort(int[] array){
            //Starta på andra elementet 
            for(int j = 1; j < array.Length; j++){
                //Loopa genom föregående element
                for(int i = 0; i < j; i++){
                    if(array[j] < array[i]){
                        //Flytta elementet på j till rätt plats och flytta fram de andra elementen i arrayen
                        for(int x = i; x < j; x++){
                            Swap(ref array[j], ref array[x]);
                        }
                    }
                }
            }
            return array;
        }
        static int[] MergeSort(int[] array){
            return array;
        }
    }
}