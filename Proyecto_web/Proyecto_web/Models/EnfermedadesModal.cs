using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Proyecto_web.BO_Admin;
using System.Data.SqlClient;

namespace Proyecto_web.Models
{
    public class EnfermedadesModal
    {
        ConneccionBD_Modal Conex = new ConneccionBD_Modal();

        public int AgregarEnfermedad(BO_Admin.EnfermedadBO obj)
        {
            string sql = "Insert into Enfermedades (Nombre) values ('" + obj.Nombre + "')";
            return Conex.EjecutarComando(sql);
        }

        public DataTable Tabla_Enfermedad_BD()
        {
            string Con_SQL = string.Format("Select ID_enfermedad, Nombre FROM Enfermedades");
            return Conex.Tabla_Consultada(Con_SQL);
        }

        public BO_Admin.EnfermedadBO Obtener_Enfermedad(int id)
        {
            var ex = new BO_Admin.EnfermedadBO();
            String strBuscar = string.Format("Select ID_enfermedad, Nombre FROM Enfermedades where ID_enfermedad ={0}", id);
            DataTable datos = Conex.Tabla_Consultada(strBuscar);
            DataRow row = datos.Rows[0];
            ex.id = Convert.ToInt32(row["ID_enfermedad"]);
            ex.Nombre = row["Nombre"].ToString();
            return ex;
        }

        public int EnfermedadActualizar(BO_Admin.EnfermedadBO obj)
        {
            string sql = "Update Enfermedades Set Nombre='" + obj.Nombre + "' where ID_enfermedad='" + obj.id + "'";
            return Conex.EjecutarComando(sql);
        }

        public int EliminarEnfermedad(BO_Admin.EnfermedadBO obj)
        {
            string sql = "delete from Enfermedades where ID_enfermedad = '" + obj.id + "'";
        
            return Conex.EjecutarComando(sql);
        }
    }
}