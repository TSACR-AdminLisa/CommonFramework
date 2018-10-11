using EFC2_CommonDB.Context;
using System.Threading.Tasks;

namespace DataModel.Actions
{
    public interface IRegMovimientos
    {

        Task<int> RegistrarMovimientoAsync(RegMovimientos ReMovimientos);

    }
}
