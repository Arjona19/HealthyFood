using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Admin;

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
        public ActionResult VerTodaslasComidas()
        {
            ComidasModal OBJ = new ComidasModal();

            return View(OBJ.Comidas_Aprobadas());
        }





    }
}