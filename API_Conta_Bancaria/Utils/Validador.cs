using API_Conta_Bancaria.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Utils
{
    public class Validador
    {
        public async Task<IEnumerable<int>> ValidaConta(int conta, MySqlConnection conn)
        {
            ValidadorModel obj = new ValidadorModel();
            obj.Conta = conta;
            var query = "select * from tb_conta where conta = @Conta";
            var result = await conn.QueryAsync<int>(query, obj);

            return result;
        }
    }
}
