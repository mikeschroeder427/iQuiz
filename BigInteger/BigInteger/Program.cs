using System;

namespace BigInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(AddHugeIntegers("8274019656219028659301288111182982891661022947253820", "7396983492654280852359244735289764547811192735453222"));
            Console.WriteLine(AddHugeIntegers("100", "20"));
            Console.WriteLine(AddHugeIntegers("000020", "1"));
        }

        //Currently does not handle negative numbers. Time permitting I will revisit.
        public static string AddHugeIntegers(string x, string y) 
        {
            string bigNumber, litleNumber, sumStr = string.Empty; //bigNumber = the string with more digits, littleNumber = less digits, sumStr holds the sum of the strings in reverse order.

            if (x.Length >= y.Length)
            {
                bigNumber = x;
                litleNumber = y;
            }
            else 
            {
                litleNumber = x;
                bigNumber = y;
            }

            /*
            * To avoid indexOutOfRange, we need to stop the subsequent loop before it reaches index -1 on the litteNumber. Length diff will be used in second loop for remaining digits in bigNumber.
            * 12345 = 5
            * 9876  = 4
            * lengthDiff = 1
            */
            int lengthDiff = bigNumber.Length - litleNumber.Length;
            int carry = 0; // If sum > 10, carry will be used to store the carry over for the next sum.

            /*
             * Its been awhile, had to google how to take a char to an int properly.
             * 
             *  Starting from the back of the littleNumber String, begin adding corresponding values from the bigNumber string.
             *  Big Number needs an offset to ensure its using the proper number to sum with littleNumber
             *  For instance, if index i = 2...
             *       bigNumber[2]     from    12345  => 3
             *       littleNumber[2]  from     9876  => 7
             *  In this example, we want to add the 4 from bigNumber (bigNumber[3] and the 7 from littleNumber (littleNumber[2]), so we add the lengthDiff (offset) to the index on bigNumber.
             *  If the sum is > 10 subtract to ensure we are only using a single digit (sum = 17, will need to carry the 1 to the next loop, so we minus 10 to get 7).
             *  If sum is greater > 10, carry over the 1 to the next  loop.
             *  Rinse and repeat for all digits in littleNumber
             */
            for (int i = litleNumber.Length - 1; i >= 0; i--)
            {
                int sum = ((int)litleNumber[i] - '0') + ((int)bigNumber[i + lengthDiff] - '0') + carry;
                sumStr += sum >= 10 ? (sum - 10).ToString() : sum.ToString();
                carry = sum / 10;
            }

            /*
             * For any remaining digits that were not added from bigNumber, add them to sumStr.
             */
            for (int i = lengthDiff - 1; i >= 0; i--) 
            { 
                int sum = ((int)bigNumber[i] - '0') + carry;
                sumStr += sum >= 10 ? (sum - 10).ToString() : sum.ToString();
                carry = sum / 10;
            }

            //If there is still a carry at, add it at the end.
            if (carry != 0)
                sumStr += carry.ToString();

            /*
             * Sumstr is currently in reverse order, as we have been appending to sumStr instead of inserting the latest additions to the front of the string.
             * Simply reverse the string, remove leading 0s, and return.
             */
            var chars = sumStr.ToCharArray();
            Array.Reverse(chars);
            return new string(chars).TrimStart('0'); 
        }
    }
}
