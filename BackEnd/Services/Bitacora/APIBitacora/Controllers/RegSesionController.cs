using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.DMBitacora.Objects;
using DataModel.Objects;
using EFC2_CommonDB.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBitacora.Controllers
{
    [Produces("application/json")]
    [Route("api/RegSesion")]
    [ApiController]
    public class RegSesionController : ControllerBase
    {
        private readonly DALRegSesion _model = new DALRegSesion();

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        public async virtual Task<int> CreateAsync([FromBody] RegSesion ReSesion)
        {
            try
            {
                return await _model.RegistrarSesionAsync(ReSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}