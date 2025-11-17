namespace ApiUsuarios.WEB.Models
{
    public class VehiculoDto
    {
        public int Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int? Anno { get; set; }

        public decimal? Precio { get; set; }

        public string Color { get; set; }
    }
}
