using EFC2_CommonDB.Context;
using System.Threading.Tasks;

namespace DataModel.Actions
{
    public interface IRegSesion
    {
        Task<int> RegistrarSesionAsync(RegSesion ReSesion);
    }
}
