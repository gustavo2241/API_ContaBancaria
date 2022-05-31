using API_Conta_Bancaria.Models;
using API_Conta_Bancaria.Repository.Deposito;
using API_Conta_Bancaria.Repository.Extrato;
using API_Conta_Bancaria.Repository.Saque;
using API_Conta_Bancaria.Repository.Transferencia;
using System;
using Xunit;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Testes
{
    public class TestesApiBancaria
    {
        private readonly ExtratoRepository extrato = new ExtratoRepository();
        private readonly DepositoRepository deposito = new DepositoRepository();
        private readonly SaqueRepository saque = new SaqueRepository();
        private readonly TransferenciaRepository transferencia = new TransferenciaRepository();

        [Fact]
        public void Extrato()
        {
            ExtratoModelRequest conta = new ExtratoModelRequest();
            conta.Conta = 101;
            var extratoValido= extrato.BuscaExtrato(conta);
        }

        [Fact]
        public void Deposito()
        {
            DepositoModel conta = new DepositoModel();
            conta.Conta = 101;
            conta.Valor = 100;
            var depositoValido = deposito.InsereDeposito(conta);
        }

        [Fact]
        public void Saque()
        {
            SaqueModel conta = new SaqueModel();
            conta.Conta = 101;
            conta.Valor = 100;
            var saqueValido = saque.RealizaSaque(conta);
        }

        [Fact]
        public void Transferencia()
        {
            TransferenciaModel conta = new TransferenciaModel();
            conta.ContaOrigem = 101;
            conta.ContaDestino = 102;
            conta.Valor = 100;
            var transferenciaValida = transferencia.RealizaTransferencia(conta);
        }
    }
}
