using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        int idLibro;
        string nombre;
        int numeroPaginas;
        string fechaPublicacion;
        string edicion;

        ML.Autor autor;
        ML.Editorial editorial;
        ML.Genero genero;

        public int IdLibro { get => idLibro; set => idLibro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int NumeroPaginas { get => numeroPaginas; set => numeroPaginas = value; }
        public string FechaPublicacion { get => fechaPublicacion; set => fechaPublicacion = value; }
        public string Edicion { get => edicion; set => edicion = value; }
        public Autor Autor { get => autor; set => autor = value; }
        public Editorial Editorial { get => editorial; set => editorial = value; }
        public Genero Genero { get => genero; set => genero = value; }
    }
}
