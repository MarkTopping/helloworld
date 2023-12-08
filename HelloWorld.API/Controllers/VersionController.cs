using HelloWorld.API;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet(Name = "GetVersion")]
        public string Get()
        {
            return $"Response from host: {Environment.GetEnvironmentVariable("HOSTNAME")}. Image version: {Environment.GetEnvironmentVariable("IMAGE_TAG")}";
        }
    }
}