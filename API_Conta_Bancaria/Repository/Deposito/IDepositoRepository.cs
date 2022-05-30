using API_Conta_Bancaria.Models;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Deposito
{
    public interface IDepositoRepository
    {
        public Task InsereDeposito(DepositoModel valor);
    }
}