using Student.Common.Logic.Log4Net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Repository
{
    public class RepositoryStudent : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;

        #region Constructores
        public RepositoryStudent() { }

        public RepositoryStudent(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=P-0314;Initial Catalog=VuelingApiD;Integrated Security=true;";
        }
        #endregion

        #region Add
        public int AddAlumno(Alumno alumno)
        {
            try
            {
                var sql = "INSERT INTO dbo.Alumnos (Guid, Nombre, Apellidos, Dni, Registro, Nacimiento, Edad) VALUES (@Guid, @Nombre, @Apellidos, @Dni, @Registro, @Nacimiento, @Edad)";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", alumno.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@IDENTITY";

                        // Obtener el ultimo identificador insertado.
                        return Convert.ToInt32(_cmd.ExecuteScalar());

                        // var id = Convert.ToInt32(_cmd.ExecuteScalar());
                        // return SelectById(id);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public List<Alumno> GetAll()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            try
            {
                var sql = "SELECT * FROM dbo.Alumnos";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    // Importante abrir la conexion antes de lanzar ningun comando
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno alumno = new Alumno(Guid.Parse(reader["guid"].ToString()), Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellidos"].ToString(), reader["dni"].ToString(), Convert.ToInt32(reader["edad"]), DateTime.Parse(reader["nacimiento"].ToString()), DateTime.Parse(reader["registro"].ToString()));
                                listaAlumnos.Add(alumno);
                            }
                        }
                    }
                }

                return listaAlumnos;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region GetById
        public Alumno GetById(Guid guid)
        {
            Alumno alumno = null;

            try
            {
                var sql = "SELECT * FROM dbo.Alumnos WHERE Guid=@GUID";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@GUID", guid);

                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumno = new Alumno(Guid.Parse(reader["guid"].ToString()), Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellidos"].ToString(), reader["dni"].ToString(), Convert.ToInt32(reader["edad"]), DateTime.Parse(reader["nacimiento"].ToString()), DateTime.Parse(reader["registro"].ToString()));
                            }
                        }
                    }
                }

                return alumno;
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Remove
        public int Remove(Guid guid)
        {
            try
            {
                // var sql = "DELETE FROM dbo.Alumnos WHERE Guid='@GUID'";
                var sql = "DELETE FROM dbo.Alumnos WHERE Guid=@GUID";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();
                        
                        _cmd.Parameters.AddWithValue("@GUID", guid);

                        _cmd.ExecuteNonQuery();

                        return 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public Alumno Update(Guid guid, Alumno alumno)
        {
            try
            {
                var sql = "UPDATE dbo.Alumnos SET Guid=@Guid, Nombre=@Nombre, Apellidos=@Apellidos, Dni=@Dni, Registro=@Registro, Nacimiento=@Nacimiento, Edad=@Edad WHERE Guid=@Guid";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@Guid", guid);
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento.ToString());
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad.ToString());

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        return GetById(guid);
                    }
                }
            }
            catch (SqlException ex)
            {
                log.Error(ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion
        
    }
}
