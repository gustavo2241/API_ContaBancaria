using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Repository.Extrato;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Conta_Bancaria.Services.Extrato
{
    public class ExtratoService : IExtratoService
    {
        private readonly IExtratoRepository _repo;

        public ExtratoService(IExtratoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ExtratoModelReturn>> Extrato(ExtratoModelRequest conta)
        {
            try
            {
                return await _repo.BuscaExtrato(conta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
