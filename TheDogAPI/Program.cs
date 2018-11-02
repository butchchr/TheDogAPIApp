using RestSharp;
using System;
using System.IO;

namespace TheDogAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var doggoService = new DoggoService("https://dog.ceo/api/breeds/");
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
                    var doggos = doggoService.GetDoggos();
                    Console.WriteLine(doggos);
                }
                else if (userInt == 2)
                {
                    Console.WriteLine("You picked option 2, download and save a random dog photo!");
                    var image = doggoService.GetRandomDoggoPhoto();
                    var filePath = Path.GetTempFileName() + ".jpg";
                    File.WriteAllBytes(filePath, image);
                    Console.WriteLine($"I wrote the photo to {filePath}");
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

        class DoggoService
        {
            private readonly IRestClient client;

            public DoggoService(string baseUrl)
            {
                client = new RestClient(baseUrl);
            }

            public string GetDoggos()
            {
                var request = new RestRequest("list/all", dataFormat: DataFormat.Json);

                var response = client.Get(request);

                return response.Content;
            }

            public byte[] GetRandomDoggoPhoto()
            {
                var request = new RestRequest("image/random", dataFormat: DataFormat.Json);

                var response = client.Get<DoggoImage>(request);

                var photoRequest = new RestRequest(response.Data.Message);

                return client.DownloadData(photoRequest);
            }
        }

        class DoggoImage
        {
            public string Status { get; set; }

            public string Message { get; set; }
        }
    }
}
