using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Repository.Saque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Services.Saque
{
    public class SaqueService : ISaqueService
    {
        private readonly ISaqueRepository _repo;
        public SaqueService(ISaqueRepository repo)
        {
            _repo = repo;
        }
        public async Task<String> Saque(SaqueModel saque)
        {
            try
            {
                await _repo.RealizaSaque(saque);

                return "Saque realizado com sucesso.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
