using System;
using System.IO;

namespace TheDogAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var doggoService = new DoggoService("https://dog.ceo/api/breeds/");
            do
            {
                Console.WriteLine("Hello User! I am a program that helps you interact with 'The Dog API'");
                Console.WriteLine("Please press '1' to see a list of dog breeds");
                Console.WriteLine("Please press '2' to have me download and save a random dog photo!");

                var choice = int.TryParse(Console.ReadLine(), out var userInt) ? userInt : 0;

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("You picked option 1, see a list of dog breeds");
                            var doggos = doggoService.GetDoggos();
                            foreach (var dog in doggos.Message)
                            {
                                Console.WriteLine(dog.Key);
                                foreach (var sub in dog.Value)
                                {
                                    Console.WriteLine("\t" + sub);
                                }
                            }
                            break;
                        }

                    // Appended .jpg to the end of the file name as the documentation for the dog api indicates that 
                    // .jpg is always the time of image that is returned
                    case 2:
                        {
                            Console.WriteLine("You picked option 2, download and save a random dog photo!");
                            var image = doggoService.GetRandomDoggoPhoto();
                            var filePath = Path.GetTempFileName() + ".jpg";
                            File.WriteAllBytes(filePath, image);
                            Console.WriteLine($"I wrote the photo to {filePath}");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("I'm sorry I did not understand that command");
                            continue;
                        }
                }
            }
            while (ShouldRepeat());
        }

        static bool ShouldRepeat()
        {
            Console.WriteLine("Repeat the program? (y/n):");
            ConsoleKeyInfo pressed = Console.ReadKey();
            Console.WriteLine();
            var shouldContinue = true;

            if (pressed.Key == ConsoleKey.Y)
            {
                shouldContinue = true;
            }
            else if (pressed.Key == ConsoleKey.N)
            {
                shouldContinue = false;
            }
            else
            {
                ShouldRepeat();
            }
            return shouldContinue;
        }
        
    }
}
