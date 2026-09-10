/*
    অধ্যায় ৮: মৌলিক সর্টিং (Basic Sorting)
    এই সর্টিংগুলো তুলনামূলক সহজ কিন্তু বড় ডেটা সেটের জন্য কিছুটা ধীরগতির (O(n2) সময় জটিলতা)  

    ১. বাবল সর্ট (Bubble Sort)
    শিক্ষক হিসেবে: এটি সবচেয়ে সহজ সর্টিং পদ্ধতি। এতে তালিকার পাশাপাশি দুটি উপাদানের তুলনা করা হয় এবং তারা ভুল ক্রমে থাকলে অদলবদল (Swap) করা হয়। 
    এভাবে প্রতিটি পাসে সবচেয়ে বড় উপাদানটি তালিকার শেষে চলে যায়, অনেকটা বুদবুদ (Bubble) যেমন পানির উপরে ভেসে ওঠে। 
    বন্ধুর টিপস: মনে কর, তোমরা কয়েক বন্ধু লাইনে উচ্চতা অনুযায়ী দাঁড়াবে।পাশাপাশি দুজন দাঁড়িয়ে তুলনা করলে এবং যে লম্বা সে পেছনে চলে গেলেএভাবে সবাই সঠিক জায়গায় না আসা পর্যন্ত কাজটা চলবে
    
    => এটি সময় জটিলতা: O(n2)।
    বৈশিষ্ট্য: এটি স্ট্যাবল (Stable) এবং ইন-প্লেস (In-place) সর্ট।

    ২. সিলেকশন সর্ট (Selection Sort)
    শিক্ষক হিসেবে: এই পদ্ধতিতে পুরো তালিকার মধ্যে সবচেয়ে ছোট উপাদানটি খুঁজে বের করে সেটিকে প্রথম অবস্থানে আনা হয়।
    এরপর বাকি অংশের মধ্যে সবচেয়ে ছোটটি খুঁজে দ্বিতীয় অবস্থানে রাখা হয় এবং এভাবে পুরো তালিকা সাজানো হয়।
    বন্ধুর টিপস: এটা অনেকটা বাজারে গিয়ে সবচেয়ে সস্তা জিনিসটা খুঁজে বের করে ব্যাগে ভরার মতো। তারপর বাকি সবগুলোর মধ্যে থেকে আবার সস্তাটা খোঁজা!
        সময় জটিলতা: O(n2)।
    
    ৩. ইনসারশন সর্ট (Insertion Sort)
    শিক্ষক হিসেবে: এটি অনেকটা তাসের কার্ড সাজানোর মতো। আপনি একটি করে কার্ড নেন এবং সেটিকে আগের সাজানো কার্ডগুলোর মধ্যে সঠিক স্থানে বসিয়ে দেন।
    এতে একটি সাজানো সাব-লিস্ট (Sorted sublist) বজায় রাখা হয় যেখানে নতুন উপাদানটি 'ইনসার্ট' করা হয় । 
    বন্ধুর টিপস: বইয়ের তাকে নতুন বই ঢোকানোর কথা ভাবো। তুমি বইটা হাতে নিয়ে দেখবে আগের বইগুলোর কোথায় এটা বসবে, তারপর জায়গা করে সেখানে ঢুকিয়ে দেবে।
    সময় জটিলতা: গড় ও ওরস্ট-কেস O(n2), তবে বেস্ট-কেস O(n)।    
 */

using Module___4_Sorting_Algorithms;

Sorting_Algo bubblesort = new Sorting_Algo();
//Console.WriteLine("Bubble Sort");

Random random = new Random();
int num = random.Next(1, 15);
//Console.WriteLine(num);

int[] randomArray = new int[num];

for (int i = 0; i < num; i++)
{
    randomArray[i] = random.Next(100, 1000);
}
//foreach (int item in randomArray)
//{
//    Console.Write(item + " ");
//}

int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
int[] arr3 = { 8, 7, 6, 5, 4, 3, 2, 1, 0 };
int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int[] scores = { 89, 45, 67, 23, 90, 12 };

// BubbleSort is declared static; call it on the type rather than the instance
//Sorting_Algo.BubbleSort(arr);
//Sorting_Algo.Hw01BubbleSort(arr2);
//Sorting_Algo.HW_SelectionSort(scores);
//Sorting_Algo.SelectionSort(arr);
int[] Exercise2 = { 5,2,8,1,4 };
//Sorting_Algo.InsertionSort(Exercise2);
//Sorting_Algo.Exersie07(Exercise2);
Sorting_Algo.Exersie_08(Exercise2);
//Sorting_Algo.HW_InsertionSort(randomArray);

//Console.WriteLine("Sorted array:");
//foreach (int item in scores)
//{
//    Console.Write(item + " ");
//}
//Console.WriteLine();