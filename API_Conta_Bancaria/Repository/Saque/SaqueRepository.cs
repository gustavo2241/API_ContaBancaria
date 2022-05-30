using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Utils;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Saque
{
    public class SaqueRepository : ISaqueRepository
    {
        private readonly IConfiguration _configuration;

        public SaqueRepository()
        {
        }
        public SaqueRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task RealizaSaque(SaqueModel saque)
        {
            try
            {           
                var connection = _configuration.GetConnectionString("MySqlConnection");
                using (var conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    await ValidaCobrançaTaxa(saque, conn);

                    var validador = new Validador();
                    var result = await validador.ValidaConta(saque.Conta, conn);

                    if (result.Count() == 0)
                    {
                        throw new Exception("Não foi possível identificar a conta informada.");
                    }

                    var query = "UPDATE tb_conta SET saldo = (saldo - @Valor) WHERE conta = @Conta;";
                    await conn.ExecuteAsync(query, saque);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private static async Task ValidaCobrançaTaxa(SaqueModel saque, MySqlConnection conn)
        {
            var taxaSaque = 4.0;
            var taxaComValorSaque = taxaSaque + saque.Valor;

            var querySaldo = "select saldo from tb_conta WHERE conta = @Conta;";
            dynamic saldo = await conn.QueryAsync<dynamic>(querySaldo, saque);
            if ((double)saldo[0].saldo < taxaComValorSaque)
            {
                throw new Exception("Não foi possível realizar operação, saldo insuficiente.");
            }

            saque.Valor = taxaComValorSaque;
        }
    }
}
