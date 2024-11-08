using CapaDeNegocio.Datos;
using CapaDeNegocio.Interfaces;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Clases
{
    internal class Carrera : IID, ICarrera, IABMC
    {
        private static DatosCarrera datos = new DatosCarrera();
        public string Nombre { get; set; }
        public string Sigla { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public int ID { get; set; }

        public Carrera FindSigla(string sigla)
        {
            throw new Exception("No se ha encontrado ningun usuario con esta Sigla");
        }

        public string List()
        {
            return datos.List();
        }

        public bool NameExist(string nombre)
        {
            return false;
        }

        public bool SiglaExist(string sigla)
        {
            return false;
        }
    }
}
