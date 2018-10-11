using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Objects;
using EFC2_CommonDB.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBitacora.Controllers
{
    [Produces("application/json")]
    [Route("api/RegMovimiento")]
    [ApiController]
    public class RegMovimientoController : ControllerBase
    {

        private readonly DALRegMovimientos _model = new DALRegMovimientos();

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(404)]
        public async virtual Task<int> CreateAsync([FromBody] RegMovimientos ReMovimientos)
        {
            try
            {
                return await _model.RegistrarMovimientoAsync(ReMovimientos);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}