using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_web.BO_Usuario;
using Proyecto_web.Models;
using System.Data.SqlClient;
using System.Data;
using Proyecto_web.Models;

namespace Proyecto_web.Models
{
    public class UsuarioModal
    {

        ConneccionBD_Modal Conex = new ConneccionBD_Modal();


        ConneccionBD_Modal Obj = new ConneccionBD_Modal();

        public int AgregarUsuario(BO_Usuario.LoginBO obj)
        {
            string sql = "Insert into Usuarios (Nombre, Apellido, Email, Estatus, Contraseña, Nombre_Usuario, ID_Tipo, ID_enfermedad) values ('" + obj.nombre + "','" + obj.apellido + "','" + obj.Email + "', 'Activo', '" + obj.contraseña + "','" + obj.Nombre_usuario + "','2','1')";
            return Obj.EjecutarComando(sql);


        }
        
        public int validar()
        {
            return 1;
        }




    }
}