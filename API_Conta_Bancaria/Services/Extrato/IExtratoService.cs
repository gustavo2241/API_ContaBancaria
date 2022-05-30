using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Conta_Bancaria.Models.ExtratoModel;

namespace API_Conta_Bancaria.Services.Extrato
{
    public interface IExtratoService
    {
        public Task<IEnumerable<ExtratoModelReturn>> Extrato(ExtratoModelRequest conta);
    }
}
