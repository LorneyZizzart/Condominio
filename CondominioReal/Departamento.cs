using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioReal
{
    class Departamento
    {
        public int ID_Vivienda { get; set; }
        public int ID_Pisos { get; set; }
        public int ID_Estado { get; set; }
        public int ID_TipoVivienda { get; set; }
        public string Nombre { get; set; }
        public int NroHabitaciones { get; set; }
        public int NroSanitario { get; set; }
        public int CompraOriginal { get; set; }
        public int VentaActual { get; set; }
        public string Superficie { get; set; }
        public string Descripcion { get; set; }
        public bool Oferta { get; set; }
        public Image Fotografias { get; set; }
        public string TipoMultimedia { get; set; }
        public string RutaMultimedia { get; set; }

        public Departamento() { }

        public Departamento(int id_Pisos, int id_Estado, int id_TipoVivienda, string nombre, int nroHabitaciones, int nroSanitario, int compraOriginal, int ventaActual,
            string superficie, string descripcion, bool oferta)
        {
            this.ID_Pisos = id_Pisos;
            this.ID_Estado = id_Estado;
            this.ID_TipoVivienda = id_TipoVivienda;
            this.Nombre = nombre;
            this.NroHabitaciones = nroHabitaciones;
            this.NroSanitario = nroSanitario;
            this.CompraOriginal = compraOriginal;
            this.VentaActual = ventaActual;
            this.Superficie = superficie;
            this.Descripcion = descripcion;
            this.Oferta = oferta;
        }
    }
}
