using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace Proyecto_web.Models
{
    public class EnviarEmail
    {
        private string To;
        private string Subject;
        private string Body;

        private MailMessage mail;
        private Attachment Data;
        public int Enviar(string Para, string asunto, string body)
        {

            To = Para;
            Subject = asunto;
            Body = body;

            mail = new MailMessage();
            mail.To.Add(new MailAddress(this.To));
            mail.From = new MailAddress("HealthyFood_@outlook.es");
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = false;


            SmtpClient client = new SmtpClient("smtp.live.com", 587);
            using (client)
            {
                client.Credentials = new System.Net.NetworkCredential("HealthyFood_@outlook.es", "Comida_Saludable");
                client.EnableSsl = true;
                client.Send(mail);
            }
            return 1;

        }
    }
}