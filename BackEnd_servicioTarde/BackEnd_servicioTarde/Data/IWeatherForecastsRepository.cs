using BackEnd_servicioTarde;
using cursoInduccion.backend.Model;

namespace cursoInduccion.backend.Repositories
{
    public interface IWeatherForecastsRepository
    {
        Task<IEnumerable<WeatherForecast>> ListAsync();
        Task<WeatherForecast?> FindAsync(int id);
        Task<int> Add(WeatherForecast weatherForecast);
        Task<int> Update(WeatherForecast weatherForecast);
        Task<int> Remove(WeatherForecast weatherForecast);
        bool Exists(int id);
    }
}