using API_Conta_Bancaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Services.Transferencia
{
    public interface ITransferenciaService
    {
        public Task<String> Transferencia(TransferenciaModel infos);
    }
}
