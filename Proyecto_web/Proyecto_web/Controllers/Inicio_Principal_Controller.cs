using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Proyecto_web.Models;
using Proyecto_web.BO_Usuario;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_web.Controllers
{
    public class Inicio_Principal_Controller : Controller
    {
        UsuarioModal Obj = new UsuarioModal();
        UsuarioLoginBO Obj_Bo = new UsuarioLoginBO();
     


        int ID;
     string Contraseña;

        // GET: Inicio_Principal_
        public ActionResult Index()
        {
            
            ViewBag.ID = ID; 
            return View();
        }
        public ActionResult Incio_Admin()
        {

            ViewBag.ID = ID;
            return View("Incio_Admin");
        }
        public ActionResult  Login()
        {

            ViewBag.ID = ID;
            ViewBag.Reg = ID;
           

          
            return View(/*ViewBag.showSuccessAlert=true*/);
        }
        public ActionResult RecuperarContraseña(string Correo)
        {
            
            SqlCommand cmd = new SqlCommand("select Email, Contraseña from Usuarios  where Email = '" + Correo+"'", con);
            AbrirConexion();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
               Contraseña = dr["Contraseña"].ToString();
                
            }

            EnviarEmail obj = new EnviarEmail();
            string Asunto = "Recuperar Contraseña";
            string Mensaje = "Tu contraseña es:" + Contraseña;
            string Destinatario = Correo;
            obj.Enviar(Destinatario, Asunto, Mensaje);
            return View("Login");
        }
        [HttpPost]
        public ActionResult Loguearse(string Nombre_Usuario, string Contraseña)
        {

            string Nombre = "";
            string apellido = "";
            string email = "";
            string id = "";

            AbrirConexion();
            SqlCommand cmd = new SqlCommand("SELECT  Nombre_Usuario, ID_Tipo, Apellido, Email, Contraseña, Nombre, ID FROM Usuarios WHERE Nombre_Usuario = @Nombre_Usuario AND Contraseña = @Contraseña", con);
            cmd.Parameters.AddWithValue("Nombre_Usuario", Nombre_Usuario);
            cmd.Parameters.AddWithValue("Nombre", Nombre);
            cmd.Parameters.AddWithValue("Contraseña", Contraseña);
            cmd.Parameters.AddWithValue("ID", id);
            cmd.Parameters.AddWithValue("Email", email);
            cmd.Parameters.AddWithValue("Apellido", apellido);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ViewBag.Data = dt;
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Session["Nombre_Admin"] = Nombre_Usuario;
                Session["Nombre_perfil"] = dt.Rows[0][5].ToString();
                Session["Id_Admin"] = dt.Rows[0][6].ToString();
                Session["Contraseña"] = Contraseña;
                Session["Email"] = dt.Rows[0][3].ToString();
                Session["Apellido"] = dt.Rows[0][2].ToString();
                Session["Nombre"] = dt.Rows[0][1].ToString();
                Session["Alerta"] = "1";
                if(dt.Rows[0][1].ToString() == "1")
                {
                    ID = 1;
                    return View("~/Views/Admin_principal_/Inicio_Admin.cshtml");

                }
                else if(dt.Rows[0][1].ToString() == "2")
                {
                    ID = 1;

                    
                    return View("Index");
                }
            
            }
  
                ViewBag.ID = null;          CerrarConexion();
            return View("Login");
  





        }
       

        public ActionResult RegistroLogin()
        {
            
            return View();
        }



        public ActionResult Registro(string Nombre, string Apellido, string contraseña, string Email, string Nombre_Usuario)
        {

            LoginBO obj = new LoginBO();
            obj.nombre = Nombre;
            obj.Nombre_usuario = Nombre_Usuario;
            obj.contraseña = contraseña;
            obj.Email = Email;
            obj.apellido = Apellido;

             Obj.AgregarUsuario(obj);
            ID = 1;

            return RedirectToAction("Login");

        }







        //************************************************ conexion de la base de datos ******************************************
        SqlConnection con = new SqlConnection("Data Source=SANTIAGO-ARJONA\\SANTIAGO;Initial Catalog=Proyecto_cocina;Integrated Security=True");

        public void AbrirConexion()
        {
            con.Open();
        }

        public void CerrarConexion()
        {
            con.Close();
        }




        //***************************************************************************************************************************
        public ActionResult Error403()
        {
            return View();
        }









    }
}