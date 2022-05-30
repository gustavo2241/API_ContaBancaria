using System.Collections.Generic;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Conta_Bancaria.Repository.Extrato
{
    public interface IExtratoRepository
    {
        public Task<IEnumerable<ExtratoModelReturn>> BuscaExtrato(ExtratoModelRequest conta);
    }
}