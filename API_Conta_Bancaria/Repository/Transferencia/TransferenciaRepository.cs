using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Utils;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Transferencia
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly IConfiguration _configuration;

        public TransferenciaRepository()
        {
        }

        public TransferenciaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task RealizaTransferencia(TransferenciaModel infos)
        {
            try
            {
                var valorTransferencia = infos.Valor;
                var connection = _configuration.GetConnectionString("MySqlConnection");
                using (var conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    var validador = new Validador();
                    var result = await validador.ValidaConta(infos.ContaOrigem, conn);

                    if (result.Count() == 0)
                    {
                        throw new Exception("Não foi possível identificar a conta informada.");
                    }

                    await ValidaCobrançaTaxaTransferencia(infos, conn);

                    var query = @$"UPDATE tb_conta SET saldo = (saldo - @Valor) WHERE conta = @ContaOrigem;
                                   UPDATE tb_conta SET saldo = (saldo + {valorTransferencia}) WHERE conta = @ContaDestino";
                    await conn.ExecuteAsync(query, infos);

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static async Task ValidaCobrançaTaxaTransferencia(TransferenciaModel infos, MySqlConnection conn)
        {
            var taxaTransferencia = 1.0;
            var taxaComValorTransferencia = taxaTransferencia + infos.Valor;

            var querySaldo = "select saldo from tb_conta WHERE conta = @ContaOrigem;";
            dynamic saldo = await conn.QueryAsync<dynamic>(querySaldo, infos);
            if ((double)saldo[0].saldo < taxaComValorTransferencia)
            {
                throw new Exception("Não foi possível realizar operação, saldo insuficiente.");
            }

            infos.Valor = taxaComValorTransferencia;
        }
    }
}
