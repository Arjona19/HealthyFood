using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_web.BO_Usuario;

namespace Proyecto_web.Models
{
    public class IngredientesModal
    {

        ConneccionBD_Modal Obj = new ConneccionBD_Modal();

        public int AgregarIngrediente(BO_Admin.IngredientesBo obj)
        {
            string sql = "Insert into Ingredientes (Nombre, Imagen) values ('" + obj.Nombre + "','" + obj.icono + "')";
            return Obj.EjecutarComando(sql);

        }

        public int AgregarEnfermedad(BO_Admin.EnfermedadBO obj)
        {
            string sql = "Insert into Enfermedades (Nombre) values ('" + obj.Nombre + "')";
            return Obj.EjecutarComando(sql);

        }
        public int AgregarMedidas(BO_Admin.MedidasBO obj)
        {
            string sql = "Insert into Medidas (Medida) values ('"+obj.Medida+"')";
            return Obj.EjecutarComando(sql);
        }


    }
}