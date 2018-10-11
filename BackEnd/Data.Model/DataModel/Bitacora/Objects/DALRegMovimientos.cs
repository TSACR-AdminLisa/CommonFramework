using DataModel.Actions;
using EFC2_CommonDB.Context;
using GeneralProperties;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataModel.Objects
{
    public class DALRegMovimientos : IRegMovimientos
    {
        public General genEntities = new General();

        public async Task<int> RegistrarMovimientoAsync(RegMovimientos ReMovimientos)
        {
            using (var db = new CGCGeneraldbContext(genEntities.ConnectionString))
            {

                db.RegMovimientos.Add(ReMovimientos);

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
