using Student.Common.Logic.Log4Net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao
{
    public class StudentDao : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;

        public StudentDao() { }

        public StudentDao(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=P-0314;Initial Catalog=VuelingApiD;Integrated Security=true;";
        }



        // Al utilizar SQL connection -> te casas con un tipo de sql
        // DBConnection y DBCommand son las bases donde heredan todos 

        public int AddAlumno(Alumno alumno)
        {
            try
            {
                var sql = "INSERT INTO dbo.Alumnos (UUID, Nombre, Apellido, Dni, DateRegistry, DateBorn, Edad) VALUES (@UUID, @Nombre, @Apellido, @Dni, @DateRegistry, @DateBorn, @Edad)";

                using(SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        // Importante abrir la conexion antes de lanzar ningun comando
                        _conn.Open();

                        _cmd.Parameters.AddWithValue("@UUID", alumno.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre.ToString());
                        _cmd.Parameters.AddWithValue("@Apellido", alumno.Apellidos.ToString());
                        _cmd.Parameters.AddWithValue("@Dni", alumno.Dni.ToString());
                        _cmd.Parameters.AddWithValue("@DateRegistry", alumno.Registro.ToString());
                        _cmd.Parameters.AddWithValue("@DateBorn", alumno.Nacimiento.ToString());
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
