using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_web.Models
{
    public class ComidasModal
    {

        ConneccionBD_Modal conex = new ConneccionBD_Modal();


        public DataTable Comidas_Aprobadas()
        {
            string Con_SQL = string.Format("select Nombre, ID_clasificacion, Descripcion, ID_usuario, ID from Comidas  where Estatus = '1'  ");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public DataTable Comidas_Desaprobadas()
        {
            string Con_SQL = string.Format("select Nombre, ID_clasificacion, Descripcion, ID_usuario, ID from Comidas  where Estatus = '2' ");
            return conex.Tabla_Consultada(Con_SQL);
        }

        public int ActualizarrEstatus(BO_Admin.ComidaBO ObjP)
        {
            string sql = "Update Comidas Set Estatus = 2 where ID ='" + ObjP.id + "'";
            return conex.EjecutarComando(sql);
        }

        public int ActualizarrEstatus_Desaprobado(BO_Admin.ComidaBO ObjP)
        {
            string sql = "Update Comidas Set Estatus = 1 where ID ='" + ObjP.id + "'";
            return conex.EjecutarComando(sql);
        }

    }
}