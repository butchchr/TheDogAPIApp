using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace TheDogAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var doggoService = new DoggoService("https://dog.ceo/api/breeds/");
            var shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Hello User! I am a program that helps you interact with 'The Dog API'");
                Console.WriteLine("Please press '1' to see a list of dog breeds");
                Console.WriteLine("Please press '2' to have me download and save a random dog photo!");
                
                var isNumber = int.TryParse(Console.ReadLine(), out var userInt);

                // minor validation make sure the user entered '1' or '2'
                if (!(isNumber) || 1 > userInt || userInt > 2)
                {
                    Console.WriteLine("I'm sorry I did not understand that command");
                    continue;
                }

                // TODO: Refactor to switch case
                if (userInt == 1)
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
                }
                
                // Appended .jpg to the end of the file name as the documentation for the dog api indicates that 
                // a .jpg is always the time of image that is returned 
                else if (userInt == 2)
                {
                    Console.WriteLine("You picked option 2, download and save a random dog photo!");
                    var image = doggoService.GetRandomDoggoPhoto();
                    var filePath = Path.GetTempFileName() + ".jpg";
                    File.WriteAllBytes(filePath, image);
                    Console.WriteLine($"I wrote the photo to {filePath}");
                }


                //repeats program if y presses (independant of case). y and n are the options or promp will repeat.
                //TODO Refactor to switch case or do while.
                var invalidKeyPressed = true;
                while (invalidKeyPressed)
                {
                    Console.WriteLine("Repeat the program? (y/n):");
                    ConsoleKeyInfo pressed = Console.ReadKey();
                    Console.WriteLine();
                    var isY = pressed.Key == ConsoleKey.Y;
                    var isN = pressed.Key == ConsoleKey.N;

                    invalidKeyPressed = !isY && !isN;
                    shouldContinue = isY;
                }
            }
        }
    }
}
