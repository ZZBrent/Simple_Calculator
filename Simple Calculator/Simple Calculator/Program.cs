using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }

        static void start()
        {
            Console.WriteLine(@"Press any of the following keys to perform an arithmetic operation:
                                1 - Addition
                                2 - Subtraction
                                3 - Multipliation
                                4 - Division");
            Read:
            string n = Console.ReadLine();
            switch (n)
            {
                case "1":
                    addition();
                    break;
                case "2":
                    subtraction();
                    break;
                case "3":
                    multiplication();
                    break;
                case "4":
                    division();
                    break;
                default:
                    invalidInput();
                    goto Read;
            }
        }

        static void addition()
        {
            var arr = getValues();
            finalOutput(arr, "+", arr[0] + arr[1]);
        }

        static void subtraction()
        {
            var arr = getValues();
            finalOutput(arr, "-", arr[0] - arr[1]);
        }

        static void multiplication()
        {
            var arr = getValues();
            finalOutput(arr, "*", arr[0] * arr[1]);
        }

        static void division()
        {
            var arr = getValues();
            finalOutput(arr, "/", arr[0] / arr[1]);
        }

        static float[] getValues()
        {
            var arr = new float[2];
            for(int i=1; i<3; i++)
            {
                Value:
                Console.Write(String.Format("Value {0}: ", i.ToString()));
                string s = Console.ReadLine();
                if (!float.TryParse(s, out float f))
                {
                    invalidInput();
                    goto Value;
                }
                arr[i-1] = f;
            }
            return arr;
        }
        
        static void invalidInput()
        {
            Console.WriteLine(@"That input is unacceptable... Please try again.");
        }

        static void finalOutput(float[] arr, string oper, float val)
        {
            Console.WriteLine(String.Format("{0} {1} {2} = {3}", arr[0], oper, arr[1], val));
            Console.WriteLine(@"Would you like perform another operation? (Y/N)");
            string repeat = Console.ReadLine();
            if(repeat.ToUpper() == "Y" || repeat.ToUpper() == "YES")
            {
                start();
            }
        }
    }
}
