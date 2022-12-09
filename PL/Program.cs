using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($" Menu \n 1 - Get All \n 2 - Add \n 3 - Update \n 4 - Delete \n 5 - GetById   ");
                Console.Write($" Selecciona una opción: ");
                int opcion = int.Parse(Console.ReadLine());

                Redireccionar(opcion);
                Console.ReadLine();
            } while (true);

        }

        static void Redireccionar(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    {
                        Libro.GetAll();
                        break;
                    }
                case 2:
                    {
                        Libro.Add();
                        break;
                    }
                case 3:
                    {
                        Libro.Update();
                        break;
                    }
                case 4:
                    {
                        Libro.Delete();
                        break;
                    }
                case 5:
                    {
                        Libro.GetById();
                        break;
                    }
                case 6:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Console.WriteLine("Opción Invalida");
                    break;
            }
        }

    }
}
