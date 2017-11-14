using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_web.Models
{
    public class ClasificacionModal
    {
        ConneccionBD_Modal Conex = new ConneccionBD_Modal();

        public int AgregarClasificacion(BO_Admin.ClasificaciónComidasBO obj)
        {
            string sql = "Insert into Clasificacion (Nombre) values ('" + obj.Clasificaion + "')";
            return Conex.EjecutarComando(sql);
        }

        public DataTable Tabla_Clasificacion_BD()
        {
            string Con_SQL = string.Format("Select ID_clasificacion, Nombre FROM Clasificacion");
            return Conex.Tabla_Consultada(Con_SQL);
        }

        public BO_Admin.ClasificaciónComidasBO Obtener_Clasificacion(int id)
        {
            var ex = new BO_Admin.ClasificaciónComidasBO();
            String strBuscar = string.Format("Select ID_clasificacion, Nombre FROM Clasificacion where ID_clasificacion = {0}", id);
            DataTable datos = Conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.id_cla = Convert.ToInt32(row["ID_clasificacion"]);
            ex.Clasificaion = row["Nombre"].ToString();
            return ex;
        }

        public int CladificacionActualizar(BO_Admin.ClasificaciónComidasBO obj)
        {
            string sql = "Update Clasificacion Set Nombre='" + obj.Clasificaion + "' where ID_clasificacion='" + obj.id_cla + "'";
            return Conex.EjecutarComando(sql);
        }

        public int EliminarClasificacion(BO_Admin.ClasificaciónComidasBO obj)
        {
            string sql = "Delete from Clasificacion where ID_clasificacion = '" + obj.id_cla + "'";

            return Conex.EjecutarComando(sql);
        }
    }
}