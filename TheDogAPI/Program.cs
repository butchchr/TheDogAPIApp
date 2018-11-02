using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheDogAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            bool y = true;
            while (y)
            {
                Console.WriteLine("Hello User! I am a program that helps you interact with 'The Dog API'");
                Console.WriteLine("Please press '1' to see a list of dog breeds");
                Console.WriteLine("Please press '2' to have me download and save a random dog photo!");

                string userChoice = Console.ReadLine();

                int userInt;
                bool num1 = int.TryParse(userChoice, out userInt);

                if (!(num1) || 1 > userInt || userInt > 2)
                {
                    Console.WriteLine("I'm sorry I did not understand that command");
                    continue;
                }


                if (userInt == 1)
                {
                    Console.WriteLine("You picked option 1, see a list of dog breeds");
                    GetDoggos();
                }

                else if (userInt == 2)
                {
                    Console.WriteLine("You picked option 2, download and save a random dog photo!");
                    GetDoggoPhoto();
                }


                bool invalid = true;
                while (invalid)
                {
                    Console.WriteLine("Continue? (y/n):");
                    ConsoleKeyInfo pressed = Console.ReadKey();
                    Console.WriteLine();
                    bool isY = pressed.Key == ConsoleKey.Y;
                    bool isN = pressed.Key == ConsoleKey.N;

                    invalid = !isY && !isN;
                    y = isY;
                }
            }
        }

        public static void GetDoggos()
        {
            var listUrl = "https://dog.ceo/api/breeds/list/all";

            //returns status "sucess"
            //and message list of dogs and sub dogs

            //if (status == sucess)
            //{
            //    Console.WriteLine("Here is a big list of all the dog breeds");
            //    Console.WriteLine();
            //}
            //else if (status != sucess)
            //{
            //    Console.WriteLine("something out of my controll went wrong, please try again");
            //}
        }

        public static void GetDoggoPhoto()
        {
            var photoUrl = "https://dog.ceo/api/breeds/image/random";

            //returns status "sucess"
            //and message random dog URL 

            //if(message == sucess)
            //{
            //    Console.WriteLine($"I have saved {jpg} at {C:\}");
            //}
            //else if(message != sucess)
            //{
            //    Console.WriteLine("something out of my controll went wrong, please try again");
            //}
            
        }

        public static string CallAPI(string url)
        {
            return "sucess";
        }
    }
}
