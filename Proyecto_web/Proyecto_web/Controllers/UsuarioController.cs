﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_web.Controllers
{
    public class UsuarioController : Controller
    {
       
        //pagina de inicio de los usuarios ya logueados
        // GET: Usuario
        public ActionResult Inicio_Usuario()
        {
            return View();
        } 

        public ActionResult Perfil_Usuario()
        {
            return View();
        }
        public ActionResult Prueba()
        {
            return View();
        }
        //pagina 

        public ActionResult HastuReceta()
        {
            return View();
        }





    }
}