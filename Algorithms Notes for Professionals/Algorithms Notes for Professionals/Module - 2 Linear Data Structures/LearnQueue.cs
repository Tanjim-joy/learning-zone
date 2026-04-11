using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module___2_Linear_Data_Structures
{
    /*
        হট পটেটো (Hot Potato) সিমুলেশন: একটি প্রোগ্রাম তৈরি করুন যা 'হট পটেটো' বা 'ফ্ল্যাভিয়াস জোসেফাস' (Josephus Problem) সমস্যাটি কিউ ব্যবহার করে সমাধান করবে। 
        এতে নির্দিষ্ট সংখ্যক বার পটেটো পাস করার পর একজনকে সার্কেল থেকে বাদ দেওয়া হবে যতক্ষণ না একজন অবশিষ্ট থাকে।

        একটি সার্কেল থেকে পটেটো পাস করার পর একজনকে সার্কেল থেকে বাদ দেওয়া হবে যতক্ষণ না একজন অবশিষ্ট থাকে।
    */
    public class LearnQueue
    {
        string[] players = new string[4];
        
        public void potatoGame()
        {
            Console.WriteLine("=================== Josephus Problem Simulation started =====================");

            string[] players = { "A", "B", "C", "D" };

            Queue<string> queue = new Queue<string>(players); // Queue is a FIFO data structure
            // List of players is added to the queue
            foreach (string player in players)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine("Enter the number of players to be removed from the circle: ");
            int num = int.Parse(Console.ReadLine());

            // make queue circular
            Queue<string> cricle = new Queue<string>();
            for (int i = 0; i < players.Length; i++)
            {
                cricle.Enqueue(players[i]); // Add players to the queue
            }
            Console.WriteLine("====== Game Has Started =====");

            while (cricle.Count > 1)
            {
                for (int i = 0; i < num; i++)
                {
                    string player = cricle.Dequeue(); // Remove the player at the front of the queue
                    cricle.Enqueue(player); // Add the removed player back to the end of the queue
                }
                string removedPlayer = cricle.Dequeue(); // Remove the player at the front of the queue after passing the potato
                Console.WriteLine(removedPlayer + " is removed from the circle"); // Print the removed player
            }
            Console.WriteLine("====== Game Over =====");
            Console.WriteLine("The winner is: " + cricle.Dequeue()); // Print the winner
        }

    }
}
