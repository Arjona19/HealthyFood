using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_web.BO_Usuario;
using System.Data;
using System.Data.SqlClient;
using Proyecto_web.BO_Admin;

namespace Proyecto_web.Models
{
    public class IngredientesModal
    {

        ConneccionBD_Modal conex = new ConneccionBD_Modal();

        public int AgregarIngrediente(IngredientesBo ObjP)
        {
            string sql = "Insert into Ingredientes (Nombre) values ('" + ObjP.Nombre+ "')";
            return conex.EjecutarComando(sql);

        }


        public int EliminarIngrediente(IngredientesBo ObjP)
        {
            string sql = "Delete from Ingredientes where ID = '" + ObjP.id + "'";

            return conex.EjecutarComando(sql);

        }

        public int ActualizarrIngrediente(IngredientesBo ObjP)
        {
            string sql = "Update Ingredientes Set Nombre='" + ObjP.Nombre + "' where ID='" + ObjP.id + "'";
            return conex.EjecutarComando(sql);

        }

        public IngredientesBo ObtenerIngredientes(int Id)
        {
            var ex = new BO_Admin.IngredientesBo();
            String strBuscar = string.Format("Select ID, Nombre FROM Ingredientes where ID = {0}", Id);
            DataTable datos = conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.id = Convert.ToInt32(row["ID_Tipo_Medida"]);
            ex.Nombre = row["Medida"].ToString();
            return ex;
        }

        public DataTable TablaINgredientes()
        {
            string Con_SQL = string.Format("Select ID, Nombre FROM Ingredientes");
            return conex.Tabla_Consultada(Con_SQL);
        }



    }
}