using cursoInduccion.backend.Model;
using System.ComponentModel.DataAnnotations;

namespace cursoInduccion.backend.DTOs
{
    public class AccesoDTO : AccesoDTO
    {
        public int IdA { get; set; }

        public string? Clave { get; set; }

        public string? Nombre { get; set; }
    }

}