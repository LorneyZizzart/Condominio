using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioReal
{
    class Habitante
    {
        public int Id_Habitante { get; set; }
        public int Id_TipoHabitante { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Carnet { get; set; }
        public string ExtencionCI { get; set; }
        public string Sexo { get; set; }
        public string Calle { get; set; }
        public string Zona { get; set; }
        public string Fotografia { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public bool Titular { get; set; }

        public Habitante() { }

        public Habitante(int id_TipoHabitante, string primerNombre, string segundoNombre, string apellidoPaterno, string apellidoMaterno,
            string carnet, string sexo, string calle, string zona)
        {
            this.Id_TipoHabitante = id_TipoHabitante;
            this.PrimerNombre = primerNombre;
            this.SegundoNombre = segundoNombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.Carnet = carnet;
            this.Sexo = sexo;
            this.Calle = calle;
            this.Zona = zona;
        }
    }
}
