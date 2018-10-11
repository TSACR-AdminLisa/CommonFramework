using ErrorHandling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Utils
{
    public class Utils
    {
        
        #region Send Mails

        protected string emailFrom = "";
        protected string passwordEmail = "";
        protected string hostEmail = "";
        protected Int32 portEmail = 80;
        /// <summary>
        /// Envío de correos partiendo de smtp y puerto saliente configurados desde la configuración de la aplicación
        /// </summary>
        /// <param name="destination">Destino</param>
        /// <param name="subject">Subject del correo</param>
        /// <param name="htmlMessage">Contenido del correo</param>
        /// <returns>True si es exitoso</returns>
        public bool SendEmail(string destination, string subject, string htmlMessage)
        {
            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                email.From = new MailAddress(emailFrom);
                email.To.Add(destination);
                email.Subject = subject;
                email.Body = htmlMessage;
                email.IsBodyHtml = true;
                smtp.Host = hostEmail;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = emailFrom;
                NetworkCred.Password = passwordEmail;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = portEmail;
                smtp.Send(email);
                return true;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.RegisterErrorEventLog(ex, "SendEmail", "Utils.cs");
                return false;
            }
        }
        #endregion

        #region Create File
        public bool CreateFileTxt(string urlFile, string content, string fileName)
        {
            try
            {
                bool existe = File.Exists(urlFile + "\\" + fileName);
                if (!existe)
                {
                    File.Create(urlFile + "\\" + fileName + ".txt");
                }
                else
                {
                    StreamWriter file = File.AppendText(urlFile + fileName);
                    file.WriteLine(content);
                    file.Flush();
                    file.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Error error = new Error();
                error.RegisterErrorEventLog(ex, "CreateFileTxt", "Utils.cs");
                return false;
            }
        }
        #endregion
    }
}
