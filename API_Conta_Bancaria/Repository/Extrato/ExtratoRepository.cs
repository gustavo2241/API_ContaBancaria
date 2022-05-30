using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Conta_Bancaria.Repository.Extrato
{
    public class ExtratoRepository : IExtratoRepository
    {
        private readonly IConfiguration _configuration;

        public ExtratoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<ExtratoModelReturn>> BuscaExtrato(ExtratoModelRequest conta)
        {
            var connection = _configuration.GetConnectionString("MySqlConnection");
            using (var conn = new MySqlConnection(connection))
            {
                conn.Open();
                var query = "select * from tb_conta where conta = @Conta";
                var result = await conn.QueryAsync<ExtratoModelReturn>(query, conta);

                if (result.Count() == 0)
                {
                    throw new Exception("Não foi possível identificar nenhum saldo para a conta informada.");
                }

                return result;
            }
        }
    }
}
