/*
    মডিউল-২: লিনিয়ার ডেটা স্ট্রাকচার (Linear Data Structures)
    লিনিয়ার ডেটা স্ট্রাকচার হলো এমন একটি ব্যবস্থা যেখানে ডেটা উপাদানগুলো ধারাবাহিকভাবে বা রৈখিকভাবে সাজানো থাকে।
    এখানে প্রতিটি উপাদান তার আগের এবং পরের উপাদানের সাথে যুক্ত থাকে।

    ১. অ্যারে (Array)
    অ্যারে হলো একই ধরণের ডেটা টাইপের একটি সংগ্রহ যা ইনডেক্সের (Index) মাধ্যমে সরাসরি অ্যাক্সেস করা যায় । C#-এ অ্যারে একটি অবজেক্ট হিসেবে কাজ করে ।
    সুবিধা: ইনডেক্স জানা থাকলে দ্রুত তথ্য পাওয়া যায় (O(1)) ।
    অসুবিধা: মাঝখানে কোনো উপাদান যোগ করা বা মুছে ফেলা ধীরগতির (O(n)) কারণ অন্যান্য উপাদানগুলোকে সরাতে হয় ।

    ২. লিঙ্কড লিস্ট (Linked List)
    এটি নোড (Node) ভিত্তিক একটি কাঠামো যেখানে প্রতিটি নোড ডেটা এবং পরবর্তী নোডের রেফারেন্স বা লিঙ্ক ধারণ করে।
    সুবিধা: ডায়নামিক মেমরি ব্যবহার করে এবং মাঝখানে ডেটা যোগ করা বা মোছা সহজ ।
    অসুবিধা: ইনডেক্সের মাধ্যমে সরাসরি অ্যাক্সেস করা যায় না, তাই তথ্য খুঁজে পেতে O(n) সময় লাগে ।
    
    ৩. স্ট্যাক (Stack)
    স্ট্যাক হলো LIFO (Last-In, First-Out) ভিত্তিক একটি কাঠামো, যেখানে সবার শেষে ঢোকানো ডেটা সবার আগে বের হয় । 
    এর প্রধান কাজগুলো হলো Push এবং Pop।
    সুবিধা: রিকার্শন এবং ব্যাকট্র্যাকিং এর জন্য উপযুক্ত ।
    অসুবিধা: সীমিত অ্যাক্সেস (শুধুমাত্র টপ এলিমেন্ট) ।

    ৪. কিউ (Queue)
    কিউ হলো FIFO (First-In, First-Out) ভিত্তিক একটি কাঠামো, যেখানে সবার আগে আসা ডেটা সবার আগে বের হয় । 
    এর প্রধান কাজগুলো হলো Enqueue এবং Dequeue।
    সুবিধা: ডেটা প্রক্রিয়াকরণের জন্য উপযুক্ত, যেমন প্রিন্টার জব বা টাস্ক শিডিউলিং।
    অসুবিধা: সীমিত অ্যাক্সেস (শুধুমাত্র ফ্রন্ট এবং রিয়ার এলিমেন্ট) ।
*/

using Module___2_Linear_Data_Structures;
using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace LinearDataStructures
{
    // Linked List Node Definition
    public class Node
    {
        public object Element { get; set; } // ডেটা ধারণ করে
        public Node Link { get; set; } // পরবর্তী নোডের রেফারেন্স

        public Node(object element)
        {
            // নোডের ডেটা সেট করা হচ্ছে এবং লিঙ্ক null করা হচ্ছে
            Element = element;
            Link = null;
        }
    }
    

    // Queue Implementation
    public class CQueue
    {
        private ArrayList List;
        private int f_index = -1;
        private int r_index = -1;

        public CQueue()
        {
            List = new ArrayList();
        }

        public void enqueue(object item)
        {
            List.Add(item);
            r_index++;
        }
        public object dequeue()
        {
            object obj = List[f_index + 1];
            List.RemoveAt(f_index + 1);
            f_index++;
            return obj;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Queue implementation
            LearnQueue learnQueue = new LearnQueue();
            learnQueue.potatoGame();


            // stack implementation

            //numberSystemConversion numberSystemConversion = new numberSystemConversion();
            //Console.WriteLine(numberSystemConversion.convertToBinary(15)); // Output: 1111
            //Console.WriteLine(numberSystemConversion.convertToOctal(15)); // Output: 17
            //Console.WriteLine(numberSystemConversion.convertToHexadecimal(94)); // Output: F

            // Blanced Brackets
            //balancedBrackets<char> balancedBrackets = new balancedBrackets<char>();
            //balancedBrackets.isBalancedBracketsData("({[]})".ToCharArray()); // Output: Balanced
            //balancedBrackets.isBalancedBracketsData("([{}])".ToCharArray());


            //reverseString<char> reverse = new reverseString<char>();
            //string input = "hello";
            //Console.WriteLine(reverse.reverse(input.ToCharArray()));

            //questions_1 ques01 = new questions_1();
            //ques01.stackOperations();


            //LearnStack<char> learnStack = new LearnStack<char>();
            //string text = "madam";
            //Console.WriteLine(learnStack.Ispalindrome(text.ToCharArray()));

            // Example usage of Linked List
            //Node head = new Node(10);
            //head.Link = new Node(20);
            //head.Link.Link = new Node(30);
            //head.Link.Link.Link = new Node(40);

            //// Beginning of the linked list Insert
            //Node newNode = new Node(5);
            //newNode.Link = head; // নতুন নোডের লিঙ্ক হেডের সাথে যুক্ত করা হচ্ছে
            //head = newNode; // হেডকে নতুন নোডে সেট করা হচ্ছে

            //// Insert at the end of the linked list
            //Node endNode = new Node(50);
            //Node current = head; // লিঙ্কড লিস্টের শুরু থেকে শুরু করা হচ্ছে
            //while (current.Link != null)
            //{
            //    current = current.Link; // পরবর্তী নোডে যাওয়া হচ্ছে
            //}
            //current.Link = endNode; // শেষ নোডের লিঙ্ক নতুন নোডে সেট করা হচ্ছে

            //// Insert in the middle of the linked list
            //Node MiddleNode = new Node(19);
            //current = head; // লিঙ্কড লিস্টের শুরু থেকে শুরু করা হচ্ছে
            //while (current != null && (int)current.Element < 20)
            //{
            //    current = current.Link; // পরবর্তী নোডে যাওয়া হচ্ছে যতক্ষণ না 20 এর চেয়ে বড় ডেটা পাওয়া যায়
            //}
            //MiddleNode.Link = current.Link; // নতুন নোডের লিঙ্ক বর্তমান নোডের লিঙ্কে সেট করা হচ্ছে
            //current.Link = MiddleNode; // বর্তমান নোডের লিঙ্ক নতুন নোডে সেট করা হচ্ছে

            //Node AddNewNode = new Node(25);
            //while (current != null && (int)current.Link.Element < 35) 
            //{
            //    current = current.Link; // পরবর্তী নোডে যাওয়া হচ্ছে যতক্ষণ না 35 এর চেয়ে বড় ডেটা পাওয়া যায়
            //}
            //AddNewNode.Link = current.Link; // নতুন নোডের লিঙ্ক বর্তমান নোডের লিঙ্কে সেট করা হচ্ছে
            //current.Link = AddNewNode; // বর্তমান নোডের লিঙ্ক নতুন নোডে সেট করা হচ্ছে

            ////Console.WriteLine(head.Element);
            ////Console.WriteLine(head.Link.Element); // output: 20
            ////Console.WriteLine(endNode.Element);

            ////Node currnt = head; // লিঙ্কড লিস্টের সব নোডের ডেটা প্রিন্ট করা হচ্ছে
            ////while (currnt != null)
            ////{
            ////    Console.WriteLine(currnt.Element); // প্রতিটি নোডের ডেটা প্রিন্ট করা হচ্ছে
            ////    currnt = currnt.Link; // পরবর্তী নোডে যাওয়া হচ্ছে
            ////}

            //// Remove a node from the 1st position of the linked list
            //Node temp = head; // লিঙ্কড লিস্টের শুরু থেকে শুরু করা হচ্ছে
            //head = head.Link; // হেডকে পরবর্তী নোডে সেট করা হচ্ছে
            //Console.WriteLine(newNode.Element);

            //Node lastEle = head; // লিঙ্কড লিস্টের সব নোডের ডেটা প্রিন্ট করা হচ্ছে

            //while (lastEle.Link != null)
            //{
            //    lastEle = lastEle.Link;
            //}
            //Console.WriteLine(lastEle.Element);
            //lastEle.Element = null;
            //Console.WriteLine($"Linked List after removing the last node:{lastEle.Element}");

            //Node midlleNode = head;
            //while (midlleNode != null && (int)midlleNode.Element != 19)
            //{
            //    midlleNode = midlleNode.Link; 
            //}
            //// previous node of middle node
            //Node preNode = head;
            //while (preNode != null && (int)preNode.Link.Element != 19)
            //{
            //    preNode = preNode.Link;
            //}

            //Node nextlink = midlleNode.Link; // middle node এর পরবর্তী নোডের লিঙ্ক

            //Console.WriteLine($"pre Node before removing: {preNode.Element}");
            //Console.WriteLine($"Middle Node before removing: {midlleNode.Element}");
            //Console.WriteLine($"next Node before removing: {nextlink.Element}");

            //preNode.Link = nextlink; // previous node এর লিঙ্ক middle node এর পরবর্তী নোডে সেট করা হচ্ছে
            //midlleNode.Link = null; // middle node এর লিঙ্ক null করা হচ্ছে, যা middle node কে লিঙ্কড লিস্ট থেকে বিচ্ছিন্ন করে দেয়

            ////midlleNode.Link = null;
            //Node currentNode = head; // লিঙ্কড লিস্টের শুরু থেকে শুরু করা হচ্ছে
            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Element); // প্রতিটি নোডের ডেটা প্রিন্ট করা হচ্ছে
            //    currentNode = currentNode.Link; // পরবর্তী নোডে যাওয়া হচ্ছে                
            //}

            // revrse linked list
            // last node of the linked list
            //Node lastNode = head;
            //Node prev = null;
            //Node current = head;
            //Node next = null;

            //while (current != null) 
            //{
            //    next = current.Link;
            //    current.Link = prev;
            //    prev = current;
            //    current = next;
            //}
            //head = prev;
            //Console.WriteLine($"--------Reversed Linked List----");

            //while (head != null)
            //{
            //    Console.WriteLine(head.Element); // প্রতিটি নোডের ডেটা প্রিন্ট করা হচ্ছে
            //    head = head.Link; // পরবর্তী নোডে যাওয়া হচ্ছে
            //}


            //Console.WriteLine("Hello, World!");
        }
    }
}
