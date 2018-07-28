using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Contracts
{
    public interface IRepository
    {
        int AddAlumno(Alumno alumno);
        List<Alumno> GetAll();
    }
}
