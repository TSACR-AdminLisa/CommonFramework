using EFC2_CommonDB.Context;
using System;

namespace ErrorHandling
{
    public class Error
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

                using (var context = new CGCGeneraldbContext())
                {
                    var error = new Errores
                    {
                        Codigo = exception.HResult.ToString(),
                        Detalle = exception.Message,
                        Archivo = archivo,
                        Metodo = metodo,
                        Fecha = DateTime.Now
                    };
                    context.Errores.Add(error);
                    result = context.SaveChanges() != 0;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion
    }
}
