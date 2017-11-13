using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Usuario;

namespace Proyecto_web.Controllers
{
    public class Inicio_Principal_Controller : Controller
    {
        LoginBO obj = new LoginBO();
        UsuarioModel Obj = new UsuarioModel();
        // GET: Inicio_Principal_
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult RegistroLogin()
        {
            return View();
        }
        public ActionResult Registro(string Nombre, string Apellido, string Contraseña, string email, string nombre_usuario)
        {
            
            obj.Email = email;
            obj.contraseña = Contraseña;
            obj.nombre = Nombre;
            obj.apellido = Apellido;
            obj.Nombre_usuario = nombre_usuario;

            Obj.AgregarUsuario(obj);
            return RedirectToAction("RegistroLogin");
        }
        public ActionResult Login(string Nombre_Usuario, string Contraseña)
        {
            obj.contraseña = Contraseña;
           obj.Nombre_usuario = Nombre_Usuario;
            if (Obj.Logear(obj))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


    }
}