using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_web.Models
{
    public class RespaldoModal
    {
        ConneccionBD_Modal oConexion;

        public RespaldoModal()
        {
            oConexion = new ConneccionBD_Modal();
        }

        public void Respaldo()
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + " Proyecto_cocina_Resp");
            string Comando_Consulta = "BACKUP DATABASE [Proyecto_cocina] TO DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.SANTIAGO\\MSSQL\\Backup\\" + nombre_copia + ".bak' WITH NOFORMAT, NOINIT,  NAME = N'Integrador-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand cmd = new SqlCommand(Comando_Consulta, oConexion.ConectarBD());
            oConexion.AbrirConexion();
            cmd.ExecuteNonQuery();
            oConexion.CerrarConexion();
            oConexion.ConectarBD().Dispose();
        }
    }
}