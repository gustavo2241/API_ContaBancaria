using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Services.Saque;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Controllers
{
    public class SaqueController : ControllerBase
    {
        private readonly ISaqueService _saque;
        public SaqueController(ISaqueService saque)
        {
            _saque = saque;
        }

        [HttpPost("Saque/Executar")]
        public async Task<IActionResult> Saque([FromBody] SaqueModel obj)
        {
            try
            {
                var result = await _saque.Saque(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
