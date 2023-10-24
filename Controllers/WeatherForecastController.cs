using Microsoft.AspNetCore.Mvc;

namespace SurisCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      

        private static readonly IList<int> Vagones = new List<int>();


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetVagones")]
        public IList<int> Get()
        {
            return Vagones;
        }


        // Add Vagon derecha
        [HttpPost("AddVagonDerecha")]
        public IActionResult AddDerecha([FromBody] int nuevo) {

            Vagones.Add(nuevo);
            return Ok();
        }


        //// Add vagon izq
        [HttpPost("AddVagonIzquierda")]
        public IActionResult AddIzquierda([FromBody] int nuevo)
        {
            Vagones.Insert(0, nuevo);
            return Ok();

            
        }



        //Eliminar der
        [HttpDelete("DeleteDerecha")]
        public IActionResult DeleteDerecha()
        {
            if (Vagones.Count == 0)
            {
                return NoContent();
            }
            Vagones.RemoveAt(Vagones.Count - 1);
            return Ok();
        }


        //Eliminar izq
        [HttpDelete("DeleteIzquierda")]
        public IActionResult DeleteIzquierda()
        {
            if(Vagones.Count == 0)
            {
                return NoContent();
            }
            Vagones.RemoveAt(0);
            return Ok();
        }

    }
}