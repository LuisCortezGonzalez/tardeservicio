using cursoInduccion.backend.DTOs;
using cursoInduccion.backend.Model;
using cursoInduccion.backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace cursoInduccion.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosController : ControllerBase
    {
        private readonly IWeatherForecastsService _weatherForecastsService;

        public AccesosController(IWeatherForecastsService weatherForecastsService)
        {
            _weatherForecastsService = weatherForecastsService;
        }

        [HttpGet]
        [ProducesResponseType(
            typeof(IEnumerable<WeatherForecastsDTO>),
            StatusCodes.Status200OK,
            MediaTypeNames.Application.Json
        )]
        public async Task<IEnumerable<WeatherForecastsDTO>> GetWeatherForecast()
        {
            return (await _weatherForecastsService.ToListAsync()).Select(WeatherForecastsDTO.ToDTO);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(
            typeof(WeatherForecastsDTO),
            StatusCodes.Status200OK,
            MediaTypeNames.Application.Json
        )]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WeatherForecastsDTO>> GetWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastsService.FindAsync(id);
            if (weatherForecast == null) return NotFound();
            return WeatherForecastsDTO.ToDTO(weatherForecast);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecastsDTO _weatherForecast)
        {
            if (id != _weatherForecast.Id) return BadRequest();
            await _weatherForecastsService.Update(WeatherForecastsDTO.ToObject(_weatherForecast));
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(WeatherForecastsDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastsDTO>> PostWeatherForecast(WeatherForecastsNewDTO _weatherForecast)
        {
            var weatherForecast = WeatherForecastsNewDTO.ToObject(_weatherForecast);
            await _weatherForecastsService.Add(weatherForecast);
            return WeatherForecastsDTO.ToDTO(weatherForecast);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWeatherForecast(int id)
        {
            var weatherForecast = await _weatherForecastsService.FindAsync(id);
            if (weatherForecast == null) return NotFound();
            await _weatherForecastsService.Remove(weatherForecast);
            return NoContent();
        }

        private bool WeatherForecastExists(int id)
        {
            return _weatherForecastsService.Exists(id);
        }
    }
}