using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logi.BusinessLogic
{
    public interface IBusiness
    {
        int AddAlumno(Alumno alumno);
        List<Alumno> GetAll();
        Alumno GetById(Guid guid);
        int Remove(Guid guid);
        Alumno Update(Guid guid, Alumno alumno);
    }
}
