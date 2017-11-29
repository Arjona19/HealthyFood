using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Admin;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace Proyecto_web.Controllers
{
    public class Admin_principal_Controller : Controller
    {

        IngredientesModal Objeto_INgrediente = new IngredientesModal();
        string Nombre;
        string id_glo;

        ConneccionBD_Modal Con;
        public Admin_principal_Controller()
        {
            Con = new ConneccionBD_Modal();
        }

        // GET: Admin_principal_
        public ActionResult Admin_Principal()
        {

            return View();
        }

        public ActionResult Inicio_Admin()
        {
            return View();
        }

        public ActionResult Consultar(EnfermedadBO obj)
        {
            int id = obj.id;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre,  ID_enfermedad  from Enfermedades where ID_enfermedad ='" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                id_glo = dr["ID_enfermedad"].ToString();
                Nombre = dr["Nombre"].ToString();
            }
            Agregar_Enfermedad();



            return View("Agregar_Enfermedad");
        }

        public ActionResult Agregar_Enfermedad()
        {
            EnfermedadesModal enfM = new EnfermedadesModal();
            ViewBag.Nombre = Nombre;
            ViewBag.Id = id_glo;
            return View(enfM.Tabla_Enfermedad_BD());
        }

        public ActionResult Actualizar_Datos_Enfermedad(int id, string Nombre)
        {
            EnfermedadesModal Obj = new EnfermedadesModal();
            BO_Admin.EnfermedadBO obj = new BO_Admin.EnfermedadBO();
            obj.id = id;
            obj.Nombre = Nombre;
            Obj.EnfermedadActualizar(obj);
            Agregar_Enfermedad();
            return View("Agregar_Enfermedad");
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
            ViewBag.Id = id_glo;
            return View(Obj.Tabla_Medidas_BD());

        }

        public ActionResult Consulta_Medida(MedidasBO obj)
        {
            int id = obj.ID_medida;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Medida, ID_Tipo_Medida from Medidas where ID_Tipo_Medida ='" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Medida"].ToString();
                id_glo = dr["ID_Tipo_Medida"].ToString();
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
            SqlCommand cmd = new SqlCommand("Select Nombre, ID_clasificacion from Clasificacion Where ID_clasificacion = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Nombre"].ToString();
                id_glo = dr["ID_clasificacion"].ToString();
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
            ViewBag.Id = id_glo;
            return View(ObjC.Tabla_Clasificacion_BD());
        }

        public ActionResult Consulta_Ingrediente(IngredientesBo obj)
        {
            int id = obj.id;
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre, ID from Ingredientes Where ID = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Nombre"].ToString();
                id_glo = dr["ID"].ToString();
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

        public ActionResult Actualizar_Datos_Clas(int id, string Nombre)
        {
            ClasificacionModal ObjC = new ClasificacionModal();
            BO_Admin.ClasificaciónComidasBO objC = new BO_Admin.ClasificaciónComidasBO();
            objC.id_cla = id;
            objC.Clasificaion = Nombre;
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
            ViewBag.Id = id_glo;
            return View(ObjI.TablaINgredientes());
        }

        public ActionResult Agregar_ingredientes(string Nombre)
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

        public ActionResult Actualizar_Datos_ingrediente(int id, string Nombre)
        {
            IngredientesModal ObjC = new IngredientesModal();
            BO_Admin.IngredientesBo objC = new BO_Admin.IngredientesBo();
            objC.id = id;
            objC.Nombre = Nombre;
            ObjC.ActualizarrIngrediente(objC);
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

        public ActionResult Consultar_Perfil_Admin(BO_Usuario.LoginBO obj)
        {
            int id = obj.id;
               
            ConneccionBD_Modal con = new ConneccionBD_Modal();
            SqlCommand cmd = new SqlCommand("Select Nombre, ID, Apellido, Email, Contraseña from Usuarios Where ID = '" + id + "' ", con.ConectarBD());
            con.AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                Nombre = dr["Nombre"].ToString();
                id_glo = dr["ID"].ToString();
            }
            Agregar_Ingrediente();



            return View("Agregar_Ingrediente");
        }

        public ActionResult Actualizar_Datos_perfil( string Nombre, string Apellido, string Email, string Contraseña)
        {
            UsuarioModal Obj = new UsuarioModal();
            BO_Usuario.LoginBO obj = new BO_Usuario.LoginBO();
            obj.id = int.Parse(Session["ID_Usuario"].ToString());
            obj.apellido = Apellido;
            obj.Email = Email;
            obj.contraseña = Contraseña;
            obj.nombre = Nombre;
            Obj.Actualizad_admin(obj);
         
            return View("Perfil_Admin");
        }

        public ActionResult Cerrar_session()
        {
            
                Session.Remove("ID_Usuario");
              Response.Redirect("http://localhost:58232/Inicio_principal_/Login");
            

            return View();
        }
        
        public ActionResult Items()
        {
            return View();
        }

        public ActionResult Aprobados()
        {
            ComidasModal OBJ = new ComidasModal();

            return View(OBJ.Comidas_Aprobadas());
        }


        public ActionResult Actualizar_Estatus_Aprobado_a_Desaprobado(int id)
        {

            ComidasModal ObjC = new ComidasModal();
            BO_Admin.ComidaBO objC = new BO_Admin.ComidaBO();
            objC.id = id;
            ObjC.ActualizarrEstatus(objC);
            Aprobados();
            return View("Aprobados");
        }

        public ActionResult DesAprobados()
        {
            ComidasModal OBJ = new ComidasModal();

            return View(OBJ.Comidas_Desaprobadas());
        }

        public ActionResult Actualizar_Estatus_Desaprobado_a_aprobado(int id)
        {

            ComidasModal ObjC = new ComidasModal();
            BO_Admin.ComidaBO objC = new BO_Admin.ComidaBO();
            objC.id = id;
            ObjC.ActualizarrEstatus_Desaprobado(objC);
            DesAprobados();
            return View("DesAprobados");
        }

        public ActionResult Respaldos()
        {
            RespaldoModal ObjR = new RespaldoModal();
            ObjR.Respaldo();
            return View();
        }

        public ActionResult ReporteIngredientes()
        {
            {
                #region Datos dummy
                string query = ("Select Nombre, Imagen from Ingredientes");
                var result = Con.Tabla_Consultada(query);
                List<IngredientesBo> Ingredientes = new List<IngredientesBo>();
                foreach (DataRow Ingrediente in result.Rows)
                {
                    var ingBO = new IngredientesBo();
                    ingBO.Nombre = Ingrediente[0].ToString();
                    ingBO.icono = Ingrediente[1].ToString();
                    Ingredientes.Add(ingBO);
                }
                #endregion Datos dummy

                string DirectorioReportesRelativo = "~/Reportes/Reportes/";
                string urlArchivo = string.Format("{0}.{1}", "ReporteIngrediente", "rdlc");
                string FullPathReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirectorioReportesRelativo), urlArchivo);
                ReportViewer reporte = new ReportViewer();
                reporte.Reset();
                reporte.LocalReport.ReportPath = FullPathReport;
                ReportDataSource DatosDS = new ReportDataSource("DatoIngrediente", Ingredientes);
                reporte.LocalReport.DataSources.Add(DatosDS);
                reporte.LocalReport.Refresh();
                byte[] file = reporte.LocalReport.Render("PDF");

                return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "ReporteIngredientes.", "PDF"));
            }
        }

        public ActionResult ReporteEnfermedades()
        {
            {
                #region Datos dummy
                string query = ("Select Nombre from Enfermedades");
                var result = Con.Tabla_Consultada(query);
                List<EnfermedadBO> Enfermedades = new List<EnfermedadBO>();
                foreach (DataRow Enfermedad in result.Rows)
                {
                    var enfBO = new EnfermedadBO();
                    enfBO.Nombre = Enfermedad[0].ToString();
                    Enfermedades.Add(enfBO);
                }
                #endregion Datos dummy

                string DirectorioReportesRelativo = "~/Reportes/Reportes/";
                string urlArchivo = string.Format("{0}.{1}", "ReporteEnfermedad", "rdlc");
                string FullPathReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirectorioReportesRelativo), urlArchivo);
                ReportViewer reporte = new ReportViewer();
                reporte.Reset();
                reporte.LocalReport.ReportPath = FullPathReport;
                ReportDataSource DatosDS = new ReportDataSource("DatoEnfermedad", Enfermedades);
                reporte.LocalReport.DataSources.Add(DatosDS);
                reporte.LocalReport.Refresh();
                byte[] file = reporte.LocalReport.Render("PDF");

                return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "ReporteEnfermedad.", "PDF"));
            }
        }

        public ActionResult ReporteClasificacion()
        {
            {
                #region Datos dummy
                string query = ("Select Nombre from Clasificacion");
                var result = Con.Tabla_Consultada(query);
                List<ClasificaciónComidasBO> Clasificaciones = new List<ClasificaciónComidasBO>();
                foreach (DataRow Clasificacion in result.Rows)
                {
                    var claBO = new ClasificaciónComidasBO();
                    claBO.Clasificaion = Clasificacion[0].ToString();
                    Clasificaciones.Add(claBO);
                }
                #endregion Datos dummy

                string DirectorioReportesRelativo = "~/Reportes/Reportes/";
                string urlArchivo = string.Format("{0}.{1}", "ReporteClasificacion", "rdlc");
                string FullPathReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirectorioReportesRelativo), urlArchivo);
                ReportViewer reporte = new ReportViewer();
                reporte.Reset();
                reporte.LocalReport.ReportPath = FullPathReport;
                ReportDataSource DatosDS = new ReportDataSource("DatoClasificacion", Clasificaciones);
                reporte.LocalReport.DataSources.Add(DatosDS);
                reporte.LocalReport.Refresh();
                byte[] file = reporte.LocalReport.Render("PDF");

                return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "ReporteClasificacion.", "PDF"));
            }
        }

        public ActionResult ReporteMedidas()
        {
            {
                #region Datos dummy
                string query = ("Select Medida from Medidas");
                var result = Con.Tabla_Consultada(query);
                List<MedidasBO> Medidas = new List<MedidasBO>();
                foreach (DataRow Medida in result.Rows)
                {
                    var medBO = new MedidasBO();
                    medBO.Medida = Medida[0].ToString();
                    Medidas.Add(medBO);
                }
                #endregion Datos dummy

                string DirectorioReportesRelativo = "~/Reportes/Reportes/";
                string urlArchivo = string.Format("{0}.{1}", "ReporteMedida", "rdlc");
                string FullPathReport = string.Format("{0}{1}", this.HttpContext.Server.MapPath(DirectorioReportesRelativo), urlArchivo);
                ReportViewer reporte = new ReportViewer();
                reporte.Reset();
                reporte.LocalReport.ReportPath = FullPathReport;
                ReportDataSource DatosDS = new ReportDataSource("DatoMedida", Medidas);
                reporte.LocalReport.DataSources.Add(DatosDS);
                reporte.LocalReport.Refresh();
                byte[] file = reporte.LocalReport.Render("PDF");

                return File(new MemoryStream(file).ToArray(), System.Net.Mime.MediaTypeNames.Application.Octet, string.Format("{0}{1}", "ReporteMedida.", "PDF"));
            }
        }
    }
}