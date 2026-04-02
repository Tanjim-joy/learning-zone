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

using System;
using System.Collections;

namespace LinearDataStructures
{
    // Linked List Node Definition
    public class Node
    {
        public object Element { get; set; }
        public Node Link { get; set; }

        public Node(object element)
        {
            Element = element;
            Link = null;
        }
    }

    // Stack Implementation
    public class CStack
    {
        private ArrayList List;
        private int p_index = -1;

        public void push(object item)
        {
            List.Add(item);
            p_index++;
        }

        public object pop()
        {
            object obj = List[p_index];
            List.RemoveAt(p_index);
            p_index--;
            return obj;
        }
    }

    // Queue Implementation
    public class CQueue
    {
        private ArrayList List;
        private int f_index = -1;
        private int r_index = -1;
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
            // Example usage of Linked List
            Node head = new Node(10);
            head.Link = new Node(20);
            head.Link.Link = new Node(30);
    
            Console.WriteLine(head.Element); // Output: 10
                                             
            // Example usage of Stack
            //CStack stack = new CStack();
            //    stack.push(1);
            //    stack.push(2);
            //    stack.push(3);
            //    Console.WriteLine(stack.pop()); // Output: 3

            //    // Example usage of Queue
            //    CQueue queue = new CQueue();
            //    queue.enqueue(1);
            //    queue.enqueue(2);
            //    queue.enqueue(3);
            //    Console.WriteLine(queue.dequeue()); // Output: 1

            //Console.WriteLine("Hello, World!");
        }
    }
}
