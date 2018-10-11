using DataModel.Actions;
using EFC2_CommonDB.Context;
using GeneralProperties;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.DMBitacora.Objects
{
    public class DALRegSesion : IRegSesion
    {
        public General genEntities = new General();

        public async Task<int> RegistrarSesionAsync(RegSesion ReSesion)
        {
            using (var db = new CGCGeneraldbContext(genEntities.ConnectionString))
            {

                db.RegSesion.Add(ReSesion);

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
