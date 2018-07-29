using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Log4Net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Contracts;

namespace Student.Business.Logi.BusinessLogic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;

        public StudentBL(ILogger Logger, IRepository dao)
        {
            this.Log = Logger;
            this.repository = dao;
        }

        public int AddAlumno(Alumno alumno)
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.AddAlumno(alumno);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public List<Alumno> GetAll()
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Alumno GetById(Guid guid)
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.GetById(guid);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public Alumno Update(Guid guid, Alumno alumno)
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Update(guid, alumno);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        public int Remove(Guid guid)
        {
            try
            {
                // Obtener el nombre del metodo --> System.Reflection.MethodBase.GetCurrentMethod().Name
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.Remove(guid);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }
    }
}
