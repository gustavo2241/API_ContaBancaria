using API_Conta_Bancaria.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Deposito
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly IConfiguration _configuration;

        public DepositoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task InsereDeposito(DepositoModel valor)
        {
            try
            {
                var connection = _configuration.GetConnectionString("MySqlConnection");
                using (var conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    var result = await ValidaConta(valor, conn);

                    if (result.Count() == 0)
                    {
                        throw new Exception("Não foi possível identificar a conta informada.");
                    }

                    var query = "UPDATE tb_conta SET saldo = (saldo + @Valor) WHERE conta = @Conta;";
                    await conn.ExecuteAsync(query, valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        private static async Task<IEnumerable<int>> ValidaConta(DepositoModel valor, MySqlConnection conn)
        {
            var query = "select * from tb_conta where conta = @Conta";
            var result = await conn.QueryAsync<int>(query, valor);

            return result;
        }
    }
}
