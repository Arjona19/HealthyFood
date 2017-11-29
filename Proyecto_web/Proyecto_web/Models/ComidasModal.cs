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
            string Con_SQL = string.Format("select C.Nombre, CL.Nombre  as 'Clasificacion', C.Descripcion, U.Nombre_Usuario, C.ID, C.Estatus from Comidas C INNER JOIN Usuarios U  ON C.ID_usuario = U.ID INNER JOIN Clasificacion CL on C.ID_clasificacion = CL.ID_clasificacion where C.Estatus = '1'  ");
            return conex.Tabla_Consultada(Con_SQL);
        }
        public DataTable Comidas_Desaprobadas()
        {
            string Con_SQL = string.Format("select C.Nombre, CL.Nombre  as 'Clasificacion', C.Descripcion, U.Nombre_Usuario, C.ID, C.Estatus from Comidas C INNER JOIN Usuarios U  ON C.ID_usuario = U.ID INNER JOIN Clasificacion CL on C.ID_clasificacion = CL.ID_clasificacion where C.Estatus = '2'  ");
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