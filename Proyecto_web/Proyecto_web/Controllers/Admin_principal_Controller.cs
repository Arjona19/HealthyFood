using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Admin;
namespace Proyecto_web.Controllers
{
    public class Admin_principal_Controller : Controller
    {
        // GET: Admin_principal_
        public ActionResult Admin_Principal()
        {
            return View();
        }

        public ActionResult Agregar_Ingrediente()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            EnfermedadesModal enfM = new EnfermedadesModal();

            return View();
        }

        public ActionResult Agregar_Enfermedad()
        {
            EnfermedadesModal enfM = new EnfermedadesModal();

            return View(enfM.Tabla_Enfermedad_BD());
        }
        public ActionResult AgregarEnfe(string Nombre)
        {
            EnfermedadesModal enfM = new EnfermedadesModal();
            BO_Admin.EnfermedadBO oEnf = new EnfermedadBO();
            oEnf.Nombre = Nombre;
            enfM.AgregarEnfermedad(oEnf);
            Agregar_Enfermedad();
            return View("Agregar_Enfermedad");
        }
        public ActionResult Actualizar_Enfermedad(EnfermedadBO Obj_Enfermedad)
        {
            EnfermedadesModal Objeto_Enfermedad = new EnfermedadesModal();
            Objeto_Enfermedad.EnfermedadActualizar(Obj_Enfermedad);
            return View("Agregar_Enfermedad");
        }

        public ActionResult Actualizar_Datos(int id, string Nombre)
        {

            EnfermedadesModal enfM = new EnfermedadesModal();
            EnfermedadBO oEnf = new EnfermedadBO();
            oEnf.id = id;
            oEnf.Nombre = Nombre;
            enfM.EnfermedadActualizar(oEnf);
            Agregar_Enfermedad();
            return View("Agregar_Enfermedad");
        }

        public ActionResult Eliminar_Datos(EnfermedadBO oEnf)
        {
            EnfermedadesModal enfM = new EnfermedadesModal();
            enfM.EliminarEnfermedad(oEnf);
            Agregar_Enfermedad();
            return View("Agregar_Enfermedad");
        }
        public ActionResult AgregarMedida(string Medida)
        {
            IngredientesModal Obj = new IngredientesModal();
            BO_Admin.MedidasBO obj = new BO_Admin.MedidasBO();
            obj.Medida = Medida;
            Obj.AgregarMedidas(obj);
            return View("AgregarMedida");
        }

    }
}