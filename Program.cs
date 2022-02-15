using System;
using System.Diagnostics;
using System.Threading;

namespace Sorting_algorithms
{
    class Program
    {
        const int globalArrayLength = 4;
        const int globalMinVal = -9;
        const int globalMaxVal = 10;
        static bool printArrays = true;
        

        static int[] GenerateUnsortedArray(int arrayLength, int minVal, int maxVal){
            Random rand = new Random();
            int[] array = new int[arrayLength];

            for(int i = 0; i < arrayLength; i++){
                array[i] = rand.Next(minVal, maxVal);
            }
            return array;
        }

        static void PrintArray(int[] array){
            if(!printArrays) return;

            Console.WriteLine("");
            for(int i = 0; i < array.Length - 1; i++){
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine(array[array.Length - 1]);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
 
            int[] array = GenerateUnsortedArray(globalArrayLength, globalMinVal, globalMaxVal);
            PrintArray(array);



            stopwatch.Start();

            //array = BubbleSort(array);
            //array = SelectionSort(array);
            //array = InsertionSort(array);
            //array = MergeSort(array);
            array = QuickSort(array);

            stopwatch.Stop();

            PrintArray(array);
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
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
            Console.WriteLine("Running SelectionSort"); 
            for(int j = 0; j < array.Length - 1; j++){
                for(int i = j + 1; i < array.Length; i++){
                    if(array[j] > array[i]){
                        Swap(ref array[j], ref array[i]);
                    }
                }
            }
            return array;
        }
        static int[] InsertionSort(int[] array){
            Console.WriteLine("Running Insertionsort");
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
        static int[] MergeSort(int[] arrayA){
            Console.WriteLine("Running Mergesort");
            //Kopierar arrayA till arrayB
            int[] arrayB = new int[arrayA.Length];
            for(int i = 0; i < arrayA.Length; i++){
                arrayB[i] = arrayA[i];
            }
            SplitAndMergeArray(ref arrayB, 0, arrayA.Length, ref arrayA);
            return arrayA;
        }
        //Delar upp arrayA i två delar och sortera arrayA's halvor in i arrayB. Sortera sedan ihop halvorna från arrayB och lägg in hela sorterade arrayen i arrayA
        /// <summary>
        /// beginIndex och endIndex utgör start- och slutIndex för en delarray
        /// </summary>
        static void SplitAndMergeArray(ref int[] arrayB, int beginIndex, int endIndex, ref int[] arrayA){
            //Returnerar om del-arrayen har längden 1 eller mindre.
            if((endIndex - beginIndex) <= 1) return; 

            int midIndex = (beginIndex + endIndex) / 2;

            SplitAndMergeArray(ref arrayA, beginIndex, midIndex, ref arrayB);
            SplitAndMergeArray(ref arrayA, midIndex, endIndex, ref arrayB);

            MergeArrays(ref arrayB, beginIndex, midIndex, endIndex, ref arrayA);
        }
        //Merges two sorted halves of arrayA into sorted arrayB
        static void MergeArrays(ref int[] arrayA, int beginIndex, int midIndex, int endIndex, ref int[] arrayB){
            int a = beginIndex, b = midIndex;

            for(int i = beginIndex; i < endIndex; i++){
                if(a >= midIndex){
                    arrayB[i] = arrayA[b];
                    b++;
                }
                else if(b >= endIndex){
                    arrayB[i] = arrayA[a];
                    a++;
                }
                else if(arrayA[a] > arrayA[b]){
                    arrayB[i] = arrayA[b];
                    b++;
                }
                else{
                    arrayB[i] = arrayA[a];
                    a++;
                }
            }
        }
        static int[] QuickSort(int[] array){
            int pivotIndex = array.Length / 2 - 1;

            

            for(int i = 0; i < array.Length; i++){
                if(i == pivotIndex) continue;

                if(array[pivotIndex] > array[i]){
                    Insert(ref array, i, pivotIndex + 1);
                }
                else if(array[pivotIndex] < array[i]){
                    Insert(ref array, i, pivotIndex - 1);
                }
            }
            return array;
        }

        //Insert moves an index to aposition in array while pushing up other elements into the array
        static void Insert(ref int[] array, int indexToMove, int indexToInsertAt){
            int direction = indexToInsertAt - indexToMove;

            if(direction < 0){
                //Move left in array
                for(int i = indexToMove; i > indexToInsertAt; i--){
                    Swap(ref array[i], ref array[i - 1]);
                }
            }
            else if(direction > 0){
                //Move right in array
                for(int i = indexToMove; i < indexToInsertAt; i++){
                    Swap(ref array[i], ref array[i + 1]);
                }
            }
        }
    }
}