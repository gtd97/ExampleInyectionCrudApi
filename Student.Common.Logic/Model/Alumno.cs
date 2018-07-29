using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Model
{
    public class Alumno: IVuelingObject
    {
        #region Propiedades
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Registro { get; set; }
        #endregion

        #region Constructores
        public Alumno() { }
        public Alumno(Guid guid, int id, string nombre, string apellidos, string dni, int edad, DateTime nacimiento, DateTime registro)
        {
            this.Guid = guid;
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Edad = edad;
            this.Nacimiento = nacimiento;
            this.Registro = registro;
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Guid.Equals(alumno.Guid) &&
                   Id == alumno.Id &&
                   Dni == alumno.Dni &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   Edad == alumno.Edad &&
                   Nacimiento == alumno.Nacimiento &&
                   Registro == alumno.Registro;
        }
        #endregion

        #region GetHashCode
        public override int GetHashCode()
        {
            var hashCode = -377388725;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Guid);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + Nacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Registro.GetHashCode();
            return hashCode;
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}