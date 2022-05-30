using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Utils;
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

        public DepositoRepository()
        {
        }

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

                    var validador = new Validador();
                    var result = await validador.ValidaConta(valor.Conta, conn);

                    if (result.Count() == 0)
                    {
                        throw new Exception("Não foi possível identificar a conta informada.");
                    }

                    var query = "UPDATE tb_conta SET saldo = (saldo + @Valor) WHERE conta = @Conta;";
                    await conn.ExecuteAsync(query, valor);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
