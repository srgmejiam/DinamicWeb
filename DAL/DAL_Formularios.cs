using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Formularios
    {
        public static Formularios Insert(Formularios Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Formularios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(Formularios Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = bd.Formularios.Find(Entidad.IdFormulario);
                RegistroBD.Formulario = Entidad.Formulario;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(Formularios Entidad)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var RegistroBD = bd.Formularios.Find(Entidad.IdFormulario);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<Formularios> List(bool Activo = true)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return bd.Formularios.Where(a => a.Activo == Activo).ToList();
            }
        }
        public static Formularios Registro(int IdRegistro)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                return bd.Formularios.Find(IdRegistro);
            }
        }
        public static List<Formularios> Buscar(string Palabra)
        {
            using (BDDinamicWeb bd = new BDDinamicWeb())
            {
                var Consulta = bd.Formularios.Where(a => a.Formulario.Contains(Palabra)).ToList();
                return Consulta;
            }
        }

    }
}
