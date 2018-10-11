using EFC2_CommonDB.Context;
using System.Threading.Tasks;

namespace DataModel.Actions.Bitacora
{
    interface IRegSesionError
    {
        Task<int> RegistrarErrorSesionAsync(RegSesionError ReSesionError);
    }
}
