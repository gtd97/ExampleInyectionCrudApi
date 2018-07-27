using Student.Common.Logic.Log4Net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Contracts;
using System;
using System.Collections.Generic;
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
    }
}
