using System.Net.Http;
namespace RobotProject.Services
{
    public class LocationService
    {

        private readonly HttpClient _httpClient;
        public LocationService(HttpClient client)
        {
            _httpClient = client;
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
        }
        public async Task<string> GetNearestWaterFromLocation(Location location)
        {
            
            //client.DefaultRequestHeaders.Add("Name", "My App"); ///Specify Application
            HttpResponseMessage x =await _httpClient.GetAsync($"https://nominatim.openstreetmap.org/search.php?q=Water+near+{location.Suburb}+Australia&format=jsonv2");///Getting info from Maps API
            return await x.Content.ReadAsStringAsync();  ///Read content as string
        }
    }
}
