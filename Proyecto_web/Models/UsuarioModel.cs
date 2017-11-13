using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_web.Models;
using Proyecto_web.BO_Usuario;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace Proyecto_web.Models
{
    public class UsuarioModel
    {
        string Contraseña;
        string NombreUS;
        ConneccionBD_Modal Obj = new ConneccionBD_Modal();

        public int AgregarUsuario(BO_Usuario.LoginBO obj)
        {
            string sql = "Insert into Usuarios (Nombre, Apellido, Email, Contraseña, Nombre_Usuario, ID_Tipo, ID_enfermedad) values ('"+obj.nombre+"','"+obj.apellido+"','"+obj.Email+"','"+obj.contraseña+"','"+obj.Nombre_usuario+"','2','1')";
            return Obj.EjecutarComando(sql);
           
        }
        public Boolean Logear(LoginBO obj)
        {
            
            SqlCommand cmd = new SqlCommand("select Nombre_Usuario, Contraseña from Usuarios where Nombre_Usuario='"+obj.Nombre_usuario+"' and Contraseña='"+obj.contraseña+"'");
            Obj.AbrirConexion();

            SqlDataReader datos = cmd.ExecuteReader();
            while (datos.Read())
            {
               NombreUS = datos["Nombre_Usuario"].ToString() ;
                Contraseña = datos["Contraseña"].ToString();
         
            }
                 if (obj.contraseña == Contraseña && obj.Nombre_usuario == NombreUS)
                 {
                    return true;
                }
                else
                {
                    return false;
                }
             
        }



    }
}