using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Services.Transferencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Controllers
{
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferencia;
        public TransferenciaController(ITransferenciaService transferencia)
        {
            _transferencia = transferencia;
        }

        [HttpPost("Transferencia/Executar")]
        public async Task<IActionResult> Transferencia([FromBody] TransferenciaModel obj)
        {
            try
            {
                var result = await _transferencia.Transferencia(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
