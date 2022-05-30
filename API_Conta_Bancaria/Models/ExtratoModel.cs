using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Models
{
    public class ExtratoModel
    {
        public class ExtratoModelRequest
        {
            public int Conta { get; set; }
        }

        public class ExtratoModelReturn
        {
            public int Conta { get; set; }
            public double Saldo { get; set; }
        }
    }
}
