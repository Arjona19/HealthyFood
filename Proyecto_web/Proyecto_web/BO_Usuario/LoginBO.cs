using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_web.BO_Usuario
{
    public class LoginBO
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contraseña { get; set; }
        public string status { get; set; }
        public string Email { get; set; }
        public string Nombre_usuario { get; set; }
        public int id_tipo { get; set; }
        public int id_enfermedad { get; set; }


    }
}