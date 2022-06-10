using Microsoft.AspNetCore.Mvc;
using RobotProject.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobotProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase ///Maps Request to a response
    {
        /*private static readonly string[] Summaries = new[]
        {
            "Water Source"
        };*/

        private readonly ILogger<RobotController> _logger;
        private readonly LocationService _service;

        private List<Location> _location = new List<Location>()
        {
            new Location()
            {
                Name= "Pacific Ocean",
                Longitude= 8,
                Latitude= 125,
            }
        };

        public RobotController(LocationService service, ILogger<RobotController> logger)
        {
            _service = service; 
            _logger = logger;
        }

        [HttpGet(Name = "RobotSpotted")] ///EndPoint
        public string Get()
        {
            
            {
                return "Water Source";
            }
           
        }
        [HttpPost(Name = "RobotSpotted")] ///EndPoint
        public async Task<string> Post(Location location, CancellationToken token)
       /// public Location Post(Location location, CancellationToken token)
        {

            
                 _logger.Log(LogLevel.Information, new EventId(),null,"Location name sent:" + location.Name, null); ///logging location data

                
                ////Need to deserialise the json data
                string NearbyWater = await _service.GetNearestWaterFromLocation(location);
                //var x = await _service.GetNearestWaterFromLocation(location);
                JsonSerializer.Serialize(NearbyWater);
                Class1[] water =JsonSerializer.Deserialize<Class1[]>(NearbyWater); 

                 return $"The nearest body of water is { water[0].display_name}"; //Referencing json name file 
                                                                              //water;
              
            

        }
    }
}