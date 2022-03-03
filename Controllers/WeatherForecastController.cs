using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        //[HttpGet("obter-valores")]
        //public ActionResult<IEnumerable<string>> ObterValores()
        //{
        //    var valores = new string[] { "valor1", "valor2", "valor3" };

        //    if (valores.Length == 5000)
        //    {
        //        return BadRequest();
        //    }

        //    return valores;
        //}

        //[HttpGet("obter-valores-resultados")]
        //public ActionResult<Array> ObterValoresResultado()
        //{
        //    var valores = new string[] { "valor1", "valor2", "valor3" };

        //    if (valores.Length == 5000)
        //    {
        //        return BadRequest();
        //    }

        //    return valores;
        //}


        //[HttpPost]
        //public IEnumerable<WeatherForecast> Post([FromBody] WeatherForecast weatherForecast)
        //{

        //    List<WeatherForecast> weather = new List<WeatherForecast>();

        //    weather.Add(weatherForecast);


        //    return weather.ToArray();




        //}

        //[HttpPost]
        ////[Route("cadastrar-produtos")]
        //public ActionResult<IEnumerable<Product>> PostProdutos([FromBody] Product produtos)
        //{
        //    var registrar = new List<Product>();

        //    registrar.Add(produtos);
        //    return CreatedAtAction(nameof(PostProdutos), registrar.ToArray());
        //}

        [HttpPost]
        [ProducesResponseType(typeof(Product),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post(Product value)
        {
            if (value.Id == 0)
            {
                return BadRequest();
            }
            return CreatedAtAction(actionName:nameof(Post), value);
        }



        [HttpGet("{id}")]
        //[Route("cadastrar-produtos")]
        public ActionResult<IEnumerable<Product>> PostProdutoss([FromBody]List<Product> lista,[FromRoute] int id)
        {

            var resultado = lista.Find(x=>x.Id==id);


            return Ok(resultado);
        }
    }

    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {

                return Ok(new
                {
                    sucess = true,
                    data = result
                });

            }

            // colecoes de erros para o frontEnd
            return BadRequest(new
            {
                sucess = false,
                erros = ObterErros()
            });
        }

        protected string ObterErros()
        {
            return "";
        }

        //validacao no back
        public bool OperacaoValida()
        {
            return true;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
