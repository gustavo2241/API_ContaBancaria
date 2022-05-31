using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Models
{
    public class TransferenciaModel
    {
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}
