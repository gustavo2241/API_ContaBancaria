using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Repository.Transferencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Services.Transferencia
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly ITransferenciaRepository _repo;
        public TransferenciaService(ITransferenciaRepository repo)
        {
            _repo = repo;
        }
        public async Task<String> Transferencia(TransferenciaModel infos)
        {
            try
            {
                await _repo.RealizaTransferencia(infos);

                return "Transferencia realizada com sucesso.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
