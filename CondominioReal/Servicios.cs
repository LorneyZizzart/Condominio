using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioReal
{
    class Servicios
    {
        public int IdServicio { get; set; }
        public string Empresa { get; set; }
        public string Servicio { get; set; }
        public string Precio { get; set; }
        public bool Obligatorio { get; set; }
        public int Telefono { get; set; }
        public string Descripcion { get; set; }

        public Servicios() { }

        public Servicios(string empresa, string servicio, string precio, bool obligatorio, int telefono, string descripcion)
        {
            this.Empresa = empresa;
            this.Servicio = servicio;
            this.Precio = precio;
            this.Obligatorio = obligatorio;
            this.Telefono = telefono;
            this.Descripcion = descripcion;
        }
    }
}
