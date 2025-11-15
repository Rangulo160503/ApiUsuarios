using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.DLL.Entidades
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Anno { get; set; }
        public decimal Precio { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
