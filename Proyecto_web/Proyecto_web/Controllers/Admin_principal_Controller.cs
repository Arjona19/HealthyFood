using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Admin;
using System.Data.SqlClient;

namespace Proyecto_web.Controllers
{
    public class Admin_principal_Controller : Controller
    {

        IngredientesModal Objeto_INgrediente = new IngredientesModal();
        string Nombre;
        // GET: Admin_principal_
        public ActionResult Admin_Principal()
        {
           
            return View();
        }

       

        public ActionResult Inicio_Admin()
        {
            return View();
        }

        public ActionResult Consultar( EnfermedadBO obj)
        {
            int id = obj.id;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre from Enfermedades where ID_enfermedad ='"+id+"' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {

                Nombre = dr["Nombre"].ToString();
            }
            Agregar_Enfermedad();
     


            return View("Agregar_Enfermedad");
        }

        public ActionResult Agregar_Enfermedad()
        {
            EnfermedadesModal enfM = new EnfermedadesModal();
            
            ViewBag.Nombre = Nombre;
            
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

        public ActionResult AgregarMedida()
        {
            MedidasModal Obj = new MedidasModal();
            ViewBag.Nombre = Nombre;
            return View(Obj.Tabla_Medidas_BD());
        }

        public ActionResult Consulta_Medida(MedidasBO obj)
        {
            int id = obj.ID_medida;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Medida from Medidas where ID_Tipo_Medida ='" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Medida"].ToString();
            }
            AgregarMedida();



            return View("AgregarMedida");
        }



        public ActionResult AgregarMed(string Medida)
        {
            MedidasModal Obj = new MedidasModal();
            BO_Admin.MedidasBO obj = new BO_Admin.MedidasBO();
            obj.Medida = Medida;
            Obj.AgregarMedidas(obj);
            AgregarMedida();
            return View("AgregarMedida");
        }


        public ActionResult Consulta_Clasificacion(ClasificaciónComidasBO obj)
        {
            int id = obj.id_cla;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre from Clasificacion Where ID_clasificacion = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Nombre"].ToString();
            }
            AgregarClasificacion();



            return View("AgregarClasificacion");
        }


        public ActionResult Actualizar_Medida(string id)
        {
            MedidasModal Obj = new MedidasModal();
            int Clave = int.Parse(id);
            return View(Obj.Obtener_Medidas(Clave));
        }

        public ActionResult Actualizar_Datos_Med(int id, string Nombre)
        {
            MedidasModal Obj = new MedidasModal();
            BO_Admin.MedidasBO obj = new BO_Admin.MedidasBO();
            obj.ID_medida = id;
            obj.Medida = Nombre;
            Obj.MedidasActualizar(obj);
            AgregarMedida();
            return View("AgregarMedida");
        }

        public ActionResult Eliminar_Datos_Med(MedidasBO obj)
        {
            MedidasModal Obj = new MedidasModal();
            Obj.EliminarMedidas(obj);
            AgregarMedida();
            return View("AgregarMedida");
        }

        public ActionResult AgregarClasificacion()
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            ViewBag.Nombre = Nombre;
            return View(ObjC.Tabla_Clasificacion_BD());
        }

        public ActionResult Consulta_Ingrediente(IngredientesBo obj)
        {
            int id = obj.id;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre from Ingredientes Where ID = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Nombre"].ToString();
            }
            Agregar_Ingrediente();



            return View("Agregar_Ingrediente");
        }
        public ActionResult AgregarClas(string Clasificacion)
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            BO_Admin.ClasificaciónComidasBO objC = new BO_Admin.ClasificaciónComidasBO();
            objC.Clasificaion = Clasificacion;
            ObjC.AgregarClasificacion(objC);
            AgregarClasificacion();
            return View("AgregarClasificacion");
        }

        public ActionResult Actualizar_Clasificacion(string id)
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            int Clave = int.Parse(id);
            return View(ObjC.Obtener_Clasificacion(Clave));
        }

        public ActionResult Actualizar_Datos_Clas(int id, string Clasificacion)
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            BO_Admin.ClasificaciónComidasBO objC = new BO_Admin.ClasificaciónComidasBO();
            objC.id_cla = id;
            objC.Clasificaion = Clasificacion;
            ObjC.CladificacionActualizar(objC);
            AgregarClasificacion();
            return View("AgregarClasificacion");
        }

        public ActionResult Eliminar_Datos_Clas(ClasificaciónComidasBO objC)
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            ObjC.EliminarClasificacion(objC);
            AgregarClasificacion();
            return View("AgregarClasificacion");
        }


        public ActionResult Agregar_Ingrediente()
        {
            IngredientesModal ObjI = new IngredientesModal();
            ViewBag.Nombre = Nombre;
            return View(ObjI.TablaINgredientes());
        }

        public ActionResult Agregar_ingredientes(string  Nombre)
        {
            IngredientesModal ObjI = new IngredientesModal();
            BO_Admin.IngredientesBo objI = new BO_Admin.IngredientesBo();
            objI.Nombre = Nombre;
            ObjI.AgregarIngrediente(objI);
            Agregar_Ingrediente();
            return View("Agregar_Ingrediente"); 
        }

        public ActionResult Actualizar_Ingredientes(string id)
        {
            IngredientesModal ObjI = new IngredientesModal();
            int Clave = int.Parse(id);
            return View(ObjI.ObtenerIngredientes(Clave));
        }

        public ActionResult Actualizar_Datos_Ing()
        {
            string id;
            IngredientesModal ObjI = new IngredientesModal();
            BO_Admin.IngredientesBo objI = new BO_Admin.IngredientesBo();
            Nombre = ViewBag.Nombre;
            id = ViewBag.Id;
            objI.Nombre = Nombre;
            ObjI.ActualizarrIngrediente(objI);
            Agregar_Ingrediente();
            return View("Agregar_Ingrediente");
        }

        public ActionResult Eliminar_Datos_Ing(IngredientesBo objI)
        {
            IngredientesModal ObjI = new IngredientesModal();
            ObjI.EliminarIngrediente(objI);
            Agregar_Ingrediente();
            return View("Agregar_ingrediente");
        }

        public ActionResult Perfil_Admin()
        {

            return View();
        }

        public ActionResult Cerrar_session()
        {
            
                Session.Remove("Id_Admin");
              Response.Redirect("http://localhost:58232/Inicio_principal_/Login");
            

            return View();
        }


    }
}