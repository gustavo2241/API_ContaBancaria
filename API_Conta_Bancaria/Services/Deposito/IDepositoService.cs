using API_Conta_Bancaria.Models;
using System;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Services.Deposito
{
    public interface IDepositoService
    {
        public Task<String> Deposito(DepositoModel valor);
    }
}
