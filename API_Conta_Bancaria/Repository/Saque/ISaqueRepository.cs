using API_Conta_Bancaria.Models;
using System.Threading.Tasks;

namespace API_Conta_Bancaria.Repository.Saque
{
    public interface ISaqueRepository
    {
        public Task RealizaSaque(SaqueModel saque);
    }
}