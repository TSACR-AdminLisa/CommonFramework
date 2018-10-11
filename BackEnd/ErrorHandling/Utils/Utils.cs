using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Utils
{
    public class Utils
    {
        #region Error Handling
        /// <summary>
        /// Registra el error en el visor de eventos de windows
        /// </summary>
        /// <param name="ex">Corresponde a la excepción generada</param>
        /// <param name="Metodo">Corresponde al método donde se origina la excepción</param>
        /// <param name="Archivo">Corresponde al archivo de donde se origina la excepción</param>

        public bool RegisterErrorEventLog(Exception exception, string metodo, string archivo)
        {
            bool result = false;
            try
            {
                //using (SqlConnection cnn = new SqlConnection(BDComun.ObtenerHileraConexion()))
                //{
                //    using (SqlCommand cmd = new SqlCommand("RolUpdate", cnn))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@Nombre", pRol.Nombre);
                //        cmd.Parameters.AddWithValue("@Id", pRol.Id);
                //        cnn.Open();
                //        result = cmd.ExecuteNonQuery() != 0;
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Send Mails

        protected string emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
        protected string passwordEmail = ConfigurationManager.AppSettings["PasswordEmail"];
        protected string hostEmail = ConfigurationManager.AppSettings["HostEMail"];
        protected Int32 portEmail = Int32.Parse(ConfigurationManager.AppSettings["PortEMail"]);
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
                RegisterErrorEventLog(ex, "SendEmail", "Utils.cs");
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
                RegisterErrorEventLog(ex, "CreateFileTxt", "Utils.cs");
                return false;
            }
        }
        #endregion
    }
}
