using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_web.Models
{
    public class MedidasModal
    {
        ConneccionBD_Modal Conex = new ConneccionBD_Modal();

        public int AgregarMedidas(BO_Admin.MedidasBO obj)
        {
            string sql = "Insert into Medidas (Medida) values ('" + obj.Medida + "')";
            return Conex.EjecutarComando(sql);
        }

        public DataTable Tabla_Medidas_BD()
        {
            string Con_SQL = string.Format("Select ID_Tipo_Medida, Medida FROM Medidas");
            return Conex.Tabla_Consultada(Con_SQL);
        }

        public BO_Admin.MedidasBO Obtener_Medidas(int id)
        {
            var ex = new BO_Admin.MedidasBO();
            String strBuscar = string.Format("Select ID_Tipo_Medida, Medida FROM Medidas where ID_Tipo_Medida = {0}", id);
            DataTable datos = Conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.ID_medida = Convert.ToInt32(row["ID_Tipo_Medida"]);
            ex.Medida = row["Medida"].ToString();
            return ex;
        }

        public int MedidasActualizar(BO_Admin.MedidasBO obj)
        {
            string sql = "Update Medidas Set Medida='" + obj.Medida + "' where ID_Tipo_Medida='" + obj.ID_medida + "'";
            return Conex.EjecutarComando(sql);
        }

        public int EliminarMedidas(BO_Admin.MedidasBO obj)
        {
            string sql = "Delete from Medidas where ID_Tipo_Medida = '" + obj.ID_medida + "'";

            return Conex.EjecutarComando(sql);
        }
    }
}