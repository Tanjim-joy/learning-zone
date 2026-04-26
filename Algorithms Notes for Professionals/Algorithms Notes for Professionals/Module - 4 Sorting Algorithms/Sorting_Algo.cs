using System;
using System.Collections.Generic;
using System.Text;

/*

অ্যালগরিদম	        Best Case	        Average Case	        Worst Case	    Stable?	    In-place?	        কখন কাজে দেবে?
Bubble Sort	        O(n)	            O(n²)	                O(n²)	        হ্যাঁ	        হ্যাঁ	            কখনো না (শুধু শিক্ষার জন্য)
Selection Sort	    O(n²)	            O(n²)	                O(n²)	        না	        হ্যাঁ	            যখন swap কম করতে চাই
Insertion Sort	    O(n)	            O(n²)	                O(n²)	        হ্যাঁ	        হ্যাঁ	            ছোট বা প্রায় সাজানো ডাটা

*/
namespace Module___4_Sorting_Algorithms
{
    public class Sorting_Algo
    {
        //public static void BubbleSort(int[] arr)
        //{
        //    int n = arr.Length;
        //    for (int i = 0; i < n  - 1; i++)
        //    {
        //        bool swapped = false;
        //        for (int j = 0; j < n - 1; j++)
        //        {
        //            // তুলনা করা হচ্ছে পাশাপাশি উপাদানগুলোর
        //            if (arr[j] > arr[j + 1])
        //            {
        //                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);  // অদলবদল করা হচ্ছে যদি তারা ভুল ক্রমে থাকে
        //                swapped = true;
        //            }
        //        }
        //        if (!swapped)
        //        {
        //            break;  // যদি কোনো অদলবদল না হয়, তাহলে তালিকা ইতিমধ্যেই সাজানো হয়েছে
        //        }
        //    }

        //}

        // Home Work : How Many Swaps in Bubble Sort..

        public static void Hw01BubbleSort(int[] arr)
        {
            int n = arr.Length;
            int countSwaps = 0;
            // loop through each element in the array

            for (int i = 0; i < n - 1; i++)
            {
                int countSwapsInPass = 0;
                bool swapped = false;
                
                for (int j = 0; j < n -1; j++)
                {
                    if (arr[j] > arr[j + 1])    
                    {
                        // Swap the elements
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        countSwapsInPass++;
                        swapped = true;
                    }
                }
                countSwaps += countSwapsInPass;
                if (!swapped)
                {
                    Console.WriteLine($"Array is already sorted. Total swaps: {countSwaps}");
                    break;
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            int arrLength = arr.Length;
            for (int i = 0; i < arrLength - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arrLength; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Console.WriteLine($"Swapping elements at index {i} and {minIndex}: {arr[i]} <-> {arr[minIndex]}");
                    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                }
            }
        }

        public static void HW_SelectionSort(int[] arr)
        {
            int arrLength = arr.Length;
            for (int i = 0; i < arrLength - 1; i++)
            {
                int mini_index = i;
                for (int j = i + 1; j < arrLength; j++)
                {
                    if (arr[j] < arr[mini_index])
                    {
                        mini_index = j;
                        //Console.WriteLine($"Swapping elements at index {i} and {mini_index}: {arr[i]} <-> {arr[mini_index]}");
                        //Console.WriteLine($"Frist Swapping {arr[i]} and {arr[mini_index]} ");
                    }
                }
                if (mini_index != i)
                {
                    (arr[i], arr[mini_index]) = (arr[mini_index], arr[i]);
                    Console.WriteLine($"After swapping: {string.Join(", ", arr)}");                    
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int arrLength = arr.Length;
            for (int i = 1; i < arrLength; i++)
            {
                int key = arr[i]; 
                int j = i - 1; 

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key; 
                Console.WriteLine($"After inserting {key}: {string.Join(", ", arr)}");                
            }
        }
        /*
            ১. key = arr[i] কেন? — বাম দিকের অংশ সবসময় sorted থাকে। arr[i] হলো নতুন উপাদান যেটাকে sorted অংশে সঠিক জায়গায় ঢোকাতে হবে। 
            এটাকে আগেই key-তে রেখে দিই কারণ shifting করতে গিয়ে এই জায়গার মান overwrite হয়ে যাবে।
            ২. while (j >= 0 && arr[j] > key) — দুটো শর্ত কেন? — j >= 0 না থাকলে array-র বাইরে চলে যাবে (index out of range error)। 
            arr[j] > key না হলে key তার সঠিক জায়গায় পৌঁছে গেছে — আর সরানোর দরকার নেই।
            ৩. arr[j + 1] = key loop-র বাইরে কেন? — loop শেষে j এমন জায়গায় আছে যেখানে arr[j] <= key অথবা j < 0।
            দুই ক্ষেত্রেই j+1 হলো key-এর সঠিক জায়গা।
         */
        public static void HW_InsertionSort(int[] arr)
        {
            List<int> sortedList = new List<int>();
            int[] stream = arr;
            //int[] stream = new int[arr.Length];
            int arrLength = arr.Length;
            
            for(int i = 0; i < arrLength; i++)
            {
                int key = arr[i];
                int j = i - 1;
                
                while(j >= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] = key; 
            }

            foreach (int i in stream)
            {
                sortedList.Add(i);
                Console.WriteLine($" {string.Join(", ", sortedList)}");
            }
        }

        /* 
            Exerise 07
            [5,2,8,1,4]
        only Sort even numbers using insertion sort
        odd numbers should remain in their original positions
        */

        public static void Exersie07(int[] arr)
        {
            int arrLength = arr.Length;
            for(int i = 1; i < arrLength; i++)
            {
                int key = arr[i];
                if (key % 2 == 0)
                {
                    int j = i - 1;
                    while (j >= 0 && arr[j]> key)
                    {
                        if (arr[j] % 2 == 0)
                        {
                            arr[j + 1] = arr[j];                            
                        }
                        j--;
                    }
                    arr[(j % 2) == 0 ? j + 1 : j + 2] = key; 
                    // যদি j-তে odd number থাকে, তাহলে key-কে j+2 তে বসাতে হবে কারণ j+1 তে odd number থাকবে।
                    // যদি j-তে even number থাকে, তাহলে key-কে j+1 তে বসাতে হবে।
                }
            }
            Console.WriteLine($"{string.Join(", ", arr)}");
        }
        public static void Exersie_08(int[] arr)
        {
            List<int> evenArr = new List<int>();
            foreach(int num in arr)
            {
                if (num % 2 ==0)
                {
                    evenArr.Add(num);
                }
            }
            int[] evenArrArr = evenArr.ToArray();
            int evenArrLength = evenArrArr.Length;

            for (int i = 0; i < evenArrLength; i++)
            {
                int store = evenArr[i];
                int j = i - 1;

                while (j >= 0 && evenArr[j] > store)
                {
                    evenArr[j + 1] = evenArr[j];
                    j--;
                }
                evenArr[j + 1] = store;
            }
            //Console.WriteLine($"Sorted Even Numbers: {string.Join(", ", evenArr)}");
            int evenIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arr[i] = evenArr[evenIndex];
                    evenIndex++;
                }
            }
            Console.WriteLine($"{string.Join(", ", arr)}");

        }
    }
}
/*  Dry Run Example 

    [7, 4, 6, 2]
    int key = 4 , j = 0
    [7, 7, 6, 2] // shift 7 to the right
    j = -1 // decrement j
    [4, 7, 6, 2] // insert key at the correct position

    Next iteration:
    int key = 6, j = 1
    [4, 7, 7, 2] // shift 7 to the right
    j = 0 // decrement j
    [4, 6, 7, 2] // insert key at the correct position
    
    Next iteration:
    int key = 2, j = 2
    [4, 6, 7, 7] // shift 7 to the right
    j = 1 // decrement j
    [4, 6, 6, 7] // shift 6 to the right
    j = 0 // decrement j
    [4, 4, 6, 7] // shift 4 to the right
    j = -1 // decrement j
    [2, 4, 6, 7] // insert key at the correct position

Exercise 2
[9, 3, 5, 1] -> এই array-এ i = 2 পর্যন্ত insertion sort চালাও (পুরো না) = [3, 5, 9, 1]

level 02:

public static void InsertionSort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        int key = arr[i];
        int j = i -1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

*/
