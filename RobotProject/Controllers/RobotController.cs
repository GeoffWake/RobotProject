using Microsoft.AspNetCore.Mvc;
using RobotProject.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RobotProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        

        private readonly ILogger<RobotController> _logger;
        private readonly LocationService _service;

     

        public RobotController(LocationService service, ILogger<RobotController> logger)
        {
            _service = service; 
            _logger = logger;
        }


        [HttpPost(Name = "RobotSpotted")] 
        public async Task<string> Post(Location location, CancellationToken token)
       
        {

            
                 _logger.Log(LogLevel.Information, new EventId(),null,"Location name sent:" + location.Suburb, null); 

                
                
                string NearbyWater = await _service.GetNearestWaterFromLocation(location);
                
                JsonSerializer.Serialize(NearbyWater);
                Class1[] water =JsonSerializer.Deserialize<Class1[]>(NearbyWater); 

                 return $"The nearest body of water to {location.Suburb} is { water[0].display_name}";
                                                                             
              
            

        }
    }
}