﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_web.BO_Usuario;
using Proyecto_web.Models;
using System.Data.SqlClient;
using System.Data;


namespace Proyecto_web.Models
{
    public class UsuarioModal
    {

        ExtrasBO _oExtrasBO = new ExtrasBO();
        private String hashkey = "hg849gh84th==3tg7-534d=_";

        ConneccionBD_Modal Obj = new ConneccionBD_Modal();

        public int AgregarUsuario(BO_Usuario.LoginBO obj)
        {
            string sql = "Insert into Usuarios (Nombre, Apellido, Email, Estatus, Contraseña, Nombre_Usuario, ID_Tipo, ID_enfermedad, SHA512) values ('" + obj.nombre + "','" + obj.apellido + "','" + obj.Email + "', 'Activo', '" + _oExtrasBO.Encriptar( obj.contraseña) + "','" + obj.Nombre_usuario + "','2','1', '" + _oExtrasBO.CreateSHAHash(obj.contraseña, hashkey) + "')";
            return Obj.EjecutarComando(sql);


        }

        public int validar()
        {
            return 1;
        }

        public int Actualizad_admin(BO_Usuario.LoginBO obj)
        {
            string sql = "update  Usuarios set Nombre='" + obj.nombre + "', Apellido = '"+ obj.apellido + "',  Email = '"+ obj.Email+ "', Contraseña = '" + obj.contraseña + "'  where ID ='" + obj.id + "'";
            return Obj.EjecutarComando(sql);
        }





    }
}