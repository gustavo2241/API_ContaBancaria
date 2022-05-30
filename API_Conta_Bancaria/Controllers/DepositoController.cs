using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Services.Deposito;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Controllers
{
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoService _deposito;
        public DepositoController(IDepositoService deposito)
        {
            _deposito = deposito;
        }

        [HttpPost("Deposito/Executar")]
        public async Task<IActionResult> Deposito([FromBody]DepositoModel obj)
        {
            try
            {
                var result = await _deposito.Deposito(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
