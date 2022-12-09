using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                ML.Libro libro;
                Console.WriteLine(result.Mensaje);
                result.Objects.ForEach(obj =>
                {
                    libro = (ML.Libro)obj;
                    PrintRegister(libro);

                });
            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void GetById()
        {
            ML.Libro libro = new ML.Libro();
            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
               
                Console.WriteLine(result.Mensaje);
                libro = (ML.Libro)result.Object;
                PrintRegister(libro);
                
            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void Add()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new Autor();
            libro.Editorial = new Editorial();
            libro.Genero = new Genero();

            Console.Write("Nombre: ");
            libro.Nombre = Console.ReadLine();
            Console.Write("Id Autor: ");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());
            Console.Write("Numero Paginas: ");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());
            Console.Write("Fecha publicación (dd/MM/yyyy): ");
            libro.FechaPublicacion = Console.ReadLine();
            Console.Write("Id Editorial: ");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
            Console.Write("Edición: ");
            libro.Edicion = Console.ReadLine();
            Console.Write("Id Genero: ");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                Console.WriteLine(result.Mensaje);

            }
            else
            {
                Error(result.Mensaje);
            }

        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new Autor();
            libro.Editorial = new Editorial();
            libro.Genero = new Genero();

            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.GetById(libro.IdLibro);

            if (result.Correct)
            {
                ML.Libro libroResult = (ML.Libro)result.Object;
                PrintRegister(libroResult);

                Console.Write("Nombre: ");
                libro.Nombre = Console.ReadLine();
                Console.Write("Id Autor: ");
                libro.Autor.IdAutor = int.Parse(Console.ReadLine());
                Console.Write("Numero Paginas: ");
                libro.NumeroPaginas = int.Parse(Console.ReadLine());
                Console.Write("Fecha publicación (dd/MM/yyyy): ");
                libro.FechaPublicacion = Console.ReadLine();
                Console.Write("Id Editorial: ");
                libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());
                Console.Write("Edición: ");
                libro.Edicion = Console.ReadLine();
                Console.Write("Id Genero: ");
                libro.Genero.IdGenero = int.Parse(Console.ReadLine());

                result = BL.Libro.Update(libro);

                if (result.Correct)
                {
                    Console.WriteLine(result.Mensaje);

                }
                else
                {
                    Error(result.Mensaje);
                }

            }
            else
            {
                Error(result.Mensaje);
            }
        }

        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();

            Console.Write("Id Libro: ");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(libro.IdLibro);

            if (result.Correct)
            {
                Console.WriteLine(result.Mensaje);

            }
            else
            {
                Error(result.Mensaje);
            }

        }
        static void Error(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        static void PrintRegister(ML.Libro libro)
        {
            Console.Write($"ID :{libro.IdLibro}\n " +
                      $"Nombre:{libro.Nombre}\n " +
                      $"Autor:{libro.Autor.Nombre}\n " +
                      $"Paginas:{libro.NumeroPaginas}\n " +
                      $"Lanzamiento:{libro.FechaPublicacion}\n " +
                      $"Editorial:{libro.Editorial.Nombre}\n " +
                      $"Edición:{libro.Edicion}\n " +
                      $"Genero:{libro.Genero.Nombre}\n" +
                      $"------------------------------------------------\n");
        }


    }
}
