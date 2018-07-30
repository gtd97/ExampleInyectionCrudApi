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

namespace Student.DataAccess.Dao.Repository.StoreProcedure
{
    public class RepositoryStoreProcedureStudent : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;

        #region Constructores
        public RepositoryStoreProcedureStudent() { }

        public RepositoryStoreProcedureStudent(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=P-0314;Initial Catalog=VuelingApiD;Integrated Security=true;";
        }
        #endregion



        #region AddAlumno
        public int AddAlumno(Alumno alumno)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand("uspInsertStudent", _conn))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;

                        _cmd.Parameters.AddWithValue("@StudentsGuid", alumno.Guid);
                        _cmd.Parameters.AddWithValue("@StudentsNombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@StudentsApellido", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@StudentsDni", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@StudentsEdad", alumno.Edad);
                        _cmd.Parameters.AddWithValue("@StudentsNacimiento", alumno.Nacimiento);
                        _cmd.Parameters.AddWithValue("@StudentsRegistro", alumno.Registro);

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();


                        using (SqlCommand _cmd2 = new SqlCommand("SELECT @@IDENTITY", _conn))
                        {
                            return Convert.ToInt32(_cmd2.ExecuteScalar());
                        }
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
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand("uspGetAllStudents", _conn))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno alumno = new Alumno(Guid.Parse(reader["guid"].ToString()),
                                                    Convert.ToInt32(reader["id"]), reader["nombre"].ToString(),
                                                    reader["apellidos"].ToString(), reader["dni"].ToString(),
                                                    Convert.ToInt32(reader["edad"]),
                                                    DateTime.Parse(reader["nacimiento"].ToString()),
                                                    DateTime.Parse(reader["registro"].ToString()));

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

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand("uspGetByGuid", _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@GuidOfStudent", guid);

                        using (SqlDataReader reader = _cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                alumno = new Alumno(Guid.Parse(reader["guid"].ToString()),
                                            Convert.ToInt32(reader["id"]), reader["nombre"].ToString(),
                                            reader["apellidos"].ToString(), reader["dni"].ToString(),
                                            Convert.ToInt32(reader["edad"]), DateTime.Parse(reader["nacimiento"].ToString()),
                                            DateTime.Parse(reader["registro"].ToString()));
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
        public bool Remove(Guid guid)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand("uspDeleteByGuid", _conn))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;
                        _cmd.Parameters.AddWithValue("@GuidOfStudent", guid);

                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        return true;
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
                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    _conn.Open();

                    using (SqlCommand _cmd = new SqlCommand("uspUpdateStudent", _conn))
                    {
                        _cmd.CommandType = CommandType.StoredProcedure;

                        _cmd.Parameters.AddWithValue("@GuidOfStudent", guid);
                        _cmd.Parameters.AddWithValue("@StudentsGuid", alumno.Guid);
                        _cmd.Parameters.AddWithValue("@StudentsNombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@StudentsApellido", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@StudentsDni", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@StudentsEdad", alumno.Edad);
                        _cmd.Parameters.AddWithValue("@StudentsNacimiento", alumno.Nacimiento);
                        _cmd.Parameters.AddWithValue("@StudentsRegistro", alumno.Registro);

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
