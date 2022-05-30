using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Repository.Deposito;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.DepositoModel;

namespace API_Conta_Bancaria.Services.Deposito
{
    public class DepositoService : IDepositoService
    {
        private readonly IDepositoRepository _repo;

        public DepositoService(IDepositoRepository repo)
        {
            _repo = repo;
        }

        public async Task<String> Deposito(DepositoModel valor)
        {
            try
            {
                double valorFinal = ValorPorcentagem(valor);
                valor.Valor = valorFinal;
                await _repo.InsereDeposito(valor);

                return "Depósito efetuado com sucesso.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static double ValorPorcentagem(DepositoModel valor)
        {
            double valorInicial = valor.Valor;
            double percentual = 1.0 / 100.0;
            double valorFinal = valorInicial - (percentual * valorInicial);
            return valorFinal;
        }
    }
}
