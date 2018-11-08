using RestSharp;

namespace TheDogAPI
{
    class DoggoService
    {
        private readonly IRestClient client;

        public DoggoService(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public DoggoBreedList GetDoggos()
        {
            var request = new RestRequest("list/all", dataFormat: DataFormat.Json);

            var response = client.Get<DoggoBreedList>(request);

            return response.Data;
        }

        public byte[] GetRandomDoggoPhoto()
        {
            var request = new RestRequest("image/random", dataFormat: DataFormat.Json);

            var response = client.Get<DoggoImage>(request);

            var photoRequest = new RestRequest(response.Data.Message);

            return client.DownloadData(photoRequest);
        }
    }
}
