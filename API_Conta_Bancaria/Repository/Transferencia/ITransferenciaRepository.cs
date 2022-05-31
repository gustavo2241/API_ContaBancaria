using API_Conta_Bancaria.Models;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Transferencia
{
    public interface ITransferenciaRepository
    {
        public Task RealizaTransferencia(TransferenciaModel infos);
    }
}