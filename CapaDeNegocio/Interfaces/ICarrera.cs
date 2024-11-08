using CapaDeNegocio.Clases;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Interfaces
{
    internal interface ICarrera
    {
        string Nombre { get; set; }
        string Sigla { get; set; }
        string Titulo { get; set; }
        int Duracion { get; set; }

        bool NameExist(string nombre);
        bool SiglaExist(string sigla);
        Carrera FindSigla(string sigla);

        string List();

    }
}
