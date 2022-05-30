using API_Conta_Bancaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Services.Saque
{
    public interface ISaqueService
    {
        public Task<String> Saque(SaqueModel saque);
    }
}
