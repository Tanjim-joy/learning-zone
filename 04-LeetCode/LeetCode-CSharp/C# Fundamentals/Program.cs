namespace CSharpFundamentals
{
    /*
        Topics to learn:
        1. .NET & C# Overview Basics
        2. variables and data types
        3. Operators
        4. Conditions
        5. Loops
        6. Methods
        7. Arrays and Collections

    */
    internal class Program
    {
        /*
            *** Core Problems ***
            ----------------------------
            1. Even/Odd Number
            2. Reverse a String
            3. Largest of three numbers
            4. Fibonacci Series
            5. Sum & average of array
            6. Count Vowels in a string
            7. Prime Number Check
            8. Palindrome Check
            9. Factorial of a number
            10. GCD & LCM of two numbers
        */
        static void Main(string[] args)
        {
            /*
                ========================== Even/Odd Number ==========================
            
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine($"{number} is an even number.");
            }
            else
            {
                Console.WriteLine($"{number} is an odd number.");
            }
            */

            /*
                ========================== Reverse a String ==========================

            */
            /*Console.Write("Enter a string: ");
            string input = Console.ReadLine();*/

            /*Console.WriteLine(input);
            input = new string(input.Reverse().ToArray()); // `Reverse()` returns an IEnumerable<char>, so we need to convert it back to a string using `new string()` constructor.
            Console.WriteLine(input);*/

            // Another way to reverse a string using a loop 

            /*Console.Write("Enter a string: ");
            input = Console.ReadLine();*/

            //Console.WriteLine(input);
            //string reversed = "";
            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    reversed += input[i];
            //}

            // using While loop
            //while (input.Length > 0)
            //{
            //    reversed += input[input.Length - 1]; // Get the last character of the string and add it to the reversed string
            //    input = input.Substring(0, input.Length - 1); // Remove the last character
            //}
            //Console.WriteLine(reversed);

            /*
                =========================== Largest of three numbers ==========================
            
            int num1 = 20, num2 = 10, num3 = 25, num4 = 60, num5 = 65, num6 = 70, num7 = 30, num8 = 45, num9 = 31;

            // Check largest among 3 numbers

            if (num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine($"{num1} is the largest number among {num1}, {num2}, and {num3}.");
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                Console.WriteLine($"{num2} is the largest number among {num1}, {num2}, and {num3}.");
            }
            else
            {
                Console.WriteLine($"{num3} is the largest number among {num1}, {num2}, and {num3}.");
            }
            */

            /* ========================== Fibonacci Series ========================== */

            /*int num = 10;

            int sum = 0;
            
            while (num > 0)
            {
                sum += num;
                num--;
            }
            Console.WriteLine($"The sum of the first 10 natural numbers is: {sum}");*/

            /* ========================== Count Vowels in a string ========================== */

            /*string VowelsCount = "the quick brown fox jumps over the lazy dog";

            if (!string.IsNullOrEmpty(VowelsCount))
            {
                int count = 0;

                foreach (char c in VowelsCount)
                {
                    if ("aeiouAEIOU".Contains(c))
                    {
                        count++;
                    }
                }

                Console.WriteLine($"The number of vowels in the string is: {count}");
            }
            else
            {
                Console.WriteLine("The string is null or empty.");
            }*/

            /* ========================== Prime Number Check ========================== */

            /*int number = 29;
            bool isPrime = true;
            if (number <= 1)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isPrime ? $"{number} is a prime number." : $"{number} is not a prime number.");*/

            /* ========================= Palindrome Check ========================== */

            /*int number = 121;
            int originalNumber = number;
            int reversedNumber = 0;

            while (number > 0)
            {
                int digit = number % 10; // Get the last digit
                reversedNumber = (reversedNumber * 10) + digit; // Append the digit to the reversed number
                number /= 10; // Remove the last digit
            }

            *//*
                number = 121 (True, কারণ 121 > 0)
                Step 1: digit = number % 10
                        digit = 121 % 10
                        digit = 1 (ভাগশেষ)

                Step 2: reversedNumber = (reversedNumber * 10) + digit
                        reversedNumber = (0 * 10) + 1
                        reversedNumber = 0 + 1
                        reversedNumber = 1

                Step 3: number /= 10
                        number = 121 / 10
                        number = 12 (ইন্টিজার ডিভিশন)

                number = 12 (True, কারণ 12 > 0)
                Step 1: digit = number % 10
                        digit = 12 % 10
                        digit = 2

                Step 2: reversedNumber = (reversedNumber * 10) + digit
                        reversedNumber = (1 * 10) + 2
                        reversedNumber = 10 + 2
                        reversedNumber = 12

                Step 3: number /= 10
                        number = 12 / 10
                        number = 1

                number = 1 (True, কারণ 1 > 0)
                Step 1: digit = number % 10
                        digit = 1 % 10
                        digit = 1

                Step 2: reversedNumber = (reversedNumber * 10) + digit
                        reversedNumber = (12 * 10) + 1
                        reversedNumber = 120 + 1
                        reversedNumber = 121

                Step 3: number /= 10
                        number = 1 / 10
                        number = 0

                number = 0 (False, লুপ শেষ)
            *//*

            Console.WriteLine(originalNumber == reversedNumber ? $"{originalNumber} is a palindrome." : $"{originalNumber} is not a palindrome.");

            string str = "madam";
            string reversedStr = new string(str.Reverse().ToArray());
            Console.WriteLine(str == reversedStr ? $"{str} is a palindrome." : $"{str} is not a palindrome.");*/

            /* ======================== Factorial of a number =========================== */
            /*int fact = 5;
            int result = 1;

            while (fact > 0)
            {
                result = result * fact;
                fact--;
            }
            Console.WriteLine($"Factorial of a number result = {result}");*/

            /* ======================= GCD & LCM of two numbers =========================== */

            int a = 12, b = 18;

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            Console.WriteLine("GCD = " + a);
        }
    }
}
