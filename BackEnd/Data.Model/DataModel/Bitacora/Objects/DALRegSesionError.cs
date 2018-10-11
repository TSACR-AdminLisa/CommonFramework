using EFC2_CommonDB.Context;
using GeneralProperties;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.DMBitacora.Objects
{
    public class DALRegSesionError
    {
        public General genEntities = new General();

        public async Task<int> RegistrarErrorSesionAsync(RegSesionError ReSesionError)
        {
            using (var db = new CGCGeneraldbContext(genEntities.ConnectionString))
            {

                db.RegSesionError.Add(ReSesionError);

                if (db.SaveChanges() > 0)
                {
                    return await db.SaveChangesAsync();
                }
                else
                    return -1;
            }
        }
    }
}
