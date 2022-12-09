using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static Result GetAll()
        {
            Result result = new Result();

            try
            {
                string query = "LibroGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        result.Objects = new List<object>();
                        ML.Libro libro = null;
                        while (reader.Read())
                        {

                            libro = new ML.Libro();
                            libro.Autor = new Autor();
                            libro.Editorial = new Editorial();
                            libro.Genero = new Genero();

                            libro.IdLibro = reader.GetInt32(0);
                            libro.Nombre = reader.GetString(1);
                            libro.Autor.IdAutor = reader.GetInt32(2);
                            libro.NumeroPaginas = reader.GetInt32(3);
                            libro.FechaPublicacion = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                            libro.Editorial.IdEditorial = reader.GetInt32(5);
                            libro.Edicion = reader.GetString(6);
                            libro.Genero.IdGenero = reader.GetInt32(7);

                            libro.Autor.Nombre = reader.GetString(8);
                            libro.Editorial.Nombre = reader.GetString(9);

                            libro.Genero.Nombre = reader.GetString(10);

                            result.Objects.Add(libro);
                        }

                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result GetById(int IdLibro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroGet";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@IdLibro", IdLibro);

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.HasRows)
                    {
                        ML.Libro libro = null;
                        reader.Read();

                        libro = new ML.Libro();
                        libro.Autor = new Autor();
                        libro.Editorial = new Editorial();
                        libro.Genero = new Genero();

                        libro.IdLibro = reader.GetInt32(0);
                        libro.Nombre = reader.GetString(1);
                        libro.Autor.IdAutor = reader.GetInt32(2);
                        libro.NumeroPaginas = reader.GetInt32(3);
                        libro.FechaPublicacion = reader.GetDateTime(4).ToString("dd/MM/yyyy");
                        libro.Editorial.IdEditorial = reader.GetInt32(5);
                        libro.Edicion = reader.GetString(6);
                        libro.Genero.IdGenero = reader.GetInt32(7);

                        libro.Autor.Nombre = reader.GetString(8);
                        libro.Editorial.Nombre = reader.GetString(9);

                        libro.Genero.Nombre = reader.GetString(10);

                        result.Object = libro;


                        result.Mensaje = "Información encontrada con éxito";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Información no encontrada";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result Add(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroAdd";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                    cmd.Parameters.AddWithValue("@IdAutor", libro.Autor.IdAutor);
                    cmd.Parameters.AddWithValue("@NumeroPaginas", libro.NumeroPaginas);
                    cmd.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    cmd.Parameters.AddWithValue("@IdEditorial", libro.Editorial.IdEditorial);
                    cmd.Parameters.AddWithValue("@Edicion", libro.Edicion);
                    cmd.Parameters.AddWithValue("@IdGenero", libro.Genero.IdGenero);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Ingresado exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO ingresado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }

        public static Result Update(ML.Libro libro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroUpdate";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                    cmd.Parameters.AddWithValue("@Nombre", libro.Nombre);
                    cmd.Parameters.AddWithValue("@IdAutor", libro.Autor.IdAutor);
                    cmd.Parameters.AddWithValue("@NumeroPaginas", libro.NumeroPaginas);
                    cmd.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    cmd.Parameters.AddWithValue("@IdEditorial", libro.Editorial.IdEditorial);
                    cmd.Parameters.AddWithValue("@Edicion", libro.Edicion);
                    cmd.Parameters.AddWithValue("@IdGenero", libro.Genero.IdGenero);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro Actualizado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO actualizado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }


        public static Result Delete(int IdLibro)
        {
            Result result = new Result();

            try
            {
                string query = "LibroDelete";
                using (SqlConnection context = new SqlConnection(Conexion.GetConexion()))
                {
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdLibro", IdLibro);

                    cmd.Connection.Open();

                    int execute = cmd.ExecuteNonQuery();


                    if (execute > 0)
                    {

                        result.Mensaje = "Registro borrado correctamente exitosamente";
                        result.Correct = true;

                    }
                    else
                    {
                        result.Mensaje = "Registro NO borrado";
                        result.Correct = false;
                    }


                    cmd.Connection.Close();

                }

            }
            catch (Exception error)
            {
                result.Exception = error;
                result.Correct = false;
                result.Mensaje = $"Error: {result.Exception.Message}";
            }

            return result;
        }
    }
}
