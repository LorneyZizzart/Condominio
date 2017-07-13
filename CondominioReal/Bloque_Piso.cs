using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominioReal
{
    class Bloque_Piso
    {
        //Atributos de un Bloque
        public int Id_Urbanizacion { get; set; }
        public string NombreBloque { get; set; }
        public int Nro_Pisos { get; set; }
        public string Direccion { get; set; }
        //Atributos de un Piso
        public int Id_Bloque { get; set; }
        public string Nombre_NroPiso { get; set; }
        public int Nros_Departamentos { get; set; }

        public Bloque_Piso() { }
        //Para el Bloque
        public Bloque_Piso(/*Para Bloques*/int id_Urbanizacion, string nombreBloque, int nro_Pisos, string direccion)
        {
            this.Id_Urbanizacion = id_Urbanizacion;
            this.NombreBloque = nombreBloque;
            this.Nro_Pisos = nro_Pisos;
            this.Direccion = direccion;
        }

        public Bloque_Piso(/*Para Pisos*/int id_Bloque, string nombre_NroPiso, int nro_Departamento)
        {
            this.Id_Bloque = id_Bloque;
            this.Nombre_NroPiso = nombre_NroPiso;
            this.Nros_Departamentos = nro_Departamento;
        }

    }
}
