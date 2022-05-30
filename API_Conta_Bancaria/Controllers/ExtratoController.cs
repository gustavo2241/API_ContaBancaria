using API_Conta_Bancaria.Services.Extrato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Conta_Bancaria.Controllers
{
    public class ExtratoController : ControllerBase
    {
        private readonly IExtratoService _extrato;
        public ExtratoController(IExtratoService extrato)
        {
            _extrato = extrato;
        }

        [HttpPost("Extrato/Executar")]
        public async Task<IActionResult> Extrato([FromBody]ExtratoModelRequest obj)
        {
            try
            {
                var result = await _extrato.Extrato(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
