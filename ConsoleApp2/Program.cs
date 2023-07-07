using System;

namespace ConsoleApp2
{

    class Program
    {
        static int accessibleInt = 7;

        public static void Main()
        {
            //int myInt = 5;
            //int mySecondInt = 10;
            //int myThirdInt = 10;


            //if(myInt < mySecondInt || mySecondInt < myThirdInt)
            //{
            //    Console.WriteLine("True");
            //}
            //else
            //{
            //    Console.WriteLine("False");
            //}


            //if (myInt > mySecondInt )
            //{
            //    myInt += 10;
            //}

            //Console.WriteLine(myInt);

            //string myCow = "Cows";
            //string myCapitalizedCow = "Cows";

            //if (myCow == myCapitalizedCow)
            //{
            //    Console.WriteLine("Equal");
            //}
            //else if(myCow == myCapitalizedCow.ToLower())
            //{
            //    Console.WriteLine("Equal without capitalization");
            //}
            //else
            //{
            //    Console.WriteLine("Not Equal");
            //}

            //switch (myCow)
            //{
            //    case "cow":
            //        Console.WriteLine("Lowercase");
            //        break;
            //    case "Cow":
            //        Console.WriteLine("Capitalized");
            //        break;
            //    default:
            //        Console.WriteLine("Default");
            //        break;
            //}

            Console.WriteLine(accessibleInt);

            int accessibleInt = 7;

            int[] intsToCompress = new int[] {10, 15, 20, 24, 34, 45, 19, 20, 8 };
            int length = intsToCompress.Length;
            int sum = 0;

            //foreach (int i in intsToCompress)
            //{
            //    if(i > 20)
            //    {
            //        sum += i;
            //    }

            //}
            //Console.WriteLine(sum);

            DateTime startTime = DateTime.Now;

            sum = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] + intsToCompress[3] + intsToCompress[4]
                    + intsToCompress[5] + intsToCompress[6] + intsToCompress[7] + intsToCompress[8];

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);

            sum = 0;
            startTime = DateTime.Now;

            for (int i = 0; i < length; i++)
            {
                sum += intsToCompress[i];
            }

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);


            sum = 0;
            startTime = DateTime.Now;

            foreach (int i in intsToCompress)
            {
                sum += i;
            }

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);


            int index = 0;
            sum = 0;
            startTime = DateTime.Now;

            while (index < length)
            {
                sum += intsToCompress[index];
                index++;
            }

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);

            index = 0;
            sum = 0;
            startTime = DateTime.Now;

            do
            {
                sum += intsToCompress[index];
                index++;
            } while (index < length);

            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);

            sum = 0;
            startTime = DateTime.Now;
            //sum = intsToCompress.Sum();
            sum = GetSum(intsToCompress);
            Console.WriteLine((DateTime.Now - startTime).TotalSeconds);
            Console.WriteLine(sum);


        }

        private static int GetSum(int[] intArray)
        {
            int sum = 0;

            foreach (int i in intArray)
            {
                sum += i;
            }

            return sum;

        }


    }


}


